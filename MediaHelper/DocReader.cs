using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace MediaHelper
{
    class DocReader
    {
        /*public static List <Project> ProjectFromXml(string docPath)
        {
            XmlSerializer ser = new XmlSerializer(typeof(List<Project>));
            using (FileStream stream = File.OpenRead(docPath))
            {
                List<Project> projects = (List<Project>)ser.Deserialize(stream);
                return projects;
            }

           
        }*/



        /*    public static List<string> ProjectFromXml(string docPath)
            {

                XDocument xmlDoc = XDocument.Load(docPath);
                var list = xmlDoc.Root.Elements("projects")
                                           .Select(element => ":"+element.Value+":")
                                           .ToList();

                foreach (string s in list)
                {
                    Console.WriteLine(s);
                }
                return list;

            }
    */
        /*
                public static List<string> ProjectFromXml(string docPath)
                {

                    XDocument doc = XDocument.Parse(docPath);

                    List<string> list = doc.Root.Elements("projects")
                                       .Select(element => element.Value)
                                       .ToList();
                    foreach (string s in list)
                    {
                        Console.WriteLine(s);
                    }
                    return list;
                }*/


        public static List<Project> ProjectFromXml(string docPath)
        {
         
                int i = 0;
                XDocument doc = XDocument.Load(docPath);
                List<Project> projects = new List<Project>();
                foreach (XElement el in doc.Root.Elements())
                {
                    string name, path;
                    List<string> names = new List<string>();
                    List<string> paths = new List<string>();
                    //Выводим имя элемента и значение аттрибута id
                    //выводим в цикле все аттрибуты, заодно смотрим как они себя преобразуют в строку
                    foreach (XAttribute attr in el.Attributes())
                    {
                        string t = attr.ToString().Split('=')[1].Trim('"');
                        names.Add(t);
                    }
                    //выводим в цикле названия всех дочерних элементов и их значения
                    foreach (XElement element in el.Elements())
                    {
                        paths.Add(element.Value.ToString());
                    }


                    for (int k = 0; k<names.Count; k++  )
                    {
                        projects.Add(new Project(names[k], paths[k]));
                    }
                    i++;
                }

                foreach (Project p in projects)
                {
                    Console.WriteLine(p.Name);
                    Console.WriteLine(p.Path);
                }

                return projects;
            
         
        }


    }
}
