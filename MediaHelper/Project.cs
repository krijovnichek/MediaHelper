using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaHelper
{
    class Project
    {
        public Project(string n) { name = n; }



        public string name;
        public string GetInfo()
        {
            return name;
        }



    }
}
