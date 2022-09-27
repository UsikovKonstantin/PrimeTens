using System.Diagnostics;
using System.Text;
using ClassLibraryPrimeTens;

namespace WinFormsAppPrimeTens
{
    public partial class Divisor_Output : Form
    {
        public Divisor_Output()
        {
            InitializeComponent();
        }

        const ulong maxNum = ulong.MaxValue;
        const int minNum = 2;
        CancellationTokenSource Cur_cts;

        private void tbInput_TextChanged(object sender, EventArgs e)
        {
            if (ulong.TryParse(tbInput.Text, out ulong n))
            {
                if (n > maxNum)
                {
                    errorProvider.SetError(tbInput, "Слишком большое число");
                    btnFindDivisors.Enabled = false;
                    return;
                }
                if (n < minNum)
                {
                    errorProvider.SetError(tbInput, "Слишком маленькое число");
                    btnFindDivisors.Enabled = false;
                    return;
                }

                errorProvider.Clear();
                btnFindDivisors.Enabled = true;
            }
            else
            {
                errorProvider.SetError(tbInput, "Нельзя привести к целому числу");
                btnFindDivisors.Enabled = false;
            }
        }

        private async void btnFindDivisors_Click(object sender, EventArgs e)
        {
            btnFindDivisors.Enabled = false;
            btnStop.Enabled = true;
            ulong num = ulong.Parse(tbInput.Text);
            (List<ulong> data, long mls) divisors;
            Cur_cts = new CancellationTokenSource();
            Task<(List<ulong> data, long mls)> Cur_run = Task.Run(() => Start_Lookup_Divisors(Cur_cts.Token));
            await Cur_run;
            divisors = Cur_run.Result;
            if (divisors == (null, 0))
            {
                Cur_run.Dispose();
                btnFindDivisors.Enabled = true;
                btnStop.Enabled = false;
                return;
            }
            
            StringBuilder sb = new();
            foreach (var item in divisors.data)
            {
                sb.Append(item.ToString() + "\n");
            }
            tbOutput.Text = $"Найдено {divisors.data.Count} делителей:\n" +
                            sb.ToString() +
                            $"Время выполнения {divisors.mls}мс";
            btnFindDivisors.Enabled = true;
            btnStop.Enabled = false;
        }

        (List<ulong> data, long mls) Start_Lookup_Divisors(CancellationToken ct)
        {
            ulong num = ulong.Parse(tbInput.Text);
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
                    tbOutput.Invoke(new Action(() => tbOutput.Text = $"{sw.ElapsedMilliseconds / 1000}.{sw.ElapsedMilliseconds / 100 % 10} с"));
                    Thread.Sleep(5);
                }
                if (ct.IsCancellationRequested)
                {
                    return (null, 0);
                }
            }
            return (null, 0);
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            Cur_cts.Cancel();
            btnFindDivisors.Enabled = true;
            btnStop.Enabled = false;
        }
    }
}
