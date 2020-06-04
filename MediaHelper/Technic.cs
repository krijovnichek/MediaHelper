using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaHelper
{
    public class Technic
    {
        public int ID { get; set; }
        public string Type { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public int Shots { get; set; }
        public int Limit { get; set; }


        public Technic()
        {

        }

        public Technic(string type, string manufacturer, string model, int shots = 0)
        {
            Type = type;
            Manufacturer = manufacturer;
            Model = model;
            Shots = 0;
            Limit = 100000;
            
        }

        public Technic(int id, string type, string manufacturer, string model, int shots = 0)
        {
            Type = type;
            Manufacturer = manufacturer;
            Model = model;
            Shots = 0;
            Limit = 100000;
            ID = id;

        }

        public Technic (string type, string manufacturer, string model, int shots, int limit)
        {
            Type = type;
            Manufacturer = manufacturer;
            Model = model;
            Shots = shots;
            Limit = limit;
        }




    }

   
}
