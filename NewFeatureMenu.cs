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
    public partial class NewFeatureMenu : Form
    {
        public NewFeatureMenu()
        {
            InitializeComponent();
            button1.DialogResult = DialogResult.OK;
            button2.DialogResult = DialogResult.Cancel;
        }

        public string Name_ => textBox14.Text;
        public string Description => textBox13.Text;
        public string Category => textBox12.Text;
        public string ArtCategory => comboBox1.SelectedItem.ToString();
        public string Unlock => textBox10.Text;
        public string DevTime => textBox9.Text;
        public string Innovation => textBox8.Text;
        public string Usability => textBox15.Text;
        public string Stability => textBox16.Text;
        public string CodeArt => textBox17.Text;
        public string Server => textBox18.Text;
        public bool Forced => checkBox1.Checked;
        public bool Vital => checkBox2.Checked;
        public string Research => textBox19.Text;
        public string From => textBox11.Text;

        public string Style { get; set; }

        private void NewFeatureMenu_Load(object sender, EventArgs e)
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
