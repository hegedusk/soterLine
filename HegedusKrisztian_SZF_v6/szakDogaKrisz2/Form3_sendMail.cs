using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net; // 1
using System.Net.Mail; // 1
using System.Net.Mime; // 1
// 1 - levélküldéshez felvevendő usingok

namespace szakDogaKrisz2
{
    public partial class Form3_sendMail : Form
    {
        public Form3_sendMail()
        {
            InitializeComponent();
            this.Text = "MasterP - Üzenj a készítőnek";
        }

        //--MENÜ--//
        private void mégsemToolStripMenuItem_Click(object sender, EventArgs e)  // FÁJL/MÉGSEM menü
        {
            Close();
        }

        //--GOMBOK--//
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
                Attachment mailCsati1 = new Attachment(textBox2_csatolmany_1.Text);
                mailUzenet.Attachments.Add(mailCsati1);
                mailUzenet.Body = textBox3_uzenet.Text;
                smtpKliens.Send(mailUzenet);
                MessageBox.Show("Sikeres levélküldés!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_megsem_Click_1(object sender, EventArgs e)   //MÉGSEMgomb
        {
            DialogResult result = MessageBox.Show("Biztosan félbehagyod a hibajegyszerkesztését?", "Hibajegyfélbehagyása", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                Close();
            }
        }

        private void button1_csatolmany_1_Click_1(object sender, EventArgs e) // TALLÓZ "1" gomb
        {
            OpenFileDialog csatiEgy = new OpenFileDialog();
            if (csatiEgy.ShowDialog() == DialogResult.OK)
            {
                textBox2_csatolmany_1.Text = csatiEgy.FileName.ToString();
            }
        }

    }
}
