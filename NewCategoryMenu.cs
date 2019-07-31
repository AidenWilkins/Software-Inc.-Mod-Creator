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
    }
}
