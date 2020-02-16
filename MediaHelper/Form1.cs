using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace MediaHelper
{
    public partial class Form1 : BaseForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        //public new void Close()
        //{
        //    this.Close();
        //}

        private void новыйПроектToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newProject();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void newProject()
        {
            Project pr1 = new Project("hi");
            pr1.GetInfo();
            label2.Text = pr1.GetInfo();
            var npwin = new newProjectForm();
            npwin.Show();
            npwin.Closed += (s, args) => this.Close();
            this.Hide();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Click(object sender, EventArgs e)
        {
            newProject();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
