using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaHelper
{
    public class Project
    {


        public string Name { get; set; }
        public string Path { get; set; }

        public Project()
        {

        }
        public Project(string n) { name = n; }

        public Project(string name, string path)
        {
            Name = name;
            Path = path;
        }



        private string name;

        public string GetInfo()
        {
            return name;
        }






    }
}
