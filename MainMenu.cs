using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using SoftwareIncSoftwareCreator.LIB;

namespace SoftwareIncSoftwareCreator
{
    public partial class MainMenu : Form
    {
        List<SoftwareType> SoftwareTypes;
        string currModName = "";

        public MainMenu()
        {
            InitializeComponent();
            SoftwareTypes = new List<SoftwareType>();

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
            //SISCFileType.Read();
        }

        int currStyle = 0;


        private void newModToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (NewModMenu m = new NewModMenu())
            {
                m.Style = currStyle;
                if (m.ShowDialog() == DialogResult.OK)
                {
                    Text = "Software Inc. Mod Creator (Alpha): " + m.ModName;
                    currModName = m.ModName;
                    label23.Text = "Mod Creator: Mod " + m.ModName + " Created Successfully";
                    listBox3.Items.Add("Mod Creator: Mod " + m.ModName + " Created Successfully");
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
            using (NewCategoryMenu ncm = new NewCategoryMenu())
            {
                ncm.BackColor = BackColor;
                if (ncm.ShowDialog() == DialogResult.OK)
                {
                    SoftwareTypes[listBox4.SelectedIndex].Categories.Add(new Categories(ncm.Popularity, ncm.Retention, ncm.Iterative, ncm.TimeScale, ncm.Description, ncm.Name_, ncm.Unlock));
                    listBox1.Items.Add(ncm.Name_);
                    label23.Text = "Mod Creator: Category " + ncm.Name_ + " Created Successfully";
                    listBox3.Items.Add("Mod Creator: Category " + ncm.Name_ + " Created Successfully");
                }
                else
                {
                    label23.Text = "Mod Creator: Category Creation Failed";
                    listBox3.Items.Add("Mod Creator: Category Creation Failed");
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using(NewFeatureMenu nfm = new NewFeatureMenu())
            {
                nfm.BackColor = BackColor;
                if (nfm.ShowDialog() == DialogResult.OK)
                {
                    SoftwareTypes[listBox4.SelectedIndex].Features.Add(new Features(nfm.From, nfm.Forced, nfm.Vital, nfm.Research, nfm.Description, nfm.Name_, nfm.Category, nfm.ArtCategory, 
                        nfm.Unlock, nfm.DevTime, nfm.Innovation, nfm.Usability, nfm.Stability, nfm.CodeArt, nfm.Server, null));
                    listBox2.Items.Add(nfm.Name_);
                    label23.Text = "Mod Creator: Feature " + nfm.Name_ + " Created Successfully";
                    listBox3.Items.Add("Mod Creator: Feature " + nfm.Name_ + " Created Successfully");
                }
                else
                {
                    label23.Text = "Mod Creator: Feature Creation Failed";
                    listBox3.Items.Add("Mod Creator: Feature Creation Failed");
                }
            }
        }

        private void saveExportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(SoftwareTypes == null)
            {
                label23.Text = "Mod Creator: Please Create A New Mod First";
                listBox3.Items.Add("Mod Creator: Please Create A New Mod First");
                return;
            }
            label23.Text = "Mod Creator: Creating Mod Folder " + currModName;
            listBox3.Items.Add("Mod Creator: Creating Mod Folder " + currModName);

            string ModFolder = currModName.Replace(' ', '-');
            string SoftwareTypesFolder = ModFolder + "//SoftwareTypes//";
            string NameGeneratorsFolder = ModFolder + "//NameGenerators//";
            string CompanyTypes = ModFolder + "//CompanyTypes//";

            if (!Directory.Exists(ModFolder))
            {
                Directory.CreateDirectory(ModFolder);
            }
            if (!Directory.Exists(SoftwareTypesFolder))
            {
                Directory.CreateDirectory(SoftwareTypesFolder);
            }
            if (!Directory.Exists(NameGeneratorsFolder))
            {
                Directory.CreateDirectory(NameGeneratorsFolder);
            }
            if (!Directory.Exists(CompanyTypes))
            {
                Directory.CreateDirectory(CompanyTypes);
            }


            label23.Text = "Mod Creator: Exporting Mod " + currModName;
            listBox3.Items.Add("Mod Creator: Exporting Mod " + currModName);

            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.IndentChars = "     ";
            settings.NewLineOnAttributes = false;
            settings.OmitXmlDeclaration = true;

            foreach (SoftwareType softwareType in SoftwareTypes)
            {
                XmlWriter writer = XmlWriter.Create(SoftwareTypesFolder + "//" + softwareType.Name + ".xml", settings);
                writer.WriteStartDocument();
                label23.Text = "Mod Creator: Exporting Softwaretype " + softwareType.Name;
                listBox3.Items.Add("Mod Creator: Exporting Softwaretype " + softwareType.Name);
                #region SoftwareType
                writer.WriteStartElement("SoftwareType");
                //Name
                if (softwareType.Name != "n/a")
                {
                    writer.WriteStartElement("Name");
                    writer.WriteString(softwareType.Name);
                    writer.WriteEndElement();
                }
                //Unlock
                if (softwareType.Unlock != "n/a")
                {
                    writer.WriteStartElement("Unlock");
                    writer.WriteString(softwareType.Unlock);
                    writer.WriteEndElement();
                }
                //Category
                if (softwareType.Category != "n/a")
                {
                    writer.WriteStartElement("Category");
                    writer.WriteString(softwareType.Category);
                    writer.WriteEndElement();
                }
                //Desc.
                if (softwareType.Description != "n/a")
                {
                    writer.WriteStartElement("Description");
                    writer.WriteString(softwareType.Description);
                    writer.WriteEndElement();
                }
                //Random
                if (softwareType.Random != "n/a")
                {
                    writer.WriteStartElement("Random");
                    writer.WriteString(softwareType.Random);
                    writer.WriteEndElement();
                }
                //OSSpecific
                writer.WriteStartElement("OSSpecific");
                writer.WriteString(softwareType.OSSpecific.ToString());
                writer.WriteEndElement();
                //OneClient
                writer.WriteStartElement("OneClient");
                writer.WriteString(softwareType.OneClient.ToString());
                writer.WriteEndElement();
                //InHouse
                writer.WriteStartElement("InHouse");
                writer.WriteString(softwareType.InHouse.ToString());
                writer.WriteEndElement();
                //IdealPrice
                if (softwareType.IdealPrice != "n/a")
                {
                    writer.WriteStartElement("IdealPrice");
                    writer.WriteString(softwareType.IdealPrice);
                    writer.WriteEndElement();
                }
                //NameGenerator
                if (softwareType.NameGenerator != "n/a")
                {
                    writer.WriteStartElement("NameGenerator");
                    writer.WriteString(softwareType.NameGenerator);
                    writer.WriteEndElement();
                }
                //OSLimit
                if (softwareType.OSLimit != "n/a")
                {
                    Debug.WriteLine("x" + softwareType.OSLimit + "x");
                    writer.WriteStartElement("OSLimit");
                    writer.WriteString(softwareType.OSLimit);
                    writer.WriteEndElement();
                }
                //TimeScale
                if (softwareType.TimeScale != "n/a")
                {
                    writer.WriteStartElement("TimeScale");
                    writer.WriteString(softwareType.TimeScale);
                    writer.WriteEndElement();
                }
                //Iterative
                if (softwareType.Iterative != "n/a")
                {
                    writer.WriteStartElement("Iterative");
                    writer.WriteString(softwareType.Iterative);
                    writer.WriteEndElement();
                }
                //Retention
                if (softwareType.Retention != "n/a")
                {
                    writer.WriteStartElement("Retention");
                    writer.WriteString(softwareType.Retention);
                    writer.WriteEndElement();
                }
                //Popularity
                if (softwareType.Popularity != "n/a")
                {
                    writer.WriteStartElement("Popularity");
                    writer.WriteString(softwareType.Popularity);
                    writer.WriteEndElement();
                }
                #endregion
                #region Category
                if (softwareType.Categories.Count != 0)
                {
                    writer.WriteStartElement("Categories");
                    foreach (Categories categories in softwareType.Categories)
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

                foreach (Features features in softwareType.Features)
                {
                    writer.WriteStartElement("Feature");
                    //From
                    if (features.From != "n/a")
                    {
                        writer.WriteAttributeString("From", features.From);
                    }
                    //Research
                    if (features.Research != "n/a")
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
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SoftwareTypes[listBox4.SelectedIndex].Categories.RemoveAt(listBox1.SelectedIndex);
            listBox1.Items.RemoveAt(listBox1.SelectedIndex);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SoftwareTypes[listBox4.SelectedIndex].Features.RemoveAt(listBox2.SelectedIndex);
            listBox2.Items.RemoveAt(listBox2.SelectedIndex);
        }

        private void applySettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void toolStripComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            label23.Text = "Mod Creator: Setting Theme";
            listBox3.Items.Add("Mod Creator: Setting Theme");
            if (toolStripComboBox2.SelectedIndex == 0)
            {
                currStyle = 0;
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
                currStyle = 1;
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
                currStyle = 2;
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

        private void saveToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //SISCFileType.Write(SoftwareType);
        }

        private void loadToolStripMenuItem1_Click(object sender, EventArgs e)
        {           
            //SoftwareType = SISCFileType.Read();
            //foreach (Categories category in SoftwareType.Categories)
            //{
            //    listBox1.Items.Add(category.Name);
            //}
            //foreach (Features feature in SoftwareType.Features)
            //{
            //    listBox2.Items.Add(feature.Name);
            //}
            //label23.Text = "Mod Creator: Loaded Mod " + SoftwareType.Name;
            //listBox3.Items.Add("Mod Creator: Loaded Mod " + SoftwareType.Name);
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                label3.Text = "Category Info:";
                label4.Text = string.Format("Name: ({0}) Unlock Year: ({1})", SoftwareTypes[listBox4.SelectedIndex].Categories[listBox1.SelectedIndex].Name, SoftwareTypes[listBox4.SelectedIndex].Categories[listBox1.SelectedIndex].Unlock);
                label5.Text = string.Format("Description: ({0})", SoftwareTypes[listBox4.SelectedIndex].Categories[listBox1.SelectedIndex].Description);
                label6.Text = string.Format("Popularity: ({0}) Retention: ({1}) Iterative: ({2}) Time-Scale: ({3})", SoftwareTypes[listBox4.SelectedIndex].Categories[listBox1.SelectedIndex].Popularity,
                    SoftwareTypes[listBox4.SelectedIndex].Categories[listBox1.SelectedIndex].Retention, SoftwareTypes[listBox4.SelectedIndex].Categories[listBox1.SelectedIndex].Iterative,
                    SoftwareTypes[listBox4.SelectedIndex].Categories[listBox1.SelectedIndex].TimeScale);
                label8.Text = "";
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("This Item Is Missing");
            }
            catch (NullReferenceException nre)
            {
                MessageBox.Show("The Was A Error");
                MessageBox.Show("Error: " + nre);
            }
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                label3.Text = "Feature Info";
                label4.Text = string.Format("From: ({0}) Forced: ({1}) Vital: ({2}) Research: ({3})", SoftwareTypes[listBox4.SelectedIndex].Features[listBox2.SelectedIndex].From, SoftwareTypes[listBox4.SelectedIndex].Features[listBox2.SelectedIndex].Forced
                    , SoftwareTypes[listBox4.SelectedIndex].Features[listBox2.SelectedIndex].Vital, SoftwareTypes[listBox4.SelectedIndex].Features[listBox2.SelectedIndex].Research);
                label5.Text = string.Format("Description: ({0}) Category: ({1}) ArtCategory: ({2})", SoftwareTypes[listBox4.SelectedIndex].Features[listBox2.SelectedIndex].Description, SoftwareTypes[listBox4.SelectedIndex].Features[listBox2.SelectedIndex].Category,
                    SoftwareTypes[listBox4.SelectedIndex].Features[listBox2.SelectedIndex].ArtCategory);
                label6.Text = string.Format("Name: ({0}) Unlock: ({1}) Dev-Time: ({2}) Innovation: ({3})", SoftwareTypes[listBox4.SelectedIndex].Features[listBox2.SelectedIndex].Name, SoftwareTypes[listBox4.SelectedIndex].Features[listBox2.SelectedIndex].Unlock,
                    SoftwareTypes[listBox4.SelectedIndex].Features[listBox2.SelectedIndex].DevTime, SoftwareTypes[listBox4.SelectedIndex].Features[listBox2.SelectedIndex].Innovation);
                label8.Text = string.Format("Usabillity: ({0}) Stablity: ({1}) Code-Art: ({2}) Server: ({3})", SoftwareTypes[listBox4.SelectedIndex].Features[listBox2.SelectedIndex].Usability, SoftwareTypes[listBox4.SelectedIndex].Features[listBox2.SelectedIndex].Sability,
                    SoftwareTypes[listBox4.SelectedIndex].Features[listBox2.SelectedIndex].CodeArt, SoftwareTypes[listBox4.SelectedIndex].Features[listBox2.SelectedIndex].Server);
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("This Item Is Missing");
            }
            catch (NullReferenceException nre)
            {
                MessageBox.Show("The Was A Error");
                MessageBox.Show("Error: " + nre);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            using(NewSoftwareTypeMenu n = new NewSoftwareTypeMenu())
            {
                n.Style = currStyle;
                if(n.ShowDialog() == DialogResult.OK)
                {
                    SoftwareTypes.Add(new SoftwareType(n.Name_, n.Unlock, n.Category, n.Description, n.Random, n.Popularity, n.Retention, n.Iterative, n.TimeScale, n.OSLimit,
                        n.NameGenerator, n.IdealPrice, n.OSSpecific, n.OneClient, n.InHouse, new List<Categories>(), new List<Features>()));
                    listBox4.Items.Add(n.Name_);
                    listBox4.SelectedIndex = 0;
                }
            }
        }

        private void listBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();

            foreach (Categories category in SoftwareTypes[listBox4.SelectedIndex].Categories)
            {
                listBox1.Items.Add(category.Name);
            }
            foreach (Features feature in SoftwareTypes[listBox4.SelectedIndex].Features)
            {
                listBox2.Items.Add(feature.Name);
            }
        }
    }
}
