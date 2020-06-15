using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace MediaHelper
{
    public partial class StartForm : BaseForm
    {
        public StartForm()
        {
            InitializeComponent();
        }

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
            int counter = 0;
            for (int i = 0; i < projects.Count; i++)
            {
                if (Directory.Exists(projects[i].Path))
                {
                    Label n = new Label();
                    n.Name = "prj_" + counter.ToString();
                    n.Width = 300;
                    n.Font = new Font("Roboto", 10, FontStyle.Bold);
                    n.ForeColor = Color.White;
                    n.Text = projects[i].Name;
                    n.Click += new EventHandler(this.label_Click);
                    n.Cursor = Cursors.Hand;
                    listlLabelName.Add(n);

                    Label p = new Label();
                    p.Name = "path_" + counter.ToString();
                    p.Width = 300;
                    p.Font = new Font("Roboto", 8, FontStyle.Regular);
                    p.ForeColor = Color.White;
                    p.Text = projects[i].Path;
                    p.Click += new EventHandler(this.label_Click);
                    p.Cursor = Cursors.Hand;

                    listlLabels.Add(p);

                    this.tableLayoutPanel1.Controls.Add(n, 0, counter);
                    this.tableLayoutPanel1.Controls.Add(p, 1, counter);
                    counter++;
                }
            }

            panel2.Cursor = Cursors.Hand;
            hardwarePanel.Cursor = Cursors.Hand;

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

            }
        }

        private void panel2_DragDrop(object sender, DragEventArgs e)
        {
            //  Запускаем форму Нового проекта и передаем массив файлов

            panel2.BackColor = System.Drawing.Color.FromArgb(31, 191, 117);
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            newProject(files);

        }


        private void label_Click(object sender, EventArgs e)
        {
            int t = -1;
            string path = "None";
            Label label = sender as Label;
            try { 
                t = int.Parse(label.Name.Split('_')[1]);

                if (Directory.Exists(listlLabels[t].Text))
                {
                    string tmp = '\\' + listlLabelName[t].Text;
                    path = listlLabels[t].Text.TrimEnd(tmp.ToCharArray());
                }
                else {
                    MessageBox.Show("Проект не найден");
                };
                

            }
            catch (Exception err)
            {
                Console.WriteLine(err.ToString());
            }

            if (t!=-1 && path !="None" && Directory.Exists(path) )
            {
                Console.WriteLine(path + "ЫЫЫ");
                ProjectWindow win = new ProjectWindow(listlLabelName[t].Text, path);
                win.Closed += (s, args) => this.Show();
                win.Show();
                this.Hide();
            }

        }

        private void hardwarePanel_MouseHover(object sender, EventArgs e)
        {
            hardwarePanel.BackColor = System.Drawing.Color.FromArgb(102, 191, 255);

        }
        private void hardwarePanel_MouseLeave(object sender, EventArgs e)
        {
            hardwarePanel.BackColor = System.Drawing.Color.FromArgb(51, 169, 255);

        }

        private void panel2_MouseHover(object sender, EventArgs e)
        {
            panel2.BackColor = System.Drawing.Color.FromArgb(53, 222, 143);

        }

        private void panel2_MouseLeave(object sender, EventArgs e)
        {
            panel2.BackColor = System.Drawing.Color.FromArgb(31, 191, 117);

        }
        
    }
}
