using System.Data;

namespace Group1_IOOP
{
    partial class DetailsInformation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DetailsInformation));
            this.btnBack = new System.Windows.Forms.Button();
            this.grpbxClassInf = new System.Windows.Forms.GroupBox();
            this.grpbxDnT = new System.Windows.Forms.GroupBox();
            this.label_Time = new System.Windows.Forms.Label();
            this.grpbxCharges = new System.Windows.Forms.GroupBox();
            this.label_Charges = new System.Windows.Forms.Label();
            this.grpbxSubName = new System.Windows.Forms.GroupBox();
            this.label_Subject = new System.Windows.Forms.Label();
            this.grpbxStuList = new System.Windows.Forms.GroupBox();
            this.listbxStuList = new System.Windows.Forms.ListBox();
            this.grpbxClassInf.SuspendLayout();
            this.grpbxDnT.SuspendLayout();
            this.grpbxCharges.SuspendLayout();
            this.grpbxSubName.SuspendLayout();
            this.grpbxStuList.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnBack
            // 
            this.btnBack.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.btnBack.Location = new System.Drawing.Point(4, 393);
            this.btnBack.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(190, 30);
            this.btnBack.TabIndex = 0;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // grpbxClassInf
            // 
            this.grpbxClassInf.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.grpbxClassInf.Controls.Add(this.grpbxDnT);
            this.grpbxClassInf.Controls.Add(this.btnBack);
            this.grpbxClassInf.Controls.Add(this.grpbxCharges);
            this.grpbxClassInf.Controls.Add(this.grpbxSubName);
            this.grpbxClassInf.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.grpbxClassInf.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.grpbxClassInf.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.grpbxClassInf.Location = new System.Drawing.Point(14, 11);
            this.grpbxClassInf.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.grpbxClassInf.Name = "grpbxClassInf";
            this.grpbxClassInf.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.grpbxClassInf.Size = new System.Drawing.Size(198, 426);
            this.grpbxClassInf.TabIndex = 1;
            this.grpbxClassInf.TabStop = false;
            this.grpbxClassInf.Text = "Class Information";
            // 
            // grpbxDnT
            // 
            this.grpbxDnT.Controls.Add(this.label_Time);
            this.grpbxDnT.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.grpbxDnT.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.grpbxDnT.Location = new System.Drawing.Point(8, 129);
            this.grpbxDnT.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.grpbxDnT.Name = "grpbxDnT";
            this.grpbxDnT.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.grpbxDnT.Size = new System.Drawing.Size(186, 47);
            this.grpbxDnT.TabIndex = 2;
            this.grpbxDnT.TabStop = false;
            this.grpbxDnT.Text = "Time";
            // 
            // label_Time
            // 
            this.label_Time.AccessibleName = "";
            this.label_Time.AutoSize = true;
            this.label_Time.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label_Time.Location = new System.Drawing.Point(6, 19);
            this.label_Time.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Time.Name = "label_Time";
            this.label_Time.Size = new System.Drawing.Size(0, 20);
            this.label_Time.TabIndex = 0;
            // 
            // grpbxCharges
            // 
            this.grpbxCharges.Controls.Add(this.label_Charges);
            this.grpbxCharges.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.grpbxCharges.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.grpbxCharges.Location = new System.Drawing.Point(6, 75);
            this.grpbxCharges.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.grpbxCharges.Name = "grpbxCharges";
            this.grpbxCharges.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.grpbxCharges.Size = new System.Drawing.Size(186, 48);
            this.grpbxCharges.TabIndex = 1;
            this.grpbxCharges.TabStop = false;
            this.grpbxCharges.Text = "Charges(RM)";
            // 
            // label_Charges
            // 
            this.label_Charges.AutoSize = true;
            this.label_Charges.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label_Charges.Location = new System.Drawing.Point(6, 18);
            this.label_Charges.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Charges.Name = "label_Charges";
            this.label_Charges.Size = new System.Drawing.Size(0, 20);
            this.label_Charges.TabIndex = 0;
            // 
            // grpbxSubName
            // 
            this.grpbxSubName.Controls.Add(this.label_Subject);
            this.grpbxSubName.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.grpbxSubName.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.grpbxSubName.Location = new System.Drawing.Point(8, 22);
            this.grpbxSubName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.grpbxSubName.Name = "grpbxSubName";
            this.grpbxSubName.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.grpbxSubName.Size = new System.Drawing.Size(186, 47);
            this.grpbxSubName.TabIndex = 0;
            this.grpbxSubName.TabStop = false;
            this.grpbxSubName.Text = "Subject Name";
            // 
            // label_Subject
            // 
            this.label_Subject.AutoSize = true;
            this.label_Subject.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label_Subject.Location = new System.Drawing.Point(6, 18);
            this.label_Subject.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Subject.Name = "label_Subject";
            this.label_Subject.Size = new System.Drawing.Size(0, 20);
            this.label_Subject.TabIndex = 0;
            // 
            // grpbxStuList
            // 
            this.grpbxStuList.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.grpbxStuList.Controls.Add(this.listbxStuList);
            this.grpbxStuList.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.grpbxStuList.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.grpbxStuList.Location = new System.Drawing.Point(228, 11);
            this.grpbxStuList.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.grpbxStuList.Name = "grpbxStuList";
            this.grpbxStuList.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.grpbxStuList.Size = new System.Drawing.Size(570, 426);
            this.grpbxStuList.TabIndex = 2;
            this.grpbxStuList.TabStop = false;
            this.grpbxStuList.Text = "Student List";
            // 
            // listbxStuList
            // 
            this.listbxStuList.BackColor = System.Drawing.SystemColors.ControlDark;
            this.listbxStuList.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.listbxStuList.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.listbxStuList.FormattingEnabled = true;
            this.listbxStuList.ItemHeight = 23;
            this.listbxStuList.Location = new System.Drawing.Point(12, 26);
            this.listbxStuList.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.listbxStuList.Name = "listbxStuList";
            this.listbxStuList.Size = new System.Drawing.Size(558, 395);
            this.listbxStuList.TabIndex = 0;
            // 
            // DetailsInformation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.ClientSize = new System.Drawing.Size(813, 450);
            this.Controls.Add(this.grpbxStuList);
            this.Controls.Add(this.grpbxClassInf);
            this.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "DetailsInformation";
            this.Text = "Excellent Tuition Centre(ETC)";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.DetailsInformation_FormClosed);
            this.Load += new System.EventHandler(this.DetailsInformation_Load);
            this.grpbxClassInf.ResumeLayout(false);
            this.grpbxDnT.ResumeLayout(false);
            this.grpbxDnT.PerformLayout();
            this.grpbxCharges.ResumeLayout(false);
            this.grpbxCharges.PerformLayout();
            this.grpbxSubName.ResumeLayout(false);
            this.grpbxSubName.PerformLayout();
            this.grpbxStuList.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Button btnBack;
        private GroupBox grpbxClassInf;
        private GroupBox grpbxStuList;
        private GroupBox grpbxDnT;
        public Label label_Time;
        private GroupBox grpbxCharges;
        public Label label_Charges;
        private GroupBox grpbxSubName;
        public Label label_Subject;
        private ListBox listbxStuList;
    }
}