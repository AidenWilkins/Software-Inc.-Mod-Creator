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
    public partial class NewNameGeneratorMenu : Form
    {
        public NewNameGeneratorMenu()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
            button8.DialogResult = DialogResult.Cancel;
            button9.DialogResult = DialogResult.OK;
        }

        public string[] Base => listBox1.Items.OfType<string>().ToArray();
        public string[] Base2 => listBox2.Items.OfType<string>().ToArray();
        public string[] End => listBox3.Items.OfType<string>().ToArray();
        public string Name_ => textBox4.Text;

        private void Preview()
        {
            string[] Base_ = listBox1.Items.OfType<string>().ToArray();
            string[] Base2_ = listBox2.Items.OfType<string>().ToArray();
            string[] End_ = listBox3.Items.OfType<string>().ToArray();


            Random random = new Random();
            string output = "";
            listBox4.Items.Clear();
            try
            {
                for (int i = 0; i < int.Parse(comboBox1.SelectedItem.ToString()); i++)
                {
                    output = Base_[random.Next(0, Base_.Length)];
                    int x = random.Next(0, 2);
                    if (x == 0)
                    {
                        output += Base2_[random.Next(0, Base2_.Length)];
                        int y = random.Next(0, 1);
                        if (y == 0)
                        {
                            output += End_[random.Next(0, End_.Length)];
                            listBox4.Items.Add(output);
                        }
                        else
                        {
                            listBox4.Items.Add(output);
                            break;
                        }
                    }
                    else if (x == 1)
                    {
                        output += End_[random.Next(0, End_.Length)];
                        listBox4.Items.Add(output);
                    }
                    else
                    {
                        listBox4.Items.Add(output);
                        break;
                    }
                }
            }
            catch (IndexOutOfRangeException)
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add(textBox1.Text);
            textBox1.Text = "";
            Preview();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox2.Items.Add(textBox2.Text);
            textBox2.Text = "";
            Preview();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox3.Items.Add(textBox3.Text);
            textBox3.Text = "";
            Preview();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Preview();
        }

        public int Style { get; set; }
        private void NewNameGeneratorMenu_Load(object sender, EventArgs e)
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
