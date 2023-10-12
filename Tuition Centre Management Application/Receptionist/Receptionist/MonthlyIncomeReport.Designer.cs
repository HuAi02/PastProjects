namespace Group1_IOOP
{
    partial class MonthlyIncomeReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MonthlyIncomeReport));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.SpecificLeveltb = new System.Windows.Forms.TextBox();
            this.SpecificSubjecttb = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SpecificMonthtb = new System.Windows.Forms.TextBox();
            this.Refreshbt = new System.Windows.Forms.Button();
            this.Calculatebt = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.MonthlyIncomeReporttb = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel3 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
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
            // panel1
            // 
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.SpecificLeveltb);
            this.panel1.Controls.Add(this.SpecificSubjecttb);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.SpecificMonthtb);
            this.panel1.Controls.Add(this.Refreshbt);
            this.panel1.Controls.Add(this.Calculatebt);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(724, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(246, 678);
            this.panel1.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label3.Location = new System.Drawing.Point(32, 224);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(155, 23);
            this.label3.TabIndex = 14;
            this.label3.Text = "Specific Level :";
            // 
            // SpecificLeveltb
            // 
            this.SpecificLeveltb.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.SpecificLeveltb.ForeColor = System.Drawing.Color.Black;
            this.SpecificLeveltb.Location = new System.Drawing.Point(32, 262);
            this.SpecificLeveltb.Name = "SpecificLeveltb";
            this.SpecificLeveltb.Size = new System.Drawing.Size(145, 32);
            this.SpecificLeveltb.TabIndex = 13;
            this.SpecificLeveltb.TextChanged += new System.EventHandler(this.SpecificLeveltb_TextChanged);
            // 
            // SpecificSubjecttb
            // 
            this.SpecificSubjecttb.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.SpecificSubjecttb.ForeColor = System.Drawing.Color.Black;
            this.SpecificSubjecttb.Location = new System.Drawing.Point(32, 177);
            this.SpecificSubjecttb.Name = "SpecificSubjecttb";
            this.SpecificSubjecttb.Size = new System.Drawing.Size(145, 32);
            this.SpecificSubjecttb.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label2.Location = new System.Drawing.Point(32, 148);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(174, 23);
            this.label2.TabIndex = 11;
            this.label2.Text = "Specific Subject :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Location = new System.Drawing.Point(32, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 23);
            this.label1.TabIndex = 9;
            this.label1.Text = "Specific Month:";
            // 
            // SpecificMonthtb
            // 
            this.SpecificMonthtb.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.SpecificMonthtb.ForeColor = System.Drawing.Color.Black;
            this.SpecificMonthtb.Location = new System.Drawing.Point(32, 104);
            this.SpecificMonthtb.Name = "SpecificMonthtb";
            this.SpecificMonthtb.Size = new System.Drawing.Size(145, 32);
            this.SpecificMonthtb.TabIndex = 8;
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
            this.Refreshbt.Location = new System.Drawing.Point(0, 367);
            this.Refreshbt.Name = "Refreshbt";
            this.Refreshbt.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.Refreshbt.Size = new System.Drawing.Size(246, 51);
            this.Refreshbt.TabIndex = 3;
            this.Refreshbt.Text = "Refresh";
            this.Refreshbt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Refreshbt.UseVisualStyleBackColor = true;
            this.Refreshbt.Click += new System.EventHandler(this.Refreshbt_Click);
            // 
            // Calculatebt
            // 
            this.Calculatebt.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Calculatebt.FlatAppearance.BorderSize = 0;
            this.Calculatebt.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.Calculatebt.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.Calculatebt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Calculatebt.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Calculatebt.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.Calculatebt.Location = new System.Drawing.Point(0, 418);
            this.Calculatebt.Name = "Calculatebt";
            this.Calculatebt.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.Calculatebt.Size = new System.Drawing.Size(246, 51);
            this.Calculatebt.TabIndex = 2;
            this.Calculatebt.Text = "Calculate";
            this.Calculatebt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Calculatebt.UseVisualStyleBackColor = true;
            this.Calculatebt.Click += new System.EventHandler(this.Calculatebt_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.MonthlyIncomeReporttb);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 469);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(246, 209);
            this.panel2.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label4.Location = new System.Drawing.Point(29, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(167, 46);
            this.label4.TabIndex = 15;
            this.label4.Text = "Monthly \r\nIncome Report :";
            this.label4.Click += new System.EventHandler(this.label4_Click_1);
            // 
            // MonthlyIncomeReporttb
            // 
            this.MonthlyIncomeReporttb.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.MonthlyIncomeReporttb.ForeColor = System.Drawing.Color.Black;
            this.MonthlyIncomeReporttb.Location = new System.Drawing.Point(32, 101);
            this.MonthlyIncomeReporttb.Name = "MonthlyIncomeReporttb";
            this.MonthlyIncomeReporttb.Size = new System.Drawing.Size(145, 32);
            this.MonthlyIncomeReporttb.TabIndex = 14;
            this.MonthlyIncomeReporttb.TextChanged += new System.EventHandler(this.MonthlyIncomeReporttb_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox1.Location = new System.Drawing.Point(14, 42);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(692, 618);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Data Reference Panel ";
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(721, 678);
            this.panel3.TabIndex = 12;
            // 
            // MonthlyIncomeReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.ClientSize = new System.Drawing.Size(970, 678);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MonthlyIncomeReport";
            this.Text = "Monthly Income Report";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView dataGridView1;
        private Panel panel1;
        private Label label3;
        private TextBox SpecificLeveltb;
        private TextBox SpecificSubjecttb;
        private Label label2;
        private Label label1;
        private TextBox SpecificMonthtb;
        private Button Refreshbt;
        private Button Calculatebt;
        private Panel panel2;
        private Label label4;
        private TextBox MonthlyIncomeReporttb;
        private GroupBox groupBox1;
        private Panel panel3;
    }
}