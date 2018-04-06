namespace szakDogaKrisz2
{
    partial class Form2_main
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
            this.label1_udvozles = new System.Windows.Forms.Label();
            this.label2_loggedIn = new System.Windows.Forms.Label();
            this.label3_userStatus = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fájlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hibajegyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kilépésToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adatkezelésToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adatfelvételToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.szűrésToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cizuálisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.összesítőkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.diagrammokToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.karbantartásToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.felhasználókKezeléseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adattáblákKezeléseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label4_statusIn = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label5_showIP = new System.Windows.Forms.Label();
            this.label6_ipValue = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1_udvozles
            // 
            this.label1_udvozles.AutoSize = true;
            this.label1_udvozles.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1_udvozles.ForeColor = System.Drawing.Color.White;
            this.label1_udvozles.Location = new System.Drawing.Point(3, 0);
            this.label1_udvozles.Name = "label1_udvozles";
            this.label1_udvozles.Size = new System.Drawing.Size(82, 13);
            this.label1_udvozles.TabIndex = 0;
            this.label1_udvozles.Text = "Üdvözöllek - ";
            // 
            // label2_loggedIn
            // 
            this.label2_loggedIn.AutoSize = true;
            this.label2_loggedIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2_loggedIn.ForeColor = System.Drawing.Color.White;
            this.label2_loggedIn.Location = new System.Drawing.Point(91, 0);
            this.label2_loggedIn.Name = "label2_loggedIn";
            this.label2_loggedIn.Size = new System.Drawing.Size(35, 13);
            this.label2_loggedIn.TabIndex = 1;
            this.label2_loggedIn.Text = "label2";
            // 
            // label3_userStatus
            // 
            this.label3_userStatus.AutoSize = true;
            this.label3_userStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3_userStatus.ForeColor = System.Drawing.Color.White;
            this.label3_userStatus.Location = new System.Drawing.Point(132, 0);
            this.label3_userStatus.Name = "label3_userStatus";
            this.label3_userStatus.Size = new System.Drawing.Size(79, 13);
            this.label3_userStatus.TabIndex = 2;
            this.label3_userStatus.Text = "  Státuszod -";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fájlToolStripMenuItem,
            this.adatkezelésToolStripMenuItem,
            this.cizuálisToolStripMenuItem,
            this.karbantartásToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(6, 36, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(938, 57);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fájlToolStripMenuItem
            // 
            this.fájlToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hibajegyToolStripMenuItem,
            this.kilépésToolStripMenuItem});
            this.fájlToolStripMenuItem.Name = "fájlToolStripMenuItem";
            this.fájlToolStripMenuItem.Size = new System.Drawing.Size(37, 19);
            this.fájlToolStripMenuItem.Text = "Fájl";
            // 
            // hibajegyToolStripMenuItem
            // 
            this.hibajegyToolStripMenuItem.Name = "hibajegyToolStripMenuItem";
            this.hibajegyToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.hibajegyToolStripMenuItem.Text = "Hibajegy";
            this.hibajegyToolStripMenuItem.Click += new System.EventHandler(this.hibajegyToolStripMenuItem_Click);
            // 
            // kilépésToolStripMenuItem
            // 
            this.kilépésToolStripMenuItem.Name = "kilépésToolStripMenuItem";
            this.kilépésToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.kilépésToolStripMenuItem.Text = "Kilépés";
            this.kilépésToolStripMenuItem.Click += new System.EventHandler(this.kilépésToolStripMenuItem_Click);
            // 
            // adatkezelésToolStripMenuItem
            // 
            this.adatkezelésToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.adatfelvételToolStripMenuItem,
            this.szűrésToolStripMenuItem});
            this.adatkezelésToolStripMenuItem.Name = "adatkezelésToolStripMenuItem";
            this.adatkezelésToolStripMenuItem.Size = new System.Drawing.Size(81, 19);
            this.adatkezelésToolStripMenuItem.Text = "Adatkezelés";
            // 
            // adatfelvételToolStripMenuItem
            // 
            this.adatfelvételToolStripMenuItem.Name = "adatfelvételToolStripMenuItem";
            this.adatfelvételToolStripMenuItem.Size = new System.Drawing.Size(250, 22);
            this.adatfelvételToolStripMenuItem.Text = "Adatfelvétel";
            this.adatfelvételToolStripMenuItem.Click += new System.EventHandler(this.adatfelvételToolStripMenuItem_Click);
            // 
            // szűrésToolStripMenuItem
            // 
            this.szűrésToolStripMenuItem.Name = "szűrésToolStripMenuItem";
            this.szűrésToolStripMenuItem.Size = new System.Drawing.Size(250, 22);
            this.szűrésToolStripMenuItem.Text = "Adatszűrés - Export és Nyomtatás";
            this.szűrésToolStripMenuItem.Click += new System.EventHandler(this.szűrésToolStripMenuItem_Click);
            // 
            // cizuálisToolStripMenuItem
            // 
            this.cizuálisToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.összesítőkToolStripMenuItem,
            this.diagrammokToolStripMenuItem});
            this.cizuálisToolStripMenuItem.Name = "cizuálisToolStripMenuItem";
            this.cizuálisToolStripMenuItem.Size = new System.Drawing.Size(58, 19);
            this.cizuálisToolStripMenuItem.Text = "Vizuális";
            // 
            // összesítőkToolStripMenuItem
            // 
            this.összesítőkToolStripMenuItem.Name = "összesítőkToolStripMenuItem";
            this.összesítőkToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.összesítőkToolStripMenuItem.Text = "Összesítők";
            this.összesítőkToolStripMenuItem.Click += new System.EventHandler(this.összesítőkToolStripMenuItem_Click);
            // 
            // diagrammokToolStripMenuItem
            // 
            this.diagrammokToolStripMenuItem.Name = "diagrammokToolStripMenuItem";
            this.diagrammokToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.diagrammokToolStripMenuItem.Text = "Diagrammok";
            this.diagrammokToolStripMenuItem.Click += new System.EventHandler(this.diagrammokToolStripMenuItem_Click);
            // 
            // karbantartásToolStripMenuItem
            // 
            this.karbantartásToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.felhasználókKezeléseToolStripMenuItem,
            this.adattáblákKezeléseToolStripMenuItem});
            this.karbantartásToolStripMenuItem.Name = "karbantartásToolStripMenuItem";
            this.karbantartásToolStripMenuItem.Size = new System.Drawing.Size(85, 19);
            this.karbantartásToolStripMenuItem.Text = "Karbantartás";
            // 
            // felhasználókKezeléseToolStripMenuItem
            // 
            this.felhasználókKezeléseToolStripMenuItem.Name = "felhasználókKezeléseToolStripMenuItem";
            this.felhasználókKezeléseToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.felhasználókKezeléseToolStripMenuItem.Text = "Felhasználók kezelése";
            this.felhasználókKezeléseToolStripMenuItem.Click += new System.EventHandler(this.felhasználókKezeléseToolStripMenuItem_Click);
            // 
            // adattáblákKezeléseToolStripMenuItem
            // 
            this.adattáblákKezeléseToolStripMenuItem.Name = "adattáblákKezeléseToolStripMenuItem";
            this.adattáblákKezeléseToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.adattáblákKezeléseToolStripMenuItem.Text = "Adattáblák kezelése";
            this.adattáblákKezeléseToolStripMenuItem.Click += new System.EventHandler(this.adattáblákKezeléseToolStripMenuItem_Click_1);
            // 
            // label4_statusIn
            // 
            this.label4_statusIn.AutoSize = true;
            this.label4_statusIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4_statusIn.ForeColor = System.Drawing.Color.White;
            this.label4_statusIn.Location = new System.Drawing.Point(217, 0);
            this.label4_statusIn.Name = "label4_statusIn";
            this.label4_statusIn.Size = new System.Drawing.Size(51, 13);
            this.label4_statusIn.TabIndex = 4;
            this.label4_statusIn.Text = "FELIRAT";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.label1_udvozles);
            this.flowLayoutPanel1.Controls.Add(this.label2_loggedIn);
            this.flowLayoutPanel1.Controls.Add(this.label3_userStatus);
            this.flowLayoutPanel1.Controls.Add(this.label4_statusIn);
            this.flowLayoutPanel1.Controls.Add(this.label5_showIP);
            this.flowLayoutPanel1.Controls.Add(this.label6_ipValue);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 312);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(938, 18);
            this.flowLayoutPanel1.TabIndex = 6;
            // 
            // label5_showIP
            // 
            this.label5_showIP.AutoSize = true;
            this.label5_showIP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5_showIP.ForeColor = System.Drawing.Color.White;
            this.label5_showIP.Location = new System.Drawing.Point(274, 0);
            this.label5_showIP.Name = "label5_showIP";
            this.label5_showIP.Size = new System.Drawing.Size(118, 13);
            this.label5_showIP.TabIndex = 8;
            this.label5_showIP.Text = "Publikus IP címed -";
            // 
            // label6_ipValue
            // 
            this.label6_ipValue.AutoSize = true;
            this.label6_ipValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label6_ipValue.ForeColor = System.Drawing.Color.White;
            this.label6_ipValue.Location = new System.Drawing.Point(398, 0);
            this.label6_ipValue.Name = "label6_ipValue";
            this.label6_ipValue.Size = new System.Drawing.Size(35, 13);
            this.label6_ipValue.TabIndex = 8;
            this.label6_ipValue.Text = "label6";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(62)))), ((int)(((byte)(62)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(938, 34);
            this.panel1.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 15);
            this.label1.TabIndex = 9;
            this.label1.Text = "label1";
            // 
            // Form2_main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.ClientSize = new System.Drawing.Size(938, 330);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form2_main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form2";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form2_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1_udvozles;
        private System.Windows.Forms.Label label2_loggedIn;
        private System.Windows.Forms.Label label3_userStatus;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fájlToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hibajegyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kilépésToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem adatkezelésToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem adatfelvételToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem szűrésToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cizuálisToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem összesítőkToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem diagrammokToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem karbantartásToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem felhasználókKezeléseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem adattáblákKezeléseToolStripMenuItem;
        private System.Windows.Forms.Label label4_statusIn;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label5_showIP;
        private System.Windows.Forms.Label label6_ipValue;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
    }
}