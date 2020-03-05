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
    public partial class StartForm : BaseForm
    {
        public StartForm()
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
            for (int i = 0; i < 5; i++)
            {
                Label l = new Label();
                l.Font = new Font("Roboto", 10, FontStyle.Bold);
                l.ForeColor = Color.White;
                l.Text = "Project"+i.ToString();
                this.tableLayoutPanel1.RowCount = ++this.tableLayoutPanel1.RowCount;
                this.tableLayoutPanel1.Size = new System.Drawing.Size(200, this.tableLayoutPanel1.Size.Height + 100);
                this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
                this.tableLayoutPanel1.Controls.Add(l, 0, i);
            }

            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

            this.Refresh();
        }

        private void newProject()
        {
            Project pr1 = new Project("hi");
            pr1.GetInfo();
            //label2.Text = pr1.GetInfo();
            var npwin = new newProjectForm();
            npwin.Show();
            npwin.Closed += (s, args) => this.Show();
            this.Hide();
        }

        private void newHardware()
        {
            var hw = new HardwareForm();
            hw.Show();
            this.Hide();
            hw.Closed += (s, args) => this.Show();
            
        }

        private void newStatistics()
        {
            var st = new StatisticsForm();
            st.Show();
            this.Hide();
            st.Closed += (s, args) => this.Show();

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

        private void panel4_MouseClick(object sender, MouseEventArgs e)
        {
            newStatistics();

        }

        private void panel5_Click(object sender, EventArgs e)
        {
            newHardware();
        }

        private void panel5_MouseClick(object sender, MouseEventArgs e)
        {
            var hw = new HardwareForm();
            {

            }
        }
    }
}
