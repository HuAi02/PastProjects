namespace Group1_IOOP
{
    partial class Administeration
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Administeration));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SpecificUserIDtb = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Viewbt = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SpecificRoletb = new System.Windows.Forms.TextBox();
            this.Refreshbt = new System.Windows.Forms.Button();
            this.Addbt = new System.Windows.Forms.Button();
            this.Updatebt = new System.Windows.Forms.Button();
            this.Deletebt = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(14, 42);
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.MenuText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.RowHeadersWidth = 51;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.RowTemplate.Height = 29;
            this.dataGridView1.Size = new System.Drawing.Size(662, 556);
            this.dataGridView1.TabIndex = 4;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox1.Location = new System.Drawing.Point(28, 42);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(692, 618);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Administrative Panel ";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.SpecificUserIDtb);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.Viewbt);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.SpecificRoletb);
            this.panel1.Controls.Add(this.Refreshbt);
            this.panel1.Controls.Add(this.Addbt);
            this.panel1.Controls.Add(this.Updatebt);
            this.panel1.Controls.Add(this.Deletebt);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(724, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(246, 678);
            this.panel1.TabIndex = 9;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // SpecificUserIDtb
            // 
            this.SpecificUserIDtb.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.SpecificUserIDtb.ForeColor = System.Drawing.Color.Black;
            this.SpecificUserIDtb.Location = new System.Drawing.Point(32, 177);
            this.SpecificUserIDtb.Name = "SpecificUserIDtb";
            this.SpecificUserIDtb.Size = new System.Drawing.Size(145, 32);
            this.SpecificUserIDtb.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label2.Location = new System.Drawing.Point(32, 148);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(162, 23);
            this.label2.TabIndex = 11;
            this.label2.Text = "Specific UserID :";
            // 
            // Viewbt
            // 
            this.Viewbt.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Viewbt.FlatAppearance.BorderSize = 0;
            this.Viewbt.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.Viewbt.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.Viewbt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Viewbt.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Viewbt.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.Viewbt.Location = new System.Drawing.Point(0, 212);
            this.Viewbt.Name = "Viewbt";
            this.Viewbt.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.Viewbt.Size = new System.Drawing.Size(246, 51);
            this.Viewbt.TabIndex = 10;
            this.Viewbt.Text = "View";
            this.Viewbt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Viewbt.UseVisualStyleBackColor = true;
            this.Viewbt.Click += new System.EventHandler(this.View_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Location = new System.Drawing.Point(32, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 23);
            this.label1.TabIndex = 9;
            this.label1.Text = "Specific Role :";
            // 
            // SpecificRoletb
            // 
            this.SpecificRoletb.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.SpecificRoletb.ForeColor = System.Drawing.Color.Black;
            this.SpecificRoletb.Location = new System.Drawing.Point(32, 104);
            this.SpecificRoletb.Name = "SpecificRoletb";
            this.SpecificRoletb.Size = new System.Drawing.Size(145, 32);
            this.SpecificRoletb.TabIndex = 8;
            this.SpecificRoletb.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // Refreshbt
            // 
            this.Refreshbt.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Refreshbt.FlatAppearance.BorderSize = 0;
            this.Refreshbt.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.Refreshbt.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.Refreshbt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Refreshbt.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Refreshbt.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.Refreshbt.Location = new System.Drawing.Point(0, 263);
            this.Refreshbt.Name = "Refreshbt";
            this.Refreshbt.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.Refreshbt.Size = new System.Drawing.Size(246, 51);
            this.Refreshbt.TabIndex = 6;
            this.Refreshbt.Text = "Refresh";
            this.Refreshbt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Refreshbt.UseVisualStyleBackColor = true;
            this.Refreshbt.Click += new System.EventHandler(this.button5_Click);
            // 
            // Addbt
            // 
            this.Addbt.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Addbt.FlatAppearance.BorderSize = 0;
            this.Addbt.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.Addbt.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.Addbt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Addbt.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Addbt.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.Addbt.Location = new System.Drawing.Point(0, 314);
            this.Addbt.Name = "Addbt";
            this.Addbt.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.Addbt.Size = new System.Drawing.Size(246, 53);
            this.Addbt.TabIndex = 4;
            this.Addbt.Text = "Add";
            this.Addbt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Addbt.UseVisualStyleBackColor = true;
            this.Addbt.Click += new System.EventHandler(this.Add_Click);
            // 
            // Updatebt
            // 
            this.Updatebt.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Updatebt.FlatAppearance.BorderSize = 0;
            this.Updatebt.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.Updatebt.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.Updatebt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Updatebt.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Updatebt.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.Updatebt.Location = new System.Drawing.Point(0, 367);
            this.Updatebt.Name = "Updatebt";
            this.Updatebt.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.Updatebt.Size = new System.Drawing.Size(246, 51);
            this.Updatebt.TabIndex = 3;
            this.Updatebt.Text = "Update";
            this.Updatebt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Updatebt.UseVisualStyleBackColor = true;
            this.Updatebt.Click += new System.EventHandler(this.Update_Click);
            // 
            // Deletebt
            // 
            this.Deletebt.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Deletebt.FlatAppearance.BorderSize = 0;
            this.Deletebt.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.Deletebt.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.Deletebt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Deletebt.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Deletebt.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.Deletebt.Location = new System.Drawing.Point(0, 418);
            this.Deletebt.Name = "Deletebt";
            this.Deletebt.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.Deletebt.Size = new System.Drawing.Size(246, 51);
            this.Deletebt.TabIndex = 2;
            this.Deletebt.Text = "Delete";
            this.Deletebt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Deletebt.UseVisualStyleBackColor = true;
            this.Deletebt.Click += new System.EventHandler(this.Delete_Click);
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 469);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(246, 209);
            this.panel2.TabIndex = 0;
            // 
            // Administeration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.ClientSize = new System.Drawing.Size(970, 678);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Administeration";
            this.Text = "Administeration";
            this.Load += new System.EventHandler(this.Form3_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private DataGridView dataGridView1;
        private GroupBox groupBox1;
        private Panel panel1;
        private Panel panel2;
        private Button Addbt;
        private Button Updatebt;
        private Button Deletebt;
        private Button Refreshbt;
        private Label label1;
        private TextBox SpecificRoletb;
        private Button Viewbt;
        private TextBox SpecificUserIDtb;
        private Label label2;
    }
}