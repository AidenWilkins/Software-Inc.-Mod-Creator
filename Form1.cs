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
using System.Xml;
using SoftwareIncSoftwareCreator.LIB;

namespace SoftwareIncSoftwareCreator
{
    public partial class Form1 : Form
    {
        SoftwareType SoftwareType;

        public Form1()
        {
            InitializeComponent();

            //XmlWriter xmlWriter = XmlWriter.Create("test.xml");

            //xmlWriter.WriteStartDocument();
            //xmlWriter.WriteStartElement("users");

            //xmlWriter.WriteStartElement("user");
            //xmlWriter.WriteAttributeString("age", "42");
            //xmlWriter.WriteString("John Doe");
            //xmlWriter.WriteEndElement();

            //xmlWriter.WriteStartElement("user");
            //xmlWriter.WriteAttributeString("age", "39");
            //xmlWriter.WriteString("Jane Doe");

            //xmlWriter.WriteEndDocument();
            //xmlWriter.Close();
        }

        private void newModToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using(NewModMenu m = new NewModMenu())
            {
                if(m.ShowDialog() == DialogResult.OK)
                {
                    SoftwareType = new SoftwareType(m.Name_, m.Unlock, m.Category, m.Description, m.Random, m.Popularity, m.Retention, m.Iterative, m.TimeScale, m.OSLimit,
                        m.NameGenerator, m.IdealPrice, m.OSSpecific, m.OneClient, m.InHouse, new List<Categories>(), new List<Features>());
                    label23.Text = "Mod Creator: Mod " + m.Name_ + " Created Successfully";
                    listBox3.Items.Add("Mod Creator: Mod " + m.Name_ + " Created Successfully");
                }
                else
                {
                    label23.Text = "Mod Creator: Mod Creation Failed";
                    listBox3.Items.Add("Mod Creator: Mod Creation Failed");
                    return;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SoftwareType.Categories.Add(new Categories(textBox3.Text, textBox6.Text, textBox4.Text, textBox5.Text, textBox7.Text, textBox1.Text, textBox2.Text));
            listBox1.Items.Add(textBox1.Text);
            label23.Text = "Mod Creator: Category " + textBox1.Text + " Created Successfully";
            listBox3.Items.Add("Mod Creator: Category " + textBox1.Text + " Created Successfully");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SoftwareType.Features.Add(new Features(textBox11.Text, checkBox1.Checked, checkBox2.Checked, textBox19.Text, textBox13.Text, textBox14.Text, textBox12.Text, comboBox1.SelectedItem.ToString(), textBox10.Text,
                textBox9.Text, textBox8.Text, textBox15.Text, textBox16.Text, textBox17.Text, textBox18.Text, null));
            listBox2.Items.Add(textBox14.Text);
            label23.Text = "Mod Creator: Feature " + textBox13.Text + " Created Successfully";
            listBox3.Items.Add("Mod Creator: Feature " + textBox13.Text + " Created Successfully");
        }

        private void saveExportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(SoftwareType == null)
            {
                label23.Text = "Mod Creator: Please Create A New Mod First";
                listBox3.Items.Add("Mod Creator: Please Create A New Mod First");
                return;
            }
            label23.Text = "Mod Creator: Exporting Mod";
            listBox3.Items.Add("Mod Creator: Exporting Mod");
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.IndentChars = "     ";
            settings.NewLineOnAttributes = false;
            settings.OmitXmlDeclaration = true;
            XmlWriter writer = XmlWriter.Create("mod.xml", settings);

            writer.WriteStartDocument();
            #region SoftwareType
            writer.WriteStartElement("SoftwareType");
            //Name
            if (SoftwareType.Name != "n/a")
            {
                writer.WriteStartElement("Name");
                writer.WriteString(SoftwareType.Name);
                writer.WriteEndElement();
            }
            //Unlock
            if (SoftwareType.Unlock != "n/a") { 
                writer.WriteStartElement("Unlock");
                writer.WriteString(SoftwareType.Unlock);
                writer.WriteEndElement();
            }
            //Category
            if (SoftwareType.Category != "n/a")
            {
                writer.WriteStartElement("Category");
                writer.WriteString(SoftwareType.Category);
                writer.WriteEndElement();
            }
            //Desc.
            if (SoftwareType.Description != "n/a")
            {
                writer.WriteStartElement("Description");
                writer.WriteString(SoftwareType.Description);
                writer.WriteEndElement();
            }
            //Random
            if (SoftwareType.Random != "n/a")
            {
                writer.WriteStartElement("Random");
                writer.WriteString(SoftwareType.Random);
                writer.WriteEndElement();
            }
            //OSSpecific
            writer.WriteStartElement("OSSpecific");
            writer.WriteString(SoftwareType.OSSpecific.ToString());
            writer.WriteEndElement();
            //OneClient
            writer.WriteStartElement("OneClient");
            writer.WriteString(SoftwareType.OneClient.ToString());
            writer.WriteEndElement();
            //InHouse
            writer.WriteStartElement("InHouse");
            writer.WriteString(SoftwareType.InHouse.ToString());
            writer.WriteEndElement();
            //IdealPrice
            if (SoftwareType.IdealPrice != "n/a")
            {
                writer.WriteStartElement("IdealPrice");
                writer.WriteString(SoftwareType.IdealPrice);
                writer.WriteEndElement();
            }
            //NameGenerator
            if (SoftwareType.NameGenerator != "n/a")
            {
                writer.WriteStartElement("NameGenerator");
                writer.WriteString(SoftwareType.NameGenerator);
                writer.WriteEndElement();
            }
            //OSLimit
            if (SoftwareType.OSLimit != "n/a")
            {
                Debug.WriteLine("x" + SoftwareType.OSLimit + "x");
                writer.WriteStartElement("OSLimit");
                writer.WriteString(SoftwareType.OSLimit);
                writer.WriteEndElement();
            }
            //TimeScale
            if (SoftwareType.TimeScale != "n/a")
            {
                writer.WriteStartElement("TimeScale");
                writer.WriteString(SoftwareType.TimeScale);
                writer.WriteEndElement();
            }
            //Iterative
            if (SoftwareType.Iterative != "n/a")
            {
                writer.WriteStartElement("Iterative");
                writer.WriteString(SoftwareType.Iterative);
                writer.WriteEndElement();
            }
            //Retention
            if (SoftwareType.Retention != "n/a")
            {
                writer.WriteStartElement("Retention");
                writer.WriteString(SoftwareType.Retention);
                writer.WriteEndElement();
            }
            //Popularity
            if (SoftwareType.Popularity != "n/a")
            {
                writer.WriteStartElement("Popularity");
                writer.WriteString(SoftwareType.Popularity);
                writer.WriteEndElement();
            }
            #endregion
            #region Category
            if (SoftwareType.Categories.Count != 0)
            {
                writer.WriteStartElement("Categories");
                foreach (Categories categories in SoftwareType.Categories)
                {
                    //Name/StartTag
                    writer.WriteStartElement("Category");
                    writer.WriteAttributeString("Name", categories.Name);

                    //Popularity
                    writer.WriteStartElement("Popularity");
                    writer.WriteString(categories.Popularity);
                    writer.WriteEndElement();
                    //Retention
                    writer.WriteStartElement("Retention");
                    writer.WriteString(categories.Retention);
                    writer.WriteEndElement();
                    //Iterative
                    writer.WriteStartElement("Iterative");
                    writer.WriteString(categories.Iterative);
                    writer.WriteEndElement();
                    //TimeScale
                    writer.WriteStartElement("TimeScale");
                    writer.WriteString(categories.TimeScale);
                    writer.WriteEndElement();
                    //Desc.
                    writer.WriteStartElement("Description");
                    writer.WriteString(categories.Description);
                    writer.WriteEndElement();
                    //Unlock
                    writer.WriteStartElement("Unlock");
                    writer.WriteString(categories.Unlock);
                    writer.WriteEndElement();

                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
            }
            #endregion
            #region Features
            writer.WriteStartElement("Features");

            foreach (Features features in SoftwareType.Features)
            {
                writer.WriteStartElement("Feature");
                //From
                if(features.From != "n/a")
                {
                    writer.WriteAttributeString("From", features.From);
                }
                //Research
                if(features.Research != "n/a")
                {
                    writer.WriteAttributeString("Research", features.Research);
                }
                writer.WriteAttributeString("Vital", features.Vital.ToString());
                writer.WriteAttributeString("Forced", features.Forced.ToString());

                //Name
                writer.WriteStartElement("Name");
                writer.WriteString(features.Name);
                writer.WriteEndElement();
                //Unlock
                writer.WriteStartElement("Unlock");
                writer.WriteString(features.Unlock);
                writer.WriteEndElement();
                //Category
                writer.WriteStartElement("Category");
                writer.WriteString(features.Category);
                writer.WriteEndElement();
                //Desc.
                writer.WriteStartElement("Description");
                writer.WriteString(features.Description);
                writer.WriteEndElement();
                //DevTime
                writer.WriteStartElement("DevTime");
                writer.WriteString(features.DevTime);
                writer.WriteEndElement();
                //Innovation
                writer.WriteStartElement("Innovation");
                writer.WriteString(features.Innovation);
                writer.WriteEndElement();
                //Usability
                writer.WriteStartElement("Usability");
                writer.WriteString(features.Usability);
                writer.WriteEndElement();
                //Stability
                writer.WriteStartElement("Stability");
                writer.WriteString(features.Sability);
                writer.WriteEndElement();
                //CodeArt
                if (features.CodeArt != "n/a")
                {
                    writer.WriteStartElement("CodeArt");
                    writer.WriteString(features.CodeArt);
                    writer.WriteEndElement();
                }
                //Server
                if (features.Server != "n/a")
                {
                    writer.WriteStartElement("Server");
                    writer.WriteString(features.Server);
                    writer.WriteEndElement();
                }
                //ArtCategory
                if (features.ArtCategory != "n/a")
                {
                    writer.WriteStartElement("ArtCategory");
                    writer.WriteString(features.ArtCategory);
                    writer.WriteEndElement();
                }

                writer.WriteEndElement();
            }

            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Close();
            #endregion
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            textBox11.Enabled = checkBox4.Checked;
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            textBox19.Enabled = checkBox3.Checked;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SoftwareType.Categories.RemoveAt(listBox1.SelectedIndex);
            listBox1.Items.RemoveAt(listBox1.SelectedIndex);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SoftwareType.Features.RemoveAt(listBox2.SelectedIndex);
            listBox2.Items.RemoveAt(listBox2.SelectedIndex);
        }

        private void applySettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
            int index = e.Index >= 0 ? e.Index : 0;
            var brush = new SolidBrush(Color.FromArgb(51, 51, 55));
            e.DrawBackground();
            e.Graphics.DrawString(comboBox1.Items[index].ToString(), e.Font, brush, e.Bounds, StringFormat.GenericDefault);
            e.DrawFocusRectangle();
        }

        private void toolStripComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            label23.Text = "Mod Creator: Setting Theme";
            listBox3.Items.Add("Mod Creator: Setting Theme");
            if (toolStripComboBox2.SelectedIndex == 0)
            {
                BackColor = Color.WhiteSmoke;
                BackgroundImage = null;
                label23.Text = "Mod Creator: Set Theme To Light";
                listBox3.Items.Add("Mod Creator: Set Theme To Light");
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
                        Button cb = (Button)child; ;
                        cb.FlatAppearance.BorderSize = 0;
                        cb.ForeColor = Color.Gray;
                        cb.BackColor = Color.White;
                    }

                    if (child is MenuStrip)
                    {
                        MenuStrip cb = (MenuStrip)child;
                        cb.ForeColor = Color.Gray;
                        cb.BackColor = Color.White;

                        foreach (ToolStripMenuItem firstLayer in cb.Items)
                        {
                            firstLayer.ForeColor = Color.Gray;
                            firstLayer.BackColor = Color.White;
                            foreach (ToolStripMenuItem secondLayer in firstLayer.DropDownItems)
                            {
                                secondLayer.ForeColor = Color.Gray;
                                secondLayer.BackColor = Color.White;
                                foreach (ToolStripComboBox thridLayer in secondLayer.DropDownItems)
                                {
                                    thridLayer.ForeColor = Color.Gray;
                                    thridLayer.BackColor = Color.White;
                                }
                            }
                        }

                        //TODO finish menu stip coloring
                        //https://www.dreamincode.net/forums/topic/143834-menu-strip-background-color/ For Help
                    }
                }
            }
            else if (toolStripComboBox2.SelectedIndex == 1)
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
                        cb.FlatAppearance.BorderSize = 0;
                        cb.ForeColor = Color.FromArgb(35, 123, 158);
                        cb.BackColor = Color.FromArgb(51, 51, 55);
                    }

                    if (child is MenuStrip)
                    {
                        MenuStrip cb = (MenuStrip)child;
                        cb.ForeColor = Color.FromArgb(35, 123, 158);
                        cb.BackColor = Color.FromArgb(38, 38, 43);

                        foreach (ToolStripMenuItem firstLayer in cb.Items)
                        {
                            firstLayer.ForeColor = Color.FromArgb(35, 123, 158);
                            firstLayer.BackColor = Color.FromArgb(38, 38, 43);
                            foreach (ToolStripMenuItem secondLayer in firstLayer.DropDownItems)
                            {
                                secondLayer.ForeColor = Color.FromArgb(35, 123, 158);
                                secondLayer.BackColor = Color.FromArgb(38, 38, 43);
                                foreach (ToolStripComboBox thridLayer in secondLayer.DropDownItems)
                                {
                                    thridLayer.ForeColor = Color.FromArgb(35, 123, 158);
                                    thridLayer.BackColor = Color.FromArgb(38, 38, 43);
                                }
                            }
                        }
                        //TODO finish menu stip coloring
                        //https://www.dreamincode.net/forums/topic/143834-menu-strip-background-color/ For Help
                    }
                }
                label23.Text = "Mod Creator: Set Theme To Dark";
                listBox3.Items.Add("Mod Creator: Set Theme To Dark");
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
                        Button cb = (Button)child; ;
                        cb.FlatAppearance.BorderSize = 0;
                        cb.ForeColor = Color.FromArgb(158, 41, 43);
                        cb.BackColor = Color.FromArgb(58, 26, 37);
                    }

                    if (child is MenuStrip)
                    {
                        MenuStrip cb = (MenuStrip)child;
                        cb.ForeColor = Color.FromArgb(158, 41, 43);
                        cb.BackColor = Color.FromArgb(87, 81, 65);

                        foreach(ToolStripMenuItem firstLayer in cb.Items)
                        {
                            firstLayer.ForeColor = Color.FromArgb(158, 41, 43);
                            firstLayer.BackColor = Color.FromArgb(87, 81, 65);
                            foreach (ToolStripMenuItem secondLayer in firstLayer.DropDownItems)
                            {
                                secondLayer.ForeColor = Color.FromArgb(158, 41, 43);
                                secondLayer.BackColor = Color.FromArgb(87, 81, 65);
                                foreach (ToolStripComboBox thridLayer in secondLayer.DropDownItems)
                                {
                                    thridLayer.ForeColor = Color.FromArgb(158, 41, 43);
                                    thridLayer.BackColor = Color.FromArgb(87, 81, 65);
                                }
                            }
                        }

                        //TODO finish menu stip coloring
                        //https://www.dreamincode.net/forums/topic/143834-menu-strip-background-color/ For Help
                    }
                }
                label23.Text = "Mod Creator: Set Theme To Software Inc. Fall";
                listBox3.Items.Add("Mod Creator: Set Theme To Software Inc. Fall");
            }
        }
    }
}
