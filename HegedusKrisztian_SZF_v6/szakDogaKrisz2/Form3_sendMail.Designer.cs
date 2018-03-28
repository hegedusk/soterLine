namespace szakDogaKrisz2
{
    partial class Form3_sendMail
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
            this.label1_to = new System.Windows.Forms.Label();
            this.label2_toCimertek = new System.Windows.Forms.Label();
            this.label3_targy = new System.Windows.Forms.Label();
            this.label4_csatolmany_1 = new System.Windows.Forms.Label();
            this.label5_uzenet = new System.Windows.Forms.Label();
            this.textBox1_targy = new System.Windows.Forms.TextBox();
            this.textBox2_csatolmany_1 = new System.Windows.Forms.TextBox();
            this.textBox3_uzenet = new System.Windows.Forms.TextBox();
            this.button1_csatolmany_1 = new System.Windows.Forms.Button();
            this.button2_kuldes = new System.Windows.Forms.Button();
            this.button3_megsem = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1_to
            // 
            this.label1_to.AutoSize = true;
            this.label1_to.Location = new System.Drawing.Point(36, 39);
            this.label1_to.Name = "label1_to";
            this.label1_to.Size = new System.Drawing.Size(46, 13);
            this.label1_to.TabIndex = 1;
            this.label1_to.Text = "Címzett:";
            // 
            // label2_toCimertek
            // 
            this.label2_toCimertek.AutoSize = true;
            this.label2_toCimertek.Location = new System.Drawing.Point(128, 39);
            this.label2_toCimertek.Name = "label2_toCimertek";
            this.label2_toCimertek.Size = new System.Drawing.Size(159, 13);
            this.label2_toCimertek.TabIndex = 2;
            this.label2_toCimertek.Text = "answeringmasterpro@gmail.com";
            // 
            // label3_targy
            // 
            this.label3_targy.AutoSize = true;
            this.label3_targy.Location = new System.Drawing.Point(36, 63);
            this.label3_targy.Name = "label3_targy";
            this.label3_targy.Size = new System.Drawing.Size(37, 13);
            this.label3_targy.TabIndex = 3;
            this.label3_targy.Text = "Tárgy:";
            // 
            // label4_csatolmany_1
            // 
            this.label4_csatolmany_1.AutoSize = true;
            this.label4_csatolmany_1.Location = new System.Drawing.Point(36, 89);
            this.label4_csatolmany_1.Name = "label4_csatolmany_1";
            this.label4_csatolmany_1.Size = new System.Drawing.Size(73, 13);
            this.label4_csatolmany_1.TabIndex = 4;
            this.label4_csatolmany_1.Text = "Csatolmány 1:";
            // 
            // label5_uzenet
            // 
            this.label5_uzenet.AutoSize = true;
            this.label5_uzenet.Location = new System.Drawing.Point(36, 113);
            this.label5_uzenet.Name = "label5_uzenet";
            this.label5_uzenet.Size = new System.Drawing.Size(44, 13);
            this.label5_uzenet.TabIndex = 5;
            this.label5_uzenet.Text = "Üzenet:";
            // 
            // textBox1_targy
            // 
            this.textBox1_targy.Location = new System.Drawing.Point(131, 63);
            this.textBox1_targy.Name = "textBox1_targy";
            this.textBox1_targy.Size = new System.Drawing.Size(100, 20);
            this.textBox1_targy.TabIndex = 6;
            // 
            // textBox2_csatolmany_1
            // 
            this.textBox2_csatolmany_1.Location = new System.Drawing.Point(131, 89);
            this.textBox2_csatolmany_1.Name = "textBox2_csatolmany_1";
            this.textBox2_csatolmany_1.Size = new System.Drawing.Size(100, 20);
            this.textBox2_csatolmany_1.TabIndex = 7;
            // 
            // textBox3_uzenet
            // 
            this.textBox3_uzenet.Location = new System.Drawing.Point(131, 113);
            this.textBox3_uzenet.Multiline = true;
            this.textBox3_uzenet.Name = "textBox3_uzenet";
            this.textBox3_uzenet.Size = new System.Drawing.Size(181, 107);
            this.textBox3_uzenet.TabIndex = 9;
            // 
            // button1_csatolmany_1
            // 
            this.button1_csatolmany_1.Location = new System.Drawing.Point(237, 87);
            this.button1_csatolmany_1.Name = "button1_csatolmany_1";
            this.button1_csatolmany_1.Size = new System.Drawing.Size(75, 23);
            this.button1_csatolmany_1.TabIndex = 8;
            this.button1_csatolmany_1.Text = "Tallóz";
            this.button1_csatolmany_1.UseVisualStyleBackColor = true;
            this.button1_csatolmany_1.Click += new System.EventHandler(this.button1_csatolmany_1_Click_1);
            // 
            // button2_kuldes
            // 
            this.button2_kuldes.Location = new System.Drawing.Point(131, 226);
            this.button2_kuldes.Name = "button2_kuldes";
            this.button2_kuldes.Size = new System.Drawing.Size(75, 23);
            this.button2_kuldes.TabIndex = 10;
            this.button2_kuldes.Text = "Küldés";
            this.button2_kuldes.UseVisualStyleBackColor = true;
            this.button2_kuldes.Click += new System.EventHandler(this.button2_kuldes_Click);
            // 
            // button3_megsem
            // 
            this.button3_megsem.Location = new System.Drawing.Point(237, 226);
            this.button3_megsem.Name = "button3_megsem";
            this.button3_megsem.Size = new System.Drawing.Size(75, 23);
            this.button3_megsem.TabIndex = 11;
            this.button3_megsem.Text = "Mégsem";
            this.button3_megsem.UseVisualStyleBackColor = true;
            this.button3_megsem.Click += new System.EventHandler(this.button3_megsem_Click_1);
            // 
            // Form3_sendMail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(622, 261);
            this.ControlBox = false;
            this.Controls.Add(this.button3_megsem);
            this.Controls.Add(this.button2_kuldes);
            this.Controls.Add(this.button1_csatolmany_1);
            this.Controls.Add(this.textBox3_uzenet);
            this.Controls.Add(this.textBox2_csatolmany_1);
            this.Controls.Add(this.textBox1_targy);
            this.Controls.Add(this.label5_uzenet);
            this.Controls.Add(this.label4_csatolmany_1);
            this.Controls.Add(this.label3_targy);
            this.Controls.Add(this.label2_toCimertek);
            this.Controls.Add(this.label1_to);
            this.Name = "Form3_sendMail";
            this.Text = "Form3_sendMail";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1_to;
        private System.Windows.Forms.Label label2_toCimertek;
        private System.Windows.Forms.Label label3_targy;
        private System.Windows.Forms.Label label4_csatolmany_1;
        private System.Windows.Forms.Label label5_uzenet;
        private System.Windows.Forms.TextBox textBox1_targy;
        private System.Windows.Forms.TextBox textBox2_csatolmany_1;
        private System.Windows.Forms.TextBox textBox3_uzenet;
        private System.Windows.Forms.Button button1_csatolmany_1;
        private System.Windows.Forms.Button button2_kuldes;
        private System.Windows.Forms.Button button3_megsem;
    }
}