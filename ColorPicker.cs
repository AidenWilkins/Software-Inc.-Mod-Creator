using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoftwareIncSoftwareCreator
{
    public partial class ColorPicker : Form
    {
        public ColorPicker()
        {
            InitializeComponent();

            textBox1.Text = trackBar1.Value.ToString();
            textBox2.Text = trackBar2.Value.ToString();
            textBox3.Text = trackBar3.Value.ToString();
            OK.DialogResult = DialogResult.OK;
        }

        public int R => trackBar1.Value;
        public int G => trackBar2.Value;
        public int B => trackBar3.Value;

        #region Stuff
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            textBox1.Text = trackBar1.Value.ToString();

            panel1.BackColor = Color.FromArgb(trackBar1.Value, trackBar2.Value, trackBar3.Value);

            string hex = DecToHex(trackBar1.Value);
            hex += DecToHex(trackBar2.Value);
            hex += DecToHex(trackBar3.Value);

            textBox4.Text = hex;
        }
        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            textBox2.Text = trackBar2.Value.ToString();
            panel1.BackColor = Color.FromArgb(trackBar1.Value, trackBar2.Value, trackBar3.Value);

            string hex = DecToHex(trackBar1.Value);
            hex += DecToHex(trackBar2.Value);
            hex += DecToHex(trackBar3.Value);

            textBox4.Text = hex;
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            textBox3.Text = trackBar3.Value.ToString();
            panel1.BackColor = Color.FromArgb(trackBar1.Value, trackBar2.Value, trackBar3.Value);

            string hex = DecToHex(trackBar1.Value);
            hex += DecToHex(trackBar2.Value);
            hex += DecToHex(trackBar3.Value);

            textBox4.Text = hex;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                trackBar1.Value = int.Parse(textBox1.Text);
                panel1.BackColor = Color.FromArgb(trackBar1.Value, trackBar2.Value, trackBar3.Value);
            }
            catch
            {

            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                trackBar2.Value = int.Parse(textBox2.Text);
                panel1.BackColor = Color.FromArgb(trackBar1.Value, trackBar2.Value, trackBar3.Value);
            }
            catch
            {

            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                trackBar3.Value = int.Parse(textBox3.Text);
                panel1.BackColor = Color.FromArgb(trackBar1.Value, trackBar2.Value, trackBar3.Value);
            }
            catch
            {

            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            try
            {
                ColorConverter cc = new ColorConverter();
                Color colorFromHex = GetColorFromString(textBox4.Text);
                trackBar1.Value = colorFromHex.R;
                trackBar2.Value = colorFromHex.G;
                trackBar3.Value = colorFromHex.B;
                textBox1.Text = colorFromHex.R.ToString();
                textBox2.Text = colorFromHex.G.ToString();
                textBox3.Text = colorFromHex.B.ToString();
                panel1.BackColor = colorFromHex;
            }
            catch
            {

            }
        }
        #endregion
        private int HexToDec(string hex)
        {
            int dec = Convert.ToInt32(hex, 16);
            return dec;
        }

        private string DecToHex(int value)
        {
            return value.ToString("X2");
        }

        private Color GetColorFromString(string hexString)
        {
            int r = HexToDec(hexString.Substring(0, 2));
            int g = HexToDec(hexString.Substring(2, 2));
            int b = HexToDec(hexString.Substring(4, 2));

            return Color.FromArgb(r, g, b);
        }
    }
}
