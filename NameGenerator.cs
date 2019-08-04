using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareIncSoftwareCreator.LIB
{
    public class NameGenerator
    {
        public string[] Base;
        public string[] Base2;
        public string[] End;
        public string Name;
        public string Path;
        public bool isFile;

        public NameGenerator(string[] Base, string[] Base2, string[] End, string Name)
        {
            this.Base = Base;
            this.Base2 = Base2;
            this.End = End;
            this.Name = Name;
            this.isFile = false;
        }

        public NameGenerator(string Name, string Path)
        {
            this.Name = Name;
            this.Path = Path;
            this.isFile = true;
        }

        public NameGenerator()
        {

        }
    }
}
