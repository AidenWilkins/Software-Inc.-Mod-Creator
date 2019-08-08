using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoftwareIncSoftwareCreator
{
    public partial class TabTesting : Form
    {
        public TabTesting()
        {
            InitializeComponent();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void TabTesting_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 5; i++)
            {
                Process process = new Process();
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                startInfo.FileName = "cmd.exe";
                startInfo.Arguments = "/C notepad.exe ";
                process.StartInfo = startInfo;
                process.Start();
            }
        }
    }
}
