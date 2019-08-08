using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SoftwareIncSoftwareCreator.LIB;
using System.Xml;

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
        public string NameGenerator => (comboBox2.SelectedItem == null) ? "n/a" : comboBox2.SelectedItem.ToString();
        public string IdealPrice => textBox10.Text;
        public bool OSSpecific => checkBox1.Checked;
        public bool OneClient => checkBox2.Checked;
        public bool InHouse => checkBox3.Checked;
        public List<NameGenerator> NameGens;

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

        private void comboBox1_Leave(object sender, EventArgs e)
        {
            if (comboBox1.SelectedText == "")
            {
                comboBox1.SelectedText = "n/a";
            }
        }
        #endregion

        public string Style { get; set; }
        private void NewSoftwareTypeMenu_Load(object sender, EventArgs e)
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
            foreach (NameGenerator i in NameGens)
            {
                comboBox2.Items.Add(i.Name);
            }
        }
    }
}
