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
        List<NameGenerator> NameGenerators;
        string currModName = "";
        string gameModDir = "";

        public MainMenu()
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

            //XmlWriter settingsxml = XmlWriter.Create("settings.xml");
            //settingsxml.WriteStartDocument();
            //settingsxml.WriteStartElement("Settings");

            //settingsxml.WriteStartElement("Setting");
            //settingsxml.WriteAttributeString("name", "gameModDir");
            //settingsxml.WriteString(gameModDir);
            //settingsxml.WriteEndElement();

            //settingsxml.WriteStartElement("Settings");
            //settingsxml.WriteAttributeString("name", "style");
            //settingsxml.WriteString(currStyle.ToString());

            //settingsxml.WriteEndDocument();
            //settingsxml.Close();

            bool wati = LoadThemes();
            XmlReader xmlReader = XmlReader.Create("settings.xml");
            while (xmlReader.Read())
            {
                if ((xmlReader.NodeType == XmlNodeType.Element) && (xmlReader.Name == "Setting"))
                {
                    if (xmlReader.HasAttributes)
                    {
                        if (xmlReader.GetAttribute("name") == "gameModDir")
                        {
                            gameModDir = xmlReader.ReadInnerXml();
                        }
                        else if(xmlReader.GetAttribute("name") == "style")
                        {
                            currStyle = xmlReader.ReadInnerXml();
                            SetTheme(currStyle);
                        }
                    }
                }
            }
        }

        string currStyle = "";


        private void newModToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (NewModMenu m = new NewModMenu())
            {
                m.Style = displayNameToFile[currStyle];
                if (m.ShowDialog() == DialogResult.OK)
                {
                    SoftwareTypes = new List<SoftwareType>();
                    NameGenerators = new List<NameGenerator>();
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
                ncm.Style = displayNameToFile[currStyle];
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
                nfm.Style = displayNameToFile[currStyle];
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
            if(currModName == "")
            {
                label23.Text = "Mod Creator: Please Create A New Mod First";
                listBox3.Items.Add("Mod Creator: Please Create A New Mod First");
                return;
            }

            folderBrowserDialog1.ShowNewFolderButton = true;
            folderBrowserDialog1.Description = "Please choose a location to save your mod to";
            string path = "";
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                path = folderBrowserDialog1.SelectedPath;
                label23.Text = "Mod Creator: Mod Ouput to " + path;
                listBox3.Items.Add("Mod Creator: Mod Ouput to " + path);
            }
            else
            {
                return;
            }

            label23.Text = "Mod Creator: Creating Mod Folder " + currModName;
            listBox3.Items.Add("Mod Creator: Creating Mod Folder " + currModName);

            string ModFolder = gameModDir + "\\" + currModName.Replace(' ', '-');
            string SoftwareTypesFolder = ModFolder + "\\SoftwareTypes\\";
            string NameGeneratorsFolder = ModFolder + "\\NameGenerators\\";
            string CompanyTypes = ModFolder + "\\CompanyTypes\\";

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

            //Export NameGenerators
            foreach (NameGenerator nameGenerator in NameGenerators)
            {
                if (!nameGenerator.isFile)
                {
                    string outPutNameGenfile = "-start(base)\n-base(base2,end,stop)\n";
                    foreach (string Base in nameGenerator.Base)
                    {
                        outPutNameGenfile += Base + "\n";
                    }
                    outPutNameGenfile += "-base2\n";
                    foreach (string Base2 in nameGenerator.Base2)
                    {
                        outPutNameGenfile += Base2 + "\n";
                    }
                    outPutNameGenfile += "-end(stop)";
                    foreach (string End in nameGenerator.End)
                    {
                        outPutNameGenfile += End + "\n";
                    }
                    File.WriteAllText(NameGeneratorsFolder + nameGenerator.Name + ".txt", outPutNameGenfile);
                }
                else
                {
                    File.Copy(nameGenerator.Path, NameGeneratorsFolder);
                }
            }



            //Export SoftwareTypes
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.IndentChars = "     ";
            settings.NewLineOnAttributes = false;
            settings.OmitXmlDeclaration = true;

            foreach (SoftwareType softwareType in SoftwareTypes)
            {
                XmlWriter writer = XmlWriter.Create(SoftwareTypesFolder + "\\" + softwareType.Name + ".xml", settings);
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
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.IndentChars = "     ";
            settings.NewLineOnAttributes = false;
            settings.OmitXmlDeclaration = true;

            XmlWriter settingsxml = XmlWriter.Create("settings.xml", settings);
            settingsxml.WriteStartDocument();
            settingsxml.WriteStartElement("Settings");

            settingsxml.WriteStartElement("Setting");
            settingsxml.WriteAttributeString("name", "gameModDir");
            settingsxml.WriteString(gameModDir);
            settingsxml.WriteEndElement();

            settingsxml.WriteStartElement("Setting");
            settingsxml.WriteAttributeString("name", "style");
            settingsxml.WriteString(currStyle);

            settingsxml.WriteEndDocument();
            settingsxml.Close();
        }

        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        Dictionary<string, string> displayNameToFile = new Dictionary<string, string>();

        private void toolStripComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetTheme(toolStripComboBox2.Items[toolStripComboBox2.SelectedIndex].ToString());
        }

        private void SetTheme(string displayName)
        {
            label23.Text = "Mod Creator: Setting Theme";
            listBox3.Items.Add("Mod Creator: Setting Theme");

            currStyle = displayName;

            #region
            try
            {
                if (File.Exists("Themes//" + displayNameToFile[displayName] + ".xml"))
                {
                    XmlReader reader = XmlReader.Create("Themes//" + displayNameToFile[displayName] + ".xml");
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
                                            try
                                            {
                                                foreach (ToolStripComboBox thridLayer in secondLayer.DropDownItems)
                                                {
                                                    thridLayer.ForeColor = Color.FromArgb(int.Parse(reader.GetAttribute("ForeColor")));
                                                    thridLayer.BackColor = Color.FromArgb(int.Parse(reader.GetAttribute("BackColor")));
                                                }
                                            }
                                            catch (InvalidCastException)
                                            {

                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (KeyNotFoundException)
            {
                MessageBox.Show("Please restart to finish loading themes");
            }
            #endregion
        }

        private bool LoadThemes()
        {
            if (!File.Exists("Themes//Themes.xml"))
            {
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;
                settings.IndentChars = "     ";
                settings.NewLineOnAttributes = false;
                settings.OmitXmlDeclaration = true;

                string[] themes = Directory.GetFiles("Themes");

                XmlWriter themexml = XmlWriter.Create("Themes//Themes.xml", settings);
                themexml.WriteStartDocument();
                themexml.WriteStartElement("Themes");

                foreach (string theme in themes)
                {
                    string filename = new FileInfo("Themes//" + theme).Name;
                    Debug.WriteLine(filename);
                    if(filename == "Themes.xml")
                    {
                        continue;
                    }
                    XmlReader reader = XmlReader.Create(theme);
                    while (reader.Read())
                    {
                        if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "DisplayName"))
                        {
                            themexml.WriteStartElement("Theme");
                            themexml.WriteAttributeString("DisplayName", reader.ReadInnerXml());
                            displayNameToFile[reader.ReadInnerXml()] = filename.Remove(filename.Length - 4);
                            themexml.WriteAttributeString("FILE", filename.Remove(filename.Length - 4));
                            themexml.WriteEndElement();
                            break;
                        }
                    }
                }
                themexml.WriteEndDocument();
                themexml.Close();
            }
            else
            {
                XmlReader xmlReader = XmlReader.Create("Themes//Themes.xml");
                while (xmlReader.Read())
                {
                    if ((xmlReader.NodeType == XmlNodeType.Element) && (xmlReader.Name == "Theme"))
                    {
                        if (xmlReader.HasAttributes)
                        {
                            displayNameToFile[xmlReader.GetAttribute("DisplayName")] = xmlReader.GetAttribute("FILE");
                        }
                    }
                }
            }

            toolStripComboBox2.Items.Clear();
            foreach (KeyValuePair<string, string> entry in displayNameToFile)
            {
                // do something with entry.Value or entry.Key
                Debug.WriteLine(entry.Value + " = " + entry.Key);
                toolStripComboBox2.Items.Add(entry.Key);
            }
            return true;
        }

        private void saveToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SISCFileType.Write(SoftwareTypes, currModName);
            foreach (NameGenerator nameGenerator in NameGenerators)
            {
                if (!nameGenerator.isFile)
                {
                    string outPutNameGenfile = "-start(base)\n-base(base2,end,stop)\n";
                    foreach (string Base in nameGenerator.Base)
                    {
                        outPutNameGenfile += Base + "\n";
                    }
                    outPutNameGenfile += "-base2\n";
                    foreach (string Base2 in nameGenerator.Base2)
                    {
                        outPutNameGenfile += Base2 + "\n";
                    }
                    outPutNameGenfile += "-end(stop)";
                    foreach (string End in nameGenerator.End)
                    {
                        outPutNameGenfile += End + "\n";
                    }
                    File.WriteAllText("SaveData\\" + currModName + "\\" + nameGenerator.Name + ".txt", outPutNameGenfile);
                }
                else
                {
                    File.Copy(nameGenerator.Path, "SaveData\\" + currModName + "\\" + nameGenerator.Name + ".txt");
                }
            }
        }

        private void loadToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            using(LoadModMenu lmm = new LoadModMenu())
            {
                if(lmm.ShowDialog() == DialogResult.OK)
                {
                    SoftwareTypes = new List<SoftwareType>();
                    string[] SISCFiles = Directory.GetFiles("SaveData\\" + lmm.ModName);

                    foreach (string SISCFile in SISCFiles)
                    {
                        Debug.WriteLine(SISCFile);
                        if (Path.GetExtension(SISCFile) == ".sisc")
                        {
                            SoftwareType softwareType = SISCFileType.Read(SISCFile);
                            SoftwareTypes.Add(softwareType);
                            listBox4.Items.Add(softwareType.Name);
                            label23.Text = "Mod Creator: Loaded SoftwareType " + softwareType.Name;
                            listBox3.Items.Add("Mod Creator: Loaded SoftwareType " + softwareType.Name);
                        }
                        else
                        {
                            NameGenerator nameGenerator = new NameGenerator(new FileInfo(SISCFile).Name.Replace(".txt", ""), SISCFile);
                            NameGenerators = new List<NameGenerator>();
                            NameGenerators.Add(nameGenerator);
                            listBox5.Items.Add(nameGenerator.Name);
                        }
                    }
                }
                label23.Text = "Mod Creator: Loaded Mod " + lmm.ModName;
                listBox3.Items.Add("Mod Creator: Loaded Mod " + lmm.ModName);
            }
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
                MessageBox.Show("There Was A Error");
                MessageBox.Show("Error: " + nre);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            using(NewSoftwareTypeMenu n = new NewSoftwareTypeMenu())
            {
                if (SoftwareTypes != null)
                {
                    n.Style = displayNameToFile[currStyle];
                    n.NameGens = NameGenerators;
                    if (n.ShowDialog() == DialogResult.OK)
                    {
                        SoftwareTypes.Add(new SoftwareType(n.Name_, n.Unlock, n.Category, n.Description, n.Random, n.Popularity, n.Retention, n.Iterative, n.TimeScale, n.OSLimit,
                            n.NameGenerator, n.IdealPrice, n.OSSpecific, n.OneClient, n.InHouse, new List<Categories>(), new List<Features>()));
                        listBox4.Items.Add(n.Name_);
                        listBox4.SelectedIndex = 0;
                    }
                }
                else
                {
                    label23.Text = "Mod Creator: Exporting Mod ";
                    listBox3.Items.Add("Mod Creator: ");
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

        private void exportToGameModFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(gameModDir == "")
            {
                MessageBox.Show("Please set the game mod folder under settings");
                return;
            }
            if (SoftwareTypes == null)
            {
                label23.Text = "Mod Creator: Please Create A New Mod First";
                listBox3.Items.Add("Mod Creator: Please Create A New Mod First");
                return;
            }
            if (currModName == "")
            {
                label23.Text = "Mod Creator: Please Create A New Mod First";
                listBox3.Items.Add("Mod Creator: Please Create A New Mod First");
                return;
            }

            label23.Text = "Mod Creator: Creating Mod Folder " + currModName;
            listBox3.Items.Add("Mod Creator: Creating Mod Folder " + currModName);

            string ModFolder = gameModDir + "\\" + currModName.Replace(' ', '-');
            string SoftwareTypesFolder = ModFolder + "\\SoftwareTypes\\";
            string NameGeneratorsFolder = ModFolder + "\\NameGenerators\\";
            string CompanyTypes = ModFolder + "\\CompanyTypes\\";

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

            //Export NameGenerators
            foreach (NameGenerator nameGenerator in NameGenerators)
            {
                if (!nameGenerator.isFile)
                {
                    string outPutNameGenfile = "-start(base)\n-base(base2,end,stop)\n";
                    foreach (string Base in nameGenerator.Base)
                    {
                        outPutNameGenfile += Base + "\n";
                    }
                    outPutNameGenfile += "-base2\n";
                    foreach (string Base2 in nameGenerator.Base2)
                    {
                        outPutNameGenfile += Base2 + "\n";
                    }
                    outPutNameGenfile += "-end(stop)";
                    foreach (string End in nameGenerator.End)
                    {
                        outPutNameGenfile += End + "\n";
                    }
                    File.WriteAllText(NameGeneratorsFolder + nameGenerator.Name + ".txt", outPutNameGenfile);
                }
                else
                {
                    File.Copy(nameGenerator.Path, NameGeneratorsFolder + "\\" + nameGenerator.Name + ".txt");
                }
            }



            //Export SoftwareTypes
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.IndentChars = "     ";
            settings.NewLineOnAttributes = false;
            settings.OmitXmlDeclaration = true;

            foreach (SoftwareType softwareType in SoftwareTypes)
            {
                XmlWriter writer = XmlWriter.Create(SoftwareTypesFolder + "\\" + softwareType.Name + ".xml", settings);
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

        private void setGameDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowNewFolderButton = true;
            folderBrowserDialog1.Description = "Please select the game mod dir. Currernt dir: " + gameModDir;
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                gameModDir = folderBrowserDialog1.SelectedPath;
                label23.Text = "Mod Creator: Mod Ouput to " + gameModDir;
                listBox3.Items.Add("Mod Creator: Mod Ouput to " + gameModDir);
            }
            else
            {
                return;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (NameGenerators != null)
            {
                using (NewNameGeneratorMenu nngm = new NewNameGeneratorMenu())
                {
                    nngm.Style = displayNameToFile[currStyle];
                    if (nngm.ShowDialog() == DialogResult.OK)
                    {
                        NameGenerators.Add(new NameGenerator(nngm.Base, nngm.Base2, nngm.End, nngm.Name_));
                        listBox5.Items.Add(nngm.Name_);
                        label23.Text = "Mod Creator: Name Generator " + nngm.Name_ + " Created Successfully";
                        listBox3.Items.Add("Mod Creator: Name Generator " + nngm.Name_ + " Created Successfully");
                    }
                    else
                    {
                        label23.Text = "Mod Creator: Name Generator Creation Failed";
                        listBox3.Items.Add("Mod Creator: Name Generator Creation Failed");
                        return;
                    }
                }
            }
            else
            {
                label23.Text = "Mod Creator: Please Create A Mod First";
                listBox3.Items.Add("Mod Creator: Please Create A Mod First");
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (NameGenerators != null)
            {
                openFileDialog1.AutoUpgradeEnabled = true;
                openFileDialog1.CheckFileExists = true;
                openFileDialog1.CheckPathExists = true;
                openFileDialog1.DefaultExt = "txt";
                openFileDialog1.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog1.Multiselect = false;
                openFileDialog1.FileName = "";
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    FileInfo info = new FileInfo(openFileDialog1.FileName);
                    NameGenerators.Add(new NameGenerator(info.Name.Replace(".txt", ""), openFileDialog1.FileName));
                    Debug.WriteLine(openFileDialog1.FileName);
                    listBox5.Items.Add(info.Name.Replace(".txt", ""));
                }
            }
            else
            {
                label23.Text = "Mod Creator: Please Create A Mod First";
                listBox3.Items.Add("Mod Creator: Please Create A Mod First");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            NameGenerators.RemoveAt(listBox5.SelectedIndex);
            listBox5.Items.RemoveAt(listBox5.SelectedIndex);
        }

        private void themeCreatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (ThemeCreator themeCreator = new ThemeCreator())
            {
                if(themeCreator.ShowDialog() == DialogResult.OK)
                {
                    File.Delete("Themes//Themes.xml");
                }
            }
        }

        private void infoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            using(Info info = new Info())
            {
                if(info.ShowDialog() == DialogResult.OK)
                {

                }
            }
        }
    }
}
