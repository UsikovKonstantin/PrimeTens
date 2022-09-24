using System.Text;

namespace WinFormsAppPrimeTens
{
    public partial class Divisor_Output : Form
    {
        public Divisor_Output(List<int> divs)
        {
            InitializeComponent();
            StringBuilder Temp = new();
            foreach (var item in divs)
            {
                Temp.Append(item.ToString() + "\n");
            }
            to_print = Temp.ToString();
        }
        string to_print;

        private void Divisor_Output_Load(object sender, EventArgs e)
        {
            RTx_Div_Out.Text = to_print;
        }
    }
}
