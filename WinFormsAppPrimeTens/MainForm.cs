using ClassLibraryPrimeTens;
using System.Diagnostics;

namespace WinFormsAppPrimeTens
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        const int min_num = 3;
        const int max_num = int.MaxValue - int.MaxValue % 10;
        const ulong max_num_b = ulong.MaxValue - (ulong.MaxValue % 10);

        dynamic Cur_run;
        CancellationTokenSource Cur_cts;
        enum Data_Type
        {
            Divisors,
            Chart
        }
        (Data_Type disp, dynamic data) cur_data;
        private async void Bt_Start_Click(object sender, EventArgs e)
        {
            SetControls(true);
            Cur_cts = new CancellationTokenSource();
            if (RB_Solver_MinMaxSeg.Checked)
            {
                ulong num = ulong.Parse(Tx_Input.Text);
                int len = int.Parse(Tx_Additional_Input.Text);
                if (num % (ulong)len != 0)
                {
                    num = num - (num % (ulong)len);
                    Tx_Input.Text = num.ToString();
                    SetControls(false);
                    return;
                }

                if (RB_Method_Erat.Checked)
                {
                    Cur_run = Task.Run(() => Start_Lookup_Segments(Cur_cts.Token, Prime_Method.Erathosphenes));
                }
                else if (RB_Method_Fast.Checked)
                {
                    Cur_run = Task.Run(() => Start_Lookup_Segments(Cur_cts.Token, Prime_Method.Fast_Lookup));
                }
                else
                {
                    Cur_run = Task.Run(() => Start_Lookup_Segments(Cur_cts.Token, Prime_Method.Division_Lookup));
                }
                await Cur_run;
                (ulong min_count, ulong min_loc, ulong max_count, ulong max_loc, long mls) result = Cur_run.Result;
                if (result == (0, 0, 0, 0, 0))
                {
                    Cur_run.Dispose();
                    SetControls(false);
                    return;
                }
                RTx_Output.Text = $"Минимальный сегмент {result.min_loc}-{result.min_loc + (ulong)(len - 1)}\n" +
                    $"Наименьшее число простых чисел {result.min_count}\n" +
                    $"Максимальный сегмент {result.max_loc}-{result.max_loc + (ulong)(len - 1)}\n" +
                    $"Максимальное число простых чисел {result.max_count}\n" +
                    $"Время выполнения {result.mls}мс";
            }
            if (RB_Solver_MaxSegment.Checked)
            {
                Cur_cts = new();
                if (RB_Method_Erat.Checked)
                {
                    Cur_run = Task.Run(() => Start_Lookup_DivisorlessRange(Cur_cts.Token, Prime_Method.Erathosphenes));
                }
                else if (RB_Method_Fast.Checked)
                {
                    Cur_run = Task.Run(() => Start_Lookup_DivisorlessRange(Cur_cts.Token, Prime_Method.Fast_Lookup));
                }
                else
                {
                    Cur_run = Task.Run(() => Start_Lookup_DivisorlessRange(Cur_cts.Token, Prime_Method.Division_Lookup));
                }
                await Cur_run;
                (ulong start, ulong end, long mls) result = Cur_run.Result;
                if (result == (0, 0, 0))
                {
                    Cur_run.Dispose();
                    SetControls(false);
                    return;
                }
                RTx_Output.Text = $"Начало сегмента {result.start}\n" +
                    $"Конец сегмента {result.end}\n" +
                    $"Длина сегмента {result.end - result.start}\n" +
                    $"Время выполнения {result.mls}мс";
            }
            if (RB_Solver_Divisors.Checked)
            {
                ulong num = ulong.Parse(Tx_Input.Text);
                (List<ulong> data, long mls) divisors;
                Cur_cts = new();
                Cur_run = Task.Run(() => Start_Lookup_Divisors(Cur_cts.Token));
                await Cur_run;
                divisors = Cur_run.Result;
                if (divisors == (null, 0))
                {
                    Cur_run.Dispose();
                    SetControls(false);
                    return;
                }
                RTx_Output.Text = $"Найдено {divisors.data.Count} делителей\n" +
                    $"Время выполнения {divisors.mls}мс" +
                    $"Результаты по кнопке \"Вывод\"";
                cur_data = (Data_Type.Divisors, divisors.data);
            }
            if (RB_Solver_BarChart.Checked)
            {
                ulong num = ulong.Parse(Tx_Input.Text);
                int len = int.Parse(Tx_Additional_Input.Text);
                if (num % (ulong)len != 0)
                {
                    num = num - (num % (ulong)len);
                    Tx_Input.Text = num.ToString();
                    SetControls(false);
                    return;
                }

                Cur_cts = new();
                if (RB_Method_Erat.Checked)
                {
                    Cur_run = Task.Run(() => Start_Lookup_Chart(Cur_cts.Token, Prime_Method.Erathosphenes));
                }
                else if (RB_Method_Fast.Checked)
                {
                    Cur_run = Task.Run(() => Start_Lookup_Chart(Cur_cts.Token, Prime_Method.Fast_Lookup));
                }
                else
                {
                    Cur_run = Task.Run(() => Start_Lookup_Chart(Cur_cts.Token, Prime_Method.Division_Lookup));
                }
                await Cur_run;
                (List<(ulong start, ulong end, ulong primeCount, double primePercent)> data, long mls) result = Cur_run.Result;
                if (result == (null, 0))
                {
                    Cur_run.Dispose();
                    SetControls(false);
                    return;
                }
                RTx_Output.Text = $"Время выполнения {result.mls}мс\n" +
                    $"Результаты по кнопке \"Вывод\"";
                cur_data = (Data_Type.Chart, result.data);
            }
            SetControls(false);
        }
        (List<ulong> data, long mls) Start_Lookup_Divisors(CancellationToken ct)
        {
            ulong num = ulong.Parse(Tx_Input.Text);
            Stopwatch sw = Stopwatch.StartNew();
            Task<List<ulong>> tas;
            tas = Task.Run(() => PrimeTens.GetDivisors(num, ct));
            bool running = true;
            while (running)
            {
                if (tas.Status == TaskStatus.RanToCompletion)
                {
                    var temp = tas.Result;
                    sw.Stop();
                    return (temp, sw.ElapsedMilliseconds);
                }
                else
                {
                    if (ct.IsCancellationRequested)
                    {
                        return (null, 0);
                    }
                    RTx_Output.Invoke(new Action(() => RTx_Output.Text = $"{sw.ElapsedMilliseconds / 1000}.{sw.ElapsedMilliseconds / 100 % 10} с"));
                    Thread.Sleep(5);
                }
                if (ct.IsCancellationRequested)
                {
                    return (null, 0);
                }
            }
            return (null, 0);
        }
        (List<(ulong start, ulong end, ulong primeCount, double primePercent)> data, long mls) Start_Lookup_Chart(CancellationToken ct, Prime_Method method)
        {
            ulong num = ulong.Parse(Tx_Input.Text);
            int len = int.Parse(Tx_Additional_Input.Text);
            Stopwatch sw = Stopwatch.StartNew();
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
                    sw.Stop();
                    List<(ulong start, ulong end, ulong primeCount, double primePercent)> data = new();

                    if (temp[0].Item1 is int)
                    {
                        foreach (var item in temp)
                        {
                            data.Add(((ulong)item.Item1, (ulong)item.Item2, (ulong)item.Item3, item.Item4));
                        }
                    }
                    else
                    {
                        data = temp;
                    }
                    return (data, sw.ElapsedMilliseconds);
                }
                else
                {
                    if (ct.IsCancellationRequested)
                    {
                        return (null, 0);
                    }
                    RTx_Output.Invoke(new Action(() => RTx_Output.Text = $"{sw.ElapsedMilliseconds / 1000}.{sw.ElapsedMilliseconds / 100 % 10} с"));
                    Thread.Sleep(5);
                }
                if (ct.IsCancellationRequested)
                {
                    return (null, 0);
                }
            }
            return (null, 0);
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
                    if (temp.Item1 is ulong)
                    {
                        start = temp.Item1;
                        end = temp.Item2;
                    }
                    else
                    {
                        start = (ulong)temp.Item1;
                        end = (ulong)temp.Item2;
                    }
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
                    if (temp.Item1 is ulong)
                    {
                        min_count = temp.Item1;
                        min_loc = temp.Item2;
                        max_count = temp.Item3;
                        max_loc = temp.Item4;
                    }
                    else
                    {
                        min_count = (ulong)temp.Item1;
                        min_loc = (ulong)temp.Item2;
                        max_count = (ulong)temp.Item3;
                        max_loc = (ulong)temp.Item4;
                    }

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

        private void Bt_End_Click(object sender, EventArgs e)
        {
            SetControls(false);
            Cur_cts.Cancel();
        }

        private void SetControls(bool isTaskRunning)
        {
            Bt_End.Enabled = isTaskRunning;
            if (!RB_Solver_Divisors.Checked)
            {
                RB_Method_Erat.Enabled = !isTaskRunning;
                RB_Method_Root.Enabled = !isTaskRunning;
                RB_Method_Fast.Enabled = !isTaskRunning;
            }
            Tx_Input.Enabled = !isTaskRunning;
            Bt_Start.Enabled = !isTaskRunning;
            if (RB_Solver_MinMaxSeg.Checked || RB_Solver_BarChart.Checked)
            {
                Tx_Additional_Input.Enabled = !isTaskRunning;
            }
            RB_Solver_BarChart.Enabled = !isTaskRunning;
            RB_Solver_Divisors.Enabled = !isTaskRunning;
            RB_Solver_MaxSegment.Enabled = !isTaskRunning;
            RB_Solver_MinMaxSeg.Enabled = !isTaskRunning;
            if (RB_Solver_Divisors.Checked || RB_Solver_BarChart.Checked)
            {
                Bt_Output.Enabled = !isTaskRunning;
            }
        }
        void check_both_inputs()
        {
            {
                if (ulong.TryParse(Tx_Input.Text, out ulong n))
                {
                    if (RB_Method_Fast.Checked)
                    {
                        if (n > max_num_b)
                        {
                            errorProvider.SetError(Tx_Input, "Слишком большое число");
                            Bt_Start.Enabled = false;
                            return;
                        }
                        if (n < min_num)
                        {
                            errorProvider.SetError(Tx_Input, "Слишком маленькое число");
                            Bt_Start.Enabled = false;
                            return;
                        }
                    }
                    else
                    {
                        if (n > max_num)
                        {
                            errorProvider.SetError(Tx_Input, "Слишком большое число");
                            Bt_Start.Enabled = false;
                            return;
                        }
                        if (n < min_num)
                        {
                            errorProvider.SetError(Tx_Input, "Слишком маленькое число");
                            Bt_Start.Enabled = false;
                            return;
                        }
                    }

                    errorProvider.Clear();
                    Bt_Start.Enabled = true;
                }
                else
                {
                    errorProvider.SetError(Tx_Input, "Нельзя привести к целому числу");
                    Bt_Start.Enabled = false;
                    return;
                }
            }
            {
                if (int.TryParse(Tx_Additional_Input.Text, out int n))
                {
                    if (n < 1)
                    {
                        errorProvider.SetError(Tx_Additional_Input, "Слишком маленькое число");
                        Bt_Start.Enabled = false;
                        return;
                    }
                    errorProvider.Clear();
                    Bt_Start.Enabled = true;
                }
                else
                {
                    errorProvider.SetError(Tx_Additional_Input, "Нельзя привести к целому числу");
                    Bt_Start.Enabled = false;
                    return;
                }
            }
        }
        private void Tx_Input_TextChanged(object sender, EventArgs e)
        {
            check_both_inputs();
        }
        void Methods_State(bool state)
        {
            if (state)
            {
                RB_Method_Erat.Enabled = true;
                RB_Method_Root.Enabled = true;
                RB_Method_Fast.Enabled = true;
            }
            else
            {
                RB_Method_Erat.Enabled = false;
                RB_Method_Root.Enabled = false;
                RB_Method_Fast.Enabled = false;
            }
        }
        void help_determine()
        {
            if (RB_Solver_MinMaxSeg.Checked)
            {
                if (RB_Method_Fast.Checked)
                {
                    Lb_Help.Text =
                "Поиск сегментов длиной k в диапазоне [2, n] с минимальным и максимальным количеством простых чисел.\r\n" +
                $"Входные данные: натуральное число n, в диапазоне [3, {max_num_b}], натуральное число k, в диапазоне [1, 99999].";
                }
                else
                {
                    Lb_Help.Text =
                "Поиск сегментов длиной k в диапазоне [2, n] с минимальным и максимальным количеством простых чисел.\r\n" +
                $"Входные данные: натуральное число n, в диапазоне [3, {max_num}], натуральное число k, в диапазоне [1, 99999].";
                }
            }
            else if (RB_Solver_MaxSegment.Checked)
            {
                if (RB_Method_Fast.Checked)
                {
                    Lb_Help.Text = "Поиск наибольшего отрезка не содержащего простых чисел в промежутке [2, n].\r\n" +
                $"Входные данные: натуральное число n, в диапазоне [3, {max_num_b}].";
                }
                else
                {
                    Lb_Help.Text = "Поиск наибольшего отрезка не содержащего простых чисел в промежутке [2, n].\r\n" +
                $"Входные данные: натуральное число n, в диапазоне [3, {max_num}].";
                }
            }
            else if (RB_Solver_Divisors.Checked)
            {
                Lb_Help.Text = "Поиск всех делителей числа n, включая 1 и n.\r\n" +
                $"Входные данные: натуральное число n, в диапазоне [3, {max_num_b}].";
            }
            else if (RB_Solver_BarChart.Checked)
            {
                if (RB_Method_Fast.Checked)
                {
                    Lb_Help.Text = "Выводит распределение простых чисел на участке [2, n], с количеством сегментов k.\r\n" +
                $"Входные данные: натуральное число n, в диапазоне [3, {max_num_b}], натуральное число k, в диапазоне [1, 99999].";
                }
                else
                {
                    Lb_Help.Text = "Выводит распределение простых чисел на участке [2, n], с количеством сегментов k.\r\n" +
                $"Входные данные: натуральное число n, в диапазоне [3, {max_num}], натуральное число k, в диапазоне [1, 99999].";
                }
            }
        }
        private void RB_Solver_MinMaxSeg_CheckedChanged(object sender, EventArgs e)
        {
            Methods_State(true);
            Tx_Additional_Input.Enabled = true;
            help_determine();
            Bt_Output.Enabled = false;
            Tx_Input_TextChanged(sender, e);
        }

        private void RB_Solver_MaxSegment_CheckedChanged(object sender, EventArgs e)
        {
            Methods_State(true);
            Tx_Additional_Input.Enabled = false;
            help_determine();
            Bt_Output.Enabled = false;
            Tx_Input_TextChanged(sender, e);
        }

        private void RB_Solver_Divisors_CheckedChanged(object sender, EventArgs e)
        {
            Methods_State(false);
            Tx_Additional_Input.Enabled = false;
            help_determine();
            Bt_Output.Enabled = true;
            Tx_Input_TextChanged(sender, e);
        }

        private void RB_Solver_BarChart_CheckedChanged(object sender, EventArgs e)
        {
            Methods_State(true);
            Tx_Additional_Input.Enabled = true;
            help_determine();
            Bt_Output.Enabled = true;
            Tx_Input_TextChanged(sender, e);
        }

        private void Tx_Additional_Input_TextChanged(object sender, EventArgs e)
        {
            check_both_inputs();
        }

        private void Bt_Output_Click(object sender, EventArgs e)
        {
            switch (cur_data.disp)
            {
                case Data_Type.Divisors:
                    Form formdiv = new Divisor_Output(cur_data.data);
                    formdiv.Show();
                    break;
                case Data_Type.Chart:
                    Form formchart = new Chart_Output(cur_data.data);
                    formchart.Show();
                    break;
                default:
                    break;
            }

        }

        private void RB_Method_Fast_CheckedChanged(object sender, EventArgs e)
        {
            Tx_Input_TextChanged(sender, e);
            help_determine();
        }

        private void RB_Method_Erat_CheckedChanged(object sender, EventArgs e)
        {
            Tx_Input_TextChanged(sender, e);
            help_determine();
        }

        private void RB_Method_Root_CheckedChanged(object sender, EventArgs e)
        {
            Tx_Input_TextChanged(sender, e);
            help_determine();
        }
    }
}