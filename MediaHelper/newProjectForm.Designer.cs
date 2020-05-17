namespace MediaHelper
{
    partial class newProjectForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.projectNameTextBox = new System.Windows.Forms.TextBox();
            this.okButton = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.fbd = new System.Windows.Forms.FolderBrowserDialog();
            this.dirLabel = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // projectNameTextBox
            // 
            this.projectNameTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(30)))), ((int)(((byte)(42)))));
            this.projectNameTextBox.Font = new System.Drawing.Font("Roboto", 18.25F);
            this.projectNameTextBox.ForeColor = System.Drawing.Color.White;
            this.projectNameTextBox.Location = new System.Drawing.Point(14, 17);
            this.projectNameTextBox.Name = "projectNameTextBox";
            this.projectNameTextBox.Size = new System.Drawing.Size(261, 37);
            this.projectNameTextBox.TabIndex = 2;
            this.projectNameTextBox.Text = "Project Name";
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(33, 158);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(87, 27);
            this.okButton.TabIndex = 4;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(162, 158);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(87, 27);
            this.button2.TabIndex = 5;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // dirLabel
            // 
            this.dirLabel.AutoSize = true;
            this.dirLabel.Font = new System.Drawing.Font("Roboto", 18F);
            this.dirLabel.LinkColor = System.Drawing.Color.White;
            this.dirLabel.Location = new System.Drawing.Point(14, 83);
            this.dirLabel.Name = "dirLabel";
            this.dirLabel.Size = new System.Drawing.Size(197, 29);
            this.dirLabel.TabIndex = 6;
            this.dirLabel.TabStop = true;
            this.dirLabel.Text = "Change Directory";
            this.dirLabel.TextChanged += new System.EventHandler(this.dirLabel_TextChanged);
            this.dirLabel.Click += new System.EventHandler(this.dirLabel_Click);
            // 
            // newProjectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(30)))), ((int)(((byte)(42)))));
            this.ClientSize = new System.Drawing.Size(301, 210);
            this.ControlBox = false;
            this.Controls.Add(this.dirLabel);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.projectNameTextBox);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(317, 249);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(317, 249);
            this.Name = "newProjectForm";
            this.Text = "New Project";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.newProjectForm_FormClosing);
            this.Load += new System.EventHandler(this.newProjectForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox projectNameTextBox;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.FolderBrowserDialog fbd;
        private System.Windows.Forms.LinkLabel dirLabel;
    }
}