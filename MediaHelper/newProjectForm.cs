using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace MediaHelper
{
    public partial class newProjectForm : BaseForm
    {
        private string docPath = @"D://project_data.xml";

        bool canI = false;
        string[] files = { };
        public newProjectForm()
        {
            InitializeComponent();
            //            WriteToXml(docPath);
        }
        public newProjectForm(string[] infiles)
        {
            InitializeComponent();
            files = infiles;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(dirLabel.Text)) {
                string fullPath = String.Concat(dirLabel.Text, "\\", projectNameTextBox.Text);
                createDirectory(fullPath);
                if (canI)
                {
                    //Кидаем в XML новый проект
                    EditXml(docPath, new Project(projectNameTextBox.Text, fullPath));
                    ProjectWindow win = new ProjectWindow(projectNameTextBox.Text, dirLabel.Text);
                    this.Close();
                    win.Show();
                }
            }
            else
            {
                MessageBox.Show("Path Error");
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
/*                var f = new StartForm();
                f.Show();
 */               this.Close();
        }

        private void dirLabel_TextChanged(object sender, EventArgs e)
        {
            dirLabel.Font = new Font("Roboto", 10, FontStyle.Regular);
        }

        private void dirLabel_Click(object sender, EventArgs e)
        {
            if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            dirLabel.Text = fbd.SelectedPath;
        
        }

        private void newProjectForm_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void newProjectForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            var f = new StartForm();
            f.Show();
            this.Hide();
        }


        public void createDirectory(string path)
        {
            try
            {
                
                // If the directory doesn't exist, create it.
                if (!Directory.Exists(path))
                {
                    canI = true;
                    Directory.CreateDirectory(path);
                    Directory.CreateDirectory(path + "\\Docs");
                    Directory.CreateDirectory(path + "\\Source");
                    Directory.CreateDirectory(path + "\\Source\\Video");
                    Directory.CreateDirectory(path + "\\Source\\Others");
                    Directory.CreateDirectory(path + "\\Source\\Audio");
                    Directory.CreateDirectory(path + "\\Source\\Images");
                 
                    Directory.CreateDirectory(path + "\\Source\\Images\\AI");
                    //Directory.CreateDirectory(path + "\\Source\\Images\\png");

                }
                else
                {
                    canI = false;
                    MessageBox.Show("Directory already exists");
                }
            }
            catch (Exception)
            {
                // Fail silently
            }

            // Запускаем сортировку тут
            if (files.Length != 0) {
                Sort(files, path);
            }

        }


        private void Sort(string [] files, string path)
        {
            List<string> f = new List<String>();
            foreach (string file in files) {
                //Console.WriteLine(file);
                string name = file.Split('\\').Last();
                //Console.WriteLine(name);
                string targetPath;
                if (file.EndsWith(".png") || file.EndsWith(".jpeg") || file.EndsWith(".jpg"))
                {
                    // изображения
                    targetPath = path + "\\Source\\Images\\" + name;
                    MoveToPath(file, targetPath);

                }
                else if (file.EndsWith(".mp4") || file.EndsWith(".mov"))
                {
                    // видео
                    targetPath = path + "\\Source\\Video\\" + name;
                    MoveToPath(file, targetPath);

                }
                else if (file.EndsWith(".mp3") || file.EndsWith(".wav"))
                {
                    // аудио
                    targetPath = path + "\\Source\\Audio\\" + name;
                    MoveToPath(file, targetPath);

                } 

               
                else if (Directory.Exists(file)) {
                   
                    foreach (string i in Directory.GetFiles(file))
                    {
                        f.Add(i);
                        

                    }
                    foreach (string d in Directory.GetDirectories(file))
                    {
                        f.Add(d);

                    }

                     
                    Sort(f.ToArray(),path);
                }
                else if (file.EndsWith(".docx") || file.EndsWith(".doc") || file.EndsWith(".pdf"))
                {
                    // move to audio folder
                    targetPath = path + "\\Docs\\" + "TZ_" + name;
                    MoveToPath(file, targetPath);

                }
                else
                {
                    targetPath = path + "\\Source\\Others\\" + name;
                    MoveToPath(file, targetPath);

                }

            }
        }


        private void MoveToPath (string file, string targetPath)
        {
            while (File.Exists(targetPath))
            {
                targetPath += "_copy";
            }
            
            try
            {
                System.IO.File.Copy(file, targetPath, false);
            }
            catch (Exception e)
            {
                Console.WriteLine("Ошибка записи");
                MessageBox.Show("Обработанная ошибка файла");
                MessageBox.Show(e.ToString());
            }

        }




        private void newProjectForm_Load(object sender, EventArgs e)
        {

        }



        public void EditXml(string docPath, Project project)
        {
            XDocument doc = XDocument.Load(docPath);

            XElement pr = new XElement(
             new XElement("project",
                 new XAttribute("name", project.Name),
                 new XElement("path", project.Path)));

            doc.Root.Add(pr);
            doc.Save(docPath);

        }

        public void WriteToXml(string docPath)
        {
            /* Запись в XML-файл  */
            try
            {

                XDocument doc = new XDocument(
                 new XElement("projects",
                 new XElement("project",
                 new XAttribute("name", "имя проекта"),
                 new XElement("path", "da")
                 )));

                doc.Save(docPath);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);

            }
        }


        public void ReadFromXml(string docPath)
        {
            try
            {
                int i = 0;
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










    }
}
