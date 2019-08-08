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
    public partial class Info : Form
    {
        public Info()
        {
            InitializeComponent();
        }

        int i = 0;

        private void Info_Click(object sender, EventArgs e)
        {
            i++;
            if(i >= 5)
            {
                TabTesting tabTesting = new TabTesting();
                tabTesting.Show();
            }
        }
    }
}
