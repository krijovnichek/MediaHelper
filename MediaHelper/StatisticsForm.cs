using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MigraDoc;
using PdfSharp;

//using MigraDoc.DocumentObjectModel;
//using MigraDoc.Rendering;
//using PdfSharp.Pdf;
//using MigraDoc.DocumentObjectModel.Tables;

using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace MediaHelper
{
    public partial class StatisticsForm : BaseForm
    {

        public StatisticsForm()
        {
            InitializeComponent();
        }

        private void np_Click(object sender, EventArgs e)
        {

        }




        
        /**//*public void CreatePDFReport()
        {

            Document document = new Document();
            Section section = document.AddSection();
            
            section.PageSetup.PageFormat = PageFormat.A4;   //стандартный размер страницы
            section.PageSetup.Orientation = MigraDoc.DocumentObjectModel.Orientation.Portrait;   //ориентация
            section.PageSetup.BottomMargin = 10;    //нижний отступ
            section.PageSetup.TopMargin = 30;   //верхний отступ

            Paragraph paragraph = section.AddParagraph();
            paragraph.Format.Font.Color = MigraDoc.DocumentObjectModel.Color.FromCmyk(100, 30, 20, 50);
            Text text = new Text("text ");
            paragraph.Add(text);    //добавление любого из перечисленых ниже
            paragraph.AddChar('c'); //символ
            paragraph.AddDateField(DateTime.Now.ToString("dd.MM.yyyy"));    //дата
            
            paragraph.AddFootnote("Footnote");  //нижняя подпись

            Table table = new Table();

            for (int i = 0; i < 4; i++)
            {
                table.AddColumn();

            }
            for (int i = 0; i < 3; i++)
            {
                table.AddRow();

            }

            section.Add(table);

            var pdfRenderer = new PdfDocumentRenderer()
            {
                Document = document
            };
            pdfRenderer.RenderDocument();
            try
            {
                pdfRenderer.PdfDocument.Save(filePath);// сохраняем
            }
            catch (Exception)
            {
                MessageBox.Show("Файл открыт.");
            }


        }
*/    }
}
