using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;

namespace szakDogaKrisz2
{
    public partial class Form3_sendMail : Form
    {
        public Form3_sendMail()
        {
            InitializeComponent();
            this.Text = "MasterP - Üzenj a készítőnek";
            label3.Text = this.Text;
            textBox2_csatolmany_1.Visible = false;
            button1_csatolmany_1.Visible = false;
        }

        // MENÜ //
        private void mégsemToolStripMenuItem_Click(object sender, EventArgs e)  // FÁJL/MÉGSEM
        {
            Close();
        }

        // GOMBOK //
        private void button2_kuldes_Click(object sender, EventArgs e)   // KÜLDÉS gomb
        {
            try
            {
                SmtpClient smtpKliens = new SmtpClient("smtp.gmail.com", 587);
                smtpKliens.EnableSsl = true;
                smtpKliens.Timeout = 10000;
                smtpKliens.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpKliens.UseDefaultCredentials = false;
                smtpKliens.Credentials = new NetworkCredential("ticketingmasterpro@gmail.com", "fvjq8ghh99HK");
                MailMessage mailUzenet = new MailMessage();
                mailUzenet.To.Add(label2_toCimertek.Text);
                mailUzenet.From = new MailAddress("ticketingmasterpro@gmail.com");
                mailUzenet.Subject = textBox1_targy.Text;
                if (checkBox1.Checked)
                {
                    Attachment mailCsati1 = new Attachment(textBox2_csatolmany_1.Text);
                    mailUzenet.Attachments.Add(mailCsati1);
                }   
                mailUzenet.Body = textBox3_uzenet.Text;
                smtpKliens.Send(mailUzenet);
                MessageBox.Show("Sikeres levélküldés!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void button3_megsem_Click_1(object sender, EventArgs e)   //MÉGSEM gomb
        {
            DialogResult result = MessageBox.Show("Biztosan félbehagyod a hibajegyszerkesztését?", "Hibajegyfélbehagyása", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                Close();
            }
        }
        private void button1_csatolmany_1_Click_1(object sender, EventArgs e) // TALLÓZ  gomb
        {
            OpenFileDialog csatiEgy = new OpenFileDialog();
            if (csatiEgy.ShowDialog() == DialogResult.OK)
            {
                textBox2_csatolmany_1.Text = csatiEgy.FileName.ToString();
            }
        }


        // FÜGGVÉNYEIM //
        // Csatolmány küldés-nemküldés opció //
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox2_csatolmany_1.Visible = true;
                button1_csatolmany_1.Visible = true;
            }
            else
            {
                textBox2_csatolmany_1.Visible = false;
                button1_csatolmany_1.Visible = false;
            }
        }
        // "X" - ablakBezárás
        private void label2_Click(object sender, EventArgs e)
        {
            Close();
        }

        // MOZGATÓSÁV PANEL
        int mouseX = 0, mouseY = 0;
        bool mouseDown;
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
        }
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                mouseX = MousePosition.X - 220;
                mouseY = MousePosition.Y - 20;
                this.SetDesktopLocation(mouseX, mouseY);
            }
        }
        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }
    }
}
