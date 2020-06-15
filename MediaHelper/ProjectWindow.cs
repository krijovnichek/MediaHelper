using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;


namespace MediaHelper
{
    public partial class ProjectWindow : Form
    {
        public ProjectWindow()
        {
            InitializeComponent();
        }
        string Path = "None";
        public ProjectWindow(string projectName, string _dirLabel)
        {

            InitializeComponent();
            
            projectNameTextBox.Text = projectName;
            string dir = _dirLabel + '\\' + projectName;
            dirLabel.Text = dir;
            int fCount = 0;

            try {fCount = Directory.GetFiles(dir, ".", SearchOption.AllDirectories).Count(); }
            catch (DirectoryNotFoundException err)
            {
                MessageBox.Show("Directory not found");
            }
            filesCount.Text = fCount.ToString();

            double s = Math.Round(GetDirectorySize(dir)/1024/1024, 2, MidpointRounding.ToEven );
            
            sizeLabel.Text = s.ToString() + " Mb";
            Path = dir;
            ToolTip t = new ToolTip();
            t.SetToolTip(panel4, "Открыть техническое задание");

        }


        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void ProjectWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Program.fClose();
        }

        static double GetDirectorySize(string p)
        {
            double size = 0;
            try
            {

                string[] a = Directory.GetFiles(p, "*.*", SearchOption.AllDirectories);

                
                size = 0;
                foreach (string name in a)
                {
                   
                    FileInfo info = new FileInfo(name);
                    size += info.Length;
                }
            }
            catch (Exception e) { Console.WriteLine(e.ToString()); }

            //size = Math.Round(size / 1024 / 1024,2, MidpointRounding.ToEven);
            return size;
        }

        private void panel4_Click(object sender, EventArgs e)
        {

        }

        private void label2_DoubleClick(object sender, EventArgs e)
        {
            // open TZ doc
            string dir = Path + "\\Docs";
            //Console.WriteLine(dir); //
            try
            {
                string[] files = Directory.GetFiles(dir);
                foreach (string f in files)
                {
                    string t = f.Split('\\').Last();
                    if (t.StartsWith("TZ_"))
                    {
                        // Открываем файл c ТЗ
                        System.Diagnostics.Process.Start(f);
                    }
                    else { MessageBox.Show("НЕТ ТЗ"); }
                }
                if (files.Length == 0)
                {
                    MessageBox.Show("НЕТ ТЗ");
                }
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine("DirectoryNotFoundException");
                MessageBox.Show("Ошибка директории");
            }
        }

        private void projectNameTextBox_TextChanged(object sender, EventArgs e)
        {
            // ИЗМЕНЕНИЕ НАЗВАНИЯ В XML
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
