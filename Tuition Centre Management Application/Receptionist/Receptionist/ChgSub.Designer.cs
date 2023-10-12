namespace Group1_IOOP
{
    partial class stdviewsub
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(stdviewsub));
            this.grpbxRequest = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbbxChange = new System.Windows.Forms.ComboBox();
            this.cmbbxSubject = new System.Windows.Forms.ComboBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.grpbxPending = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbbxDelete = new System.Windows.Forms.ComboBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.listbxTaken = new System.Windows.Forms.ListBox();
            this.listbxPending = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.grpbxRequest.SuspendLayout();
            this.grpbxPending.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpbxRequest
            // 
            this.grpbxRequest.BackColor = System.Drawing.Color.Transparent;
            this.grpbxRequest.Controls.Add(this.label2);
            this.grpbxRequest.Controls.Add(this.label1);
            this.grpbxRequest.Controls.Add(this.cmbbxChange);
            this.grpbxRequest.Controls.Add(this.cmbbxSubject);
            this.grpbxRequest.Controls.Add(this.btnSubmit);
            this.grpbxRequest.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.grpbxRequest.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.grpbxRequest.Location = new System.Drawing.Point(410, 25);
            this.grpbxRequest.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpbxRequest.Name = "grpbxRequest";
            this.grpbxRequest.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpbxRequest.Size = new System.Drawing.Size(389, 194);
            this.grpbxRequest.TabIndex = 0;
            this.grpbxRequest.TabStop = false;
            this.grpbxRequest.Text = "Subject Change Request";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(35, 90);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 19);
            this.label2.TabIndex = 5;
            this.label2.Text = "Changed to:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(35, 50);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 19);
            this.label1.TabIndex = 4;
            this.label1.Text = "Subject:";
            // 
            // cmbbxChange
            // 
            this.cmbbxChange.FormattingEnabled = true;
            this.cmbbxChange.Location = new System.Drawing.Point(181, 85);
            this.cmbbxChange.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbbxChange.Name = "cmbbxChange";
            this.cmbbxChange.Size = new System.Drawing.Size(160, 31);
            this.cmbbxChange.TabIndex = 3;
            // 
            // cmbbxSubject
            // 
            this.cmbbxSubject.FormattingEnabled = true;
            this.cmbbxSubject.Location = new System.Drawing.Point(181, 44);
            this.cmbbxSubject.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbbxSubject.Name = "cmbbxSubject";
            this.cmbbxSubject.Size = new System.Drawing.Size(160, 31);
            this.cmbbxSubject.TabIndex = 2;
            // 
            // btnSubmit
            // 
            this.btnSubmit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.btnSubmit.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnSubmit.FlatAppearance.BorderSize = 0;
            this.btnSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubmit.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.btnSubmit.Location = new System.Drawing.Point(4, 134);
            this.btnSubmit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(381, 55);
            this.btnSubmit.TabIndex = 1;
            this.btnSubmit.Text = "Submit Request";
            this.btnSubmit.UseVisualStyleBackColor = false;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // grpbxPending
            // 
            this.grpbxPending.Controls.Add(this.label3);
            this.grpbxPending.Controls.Add(this.cmbbxDelete);
            this.grpbxPending.Controls.Add(this.btnDelete);
            this.grpbxPending.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.grpbxPending.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.grpbxPending.Location = new System.Drawing.Point(410, 228);
            this.grpbxPending.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpbxPending.Name = "grpbxPending";
            this.grpbxPending.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpbxPending.Size = new System.Drawing.Size(389, 205);
            this.grpbxPending.TabIndex = 1;
            this.grpbxPending.TabStop = false;
            this.grpbxPending.Text = "Delete Pending Request";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(35, 74);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(139, 19);
            this.label3.TabIndex = 4;
            this.label3.Text = "Cancel request:";
            // 
            // cmbbxDelete
            // 
            this.cmbbxDelete.FormattingEnabled = true;
            this.cmbbxDelete.Location = new System.Drawing.Point(181, 69);
            this.cmbbxDelete.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbbxDelete.Name = "cmbbxDelete";
            this.cmbbxDelete.Size = new System.Drawing.Size(160, 31);
            this.cmbbxDelete.TabIndex = 3;
            // 
            // btnDelete
            // 
            this.btnDelete.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.btnDelete.Location = new System.Drawing.Point(4, 145);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(381, 55);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Delete Request";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // listbxTaken
            // 
            this.listbxTaken.BackColor = System.Drawing.SystemColors.ControlDark;
            this.listbxTaken.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.listbxTaken.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.listbxTaken.FormattingEnabled = true;
            this.listbxTaken.ItemHeight = 25;
            this.listbxTaken.Location = new System.Drawing.Point(23, 44);
            this.listbxTaken.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.listbxTaken.Name = "listbxTaken";
            this.listbxTaken.Size = new System.Drawing.Size(335, 154);
            this.listbxTaken.TabIndex = 2;
            // 
            // listbxPending
            // 
            this.listbxPending.BackColor = System.Drawing.SystemColors.ControlDark;
            this.listbxPending.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.listbxPending.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.listbxPending.FormattingEnabled = true;
            this.listbxPending.ItemHeight = 25;
            this.listbxPending.Location = new System.Drawing.Point(23, 254);
            this.listbxPending.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.listbxPending.Name = "listbxPending";
            this.listbxPending.Size = new System.Drawing.Size(335, 179);
            this.listbxPending.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label4.Location = new System.Drawing.Point(19, 16);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(155, 23);
            this.label4.TabIndex = 4;
            this.label4.Text = "Subjects Taken";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label5.Location = new System.Drawing.Point(19, 227);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(182, 23);
            this.label5.TabIndex = 5;
            this.label5.Text = "Pending Requests";
            // 
            // btnBack
            // 
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnBack.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnBack.Location = new System.Drawing.Point(23, 443);
            this.btnBack.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(125, 51);
            this.btnBack.TabIndex = 6;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.Controls.Add(this.listbxTaken);
            this.panel1.Controls.Add(this.btnBack);
            this.panel1.Controls.Add(this.grpbxRequest);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.grpbxPending);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.listbxPending);
            this.panel1.Location = new System.Drawing.Point(47, 97);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(822, 507);
            this.panel1.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(47, 45);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(167, 23);
            this.label6.TabIndex = 8;
            this.label6.Text = "Change Subject";
            // 
            // stdviewsub
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.ClientSize = new System.Drawing.Size(931, 643);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "stdviewsub";
            this.Text = "Change Subject";
            this.Load += new System.EventHandler(this.stdviewsub_Load);
            this.grpbxRequest.ResumeLayout(false);
            this.grpbxRequest.PerformLayout();
            this.grpbxPending.ResumeLayout(false);
            this.grpbxPending.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpbxRequest;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.GroupBox grpbxPending;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.ComboBox cmbbxChange;
        private System.Windows.Forms.ComboBox cmbbxSubject;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbbxDelete;
        private System.Windows.Forms.ListBox listbxTaken;
        private System.Windows.Forms.ListBox listbxPending;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnBack;
        private Panel panel1;
        private Label label6;
    }
}