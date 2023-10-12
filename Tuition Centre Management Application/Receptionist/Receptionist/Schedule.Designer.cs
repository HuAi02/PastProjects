namespace Group1_IOOP
{
    partial class stdscd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(stdscd));
            this.listbxSch = new System.Windows.Forms.ListBox();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnChgsub = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listbxSch
            // 
            this.listbxSch.AllowDrop = true;
            this.listbxSch.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.listbxSch.BackColor = System.Drawing.SystemColors.ControlDark;
            this.listbxSch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.listbxSch.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.listbxSch.FormattingEnabled = true;
            this.listbxSch.ItemHeight = 25;
            this.listbxSch.Location = new System.Drawing.Point(73, 91);
            this.listbxSch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.listbxSch.Name = "listbxSch";
            this.listbxSch.Size = new System.Drawing.Size(347, 179);
            this.listbxSch.TabIndex = 0;
            // 
            // btnBack
            // 
            this.btnBack.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnBack.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnBack.Location = new System.Drawing.Point(92, 314);
            this.btnBack.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(140, 35);
            this.btnBack.TabIndex = 1;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnChgsub
            // 
            this.btnChgsub.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnChgsub.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChgsub.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnChgsub.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnChgsub.Location = new System.Drawing.Point(265, 314);
            this.btnChgsub.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnChgsub.Name = "btnChgsub";
            this.btnChgsub.Size = new System.Drawing.Size(140, 35);
            this.btnChgsub.TabIndex = 2;
            this.btnChgsub.Text = "Change Subject";
            this.btnChgsub.UseVisualStyleBackColor = true;
            this.btnChgsub.Click += new System.EventHandler(this.btnChgsub_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Location = new System.Drawing.Point(185, 51);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 23);
            this.label1.TabIndex = 3;
            this.label1.Text = "Your Schedule";
            // 
            // stdscd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.ClientSize = new System.Drawing.Size(494, 384);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnChgsub);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.listbxSch);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "stdscd";
            this.Text = "Student Schedule";
            this.Load += new System.EventHandler(this.stdscd_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listbxSch;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnChgsub;
        private System.Windows.Forms.Label label1;
    }
}