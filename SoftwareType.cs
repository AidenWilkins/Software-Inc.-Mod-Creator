using System.Collections.Generic;

namespace SoftwareIncSoftwareCreator.LIB
{
    public class SoftwareType
    {
        public string Name;
        public string Unlock;
        public string Category;
        public string Description;
        public string Random;
        public string Popularity;
        public string Retention;
        public string Iterative;
        public string TimeScale;
        public string OSLimit; //Phone, Console, Computer
        public string NameGenerator;
        public string IdealPrice;
        public bool OSSpecific;
        public bool OneClient;
        public bool InHouse;

        public List<Categories> Categories;
        public List<Features> Features;

        public SoftwareType(string name, string unlock, string category, string description, string random, string popularity, string retention, string iterative, string timeScale, string oSLimit, string nameGenerator, string idealPrice, bool oSSpecific, bool oneClient, bool inHouse, List<Categories> categories, List<Features> features)
        {
            Name = name;
            Unlock = unlock;
            Category = category;
            Description = description;
            Random = random;
            Popularity = popularity;
            Retention = retention;
            Iterative = iterative;
            TimeScale = timeScale;
            OSLimit = oSLimit;
            NameGenerator = nameGenerator;
            IdealPrice = idealPrice;
            OSSpecific = oSSpecific;
            OneClient = oneClient;
            InHouse = inHouse;
            Categories = categories;
            Features = features;
        }

        public SoftwareType()
        {

        }
    }
}
