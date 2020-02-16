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
    public partial class ProjectWindow : Form
    {
        public ProjectWindow()
        {
            InitializeComponent();
        }

        public ProjectWindow(string projectName, string _dirLabel)
        {

            InitializeComponent();
            
            projectNameTextBox.Text = projectName;
            string dir = _dirLabel + '\\' + projectName;
            dirLabel.Text = dir;
           

            int fCount = Directory.GetFiles(dir, ".", SearchOption.AllDirectories).Count();
            filesCount.Text = fCount.ToString();
            sizeLabel.Text = GetDirectorySize(dir).ToString();
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



    }
}
