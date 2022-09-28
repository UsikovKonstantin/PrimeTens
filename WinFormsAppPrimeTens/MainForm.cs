using ClassLibraryPrimeTens;
using System.Diagnostics;

namespace WinFormsAppPrimeTens
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            help_determine();
        }

        const int min_num = 3;
        const int max_num = int.MaxValue - 1;
        const ulong max_num_b = ulong.MaxValue - 1;

        Task<(ulong min_count, ulong min_loc, ulong max_count, ulong max_loc, long mls)> Cur_run_segments;
        Task<(ulong start, ulong end, long mls)> Cur_run_max_segment;
        Task<(List<(ulong start, ulong end, ulong primeCount, double primePercent)> data, long mls)> Cur_run_chart;
        CancellationTokenSource Cur_cts;
        List<(ulong start, ulong end, ulong primeCount, double primePercent)> cur_data;

        private async void Bt_Start_Click(object sender, EventArgs e)
        {
            SetControls(true);
            Cur_cts = new CancellationTokenSource();
            if (RB_Solver_MinMaxSeg.Checked)
            {
                ulong n = ulong.Parse(Tx_Input.Text);
                ulong k = ulong.Parse(Tx_Additional_Input.Text);
                if (n % k != 0)
                {
                    n = n - (n % k);
                    Tx_Input.Text = n.ToString();
                    SetControls(false);
                    return;
                }

                if (RB_Method_Erat.Checked)
                    Cur_run_segments = Task.Run(() => Start_Lookup_Segments(Cur_cts.Token, Prime_Method.Erathosphenes));
                else if (RB_Method_Fast.Checked)
                    Cur_run_segments = Task.Run(() => Start_Lookup_Segments(Cur_cts.Token, Prime_Method.Fast_Lookup));
                else
                    Cur_run_segments = Task.Run(() => Start_Lookup_Segments(Cur_cts.Token, Prime_Method.Division_Lookup));
                await Cur_run_segments;

                (ulong min_count, ulong min_loc, ulong max_count, ulong max_loc, long mls) result = Cur_run_segments.Result;
                if (result == (0, 0, 0, 0, 0))
                {
                    Cur_run_segments.Dispose();
                    SetControls(false);
                    return;
                }
                RTx_Output.Text = $"Минимальный сегмент {result.min_loc}-{result.min_loc + k - 1}\n" +
                                  $"Наименьшее число простых чисел {result.min_count}\n" +
                                  $"Максимальный сегмент {result.max_loc}-{result.max_loc + k - 1}\n" +
                                  $"Максимальное число простых чисел {result.max_count}\n" +
                                  $"Время выполнения {result.mls}мс";
            }
            if (RB_Solver_MaxSegment.Checked)
            {
                if (RB_Method_Erat.Checked)
                    Cur_run_max_segment = Task.Run(() => Start_Lookup_DivisorlessRange(Cur_cts.Token, Prime_Method.Erathosphenes));
                else if (RB_Method_Fast.Checked)
                    Cur_run_max_segment = Task.Run(() => Start_Lookup_DivisorlessRange(Cur_cts.Token, Prime_Method.Fast_Lookup));
                else
                    Cur_run_max_segment = Task.Run(() => Start_Lookup_DivisorlessRange(Cur_cts.Token, Prime_Method.Division_Lookup));
                await Cur_run_max_segment;

                (ulong start, ulong end, long mls) result = Cur_run_max_segment.Result;
                if (result == (0, 0, 0))
                {
                    Cur_run_max_segment.Dispose();
                    SetControls(false);
                    return;
                }
                RTx_Output.Text = $"Начало сегмента {result.start}\n" +
                                  $"Конец сегмента {result.end}\n" +
                                  $"Длина сегмента {result.end - result.start + 1}\n" +
                                  $"Время выполнения {result.mls}мс";
            }
            if (RB_Solver_BarChart.Checked)
            {
                ulong n = ulong.Parse(Tx_Input.Text);
                ulong k = ulong.Parse(Tx_Additional_Input.Text);
                if (n % k != 0)
                {
                    n = n - (n % k);
                    Tx_Input.Text = n.ToString();
                    SetControls(false);
                    return;
                }

                if (RB_Method_Erat.Checked)
                    Cur_run_chart = Task.Run(() => Start_Lookup_Chart(Cur_cts.Token, Prime_Method.Erathosphenes));
                else if (RB_Method_Fast.Checked)
                    Cur_run_chart = Task.Run(() => Start_Lookup_Chart(Cur_cts.Token, Prime_Method.Fast_Lookup));
                else
                    Cur_run_chart = Task.Run(() => Start_Lookup_Chart(Cur_cts.Token, Prime_Method.Division_Lookup));
                await Cur_run_chart;

                (List<(ulong start, ulong end, ulong primeCount, double primePercent)> data, long mls) result = Cur_run_chart.Result;
                if (result == (null, 0))
                {
                    Cur_run_chart.Dispose();
                    SetControls(false);
                    return;
                }
                RTx_Output.Text = $"Время выполнения {result.mls}мс\n" +
                                  $"Результаты по кнопке \"Вывод\"";
                cur_data = result.data;
            }
            SetControls(false);
        }

        (ulong min_count, ulong min_loc, ulong max_count, ulong max_loc, long mls) Start_Lookup_Segments(CancellationToken ct, Prime_Method Meth)
        {
            ulong num = ulong.Parse(Tx_Input.Text);
            int len = int.Parse(Tx_Additional_Input.Text);
            ulong min_loc = 0, min_count = 0, max_loc = 0, max_count = 0;
            Stopwatch tim = new Stopwatch();
            tim.Start();

            dynamic tas;
            if (Meth == Prime_Method.Fast_Lookup)
            {
                Task<(ulong min_count, ulong min_loc, ulong max_count, ulong max_loc)> temp;
                temp = Task.Run(() => PrimeTens.GetMinMaxSegments(num, (ulong)len, ct));
                tas = temp;
            }
            else
            {
                Task<(int min_count, int min_loc, int max_count, int max_loc)> temp;
                temp = Task.Run(() => PrimeTens.GetMinMaxSegments((int)num, len, Meth, ct));
                tas = temp;
            }

            bool running = true;
            while (running)
            {
                if (tas.Status == TaskStatus.RanToCompletion)
                {
                    var temp = tas.Result;
                    min_count = temp.Item1; 
                    min_loc = temp.Item2;
                    max_count = temp.Item3;
                    max_loc = temp.Item4;
                    running = false;
                }
                else
                {
                    if (ct.IsCancellationRequested)
                    {
                        return (0, 0, 0, 0, 0);
                    }
                    RTx_Output.Invoke(new Action(() => RTx_Output.Text = $"{tim.ElapsedMilliseconds / 1000}.{tim.ElapsedMilliseconds / 100 % 10} с"));
                    Thread.Sleep(5);
                }
                if (ct.IsCancellationRequested)
                {
                    return (0, 0, 0, 0, 0);
                }
            }
            tim.Stop();
            long mls = tim.ElapsedMilliseconds;
            return (min_count, min_loc, max_count, max_loc, mls);
        }

        (ulong start, ulong end, long mls) Start_Lookup_DivisorlessRange(CancellationToken ct, Prime_Method method)
        {
            ulong num = ulong.Parse(Tx_Input.Text);
            Stopwatch tim = new Stopwatch();
            ulong start = 0, end = 0;
            tim.Start();

            dynamic tas;
            if (method == Prime_Method.Fast_Lookup)
            {
                Task<(ulong, ulong)> temp;
                temp = Task.Run(() => PrimeTens.GetMaxRangeWithoutPrimeNumbers(num, ct));
                tas = temp;
            }
            else
            {
                Task<(int, int)> temp;
                temp = Task.Run(() => PrimeTens.GetMaxRangeWithoutPrimeNumbers((int)num, method, ct));
                tas = temp;
            }

            bool running = true;
            while (running)
            {
                if (tas.Status == TaskStatus.RanToCompletion)
                {
                    var temp = tas.Result;
                    start = temp.Item1;
                    end = temp.Item2;
                    running = false;
                }
                else
                {
                    if (ct.IsCancellationRequested)
                    {
                        return (0, 0, 0);
                    }
                    RTx_Output.Invoke(new Action(() => RTx_Output.Text = $"{tim.ElapsedMilliseconds / 1000}.{tim.ElapsedMilliseconds / 100 % 10} с"));
                    Thread.Sleep(5);
                }
                if (ct.IsCancellationRequested)
                {
                    return (0, 0, 0);
                }
            }
            tim.Stop();
            long mls = tim.ElapsedMilliseconds;
            return (start, end, mls);
        }

        (List<(ulong start, ulong end, ulong primeCount, double primePercent)> data, long mls) Start_Lookup_Chart(CancellationToken ct, Prime_Method method)
        {
            ulong num = ulong.Parse(Tx_Input.Text);
            int len = int.Parse(Tx_Additional_Input.Text);
            List<(ulong start, ulong end, ulong primeCount, double primePercent)> data = new();
            Stopwatch tim = new Stopwatch();
            tim.Start();

            dynamic tas;
            if (method == Prime_Method.Fast_Lookup)
            {
                Task<List<(ulong start, ulong end, ulong primeCount, double primePercent)>> tase;
                tase = Task.Run(() => PrimeTens.GetPrimeDistribution(num, (ulong)len, ct));
                tas = tase;
            }
            else
            {
                Task<List<(int start, int end, int primeCount, double primePercent)>> tase;
                tase = Task.Run(() => PrimeTens.GetPrimeDistribution((int)num, len, method, ct));
                tas = tase;
            }

            bool running = true;
            while (running)
            {
                if (tas.Status == TaskStatus.RanToCompletion)
                {
                    var temp = tas.Result;
                    foreach (var item in temp)
                    {
                        data.Add((item.Item1, item.Item2, item.Item3, item.Item4));
                    }
                    running = false;
                }
                else
                {
                    if (ct.IsCancellationRequested)
                    {
                        return (null, 0);
                    }
                    RTx_Output.Invoke(new Action(() => RTx_Output.Text = $"{tim.ElapsedMilliseconds / 1000}.{tim.ElapsedMilliseconds / 100 % 10} с"));
                    Thread.Sleep(5);
                }
                if (ct.IsCancellationRequested)
                {
                    return (null, 0);
                }
            }
            tim.Stop();
            long mls = tim.ElapsedMilliseconds;
            return (data, mls);
        }

        private void Bt_End_Click(object sender, EventArgs e)
        {
            SetControls(false);
            Cur_cts.Cancel();
        }

        private void SetControls(bool isTaskRunning)
        {
            Bt_End.Enabled = isTaskRunning;
            Tx_Input.Enabled = !isTaskRunning;
            Bt_Start.Enabled = !isTaskRunning;
            if (RB_Solver_MinMaxSeg.Checked || RB_Solver_BarChart.Checked)
                Tx_Additional_Input.Enabled = !isTaskRunning;
            RB_Solver_BarChart.Enabled = !isTaskRunning;
            RB_Solver_MaxSegment.Enabled = !isTaskRunning;
            RB_Solver_MinMaxSeg.Enabled = !isTaskRunning;
            RB_Method_Erat.Enabled = !isTaskRunning;
            RB_Method_Fast.Enabled = !isTaskRunning;
            RB_Method_Root.Enabled = !isTaskRunning;
            if (RB_Solver_BarChart.Checked)
                Bt_Output.Enabled = !isTaskRunning;
        }

        bool CheckMainInput()
        {
            if (ulong.TryParse(Tx_Input.Text, out ulong n))
            {
                if (RB_Method_Fast.Checked)
                {
                    if (n > max_num_b)
                    {
                        errorProviderMain.SetError(Tx_Input, "Слишком большое число");
                        return false;
                    }
                }
                else if (n > max_num)
                {
                    errorProviderMain.SetError(Tx_Input, "Слишком большое число");
                    return false;
                }
                if (n < min_num)
                {
                    errorProviderMain.SetError(Tx_Input, "Слишком маленькое число");
                    return false;
                }

                errorProviderMain.Clear();
                return true;
            }
            else
            {
                errorProviderMain.SetError(Tx_Input, "Нельзя привести к целому числу");
                return false;
            }
        }

        bool CheckAdditionalInput()
        {
            const int minK = 1;
            const int maxK = 99999;
            if (ulong.TryParse(Tx_Additional_Input.Text, out ulong k))
            {
                if (RB_Solver_MinMaxSeg.Checked)
                {
                    if (RB_Method_Fast.Checked)
                    {
                        if (k > max_num_b)
                        {
                            errorProviderK.SetError(Tx_Additional_Input, "Слишком большое число");
                            return false;
                        }
                    }
                    else if (k > max_num)
                    {
                        errorProviderK.SetError(Tx_Additional_Input, "Слишком большое число");
                        return false;
                    }
                }
                else if (RB_Solver_BarChart.Checked)
                {
                    if (k > maxK)
                    {
                        errorProviderK.SetError(Tx_Additional_Input, "Слишком большое число");
                        return false;
                    }
                }
                if (k < minK)
                {
                    errorProviderK.SetError(Tx_Additional_Input, "Слишком маленькое число");
                    return false;
                }

                errorProviderK.Clear();
                return true;
            }
            else
            {
                errorProviderK.SetError(Tx_Additional_Input, "Нельзя привести к целому числу");
                return false;
            }
        }

        void check_both_inputs()
        {
            bool b1 = CheckMainInput();
            bool b2 = true;
            if (!RB_Solver_MaxSegment.Checked)
                b2 = CheckAdditionalInput();
            Bt_Start.Enabled = b1 && b2;
        }

        void help_determine()
        {
            if (RB_Solver_MinMaxSeg.Checked)
            {
                if (RB_Method_Fast.Checked)
                    Lb_Help.Text = "Поиск сегментов длиной k в диапазоне [2, n] с минимальным и максимальным количеством простых чисел.\r\n" +
                                  $"Входные данные: натуральное число n, в диапазоне [3, {max_num_b}], натуральное число k, в диапазоне [1, {max_num_b}].";
                else
                    Lb_Help.Text = "Поиск сегментов длиной k в диапазоне [2, n] с минимальным и максимальным количеством простых чисел.\r\n" +
                                  $"Входные данные: натуральное число n, в диапазоне [3, {max_num}], натуральное число k, в диапазоне [1, {max_num}].";
            }
            else if (RB_Solver_MaxSegment.Checked)
            {
                if (RB_Method_Fast.Checked)
                    Lb_Help.Text = "Поиск наибольшего отрезка не содержащего простых чисел в промежутке [2, n].\r\n" +
                                  $"Входные данные: натуральное число n, в диапазоне [3, {max_num_b}].";
                else
                    Lb_Help.Text = "Поиск наибольшего отрезка не содержащего простых чисел в промежутке [2, n].\r\n" +
                                  $"Входные данные: натуральное число n, в диапазоне [3, {max_num}].";
            }
            else if (RB_Solver_BarChart.Checked)
            {
                const int maxSeg = 99999;
                if (RB_Method_Fast.Checked)
                    Lb_Help.Text = "Выводит распределение простых чисел на участке [2, n], с количеством сегментов k.\r\n" +
                                  $"Входные данные: натуральное число n, в диапазоне [3, {max_num_b}], натуральное число k, в диапазоне [1, {maxSeg}].";
                else
                    Lb_Help.Text = "Выводит распределение простых чисел на участке [2, n], с количеством сегментов k.\r\n" +
                                  $"Входные данные: натуральное число n, в диапазоне [3, {max_num}], натуральное число k, в диапазоне [1, {maxSeg}].";
            }
        }

        private void RB_Solver_MinMaxSeg_CheckedChanged(object sender, EventArgs e)
        {
            Tx_Additional_Input.Enabled = true;
            help_determine();
            Bt_Output.Enabled = false;
            check_both_inputs();
        }

        private void RB_Solver_MaxSegment_CheckedChanged(object sender, EventArgs e)
        {
            Tx_Additional_Input.Enabled = false;
            help_determine();
            Bt_Output.Enabled = false;
            check_both_inputs();
            errorProviderK.Clear();
        }

        private void RB_Solver_BarChart_CheckedChanged(object sender, EventArgs e)
        {
            Tx_Additional_Input.Enabled = true;
            help_determine();
            Bt_Output.Enabled = false;
            check_both_inputs();
        }

        private void Tx_Input_TextChanged(object sender, EventArgs e)
        {
            check_both_inputs();
        }

        private void Tx_Additional_Input_TextChanged(object sender, EventArgs e)
        {
            check_both_inputs();
        }

        private void RB_Method_Fast_CheckedChanged(object sender, EventArgs e)
        {
            check_both_inputs();
            help_determine();
        }

        private void RB_Method_Erat_CheckedChanged(object sender, EventArgs e)
        {
            check_both_inputs();
            help_determine();
        }

        private void RB_Method_Root_CheckedChanged(object sender, EventArgs e)
        {
            check_both_inputs();
            help_determine();
        }

        private void Bt_Output_Click(object sender, EventArgs e)
        {
            Form formchart = new Chart_Output(cur_data);
            formchart.Show();
        }

        private void btnDivisors_Click(object sender, EventArgs e)
        {
            Form formdiv = new Divisor_Output();
            formdiv.Show();
        }
    }
}