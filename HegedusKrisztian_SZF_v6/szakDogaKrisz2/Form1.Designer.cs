namespace szakDogaKrisz2
{
    partial class Form1
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
            this.textBox1_userName = new System.Windows.Forms.TextBox();
            this.textBox2_password = new System.Windows.Forms.TextBox();
            this.button1_Belepes = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1_userName = new System.Windows.Forms.Label();
            this.label2_password = new System.Windows.Forms.Label();
            this.label3_loginInfo = new System.Windows.Forms.Label();
            this.button2_Kilepes = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1_userName
            // 
            this.textBox1_userName.Location = new System.Drawing.Point(247, 19);
            this.textBox1_userName.Name = "textBox1_userName";
            this.textBox1_userName.Size = new System.Drawing.Size(100, 20);
            this.textBox1_userName.TabIndex = 1;
            // 
            // textBox2_password
            // 
            this.textBox2_password.Location = new System.Drawing.Point(247, 67);
            this.textBox2_password.Name = "textBox2_password";
            this.textBox2_password.Size = new System.Drawing.Size(100, 20);
            this.textBox2_password.TabIndex = 2;
            // 
            // button1_Belepes
            // 
            this.button1_Belepes.Location = new System.Drawing.Point(261, 93);
            this.button1_Belepes.Name = "button1_Belepes";
            this.button1_Belepes.Size = new System.Drawing.Size(75, 23);
            this.button1_Belepes.TabIndex = 3;
            this.button1_Belepes.Text = "Belépés";
            this.button1_Belepes.UseVisualStyleBackColor = true;
            this.button1_Belepes.Click += new System.EventHandler(this.button1_Belepes_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::szakDogaKrisz2.Properties.Resources.icon_1968236_640_JAVITOTT;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(182, 168);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1_userName
            // 
            this.label1_userName.AutoSize = true;
            this.label1_userName.Location = new System.Drawing.Point(258, 3);
            this.label1_userName.Name = "label1_userName";
            this.label1_userName.Size = new System.Drawing.Size(81, 13);
            this.label1_userName.TabIndex = 5;
            this.label1_userName.Text = "Felhasználónév";
            // 
            // label2_password
            // 
            this.label2_password.AutoSize = true;
            this.label2_password.Location = new System.Drawing.Point(277, 51);
            this.label2_password.Name = "label2_password";
            this.label2_password.Size = new System.Drawing.Size(36, 13);
            this.label2_password.TabIndex = 6;
            this.label2_password.Text = "Jelszó";
            // 
            // label3_loginInfo
            // 
            this.label3_loginInfo.AutoSize = true;
            this.label3_loginInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3_loginInfo.ForeColor = System.Drawing.Color.Red;
            this.label3_loginInfo.Location = new System.Drawing.Point(200, 118);
            this.label3_loginInfo.Name = "label3_loginInfo";
            this.label3_loginInfo.Size = new System.Drawing.Size(0, 17);
            this.label3_loginInfo.TabIndex = 7;
            this.label3_loginInfo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label3_loginInfo.Visible = false;
            // 
            // button2_Kilepes
            // 
            this.button2_Kilepes.Location = new System.Drawing.Point(261, 157);
            this.button2_Kilepes.Name = "button2_Kilepes";
            this.button2_Kilepes.Size = new System.Drawing.Size(75, 23);
            this.button2_Kilepes.TabIndex = 4;
            this.button2_Kilepes.Text = "Mégsem";
            this.button2_Kilepes.UseVisualStyleBackColor = true;
            this.button2_Kilepes.Click += new System.EventHandler(this.button2_Kilepes_Click);
            // 
            // Form1
            // 
            this.AcceptButton = this.button1_Belepes;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 190);
            this.ControlBox = false;
            this.Controls.Add(this.button2_Kilepes);
            this.Controls.Add(this.label3_loginInfo);
            this.Controls.Add(this.label2_password);
            this.Controls.Add(this.label1_userName);
            this.Controls.Add(this.button1_Belepes);
            this.Controls.Add(this.textBox2_password);
            this.Controls.Add(this.textBox1_userName);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox textBox1_userName;
        private System.Windows.Forms.TextBox textBox2_password;
        private System.Windows.Forms.Button button1_Belepes;
        private System.Windows.Forms.Label label1_userName;
        private System.Windows.Forms.Label label2_password;
        private System.Windows.Forms.Label label3_loginInfo;
        private System.Windows.Forms.Button button2_Kilepes;
    }
}

