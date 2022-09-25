namespace WinFormsAppPrimeTens
{
    public partial class Chart_Output : Form
    {
        public Chart_Output(List<(ulong start, ulong end, ulong primeCount, double primePercent)> data)
        {
            InitializeComponent();
            Data = data;
        }
        List<(ulong start, ulong end, ulong primeCount, double primePercent)> Data;
        private void Chart_Output_Load(object sender, EventArgs e)
        {
            List<double> trim = new List<double>(Data.Count);
            foreach (var item in Data)
            {
                trim.Add((double)item.primeCount);
            }
            var bar = Pl_Out.Plot.AddBar(trim.ToArray());
            string[] labels = new string[trim.Count];
            double[] values = new double[trim.Count];
            for (int i = 0; i < Data.Count; i++)
            {
                labels[i] = $"({Data[i].start}, {Data[i].end})";
            }
            Pl_Out.Plot.XTicks(labels);
            bar.ShowValuesAboveBars = true;
            trim = new List<double>(Data.Count);
            foreach (var item in Data)
            {
                trim.Add((double)item.primePercent);
            }
            bar = Pl_Out.Plot.AddBar(trim.ToArray());
            bar.ShowValuesAboveBars = true;
            Pl_Out.Refresh();
        }
    }
}
