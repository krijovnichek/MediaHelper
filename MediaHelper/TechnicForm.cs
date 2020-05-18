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


        string docPath = @"D://data.xml";
        public TechnicForm()
        {
            InitializeComponent();
            Technic cam1 = new Technic("Camera","Canon", "66D");
            Technic cam2 = new Technic("Camera", "Canon", "70D");
            Technic cam3 = new Technic("Camera", "Canon", "80D");
            Technic cam4 = new Technic("Camera", "Canon", "60D");


            

            WriteToXml(docPath, cam1);
            EditXml(docPath, cam2);
            EditXml(docPath, cam3);
            EditXml(docPath, cam4);
            ReadFromXml(docPath);

        }
        public void WriteToXml(string docPath, Technic item)
        {
            /* Запись в XML-файл  */
            try
            {

                XDocument doc = new XDocument(
                 new XElement("technic",
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

        public void EditXml(string docPath, Technic item)
        {
            XDocument doc = XDocument.Load(docPath);

            XElement technic = new XElement(item.Type,
            new XAttribute("id", "003"),
            new XElement("manufacture", item.Manufacturer),
            new XElement("model", item.Model));

            doc.Root.Add(technic);
            doc.Save(docPath);

        }

        public void ReadFromXml(string docPath)
        {
            try
            { int i = 0; 
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
                    //выводим в цикле названия всех дочерних элементов и их значения
                    foreach (XElement element in el.Elements())
                        Console.WriteLine("    {0}: {1}", element.Name, element.Value);

                    i++;
                    


                   
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void TechnicForm_Load(object sender, EventArgs e)
        {
            List < Technic > list = new List<Technic>();
            
            list.Add(new Technic("Camera","Sony","a6300"));
            list.Add(new Technic("Camera", "Sony", "a6400"));
            dataGridView1.DataSource = list;
            
            // Load data from XML
            DataSet ds = new DataSet();
            ds.ReadXml(docPath);
            dataGridView1.DataSource = ds.Tables[0];

        }
    }

   


}
