namespace Group1_IOOP
{
    partial class EditProfile
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditProfile));
            this.NewUsernametb = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.NewPasswordtb = new System.Windows.Forms.TextBox();
            this.Applychangesbt = new System.Windows.Forms.Button();
            this.Clearbt = new System.Windows.Forms.Button();
            this.NewGmailtb = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // NewUsernametb
            // 
            this.NewUsernametb.BackColor = System.Drawing.Color.Silver;
            this.NewUsernametb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.NewUsernametb.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.NewUsernametb.ForeColor = System.Drawing.Color.DimGray;
            this.NewUsernametb.Location = new System.Drawing.Point(394, 324);
            this.NewUsernametb.Name = "NewUsernametb";
            this.NewUsernametb.PlaceholderText = "(Enter Username)";
            this.NewUsernametb.Size = new System.Drawing.Size(362, 25);
            this.NewUsernametb.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Bodoni MT Condensed", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(170, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(208, 56);
            this.label1.TabIndex = 0;
            this.label1.Text = "Profile Edit ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(180, 327);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(171, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "New Username :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Location = new System.Drawing.Point(180, 386);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(166, 23);
            this.label4.TabIndex = 4;
            this.label4.Text = "New Password :";
            // 
            // NewPasswordtb
            // 
            this.NewPasswordtb.BackColor = System.Drawing.Color.Silver;
            this.NewPasswordtb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.NewPasswordtb.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.NewPasswordtb.ForeColor = System.Drawing.Color.DimGray;
            this.NewPasswordtb.Location = new System.Drawing.Point(394, 386);
            this.NewPasswordtb.Name = "NewPasswordtb";
            this.NewPasswordtb.PlaceholderText = "(Enter New Password)";
            this.NewPasswordtb.Size = new System.Drawing.Size(362, 25);
            this.NewPasswordtb.TabIndex = 5;
            this.NewPasswordtb.TextChanged += new System.EventHandler(this.NewPassword_TextChanged);
            // 
            // Applychangesbt
            // 
            this.Applychangesbt.BackColor = System.Drawing.Color.Teal;
            this.Applychangesbt.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Applychangesbt.ForeColor = System.Drawing.Color.Transparent;
            this.Applychangesbt.Location = new System.Drawing.Point(202, 533);
            this.Applychangesbt.Name = "Applychangesbt";
            this.Applychangesbt.Size = new System.Drawing.Size(246, 46);
            this.Applychangesbt.TabIndex = 10;
            this.Applychangesbt.Text = "Apply changes ";
            this.Applychangesbt.UseVisualStyleBackColor = false;
            this.Applychangesbt.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // Clearbt
            // 
            this.Clearbt.BackColor = System.Drawing.Color.Gray;
            this.Clearbt.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Clearbt.ForeColor = System.Drawing.Color.Transparent;
            this.Clearbt.Location = new System.Drawing.Point(543, 532);
            this.Clearbt.Name = "Clearbt";
            this.Clearbt.Size = new System.Drawing.Size(226, 46);
            this.Clearbt.TabIndex = 11;
            this.Clearbt.Text = "Clear";
            this.Clearbt.UseVisualStyleBackColor = false;
            this.Clearbt.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // NewGmailtb
            // 
            this.NewGmailtb.BackColor = System.Drawing.Color.Silver;
            this.NewGmailtb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.NewGmailtb.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.NewGmailtb.ForeColor = System.Drawing.Color.DimGray;
            this.NewGmailtb.Location = new System.Drawing.Point(394, 259);
            this.NewGmailtb.Name = "NewGmailtb";
            this.NewGmailtb.PlaceholderText = "(Enter Gmail)";
            this.NewGmailtb.Size = new System.Drawing.Size(362, 25);
            this.NewGmailtb.TabIndex = 13;
            this.NewGmailtb.TextChanged += new System.EventHandler(this.NewGmail_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(180, 259);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(131, 23);
            this.label3.TabIndex = 14;
            this.label3.Text = "New Gmail :";
            // 
            // EditProfile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(970, 678);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.NewGmailtb);
            this.Controls.Add(this.Clearbt);
            this.Controls.Add(this.Applychangesbt);
            this.Controls.Add(this.NewPasswordtb);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.NewUsernametb);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EditProfile";
            this.Text = "Edit Profile ";
            this.Load += new System.EventHandler(this.AdminEdit_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private TextBox NewUsernametb;
        private Label label1;
        private Label label2;
        private Label label4;
        private TextBox NewPasswordtb;
        private Button Applychangesbt;
        private Button Clearbt;
        private TextBox NewGmailtb;
        private Label label3;
    }
}