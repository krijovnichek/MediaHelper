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

namespace MediaHelper
{
    public partial class newProjectForm : BaseForm
    {
        bool canI = false;
        string[] files;
        public newProjectForm()
        {
            InitializeComponent();
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
                    ProjectWindow win = new ProjectWindow(projectNameTextBox.Text, dirLabel.Text);
                    this.Hide();
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
                    Directory.CreateDirectory(path + "\\Source\\Audio");
                    Directory.CreateDirectory(path + "\\Source\\Images");
                    Directory.CreateDirectory(path + "\\Source\\Images\\AI");
                    Directory.CreateDirectory(path + "\\Source\\Images\\png");

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
            
            Sort(files, path);

        }


        private void Sort(string [] files, string path)
        {
            List<string> f = new List<String>();
            foreach (string file in files) {
                //Console.WriteLine(file);
                string name = file.Split('\\').Last();
                //Console.WriteLine(name);
                string targetPath;
                if (file.EndsWith(".png") || file.EndsWith(".jpeg"))
                {
                    // move to img folder
                    targetPath = path + "\\Source\\Images\\png\\" + name;
                    MoveToPath(file, targetPath);

                }
                else if (file.EndsWith(".mp4") || file.EndsWith(".mov"))
                {
                    // move to video folder
                    targetPath = path + "\\Source\\Video\\" + name;
                    MoveToPath(file, targetPath);

                }
                else if (file.EndsWith(".mp3") || file.EndsWith(".wav"))
                {
                    // move to audio folder
                    targetPath = path + "\\Source\\Audio\\" + name;
                    MoveToPath(file, targetPath);

                } else if (Directory.Exists(file)) {
                    // Если папка, то получаем её файлы и директории и передаем их в рекурсивный вызов
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
            catch (Exception)
            {
                Console.WriteLine("Ошибка записи");
                throw;
            }

            Console.WriteLine("Все ок");
        }




        private void newProjectForm_Load(object sender, EventArgs e)
        {

        }





    }
}
