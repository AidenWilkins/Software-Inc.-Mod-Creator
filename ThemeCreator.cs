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
    public partial class ThemeCreator : Form
    {
        public ThemeCreator()
        {
            InitializeComponent();
            button9.DialogResult = DialogResult.OK;
            button10.DialogResult = DialogResult.Cancel;
        }
        #region buttons
        private void button1_Click(object sender, EventArgs e)
        {
            using(ColorPicker colorPicker = new ColorPicker())
            {
                if(colorPicker.ShowDialog() == DialogResult.OK)
                {
                    label1.ForeColor = Color.FromArgb(colorPicker.R, colorPicker.G, colorPicker.B);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (ColorPicker colorPicker = new ColorPicker())
            {
                if (colorPicker.ShowDialog() == DialogResult.OK)
                {
                    label2.ForeColor = Color.FromArgb(colorPicker.R, colorPicker.G, colorPicker.B);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (ColorPicker colorPicker = new ColorPicker())
            {
                if (colorPicker.ShowDialog() == DialogResult.OK)
                {
                    label3.ForeColor = Color.FromArgb(colorPicker.R, colorPicker.G, colorPicker.B);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (ColorPicker colorPicker = new ColorPicker())
            {
                if (colorPicker.ShowDialog() == DialogResult.OK)
                {
                    label4.ForeColor = Color.FromArgb(colorPicker.R, colorPicker.G, colorPicker.B);
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            using (ColorPicker colorPicker = new ColorPicker())
            {
                if (colorPicker.ShowDialog() == DialogResult.OK)
                {
                    label8.ForeColor = Color.FromArgb(colorPicker.R, colorPicker.G, colorPicker.B);
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            using (ColorPicker colorPicker = new ColorPicker())
            {
                if (colorPicker.ShowDialog() == DialogResult.OK)
                {
                    label7.ForeColor = Color.FromArgb(colorPicker.R, colorPicker.G, colorPicker.B);
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            using (ColorPicker colorPicker = new ColorPicker())
            {
                if (colorPicker.ShowDialog() == DialogResult.OK)
                {
                    label6.ForeColor = Color.FromArgb(colorPicker.R, colorPicker.G, colorPicker.B);
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            using (ColorPicker colorPicker = new ColorPicker())
            {
                if (colorPicker.ShowDialog() == DialogResult.OK)
                {
                    label5.ForeColor = Color.FromArgb(colorPicker.R, colorPicker.G, colorPicker.B);
                }
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            using (ColorPicker colorPicker = new ColorPicker())
            {
                if (colorPicker.ShowDialog() == DialogResult.OK)
                {
                    label1.BackColor = Color.FromArgb(colorPicker.R, colorPicker.G, colorPicker.B);
                }
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            using (ColorPicker colorPicker = new ColorPicker())
            {
                if (colorPicker.ShowDialog() == DialogResult.OK)
                {
                    label2.BackColor = Color.FromArgb(colorPicker.R, colorPicker.G, colorPicker.B);
                }
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            using (ColorPicker colorPicker = new ColorPicker())
            {
                if (colorPicker.ShowDialog() == DialogResult.OK)
                {
                    label3.BackColor = Color.FromArgb(colorPicker.R, colorPicker.G, colorPicker.B);
                }
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            using (ColorPicker colorPicker = new ColorPicker())
            {
                if (colorPicker.ShowDialog() == DialogResult.OK)
                {
                    label4.BackColor = Color.FromArgb(colorPicker.R, colorPicker.G, colorPicker.B);
                }
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            using (ColorPicker colorPicker = new ColorPicker())
            {
                if (colorPicker.ShowDialog() == DialogResult.OK)
                {
                    label5.BackColor = Color.FromArgb(colorPicker.R, colorPicker.G, colorPicker.B);
                }
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            using (ColorPicker colorPicker = new ColorPicker())
            {
                if (colorPicker.ShowDialog() == DialogResult.OK)
                {
                    label7.BackColor = Color.FromArgb(colorPicker.R, colorPicker.G, colorPicker.B);
                }
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            using (ColorPicker colorPicker = new ColorPicker())
            {
                if (colorPicker.ShowDialog() == DialogResult.OK)
                {
                    label6.BackColor = Color.FromArgb(colorPicker.R, colorPicker.G, colorPicker.B);
                }
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            using (ColorPicker colorPicker = new ColorPicker())
            {
                if (colorPicker.ShowDialog() == DialogResult.OK)
                {
                    label8.BackColor = Color.FromArgb(colorPicker.R, colorPicker.G, colorPicker.B);
                }
            }
        }
        #endregion
        private void button9_Click(object sender, EventArgs e)
        {
            //Create File name
            string[] nameParts = textBox1.Text.Split(' ');
            string nameFinale = "";
            foreach (string part in nameParts)
            {
                nameFinale += part[0].ToString().ToUpper();
                nameFinale += part.Remove(0, 1);
            }


            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.IndentChars = "     ";
            settings.NewLineOnAttributes = false;
            settings.OmitXmlDeclaration = true;
            XmlWriter xmlWriter = XmlWriter.Create("Themes//" + nameFinale + ".xml", settings);
            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("Theme");

            //Name
            xmlWriter.WriteStartElement("DisplayName");
            xmlWriter.WriteString(textBox1.Text);
            xmlWriter.WriteEndElement();
            //Window Colors
            xmlWriter.WriteStartElement("WindowColors");
            xmlWriter.WriteAttributeString("ForeColor",  label1.ForeColor.ToArgb().ToString());
            xmlWriter.WriteAttributeString("BackColor", label1.BackColor.ToArgb().ToString());
            xmlWriter.WriteEndElement();
            //List Box Colors
            xmlWriter.WriteStartElement("ListBoxColors");
            xmlWriter.WriteAttributeString("ForeColor", label2.ForeColor.ToArgb().ToString());
            xmlWriter.WriteAttributeString("BackColor", label2.BackColor.ToArgb().ToString());
            xmlWriter.WriteEndElement();
            //Text Box Color
            xmlWriter.WriteStartElement("TextBoxColors");
            xmlWriter.WriteAttributeString("ForeColor", label3.ForeColor.ToArgb().ToString());
            xmlWriter.WriteAttributeString("BackColor", label3.BackColor.ToArgb().ToString());
            xmlWriter.WriteEndElement();
            //Label Colors
            xmlWriter.WriteStartElement("LabelColors");
            xmlWriter.WriteAttributeString("ForeColor", label4.ForeColor.ToArgb().ToString());
            xmlWriter.WriteAttributeString("BackColor", label4.BackColor.ToArgb().ToString());
            xmlWriter.WriteEndElement();
            //Check Box Colors
            xmlWriter.WriteStartElement("CheckBoxColors");
            xmlWriter.WriteAttributeString("ForeColor", label5.ForeColor.ToArgb().ToString());
            xmlWriter.WriteAttributeString("BackColor", label5.BackColor.ToArgb().ToString());
            xmlWriter.WriteEndElement();
            //Combo Box Colors
            xmlWriter.WriteStartElement("ComboBoxColors");
            xmlWriter.WriteAttributeString("ForeColor", label6.ForeColor.ToArgb().ToString());
            xmlWriter.WriteAttributeString("BackColor", label6.BackColor.ToArgb().ToString());
            xmlWriter.WriteEndElement();
            //Button Colors
            xmlWriter.WriteStartElement("ButtonColors");
            xmlWriter.WriteAttributeString("ForeColor", label7.ForeColor.ToArgb().ToString());
            xmlWriter.WriteAttributeString("BackColor", label7.BackColor.ToArgb().ToString());
            xmlWriter.WriteEndElement();
            //Menu Stip Colors
            xmlWriter.WriteStartElement("MenuStripColors");
            xmlWriter.WriteAttributeString("ForeColor", label8.ForeColor.ToArgb().ToString());
            xmlWriter.WriteAttributeString("BackColor", label8.BackColor.ToArgb().ToString());
            xmlWriter.WriteEndElement();

            xmlWriter.WriteEndDocument();
            xmlWriter.Close();

            
        }

        //XmlWriter xmlWriter = XmlWriter.Create("test.xml");

        //xmlWriter.WriteStartDocument();
        //xmlWriter.WriteStartElement("users");

        //xmlWriter.WriteStartElement("user");
        //xmlWriter.WriteAttributeString("age", "42");
        //xmlWriter.WriteEndElement();

        //xmlWriter.WriteStartElement("user");
        //xmlWriter.WriteAttributeString("age", "39");
        //xmlWriter.WriteString("Jane Doe");

        //xmlWriter.WriteEndDocument();
        //xmlWriter.Close();
    }
}
