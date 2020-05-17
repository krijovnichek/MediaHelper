using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;



namespace MediaHelper
{
    public partial class TechnicForm : BaseForm
    {
        public TechnicForm()
        {
            InitializeComponent();
            Technic cam1 = new Technic("Camera","Canon", "66D");
            string docPath = @"D://data.xml";

            WriteToXml(docPath, cam1);


            /*
             *
             * 
             * Чтение XML-файла via LINQ
             
             
             */

            /*try
            {
                XDocument doc = XDocument.Load(docPath);
                //MessageBox.Show(doc.Root.Value);
                foreach (XElement el in doc.Root.Elements())
                {
                    //Выводим имя элемента и значение аттрибута id
                    Console.WriteLine("{0}", el.Name);
                    Console.WriteLine("  Attributes:");
                    //выводим в цикле все аттрибуты, заодно смотрим как они себя преобразуют в строку
                    foreach (XAttribute attr in el.Attributes())
                        Console.WriteLine("    {0}", attr);
                    Console.WriteLine("  Elements:");
                    //выводим в цикле названия всех дочерних элементов и их значения
                    foreach (XElement element in el.Elements())
                        Console.WriteLine("    {0}: {1}", element.Name, element.Value);
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
*/

          



        }
        public void WriteToXml(string docPath, Technic item)
        {
            /* Запись в XML-файл  */
            try
            {

                XDocument doc = new XDocument(
                 new XElement("technics",
                 new XElement(item.Type,
                 new XAttribute("id", "003"),
                 new XElement("manufacture", item.Manufacturer),
                 new XElement("model", item.Model))));
                doc.Save(docPath);




            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);

            }
        }
    }

   


}
