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
    }
}
