namespace Group1_IOOP
{
    partial class MainMenu
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenu));
            this.panel1 = new System.Windows.Forms.Panel();
            this.LogOutbt = new System.Windows.Forms.Button();
            this.EditProfilebt = new System.Windows.Forms.Button();
            this.AdminstrativeServicebt = new System.Windows.Forms.Button();
            this.ViewMonthlyReportbt = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.Usernamelb = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panelChildForm = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AccessibleRole = System.Windows.Forms.AccessibleRole.Document;
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(7)))), ((int)(((byte)(17)))));
            this.panel1.Controls.Add(this.LogOutbt);
            this.panel1.Controls.Add(this.EditProfilebt);
            this.panel1.Controls.Add(this.AdminstrativeServicebt);
            this.panel1.Controls.Add(this.ViewMonthlyReportbt);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(258, 725);
            this.panel1.TabIndex = 0;
            // 
            // LogOutbt
            // 
            this.LogOutbt.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.LogOutbt.FlatAppearance.BorderSize = 0;
            this.LogOutbt.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.LogOutbt.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.LogOutbt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LogOutbt.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LogOutbt.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.LogOutbt.Location = new System.Drawing.Point(0, 674);
            this.LogOutbt.Name = "LogOutbt";
            this.LogOutbt.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.LogOutbt.Size = new System.Drawing.Size(258, 51);
            this.LogOutbt.TabIndex = 5;
            this.LogOutbt.Text = "Log Out";
            this.LogOutbt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LogOutbt.UseVisualStyleBackColor = true;
            this.LogOutbt.Click += new System.EventHandler(this.button5_Click);
            // 
            // EditProfilebt
            // 
            this.EditProfilebt.Dock = System.Windows.Forms.DockStyle.Top;
            this.EditProfilebt.FlatAppearance.BorderSize = 0;
            this.EditProfilebt.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.EditProfilebt.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.EditProfilebt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EditProfilebt.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.EditProfilebt.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.EditProfilebt.Location = new System.Drawing.Point(0, 368);
            this.EditProfilebt.Name = "EditProfilebt";
            this.EditProfilebt.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.EditProfilebt.Size = new System.Drawing.Size(258, 51);
            this.EditProfilebt.TabIndex = 4;
            this.EditProfilebt.Text = "Edit Profile ";
            this.EditProfilebt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.EditProfilebt.UseVisualStyleBackColor = true;
            this.EditProfilebt.Click += new System.EventHandler(this.button4_Click_1);
            // 
            // AdminstrativeServicebt
            // 
            this.AdminstrativeServicebt.Dock = System.Windows.Forms.DockStyle.Top;
            this.AdminstrativeServicebt.FlatAppearance.BorderSize = 0;
            this.AdminstrativeServicebt.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.AdminstrativeServicebt.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.AdminstrativeServicebt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AdminstrativeServicebt.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.AdminstrativeServicebt.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.AdminstrativeServicebt.Location = new System.Drawing.Point(0, 317);
            this.AdminstrativeServicebt.Name = "AdminstrativeServicebt";
            this.AdminstrativeServicebt.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.AdminstrativeServicebt.Size = new System.Drawing.Size(258, 51);
            this.AdminstrativeServicebt.TabIndex = 2;
            this.AdminstrativeServicebt.Text = "Administrative Service";
            this.AdminstrativeServicebt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.AdminstrativeServicebt.UseVisualStyleBackColor = true;
            this.AdminstrativeServicebt.Click += new System.EventHandler(this.button2_Click);
            // 
            // ViewMonthlyReportbt
            // 
            this.ViewMonthlyReportbt.Dock = System.Windows.Forms.DockStyle.Top;
            this.ViewMonthlyReportbt.FlatAppearance.BorderSize = 0;
            this.ViewMonthlyReportbt.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.ViewMonthlyReportbt.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.ViewMonthlyReportbt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ViewMonthlyReportbt.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ViewMonthlyReportbt.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.ViewMonthlyReportbt.Location = new System.Drawing.Point(0, 266);
            this.ViewMonthlyReportbt.Name = "ViewMonthlyReportbt";
            this.ViewMonthlyReportbt.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.ViewMonthlyReportbt.Size = new System.Drawing.Size(258, 51);
            this.ViewMonthlyReportbt.TabIndex = 1;
            this.ViewMonthlyReportbt.Text = "View Monthly Report";
            this.ViewMonthlyReportbt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ViewMonthlyReportbt.UseVisualStyleBackColor = true;
            this.ViewMonthlyReportbt.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.Usernamelb);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(258, 266);
            this.panel2.TabIndex = 0;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // Usernamelb
            // 
            this.Usernamelb.AutoSize = true;
            this.Usernamelb.Font = new System.Drawing.Font("Lucida Calligraphy", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Usernamelb.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.Usernamelb.Location = new System.Drawing.Point(80, 124);
            this.Usernamelb.Name = "Usernamelb";
            this.Usernamelb.Size = new System.Drawing.Size(88, 29);
            this.Usernamelb.TabIndex = 1;
            this.Usernamelb.Text = "Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.SystemColors.Window;
            this.label1.Location = new System.Drawing.Point(43, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Welcome,";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // panelChildForm
            // 
            this.panelChildForm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.panelChildForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelChildForm.Location = new System.Drawing.Point(258, 0);
            this.panelChildForm.Name = "panelChildForm";
            this.panelChildForm.Size = new System.Drawing.Size(988, 725);
            this.panelChildForm.TabIndex = 1;
            this.panelChildForm.Paint += new System.Windows.Forms.PaintEventHandler(this.panelChildform_Paint);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1246, 725);
            this.Controls.Add(this.panelChildForm);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainMenu";
            this.Text = "MainMenu";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Button EditProfilebt;
        private Button AdminstrativeServicebt;
        private Button ViewMonthlyReportbt;
        private Button LogOutbt;
        private Panel panelChildForm;
        public Label Usernamelb;
        private Label label1;
    }
}