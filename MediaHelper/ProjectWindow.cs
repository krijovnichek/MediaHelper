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
            sizeLabel.Text = GetDirectorySize(dir).ToString() + "bytes";
            Path = dir;
        }


        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void ProjectWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Program.fClose();
        }

        static long GetDirectorySize(string p)
        {
            // 1.
            // Get array of all file names.


            string[] a = Directory.GetFiles(p, "*.*");

            // 2.
            // Calculate total bytes of all files in a loop.
            long size = 0;
            foreach (string name in a)
            {
                // 3.
                // Use FileInfo to get length of each file.
                FileInfo info = new FileInfo(name);
                size += info.Length;
            }
            // 4.
            // Return total size
            return size;
        }

        private void panel4_Click(object sender, EventArgs e)
        {

        }

        private void label2_DoubleClick(object sender, EventArgs e)
        {
            // open TZ doc
            string dir = Path + "\\Docs";
            Console.WriteLine(dir);
            string[] files = Directory.GetFiles(dir);
            foreach (string f in files)
            {
                string t = f.Split('\\').Last();
                Console.WriteLine(t);
                if (t.StartsWith("TZ_")) {
                    // Открываем файл c ТЗ
                    System.Diagnostics.Process.Start(f);
                }
                else MessageBox.Show("НЕТ ТЗ");
            }

        }
    }
}
