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
    public partial class NewCategoryMenu : Form
    {
        public NewCategoryMenu()
        {
            InitializeComponent();
            button1.DialogResult = DialogResult.OK;
        }
        public string Name_ => textBox1.Text;
        public string Unlock => textBox2.Text;
        public string Popularity => textBox3.Text;
        public string Retention => textBox6.Text;
        public string TimeScale => textBox5.Text;
        public string Iterative => textBox4.Text;
        public string Description => textBox7.Text;

        public string Style { get; set; }
        private void NewCategoryMenu_Load(object sender, EventArgs e)
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
