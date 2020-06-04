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
        private string docPath = @"D://project_data.xml";


        private void новыйПроектToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newProject();
        }
        List<Control> listlLabels = new List<Control>();
        List<Control> listlLabelName = new List<Control>();

        private void Form1_Load(object sender, EventArgs e)
        {
            //TODO
            List<Project> projects = DocReader.ProjectFromXml(docPath);

            for (int i = 0; i < projects.Count; i++)
            {
                Label n = new Label();
                n.Name = "prj_" + i.ToString(); 
                n.Width = 350;
                n.Font = new Font("Roboto", 10, FontStyle.Bold);
                n.ForeColor = Color.White;
                n.Text = projects[i].Name;
                n.Click += new EventHandler(this.label_Click);
                listlLabelName.Add(n);

                Label p = new Label();
                p.Name = "path_" + i.ToString();
                p.Width = 350;
                p.Font = new Font("Roboto", 8, FontStyle.Regular);
                p.ForeColor = Color.White;
                p.Text = projects[i].Path;
                p.Click += new EventHandler(this.label_Click);
                listlLabels.Add(p);


                //this.tableLayoutPanel1.RowCount = ++this.tableLayoutPanel1.RowCount;
                // this.tableLayoutPanel1.Size = new System.Drawing.Size(200, this.tableLayoutPanel1.Size.Height + 100);
                //    this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
                this.tableLayoutPanel1.Controls.Add(n, 0, i);
                this.tableLayoutPanel1.Controls.Add(p, 1, i);
            }

            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

            this.Refresh();
        }

        private void N_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void newProject()
        {
            Project pr1 = new Project("hi");
            pr1.GetInfo();
            var npwin = new newProjectForm();
            npwin.ShowDialog();
            npwin.Closed += (s, args) => this.Show();
            this.Hide();
        }
        private void newProject(string[] files)
        {
            Project pr1 = new Project("hi");
            pr1.GetInfo();
            var npwin = new newProjectForm(files);
            npwin.ShowDialog();
            npwin.Closed += (s, args) => this.Show();
            this.Hide();
        }

        private void newHardware()
        {
            var hw = new TechnicForm();
            hw.Show();
            this.Hide();
            hw.Closed += (s, args) => this.Show();
            
        }

        private void newStatistics()
        {
            var st = new StatisticsForm();
            st.Show();
            this.Hide();
          /*  st.Closed += (s, args) => this.Show();*/

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
            var hw = new TechnicForm();
            {

            }
        }

        private void panel2_DragLeave(object sender, EventArgs e)
        {
            panel2.BackColor = System.Drawing.Color.FromArgb(31, 191, 117);

        }

        private void panel2_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false) == true)
            {
                e.Effect = DragDropEffects.All;
                panel2.BackColor = System.Drawing.Color.FromArgb(128, 255, 128);
                //31; 191; 117


            }
        }

        private void panel2_DragDrop(object sender, DragEventArgs e)
        {
            panel2.BackColor = System.Drawing.Color.FromArgb(31, 191, 117);
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            newProject(files);

            //  Запускаем форму Нового проекта и передаем массив файлов


        }


        private void label_Click(object sender, EventArgs e)
        {
            int t = -1;
            string path = "None";
            Label label = sender as Label;
            try { 
                t = int.Parse(label.Name.Split('_')[1]);

                /* MessageBox.Show(listlLabels[t].Text);
                 MessageBox.Show(listlLabelName[t].Text);*/
                string tmp = '\\'+listlLabelName[t].Text;
                path = listlLabels[t].Text.TrimEnd(tmp.ToCharArray());

            }
            catch (Exception err)
            {
                Console.WriteLine(err.ToString());
            }

            if (t!=-1 && path !="None")
            {
                ProjectWindow win = new ProjectWindow(listlLabelName[t].Text, path);
                win.Show();
                this.Hide();
            }

        }

       







    }
}
