using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace SoftwareIncSoftwareCreator.LIB
{
    public class SISCFileType
    {
        public static void Write(List<SoftwareType> softwareTypes, string modName)
        {
            Directory.CreateDirectory("SaveData\\" + modName);

            foreach (SoftwareType softwareType in softwareTypes)
            {

                string output = "";
                output += "Name = [" + softwareType.Name + "]\n";
                output += "Unlock = [" + softwareType.Unlock + "]\n";
                output += "Category = [" + softwareType.Category + "]\n";
                output += "Description = [" + softwareType.Description + "]\n";
                output += "Random = [" + softwareType.Random + "]\n";
                output += "OSSpecific = [" + softwareType.OSSpecific + "]\n";
                output += "OneClient = [" + softwareType.OneClient + "]\n";
                output += "InHouse = [" + softwareType.InHouse + "]\n";
                output += "IdealPrice = [" + softwareType.IdealPrice + "]\n";
                output += "NameGenerator = [" + softwareType.NameGenerator + "]\n";
                output += "TimeScale = [" + softwareType.TimeScale + "]\n";
                output += "Iterative = [" + softwareType.Iterative + "]\n";
                output += "Retention = [" + softwareType.Retention + "]\n";
                output += "Popularity = [" + softwareType.Popularity + "]\n";

                foreach (Features feature in softwareType.Features)
                {
                    output += "Feature";
                    output += "[Name = " + feature.Name + "]";
                    output += "[Unlock = " + feature.Unlock + "]";
                    output += "[Category = " + feature.Category + "]";
                    output += "[Description = " + feature.Description + "]";
                    output += "[DevTime = " + feature.DevTime + "]";
                    output += "[Innovation = " + feature.Innovation + "]";
                    output += "[Usability = " + feature.Usability + "]";
                    output += "[Stability = " + feature.Sability + "]";
                    output += "[CodeArt = " + feature.CodeArt + "]";
                    output += "[ArtCategory = " + feature.ArtCategory + "]";
                    output += "[From = " + feature.From + "]";
                    output += "[Forced = " + feature.Forced + "]";
                    output += "[Vital = " + feature.Vital + "]";
                    output += "[Research = " + feature.Research + "]";
                    output += "[Server = " + feature.Server + "]\n";
                }

                foreach (Categories category in softwareType.Categories)
                {
                    output += "Category";
                    output += "[Name = " + category.Name + "]";
                    output += "[unlock = " + category.Unlock + "]";
                    output += "[Popularity = " + category.Popularity + "]";
                    output += "[Retention = " + category.Retention + "]";
                    output += "[TimeScale = " + category.TimeScale + "]";
                    output += "[Iterative = " + category.Iterative + "]";
                    output += "[Description = " + category.Description + "]\n";
                }
                File.WriteAllText("SaveData\\" + modName + "\\" + softwareType.Name + ".sisc", output);
            }
        }

        public static SoftwareType Read(string fileName = "Test.sisc")
        {
            string[] lines = File.ReadAllLines(fileName);
            SoftwareType softwareType = new SoftwareType();
            softwareType.Features = new List<Features>();
            softwareType.Categories = new List<Categories>();

            foreach (string  line in lines)
            {
                string[] x = line.Split(' '/*, '[', ']'*/);
                string[] y = x[2].Split('[', ']');
                if(x[0] == "Name")
                {
                    
                    softwareType.Name = y[1];
                }
                else if(x[0] == "Unlock")
                {
                    
                    softwareType.Unlock = y[1];
                }
                else if(x[0] == "Category")
                {
                    
                    softwareType.Category = y[1];
                }
                else if (x[0] == "Description")
                {
                    
                    softwareType.Description = y[1];
                }
                else if (x[0] == "Random")
                {
                    
                    softwareType.Random = y[1];
                }
                else if (x[0] == "OSSpecific")
                {
                    
                    softwareType.OSSpecific = bool.Parse(y[1]);
                }
                else if (x[0] == "OneClient")
                {
                    
                    softwareType.OneClient = bool.Parse(y[1]);
                }
                else if (x[0] == "InHouse")
                {
                    
                    softwareType.InHouse = bool.Parse(y[1]);
                }
                else if (x[0] == "IdealPrice")
                {
                    
                    softwareType.IdealPrice = y[1];
                }
                else if (x[0] == "NameGenerator")
                {
                    
                    softwareType.NameGenerator = y[1];
                }
                else if (x[0] == "TimeScale")
                {
                    
                    softwareType.TimeScale = y[1];
                }
                else if (x[0] == "Iterative")
                {
                    softwareType.Iterative = y[1];
                }
                else if (x[0] == "Retention")
                {
                    softwareType.Retention = y[1];
                }
                else if (x[0] == "Popularity")
                {
                    softwareType.Popularity = y[1];
                }
                else
                {
                    string[] u = line.Split('[', ']');
                    if(u[0] == "Feature")
                    {
                        //bool.Parse(u[12].Split(' ')[2]);
                        //bool.Parse(u[13].Split(' ')[2]);  
                        Features feature = new Features(u[21].Split(' ')[2], bool.Parse(u[23].Split(' ')[2]), bool.Parse(u[25].Split(' ')[2]), u[27].Split(' ')[2], u[7].Split(' ')[2], u[1].Split(' ')[2], u[5].Split(' ')[2], u[19].Split(' ')[2],
                            u[3].Split(' ')[2], u[9].Split(' ')[2], u[11].Split(' ')[2], u[13].Split(' ')[2], u[15].Split(' ')[2], u[17].Split(' ')[2], u[29].Split(' ')[2], null);
                        softwareType.Features.Add(feature);
                    }
                    else if(u[0] == "Category")
                    {
                        Categories category = new Categories(u[5].Split(' ')[2], u[7].Split(' ')[2], u[11].Split(' ')[2], u[9].Split(' ')[2], u[13].Split(' ')[2], 
                            u[1].Split(' ')[2], u[3].Split(' ')[2]);
                        softwareType.Categories.Add(category);
                    }
                    else
                    {

                    }
                }

            }

            return softwareType;
        }
    }
}
