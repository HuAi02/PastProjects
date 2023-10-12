namespace Group1_IOOP
{
    partial class stdmain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(stdmain));
            this.label1 = new System.Windows.Forms.Label();
            this.lblname = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSch = new System.Windows.Forms.Button();
            this.btnChgsub = new System.Windows.Forms.Button();
            this.lblEditpro = new System.Windows.Forms.Label();
            this.grpbxStdpro = new System.Windows.Forms.GroupBox();
            this.lbllvl = new System.Windows.Forms.Label();
            this.grpbxStdpro.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(38, 50);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "Name:";
            // 
            // lblname
            // 
            this.lblname.AutoSize = true;
            this.lblname.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblname.Location = new System.Drawing.Point(112, 50);
            this.lblname.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblname.Name = "lblname";
            this.lblname.Size = new System.Drawing.Size(75, 20);
            this.lblname.TabIndex = 2;
            this.lblname.Text = "___________";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(38, 107);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 19);
            this.label2.TabIndex = 3;
            this.label2.Text = "Level:";
            // 
            // btnSch
            // 
            this.btnSch.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSch.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnSch.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnSch.Location = new System.Drawing.Point(83, 298);
            this.btnSch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSch.Name = "btnSch";
            this.btnSch.Size = new System.Drawing.Size(174, 35);
            this.btnSch.TabIndex = 4;
            this.btnSch.Text = "View Schedule";
            this.btnSch.UseVisualStyleBackColor = true;
            this.btnSch.Click += new System.EventHandler(this.btnSch_Click);
            // 
            // btnChgsub
            // 
            this.btnChgsub.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnChgsub.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChgsub.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnChgsub.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnChgsub.Location = new System.Drawing.Point(291, 298);
            this.btnChgsub.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnChgsub.Name = "btnChgsub";
            this.btnChgsub.Size = new System.Drawing.Size(174, 35);
            this.btnChgsub.TabIndex = 5;
            this.btnChgsub.Text = "Change Subject";
            this.btnChgsub.UseVisualStyleBackColor = true;
            this.btnChgsub.Click += new System.EventHandler(this.btnChgsub_Click);
            // 
            // lblEditpro
            // 
            this.lblEditpro.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblEditpro.AutoSize = true;
            this.lblEditpro.Font = new System.Drawing.Font("Century Gothic", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point);
            this.lblEditpro.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblEditpro.Location = new System.Drawing.Point(195, 231);
            this.lblEditpro.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEditpro.Name = "lblEditpro";
            this.lblEditpro.Size = new System.Drawing.Size(136, 18);
            this.lblEditpro.TabIndex = 7;
            this.lblEditpro.Text = "Edit Profile Details";
            this.lblEditpro.Click += new System.EventHandler(this.lblEditpro_Click);
            // 
            // grpbxStdpro
            // 
            this.grpbxStdpro.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.grpbxStdpro.Controls.Add(this.lbllvl);
            this.grpbxStdpro.Controls.Add(this.label1);
            this.grpbxStdpro.Controls.Add(this.lblname);
            this.grpbxStdpro.Controls.Add(this.label2);
            this.grpbxStdpro.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.grpbxStdpro.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.grpbxStdpro.Location = new System.Drawing.Point(144, 66);
            this.grpbxStdpro.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpbxStdpro.Name = "grpbxStdpro";
            this.grpbxStdpro.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpbxStdpro.Size = new System.Drawing.Size(228, 160);
            this.grpbxStdpro.TabIndex = 8;
            this.grpbxStdpro.TabStop = false;
            this.grpbxStdpro.Text = "Student Profile";
            // 
            // lbllvl
            // 
            this.lbllvl.AutoSize = true;
            this.lbllvl.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbllvl.Location = new System.Drawing.Point(112, 107);
            this.lbllvl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbllvl.Name = "lbllvl";
            this.lbllvl.Size = new System.Drawing.Size(75, 20);
            this.lbllvl.TabIndex = 4;
            this.lbllvl.Text = "___________";
            // 
            // stdmain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.ClientSize = new System.Drawing.Size(529, 423);
            this.Controls.Add(this.grpbxStdpro);
            this.Controls.Add(this.lblEditpro);
            this.Controls.Add(this.btnChgsub);
            this.Controls.Add(this.btnSch);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "stdmain";
            this.Text = "Excellent Tuition Centre";
            this.grpbxStdpro.ResumeLayout(false);
            this.grpbxStdpro.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblname;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSch;
        private System.Windows.Forms.Button btnChgsub;
        private System.Windows.Forms.Label lblEditpro;
        private System.Windows.Forms.GroupBox grpbxStdpro;
        private System.Windows.Forms.Label lbllvl;
    }
}

