namespace Group1_IOOP
{
    partial class Requests
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Requests));
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lstbxName = new System.Windows.Forms.ListBox();
            this.lstbxID = new System.Windows.Forms.ListBox();
            this.lblIndex = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lblName = new System.Windows.Forms.Label();
            this.txtbxSearch = new System.Windows.Forms.TextBox();
            this.btnView = new System.Windows.Forms.Button();
            this.lblForm = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Controls.Add(this.lblIndex);
            this.panel2.Controls.Add(this.btnSearch);
            this.panel2.Controls.Add(this.lblName);
            this.panel2.Controls.Add(this.txtbxSearch);
            this.panel2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.Location = new System.Drawing.Point(-4, 168);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(534, 270);
            this.panel2.TabIndex = 23;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.lstbxName);
            this.panel1.Controls.Add(this.lstbxID);
            this.panel1.Location = new System.Drawing.Point(3, 63);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(525, 204);
            this.panel1.TabIndex = 23;
            // 
            // lstbxName
            // 
            this.lstbxName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstbxName.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lstbxName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstbxName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lstbxName.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lstbxName.FormattingEnabled = true;
            this.lstbxName.ItemHeight = 25;
            this.lstbxName.Location = new System.Drawing.Point(129, 14);
            this.lstbxName.Name = "lstbxName";
            this.lstbxName.Size = new System.Drawing.Size(383, 175);
            this.lstbxName.TabIndex = 27;
            this.lstbxName.SelectedIndexChanged += new System.EventHandler(this.lstbxName_SelectedIndexChanged);
            // 
            // lstbxID
            // 
            this.lstbxID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lstbxID.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lstbxID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstbxID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lstbxID.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lstbxID.FormattingEnabled = true;
            this.lstbxID.ItemHeight = 25;
            this.lstbxID.Location = new System.Drawing.Point(16, 14);
            this.lstbxID.Name = "lstbxID";
            this.lstbxID.Size = new System.Drawing.Size(97, 175);
            this.lstbxID.TabIndex = 0;
            this.lstbxID.SelectedIndexChanged += new System.EventHandler(this.lstbxID_SelectedIndexChanged);
            // 
            // lblIndex
            // 
            this.lblIndex.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblIndex.AutoSize = true;
            this.lblIndex.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblIndex.Location = new System.Drawing.Point(40, 31);
            this.lblIndex.Name = "lblIndex";
            this.lblIndex.Size = new System.Drawing.Size(39, 21);
            this.lblIndex.TabIndex = 19;
            this.lblIndex.Text = "No.";
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnSearch.Location = new System.Drawing.Point(403, 21);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(111, 38);
            this.btnSearch.TabIndex = 26;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lblName
            // 
            this.lblName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblName.Location = new System.Drawing.Point(142, 31);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(61, 21);
            this.lblName.TabIndex = 20;
            this.lblName.Text = "Name";
            // 
            // txtbxSearch
            // 
            this.txtbxSearch.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.txtbxSearch.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtbxSearch.Location = new System.Drawing.Point(229, 23);
            this.txtbxSearch.Name = "txtbxSearch";
            this.txtbxSearch.Size = new System.Drawing.Size(168, 34);
            this.txtbxSearch.TabIndex = 25;
            // 
            // btnView
            // 
            this.btnView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnView.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnView.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnView.Location = new System.Drawing.Point(400, 40);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(111, 38);
            this.btnView.TabIndex = 13;
            this.btnView.Text = "View";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // lblForm
            // 
            this.lblForm.AutoSize = true;
            this.lblForm.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblForm.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblForm.Location = new System.Drawing.Point(42, 47);
            this.lblForm.Name = "lblForm";
            this.lblForm.Size = new System.Drawing.Size(97, 23);
            this.lblForm.TabIndex = 24;
            this.lblForm.Text = "Requests";
            // 
            // Requests
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.ClientSize = new System.Drawing.Size(523, 427);
            this.Controls.Add(this.btnView);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.lblForm);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Requests";
            this.Text = "Requests";
            this.Load += new System.EventHandler(this.Requests_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Panel panel2;
        private Panel panel1;
        private Button btnView;
        private Label lblIndex;
        private Label lblName;
        private Button btnSearch;
        private TextBox txtbxSearch;
        private Label lblForm;
        private ListBox lstbxName;
        private ListBox lstbxID;
    }
}