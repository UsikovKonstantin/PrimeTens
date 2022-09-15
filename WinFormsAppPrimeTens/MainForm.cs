using System.Diagnostics;

namespace WinFormsAppPrimeTens
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        const int min_num = 10;
        const int max_num = int.MaxValue - int.MaxValue % 10;

        Task<(int min_count, int min_loc, int max_count, int max_loc, long mls)> Cur_run;
        CancellationTokenSource Cur_cts;

        private async void Bt_Start_Click(object sender, EventArgs e)
        {
            SetControls(true);
            Cur_cts = new CancellationTokenSource();
            if (RB_Method_Erat.Checked)
            {
                Cur_run = Task.Run(() => Start_Erat(Cur_cts.Token));
            }
            else
            {
                Cur_run = Task.Run(() => Start_Root(Cur_cts.Token));
            }
            await Cur_run;
            var result = Cur_run.Result;
            if (result == (0, 0, 0, 0, 0))
            {
                Cur_run.Dispose();
                return;
            }
            RTx_Output.Text = $"Минимальный десяток {result.min_loc}-{result.min_loc + 9}\n" + 
                $"Наименьшее число простых чисел {result.min_count}\n" +
                $"Максимальный десяток {result.max_loc}-{result.max_loc + 9}\n" +
                $"Максимальное число простых чисел {result.max_count}\n" +
                $"Время выполнения {result.mls}мс";
            SetControls(false);
        }

        (int min_count, int min_loc, int max_count, int max_loc, long mls) Start_Erat(CancellationToken ct)
        {
            int num = int.Parse(Tx_Input.Text);
            int min_loc = -1, min_count = -1, max_loc = -1, max_count = -1;
            Stopwatch tim = new Stopwatch();
            tim.Start();
            var tas = Task.Run(() => ClassLibraryPrimeTens.PrimeTens.GetMinMaxTens(ClassLibraryPrimeTens.PrimeTens.GetPrimeNumbersEratosthenes(num, ct),ct));
            while (min_loc == -1)
            {
                if (tas.Status == TaskStatus.RanToCompletion)
                {
                    var temp = tas.Result;
                    min_count = temp.minCount;
                    min_loc = temp.minRangeStart;
                    max_count = temp.maxCount;
                    max_loc = temp.maxRangeStart;
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

        (int min_count, int min_loc, int max_count, int max_loc, long mls) Start_Root(CancellationToken ct)
        {
            int num = int.Parse(Tx_Input.Text);
            int min_loc = -1, min_count = -1, max_loc = -1, max_count = -1;
            Stopwatch tim = new Stopwatch();
            tim.Start();
            var tas = Task.Run(() => ClassLibraryPrimeTens.PrimeTens.GetMinMaxTens(ClassLibraryPrimeTens.PrimeTens.GetPrimeNumbersSqrt(num,ct), ct));
            while (min_loc == -1)
            {
                if (tas.Status == TaskStatus.RanToCompletion)
                {
                    var temp = tas.Result;
                    min_count = temp.minCount;
                    min_loc = temp.minRangeStart;
                    max_count = temp.maxCount;
                    max_loc = temp.maxRangeStart;
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
            RB_Method_Erat.Enabled = !isTaskRunning;
            RB_Method_Root.Enabled = !isTaskRunning;
            Tx_Input.Enabled = !isTaskRunning;
            Bt_Start.Enabled = !isTaskRunning;
        }

        private void Tx_Input_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(Tx_Input.Text, out int n))
            {
                int nRound = n - n % 10;
                if (nRound > max_num)
                {
                    errorProvider.SetError(Tx_Input, "Слишком большое число");
                    Bt_Start.Enabled = false;
                    return;
                }
                if (nRound < min_num)
                {
                    errorProvider.SetError(Tx_Input, "Слишком маленькое число");
                    Bt_Start.Enabled = false;
                    return;
                }
                if (n != nRound)
                {
                    errorProvider.SetError(Tx_Input, "Число должно оканчиваться на 0");
                    Bt_Start.Enabled = false;
                    return;
                }
                errorProvider.Clear();
                Bt_Start.Enabled = true;
            }
            else if (long.TryParse(Tx_Input.Text, out long _))
            {
                errorProvider.SetError(Tx_Input, "Слишком большое число");
                Bt_Start.Enabled = false;
                return;
            }
            else
            {
                errorProvider.SetError(Tx_Input, "Нельзя привести к целому числу");
                Bt_Start.Enabled = false;
                return;
            }
        }
    }
}