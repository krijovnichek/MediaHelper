using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Linq;

using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Net;
using System.Linq;

namespace MediaHelper
{
    public partial class TechnicForm : BaseForm
    {
        private string docPath = @"D://data.xml";
        private string docPath1 = @"D://data1.xml";
        private string docPath_test1 = @"D://data_test1AAA.xml";
        private string docPath_new = @"D://datanew.xml";
        private string docPath_test = @"D://data_T.xml";
        private string filePath = @"D://file1.pdf";
        int MaxId =0;
        int Id;
        public TechnicForm()
        {
            InitializeComponent();
            WebClient webClient = new WebClient();
        //    webClient.DownloadFile("http://localhost:3000/getxml", docPath);
            ReadFromXml(docPath_test1);
            //    webClient.UploadFile("http://localhost:3000/postxml", docPath1);
            //WriteReXml(5);


        }

        
        public void WriteToXml(string docPath, Technic item)
        {
            
            /* Запись в XML-файл  */
            try
            {

                XDocument doc = new XDocument(
                 new XElement("technic",
                 new XElement(item.Type,
                 new XAttribute("id", "1"),
                 new XElement("manufacture", item.Manufacturer),
                 new XElement("model", item.Model),
                 new XElement("shots", item.Shots)
                 )));

                doc.Save(docPath);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);

            }
        }
        
       

        public void EditXml(Technic item)
        {
            XDocument doc = XDocument.Load(docPath_test1);
           

            XElement technic = new XElement(item.Type,
            new XAttribute("id", item.ID.ToString()),
            new XElement("manufacture", item.Manufacturer),
            new XElement("model", item.Model),
            new XElement("shots", item.Shots));
            doc.Root.Add(technic);
            doc.Save(docPath_test1);

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
            // Load data from XML
            DataSet ds = new DataSet();
            ds.ReadXml(docPath_test1);
            dataGridView1.GridColor = Color.Green;
            dataGridView1.ForeColor = Color.Green;
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            addButton.Visible = true;
            // ID
            int last = dataGridView1.Rows.Count - 2;
            int prevId = Int32.Parse(dataGridView1.Rows[last - 1].Cells[3].Value.ToString());
            dataGridView1.Rows[last].Cells[3].Value = (prevId + 1).ToString();
            MaxId = prevId + 1;
        }

       public void ReWriteXML(string docPath, int sid, string man, string mod, string sh)
        {
            Console.WriteLine("Проверка_1");
            XDocument doc = XDocument.Load(docPath);

            var items = from it in doc.Descendants("Camera")
                        where it.Attribute("id").Value == sid.ToString()
                        select it;


            foreach (XElement itemElement in items)
            {
                itemElement.SetElementValue("manufacture", man);
                itemElement.SetElementValue("model", mod);
                itemElement.SetElementValue("shots", sh);
                Console.WriteLine(itemElement.ToString());
                Console.WriteLine("Проверка_2");
            }

            doc.Save(docPath_test);
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            //ReWriteXML(docPath1, 3, "Сапог","АХАХА","100");
                       
            int last = dataGridView1.Rows.Count - 2;

            string man = dataGridView1.Rows[last].Cells[0].Value.ToString();
            string model = dataGridView1.Rows[last].Cells[1].Value.ToString();
            
            int r;
            Int32.TryParse(dataGridView1.Rows[last].Cells[3].Value.ToString(), out r);
            int rows = dataGridView1.RowCount;
            int clmns = dataGridView1.ColumnCount;
            if (r != 0)
            {
                int id = Int32.Parse(dataGridView1.Rows[last].Cells[3].Value.ToString());
                int prevId = Int32.Parse(dataGridView1.Rows[last - 1].Cells[3].Value.ToString());

                

                
                    //XDocument temp = new XDocument();
                    //temp.Save(docPath_test1);

                addButton.Visible = false;
            }
            else
            {
                MessageBox.Show("Введите число");
            }

            WriteToXml(docPath_test1, new Technic("Camera",
                 dataGridView1.Rows[0].Cells[0].Value.ToString(),
                 dataGridView1.Rows[0].Cells[1].Value.ToString(),
                0));
            for (int i = 1; i < rows-1; i++)
            {
                EditXml(new Technic(i+1, "Camera", 
                    dataGridView1.Rows[i].Cells[0].Value.ToString(), 
                    dataGridView1.Rows[i].Cells[1].Value.ToString(),
                    Int32.Parse(dataGridView1.Rows[i].Cells[2].Value.ToString())
                    ));

            }

        }

        private void np_Click(object sender, EventArgs e)
        {
            CreatePDFiText();
        }


        public void CreatePDFiText()
        {
            Document doc = new Document(iTextSharp.text.PageSize.A4, 10, 10, 42, 35);
            try
            {
                PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream(filePath, FileMode.Create));
                MessageBox.Show("Файл записан.");

            }
            catch (Exception)
            {
                MessageBox.Show("Файл открыт.");
            }
            doc.Open();

            BaseFont bfTimes = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, false);

            //
            string ttf = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "ARIAL.TTF");
            var baseFont = BaseFont.CreateFont(ttf, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
            var font = new iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL);

            //
            string header = "ОТЧЕТ ПО СОСТОЯНИЮ ТЕХНИКИ НА " + DateTime.Now.ToString("dd.MM.yyyy");
            Paragraph par = new Paragraph(header,font);
            par.Alignment = Element.ALIGN_CENTER;
            par.SpacingAfter = 30;


            int ccount = dataGridView1.Columns.Count;
            int rcount = dataGridView1.Rows.Count;


            PdfPTable table = new PdfPTable(ccount);

            try
            {
                for (int c = 0; c < ccount; c++)
                {
                    table.AddCell(new Phrase(dataGridView1.Columns[c].HeaderText));
                }

                table.HeaderRows = 1;

                for (int i = 0; i < rcount; i++)
                {
                    for (int j = 0; j < ccount; j++)
                    {
                        if (dataGridView1.Rows[i].Cells[j].Value != null)
                        {
                            table.AddCell(new Phrase(dataGridView1.Rows[i].Cells[j].Value.ToString())); 
                        }
                    }
                }
            }
            finally
            {
                doc.Add(par);
                doc.Add(table);
                doc.Close();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
