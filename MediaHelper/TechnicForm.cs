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
        private string docPath_test = @"D://data_T.xml";
        private string docPath1 = @"D://data1.xml";
        private string filePath = @"D://file1.pdf";
        int MaxId =0;
        int Id;
        public TechnicForm()
        {
            InitializeComponent();
            WebClient webClient = new WebClient();
        //    webClient.DownloadFile("http://localhost:3000/getxml", docPath);
            ReadFromXml(docPath);
            //    webClient.UploadFile("http://localhost:3000/postxml", docPath1);



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

        public void EditXml(string docPath, Technic item)
        {
            XDocument doc = XDocument.Load(docPath);

            XElement technic = new XElement(item.Type,
            new XAttribute("id", MaxId.ToString()),
            new XElement("manufacture", item.Manufacturer),
            new XElement("model", item.Model),
            new XElement("shots", item.Shots));


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
            // Load data from XML
            DataSet ds = new DataSet();
            ds.ReadXml(docPath);
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

       /* public void ReWriteXML(string docPath, Technic item)
        {
            XDocument doc = XDocument.Load(docPath);
            var deleteQuery = from r in doc.Descendants("technic") where r.Element("model").Value == txt.Text.Trim() select r;
            foreach (var qry in deleteQuery)
            {
                qry.Element("Camera").Remove();
                
            }
            doc.Save(docPath_test);
        }*/

        private void addButton_Click(object sender, EventArgs e)
        {
            int last = dataGridView1.Rows.Count - 2;

            string man = dataGridView1.Rows[last].Cells[0].Value.ToString();
            string model = dataGridView1.Rows[last].Cells[1].Value.ToString();
            int r;
            Int32.TryParse(dataGridView1.Rows[last].Cells[3].Value.ToString(), out r);
            if (r != 0)
            {
                int id = Int32.Parse(dataGridView1.Rows[last].Cells[3].Value.ToString());
                int prevId = Int32.Parse(dataGridView1.Rows[last - 1].Cells[3].Value.ToString());

                EditXml(docPath, new Technic(prevId+1, "Camera", man, model));
                addButton.Visible = false;
            }
            else
            {
                MessageBox.Show("Введите число");
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
