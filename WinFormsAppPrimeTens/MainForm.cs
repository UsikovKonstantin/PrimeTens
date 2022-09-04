using System.Diagnostics;

namespace WinFormsAppPrimeTens
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Tx_Input.Text = exemnum.ToString();
            Bt_Start.Enabled = true;
        }
        const int exemnum = 100;
        private void ChB_Method_Root_CheckedChanged(object sender, EventArgs e)
        {
            if (ChB_Method_Erat.Checked == false && ChB_Method_Root.Checked == false)
            {
                ChB_Method_Root.Checked = true;
            }
            if (ChB_Method_Erat.Checked == true && ChB_Method_Root.Checked == true)
            {
                ChB_Method_Root.Checked = true;
                ChB_Method_Erat.Checked = false;
            }
        }

        private void ChB_Method_Erat_CheckedChanged(object sender, EventArgs e)
        {
            if (ChB_Method_Erat.Checked == false && ChB_Method_Root.Checked == false)
            {
                ChB_Method_Erat.Checked = true;
            }
            if (ChB_Method_Erat.Checked == true && ChB_Method_Root.Checked == true)
            {
                ChB_Method_Erat.Checked = true;
                ChB_Method_Root.Checked = false;
            }
        }

        private void Bt_Check_Click(object sender, EventArgs e)
        {
            if (int.TryParse(Tx_Input.Text, out _) == true)
            {
                Tx_Input.Text = ((int.Parse(Tx_Input.Text) / 10) * 10).ToString();
                if ((int.Parse(Tx_Input.Text) < 10))
                {
                    Tx_Input.Text = "10";
                }
                Bt_Start.Enabled = true;
            }
            else
            {
                Tx_Input.Text = exemnum.ToString();
                Bt_Start.Enabled = true;
            }
        }
        Task<(int min_count, int min_loc, int max_count, int max_loc, long mls)> Cur_run;
        CancellationTokenSource Cur_cts;
        private async void Bt_Start_Click(object sender, EventArgs e)
        {
            Bt_End.Enabled = true;
            Bt_Check.Enabled = false;
            ChB_Method_Erat.Enabled = false;
            ChB_Method_Root.Enabled = false;
            Tx_Input.Enabled = false;
            Bt_Start.Enabled = false;
            Cur_cts = new();
            if (ChB_Method_Erat.Checked)
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
            RTx_Output.Text = $"Минимальный десяток {result.min_loc}-{result.min_loc + 9}\nНаименьшее число простых чисел {result.min_count}\nМаксимальный десяток {result.max_loc}-{result.max_loc + 9}\nМаксимальное число простых чисел {result.max_count}\nВремя выполнения {result.mls}мс";
            Bt_End.Enabled = false;
            Bt_Check.Enabled = true;
            ChB_Method_Erat.Enabled = true;
            ChB_Method_Root.Enabled = true;
            Tx_Input.Enabled = true;
            Bt_Start.Enabled = true;
        }
        async Task<(int min_count, int min_loc, int max_count, int max_loc, long mls)> Start_Erat(CancellationToken ct)
        {
            int num = int.Parse(Tx_Input.Text);
            int min_loc = -1, min_count = -1, max_loc = -1, max_count = -1;
            Stopwatch tim = new();
            tim.Start();
            var tas = Task.Factory.StartNew(() => ClassLibraryPrimeTens.PrimeTens.GetMinMaxTens(ClassLibraryPrimeTens.PrimeTens.GetPrimeNumbersEratosthenes(num, ct),ct));
            while (min_loc == -1)
            {
                if (tas.Status == TaskStatus.RanToCompletion)
                {
                    (int, int, int, int) temp = tas.Result;
                    min_count = temp.Item1;
                    min_loc = temp.Item2;
                    max_count = temp.Item3;
                    max_loc = temp.Item4;
                }
                else
                {
                    if (ct.IsCancellationRequested)
                    {
                        return (0, 0, 0, 0, 0);
                    }
                    RTx_Output.Invoke(new Action(() => RTx_Output.Text = $"{tim.ElapsedMilliseconds}мс"));
                    await Task.Delay(10);
                }
                if (ct.IsCancellationRequested)
                {
                    return (0, 0, 0, 0, 0);
                }
            }
            tim.Stop();
            long mls = tim.ElapsedMilliseconds;
            await tas;
            return (min_count, min_loc, max_count, max_loc, mls);
        }
        async Task<(int min_count, int min_loc, int max_count, int max_loc, long mls)> Start_Root(CancellationToken ct)
        {
            int num = int.Parse(Tx_Input.Text);
            int min_loc = -1, min_count = -1, max_loc = -1, max_count = -1;
            Stopwatch tim = new();
            tim.Start();
            var tas = Task.Factory.StartNew(() => ClassLibraryPrimeTens.PrimeTens.GetMinMaxTens(ClassLibraryPrimeTens.PrimeTens.GetPrimeNumbersSqrt(num,ct), ct));
            while (min_loc == -1)
            {
                if (tas.Status == TaskStatus.RanToCompletion)
                {
                    (int, int, int, int) temp = tas.Result;
                    min_count = temp.Item1;
                    min_loc = temp.Item2;
                    max_count = temp.Item3;
                    max_loc = temp.Item4;
                }
                else
                {
                    if (ct.IsCancellationRequested)
                    {
                        return (0, 0, 0, 0, 0);
                    }
                    RTx_Output.Invoke(new Action(() => RTx_Output.Text = $"{tim.ElapsedMilliseconds}мс"));
                    await Task.Delay(10);
                }
                if (ct.IsCancellationRequested)
                {
                    return (0,0,0,0,0);
                }
            }
            tim.Stop();
            long mls = tim.ElapsedMilliseconds;
            await tas;
            return (min_count, min_loc, max_count, max_loc, mls);
        }
        private void Bt_End_Click(object sender, EventArgs e)
        {
            Bt_End.Enabled = false;
            Bt_Check.Enabled = true;
            ChB_Method_Erat.Enabled = true;
            ChB_Method_Root.Enabled = true;
            Tx_Input.Enabled = true;
            Bt_Start.Enabled = true;
            Cur_cts.Cancel();
        }

        private void Tx_Input_TextChanged(object sender, EventArgs e)
        {
            Bt_Start.Enabled = false;
        }
    }
}