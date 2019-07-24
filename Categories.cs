namespace SoftwareIncSoftwareCreator.LIB
{
    public class Categories
    {
        public string Popularity;
        public string Retention;
        public string Iterative;
        public string TimeScale;
        public string Description;
        public string Name;
        public string Unlock;

        public Categories(string popularity, string retention, string iterative, string timeScale, string description, string name, string unlock)
        {
            Popularity = popularity;
            Retention = retention;
            Iterative = iterative;
            TimeScale = timeScale;
            Description = description;
            Name = name;
            Unlock = unlock;
        }
    }
}
