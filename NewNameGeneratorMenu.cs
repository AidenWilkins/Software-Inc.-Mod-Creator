using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

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

        public string Style { get; set; }
        private void NewNameGeneratorMenu_Load(object sender, EventArgs e)
        {
            #region
            XmlReader reader = XmlReader.Create("Themes//" + Style + ".xml");
            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element)
                {
                    if (reader.Name == "WindowColors")
                    {
                        BackColor = Color.FromArgb(int.Parse(reader.GetAttribute("BackColor")));
                        ForeColor = Color.FromArgb(int.Parse(reader.GetAttribute("ForeColor")));
                    }
                    else if (reader.Name == "ListBoxColors")
                    {
                        foreach (Control listBox in this.Controls)
                        {
                            if (listBox is ListBox)
                            {
                                listBox.BackColor = Color.FromArgb(int.Parse(reader.GetAttribute("BackColor")));
                                listBox.ForeColor = Color.FromArgb(int.Parse(reader.GetAttribute("ForeColor")));
                            }
                        }
                    }
                    else if (reader.Name == "TextBoxColors")
                    {
                        foreach (Control textBox in this.Controls)
                        {
                            if (textBox is TextBox)
                            {
                                textBox.BackColor = Color.FromArgb(int.Parse(reader.GetAttribute("BackColor")));
                                textBox.ForeColor = Color.FromArgb(int.Parse(reader.GetAttribute("ForeColor")));
                            }
                        }
                    }
                    else if (reader.Name == "LabelColors")
                    {
                        foreach (Control label in this.Controls)
                        {
                            if (label is Label)
                            {
                                label.BackColor = Color.FromArgb(int.Parse(reader.GetAttribute("BackColor")));
                                label.ForeColor = Color.FromArgb(int.Parse(reader.GetAttribute("ForeColor")));
                            }
                        }
                    }
                    else if (reader.Name == "CheckBoxColors")
                    {
                        foreach (Control checkBox in this.Controls)
                        {
                            if (checkBox is CheckBox)
                            {
                                checkBox.BackColor = Color.FromArgb(int.Parse(reader.GetAttribute("BackColor")));
                                checkBox.ForeColor = Color.FromArgb(int.Parse(reader.GetAttribute("ForeColor")));
                            }
                        }
                    }
                    else if (reader.Name == "ComboBoxColors")
                    {
                        foreach (Control comboBox in this.Controls)
                        {
                            if (comboBox is ComboBox)
                            {
                                comboBox.BackColor = Color.FromArgb(int.Parse(reader.GetAttribute("BackColor")));
                                comboBox.ForeColor = Color.FromArgb(int.Parse(reader.GetAttribute("ForeColor")));
                            }
                        }
                    }
                    else if (reader.Name == "ButtonColors")
                    {
                        foreach (Control control in this.Controls)
                        {
                            if (control is Button)
                            {
                                Button button = (Button)control;
                                button.FlatAppearance.BorderSize = 0;
                                button.BackColor = Color.FromArgb(int.Parse(reader.GetAttribute("BackColor")));
                                button.ForeColor = Color.FromArgb(int.Parse(reader.GetAttribute("ForeColor")));
                            }
                        }
                    }
                    else if (reader.Name == "MenuStripColors")
                    {
                        foreach (Control control in this.Controls)
                        {
                            if (!(control is MenuStrip))
                            {
                                continue;
                            }

                            MenuStrip menustrip = (MenuStrip)control;
                            menustrip.BackColor = Color.FromArgb(int.Parse(reader.GetAttribute("BackColor")));
                            menustrip.ForeColor = Color.FromArgb(int.Parse(reader.GetAttribute("ForeColor")));
                            foreach (ToolStripMenuItem firstLayer in menustrip.Items)
                            {
                                firstLayer.ForeColor = Color.FromArgb(int.Parse(reader.GetAttribute("ForeColor")));
                                firstLayer.BackColor = Color.FromArgb(int.Parse(reader.GetAttribute("BackColor")));
                                foreach (ToolStripMenuItem secondLayer in firstLayer.DropDownItems)
                                {
                                    secondLayer.ForeColor = Color.FromArgb(int.Parse(reader.GetAttribute("ForeColor")));
                                    secondLayer.BackColor = Color.FromArgb(int.Parse(reader.GetAttribute("BackColor")));
                                    foreach (ToolStripComboBox thridLayer in secondLayer.DropDownItems)
                                    {
                                        thridLayer.ForeColor = Color.FromArgb(int.Parse(reader.GetAttribute("ForeColor")));
                                        thridLayer.BackColor = Color.FromArgb(int.Parse(reader.GetAttribute("BackColor")));
                                    }
                                }
                            }
                        }
                    }
                }
            }
            #endregion
        }
    }
}
