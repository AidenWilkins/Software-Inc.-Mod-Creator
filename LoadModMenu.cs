using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace SoftwareIncSoftwareCreator
{
    public partial class LoadModMenu : Form
    {
        public LoadModMenu()
        {
            InitializeComponent();
            button1.DialogResult = DialogResult.OK;
            button3.DialogResult = DialogResult.Cancel;
            string[] modDir = Directory.GetDirectories("SaveData");
            foreach (string dir in modDir)
            {
                listBox1.Items.Add(new DirectoryInfo(dir).Name);
            }
        }

        public string ModName => listBox1.Items[listBox1.SelectedIndex].ToString();

        public int Style { get; set; }
        private void LoadModMenu_Load(object sender, EventArgs e)
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
