﻿using ClassLibraryPrimeTens;
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

        dynamic Cur_run;
        CancellationTokenSource Cur_cts;

        dynamic cur_data;

        private async void Bt_Start_Click(object sender, EventArgs e)
        {
            SetControls(true);
            Cur_cts = new CancellationTokenSource();
            if (RB_Solver_MinMaxSeg.Checked)
            {
                int num = int.Parse(Tx_Input.Text);
                int len = int.Parse(Tx_Additional_Input.Text);
                if (num % len != 0)
                {
                    num = num - (num % len);
                    Tx_Input.Text = num.ToString();
                    SetControls(false);
                    return;
                }
                
                if (RB_Method_Erat.Checked)
                {
                    Cur_run = Task.Run(() => Start_Lookup_Segments(Cur_cts.Token, Prime_Method.Erathosphenes));
                }
                else
                {
                    Cur_run = Task.Run(() => Start_Lookup_Segments(Cur_cts.Token, Prime_Method.Division_Lookup));
                }
                await Cur_run;
                (int min_count, int min_loc, int max_count, int max_loc, long mls) result = Cur_run.Result;
                if (result == (0, 0, 0, 0, 0))
                {
                    Cur_run.Dispose();
                    return;
                }
                RTx_Output.Text = $"Минимальный сегмент {result.min_loc}-{result.min_loc + (len - 1)}\n" +
                    $"Наименьшее число простых чисел {result.min_count}\n" +
                    $"Максимальный сегмент {result.max_loc}-{result.max_loc + (len - 1)}\n" +
                    $"Максимальное число простых чисел {result.max_count}\n" +
                    $"Время выполнения {result.mls}мс";
            }
            if (RB_Solver_MaxSegment.Checked)
            {
                if (RB_Method_Erat.Checked)
                {

                }
                else
                {

                }
            }
            if (RB_Solver_Divisors.Checked)
            {

            }
            if (RB_Solver_BarChart.Checked)
            {
                if (RB_Method_Erat.Checked)
                {

                }
                else
                {

                }
            }
            SetControls(false);
        }
        (int min_count, int min_loc, int max_count, int max_loc, long mls) Start_Lookup_Segments(CancellationToken ct, Prime_Method Meth)
        {
            int num = int.Parse(Tx_Input.Text);
            int len = int.Parse(Tx_Additional_Input.Text);
            int min_loc = -1, min_count = -1, max_loc = -1, max_count = -1;
            Stopwatch tim = new Stopwatch();
            tim.Start();
            Task<(int min_count, int min_loc, int max_count, int max_loc)> tas;
            tas = Task.Run(() => PrimeTens.GetMinMaxSegments(num, len, Meth, ct));
            bool running = true;
            while (running)
            {
                if (tas.Status == TaskStatus.RanToCompletion)
                {
                    var temp = tas.Result;
                    min_count = temp.min_count;
                    min_loc = temp.min_loc;
                    max_count = temp.max_count;
                    max_loc = temp.max_loc;
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
            RB_Method_Erat.Enabled = !isTaskRunning;
            RB_Method_Root.Enabled = !isTaskRunning;
            Tx_Input.Enabled = !isTaskRunning;
            Bt_Start.Enabled = !isTaskRunning;
            Tx_Additional_Input.Enabled = !isTaskRunning;
            RB_Solver_BarChart.Enabled = !isTaskRunning;
            RB_Solver_Divisors.Enabled = !isTaskRunning;
            RB_Solver_MaxSegment.Enabled = !isTaskRunning;
            RB_Solver_MinMaxSeg.Enabled = !isTaskRunning;
            if (RB_Solver_Divisors.Checked || RB_Solver_BarChart.Checked)
            {
                Bt_Output.Enabled = !isTaskRunning;
            }
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
        void Methods_State(bool state)
        {
            if (state)
            {
                RB_Method_Erat.Enabled = true;
                RB_Method_Root.Enabled = true;
            }
            else
            {
                RB_Method_Erat.Enabled = false;
                RB_Method_Root.Enabled = false;
            }
        }
        private void RB_Solver_MinMaxSeg_CheckedChanged(object sender, EventArgs e)
        {
            Methods_State(true);
            Tx_Additional_Input.Enabled = true;
            Lb_Help.Text =
                "Поиск сегментов длиной k в диапазоне [2, n] с минимальным и максимальным количеством простых чисел.\r\n" +
                "Входные данные: натуральное число n, в диапазоне [3, 2147483640], натуральное число k, в диапазоне [1, 99999].";
            Bt_Output.Enabled = false;
        }

        private void RB_Solver_MaxSegment_CheckedChanged(object sender, EventArgs e)
        {
            Methods_State(true);
            Tx_Additional_Input.Enabled = false;
            Lb_Help.Text = "Поиск наибольшего отрезка не содержащего простых чисел в промежутке [2, n].\r\n" +
                "Входные данные: натуральное число n, в диапазоне [3, 2147483640].";
            Bt_Output.Enabled = false;
        }

        private void RB_Solver_Divisors_CheckedChanged(object sender, EventArgs e)
        {
            Methods_State(false);
            Tx_Additional_Input.Enabled = false;
            Lb_Help.Text = "Поиск всех делителей числа n, включая 1 и n.\r\n" +
                "Входные данные: натуральное число n, в диапазоне [3, 2147483640].";
            Bt_Output.Enabled = true;
        }

        private void RB_Solver_BarChart_CheckedChanged(object sender, EventArgs e)
        {
            Methods_State(true);
            Tx_Additional_Input.Enabled = true;
            Lb_Help.Text = "Выводит распределение простых чисел на участке [2, n], с количеством сегментов k.\r\n" +
                "Входные данные: натуральное число n, в диапазоне [3, 2147483640], натуральное число k, в диапазоне [1, 99999].";
            Bt_Output.Enabled = true;
        }

        private void Tx_Additional_Input_TextChanged(object sender, EventArgs e)
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
}