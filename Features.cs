using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareIncSoftwareCreator.LIB
{
    public class Features
    {
        public string From;
        public bool Forced;
        public bool Vital;
        public string Research;
        public string Description;
        public string Name;
        public string Category;
        public string ArtCategory;
        public string Unlock;
        public string DevTime;
        public string Innovation;
        public string Usability;
        public string Sability;
        public string CodeArt;
        public string Server;
        public List<string> Dependency;

        public Features(string from, bool forced, bool vital, string research, string description, string name, string category, string artCategory, string unlock, string devTime, string innovation, string usability, string sability, string codeArt, string server, List<string> dependency)
        {
            From = from;
            Forced = forced;
            Vital = vital;
            Research = research;
            Description = description;
            Name = name;
            Category = category;
            ArtCategory = artCategory;
            Unlock = unlock;
            DevTime = devTime;
            Innovation = innovation;
            Usability = usability;
            Sability = sability;
            CodeArt = codeArt;
            Server = server;
            Dependency = dependency;
        }
        //TODO add software category support

    }
}
