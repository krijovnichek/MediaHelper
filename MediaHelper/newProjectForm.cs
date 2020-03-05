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
        public newProjectForm()
        {
            InitializeComponent();
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
                var f = new StartForm();
                f.Show();
                this.Hide();
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


        private void createDirectory(string path)
        {
            try
            {
                
                // If the directory doesn't exist, create it.
                if (!Directory.Exists(path))
                {
                    canI = true;
                    Directory.CreateDirectory(path);
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
        }
    }
}
