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
    public partial class NewSoftwareTypeMenu : Form
    {
        public NewSoftwareTypeMenu()
        {
            InitializeComponent();
            OkBTN.DialogResult = DialogResult.OK;
        }

        public string Name_ => textBox1.Text;
        public string Unlock => textBox2.Text;
        public string Category => textBox3.Text;
        public string Description => textBox6.Text;
        public string Random => textBox5.Text;
        public string Popularity => textBox4.Text;
        public string Retention => textBox9.Text;
        public string Iterative => textBox8.Text;
        public string TimeScale => textBox7.Text;
        public string OSLimit => (comboBox1.SelectedItem == null) ? "n/a" : comboBox1.SelectedItem.ToString(); //Phone, Console, Computer
        public string NameGenerator => textBox11.Text;
        public string IdealPrice => textBox10.Text;
        public bool OSSpecific => checkBox1.Checked;
        public bool OneClient => checkBox2.Checked;
        public bool InHouse => checkBox3.Checked;

        #region TextboxStuff
        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "n/a";
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {          
                textBox2.Text = "n/a";
            }
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                textBox3.Text = "n/a";
            }
        }
        private void textBox4_Leave(object sender, EventArgs e)
        {
            if (textBox4.Text == "")
            {
                textBox4.Text = "n/a";
            }
        }
        private void textBox5_Leave(object sender, EventArgs e)
        {
            if (textBox5.Text == "")
            {
                textBox5.Text = "n/a";
            }
        }
        private void textBox6_Leave(object sender, EventArgs e)
        {
            if (textBox6.Text == "")
            {
                textBox6.Text = "n/a";
            }
        }
        private void textBox7_Leave(object sender, EventArgs e)
        {
            if (textBox7.Text == "")
            {
                textBox7.Text = "n/a";
            }
        }
        private void textBox8_Leave(object sender, EventArgs e)
        {
            if (textBox8.Text == "")
            {
                textBox8.Text = "n/a";
            }
        }
        private void textBox9_Leave(object sender, EventArgs e)
        {
            if (textBox9.Text == "")
            {
                textBox9.Text = "n/a";
            }
        }
        private void textBox10_Leave(object sender, EventArgs e)
        {
            if (textBox10.Text == "")
            {
                textBox10.Text = "n/a";
            }
        }
        private void textBox11_Leave(object sender, EventArgs e)
        {
            if (textBox11.Text == "")
            {
                textBox11.Text = "n/a";
            }
        }

        private void comboBox1_Leave(object sender, EventArgs e)
        {
            if (comboBox1.SelectedText == "")
            {
                comboBox1.SelectedText = "n/a";
            }
        }
        #endregion

        public int Style { get; set; }
        private void NewSoftwareTypeMenu_Load(object sender, EventArgs e)
        {
            #region Set Theme
            if (Style == 0)
            {
                BackColor = Color.WhiteSmoke;
                BackgroundImage = null;
                foreach (Control child in this.Controls)
                {
                    if (child is ListBox)
                    {
                        ListBox lbl = (ListBox)child;
                        lbl.ForeColor = Color.Gray;
                        lbl.BackColor = Color.White;
                    }

                    if (child is TextBox)
                    {
                        TextBox cb = (TextBox)child;
                        cb.ForeColor = Color.Gray;
                        cb.BackColor = Color.White;
                    }

                    if (child is Label)
                    {
                        Label cb = (Label)child;
                        cb.ForeColor = Color.Gray;
                    }

                    if (child is CheckBox)
                    {
                        CheckBox cb = (CheckBox)child;
                        cb.ForeColor = Color.Gray;
                    }

                    if (child is ComboBox)
                    {
                        ComboBox cb = (ComboBox)child;
                        cb.ForeColor = Color.Gray;
                        cb.BackColor = Color.White;
                    }

                    if (child is Button)
                    {
                        Button cb = (Button)child;
                        cb.FlatStyle = FlatStyle.Flat;
                        cb.FlatAppearance.BorderSize = 0;
                        cb.ForeColor = Color.Gray;
                        cb.BackColor = Color.White;
                    }
                }
            }
            else if (Style == 1)
            {
                BackgroundImage = null;
                BackColor = Color.FromArgb(38, 38, 43);
                foreach (Control child in this.Controls)
                {
                    if (child is ListBox)
                    {
                        ListBox lbl = (ListBox)child;
                        lbl.BackColor = Color.FromArgb(51, 51, 55);
                        lbl.ForeColor = Color.FromArgb(35, 123, 158);
                    }

                    if (child is TextBox)
                    {
                        TextBox cb = (TextBox)child;
                        cb.ForeColor = Color.FromArgb(35, 123, 158);
                        cb.BackColor = Color.FromArgb(51, 51, 55);
                    }

                    if (child is Label)
                    {
                        Label cb = (Label)child;
                        cb.ForeColor = Color.FromArgb(35, 123, 158);
                    }

                    if (child is CheckBox)
                    {
                        CheckBox cb = (CheckBox)child;
                        cb.ForeColor = Color.FromArgb(35, 123, 158);
                    }

                    if (child is ComboBox)
                    {
                        ComboBox cb = (ComboBox)child;
                        cb.ForeColor = Color.FromArgb(35, 123, 158);
                        cb.BackColor = Color.FromArgb(51, 51, 55);
                    }

                    if (child is Button)
                    {
                        Button cb = (Button)child; ;
                        cb.FlatStyle = FlatStyle.Flat;
                        cb.FlatAppearance.BorderSize = 0;
                        cb.ForeColor = Color.FromArgb(35, 123, 158);
                        cb.BackColor = Color.FromArgb(51, 51, 55);
                    }
                }
            }
            else
            {
                BackColor = Color.FromArgb(87, 81, 65);
                foreach (Control child in this.Controls)
                {
                    if (child is ListBox)
                    {
                        ListBox lbl = (ListBox)child;
                        lbl.BackColor = Color.FromArgb(58, 26, 37);
                        lbl.ForeColor = Color.FromArgb(158, 41, 43);
                    }

                    if (child is TextBox)
                    {
                        TextBox cb = (TextBox)child;
                        cb.ForeColor = Color.FromArgb(35, 123, 158);
                        cb.BackColor = Color.FromArgb(58, 26, 37);
                    }

                    if (child is Label)
                    {
                        Label cb = (Label)child;
                        cb.ForeColor = Color.FromArgb(158, 41, 43);
                    }

                    if (child is CheckBox)
                    {
                        CheckBox cb = (CheckBox)child;
                        cb.ForeColor = Color.FromArgb(158, 41, 43);
                        //cb.BackColor = Color.FromArgb(58, 26, 37);
                    }

                    if (child is ComboBox)
                    {
                        ComboBox cb = (ComboBox)child;
                        cb.ForeColor = Color.FromArgb(158, 41, 43);
                        cb.BackColor = Color.FromArgb(51, 51, 55);
                    }

                    if (child is Button)
                    {
                        Button cb = (Button)child;
                        cb.FlatStyle = FlatStyle.Flat;
                        cb.FlatAppearance.BorderSize = 0;
                        cb.ForeColor = Color.FromArgb(158, 41, 43);
                        cb.BackColor = Color.FromArgb(58, 26, 37);
                    }
                }
            }
            #endregion
        }
    }
}
