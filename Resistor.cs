using Resistance;

namespace Resistence
{
    public partial class Resistor : Form

    {

        Dictionary<string, string> toleranceArr = new Dictionary<string, string>();

        public Resistor()
        {
            InitializeComponent();



            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            comboBox3.SelectedIndex = 0;
            comboBox4.SelectedIndex = 0;

            toleranceArr.Add("Black", "");
            toleranceArr.Add("Brown", "±1% (F)");
            toleranceArr.Add("Red", "±2% (G)");
            toleranceArr.Add("Orange", "±0.05% (W)");
            toleranceArr.Add("Yellow", "±0.02% (P)");
            toleranceArr.Add("Green", "±0.5% (D)");
            toleranceArr.Add("Blue", "±0.25% (C)");
            toleranceArr.Add("Violet", "±0.1% (B)");
            toleranceArr.Add("Grey", "±0.01% (L)");
            toleranceArr.Add("White", "");
            toleranceArr.Add("Gold", "±5% (J)");
            toleranceArr.Add("Silver", "±10% (K)");
        }

        string[] resistenceArr = { "Black", "Brown", "Red", "Orange", "Yellow", "Green", "Blue", "Violet", "Grey", "White" };



        double bandValue_1;
        double bandValue_2;
        double bandValue_3;
        double result;
        string symbol = "Ω";

        private void button1_Click(object sender, EventArgs e)
        {
            string band_1 = comboBox1.SelectedItem.ToString();
            string band_2 = comboBox2.SelectedItem.ToString();
            string band_3 = comboBox3.SelectedItem.ToString();
            string band_4 = comboBox4.SelectedItem.ToString();
            string tolerance = "";

            if (band_4 != "Select Color")
            {
                tolerance = toleranceArr[band_4];
            }

            if (band_1 == "Select Color" || band_2 == "Select Color" || band_3 == "Select Color")
            {
                MessageBox.Show("Please select valid colors for all bands.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            for (int i = 0; i < resistenceArr.Length; i++)
            {
                if (band_1 == resistenceArr[i])
                {
                    bandValue_1 = i * 10;
                }

                if (band_2 == resistenceArr[i])
                {
                    bandValue_2 = i;
                }

                if (band_3 == resistenceArr[i])
                {
                    bandValue_3 = Math.Pow(10, i);
                }

            }

            result = (bandValue_1 + bandValue_2) * bandValue_3;

            if (result >= Math.Pow(10, 3) && result < Math.Pow(10, 6))
            {
                result = result / Math.Pow(10, 3);
                symbol = "KΩ";

            }

            else if (result >= Math.Pow(10, 6))
            {
                result = result / Math.Pow(10, 6);
                symbol = "MΩ";
            }

            label1.Text = "Resistance is: " + result.ToString() + symbol + " " + tolerance;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Handle selected index change event if needed
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            PictureForm picture = new PictureForm();
            picture.Show();
        }
    }
}
