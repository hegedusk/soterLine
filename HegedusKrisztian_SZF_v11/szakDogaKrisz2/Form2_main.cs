using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Net.Mail;
using System.Net;
using System.IO;

namespace szakDogaKrisz2
{
    public partial class Form2_main : Form
    {
        // DEKLARÁLÁSOK //
        MySqlConnection sqlKapcsolat = new MySqlConnection(@"Data Source=213.181.208.171;port=3306;Initial Catalog=sharpshark;User Id=sharpsharkuser;password='sh4rk$h4rp'");

        public Form2_main(String UserName)
        {
            InitializeComponent();
            label2_loggedIn.Text = UserName;
            label6_ipValue.Text = getPublicIP();
            this.Text = "MasterP - Vezérlőpult";
            label1.Text = this.Text;
            karbantartásToolStripMenuItem.Enabled = false;
            groupCheck();
        }

        //- Mdi háttérszín kezelése//
        private void Form2_Load(object sender, EventArgs e)
        {
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is MdiClient)
                {
                    ctrl.BackColor = Color.FromArgb(105, 105, 105);
                }
            }
        }

        // MENÜPONTOK //
        private void kilépésToolStripMenuItem_Click(object sender, EventArgs e) // FÁJL/KILÉPÉS
        {
            DialogResult result = MessageBox.Show("Biztosan kilépsz az alkalmazásból?", "Kilépés megerősítése", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
        private void hibajegyToolStripMenuItem_Click(object sender, EventArgs e)    //  FÁJL/HIBAJEGY
        {
            Form3_sendMail formMail = new Form3_sendMail();
            formMail.ShowDialog();
        }
        private void felhasználókKezeléseToolStripMenuItem_Click(object sender, EventArgs e)    // KARBANTARTÁS/FELHASZNÁLÓ KEZELÉSE
        {
            foreach (Form f in Application.OpenForms)
            {
                if (f is Form4_userHandling)
                {
                    f.Focus();
                    return;
                }
            }

            Form4_userHandling formUserKezelolap = new Form4_userHandling(label2_loggedIn.Text);
            formUserKezelolap.MdiParent = this;
            formUserKezelolap.Show();
        }
        private void adattáblákKezeléseToolStripMenuItem_Click_1(object sender, EventArgs e)      //KARBANTARTÁS/ADATTÁBLÁK KEZELÉSE
        {
            foreach (Form f in Application.OpenForms)
            {
                if (f is Form5_tableHandling)
                {
                    f.Focus();
                    return;
                }
            }

            Form5_tableHandling formTablaKezelolap = new Form5_tableHandling(label2_loggedIn.Text);
            formTablaKezelolap.MdiParent = this;
            formTablaKezelolap.Show();
        }
        private void összesítőkToolStripMenuItem_Click(object sender, EventArgs e)  // VIZUÁLIS/Összesítők
        {
            foreach (Form f in Application.OpenForms)
            {
                if (f is Form8_Sum)
                {
                    f.Focus();
                    return;
                }
            }

            Form8_Sum formOsszesitoke = new Form8_Sum(label2_loggedIn.Text);
            formOsszesitoke.MdiParent = this;
            formOsszesitoke.Show();
        }
        private void diagrammokToolStripMenuItem_Click(object sender, EventArgs e)  // VIZUÁLIS/Diagrammok
        {
            foreach (Form f in Application.OpenForms)
            {
                if (f is Form9_Diagramms)
                {
                    f.Focus();
                    return;
                }
            }

            Form9_Diagramms formDiagrammok = new Form9_Diagramms(label2_loggedIn.Text);
            formDiagrammok.MdiParent = this;
            formDiagrammok.Show();
        }
        private void adatfelvételToolStripMenuItem_Click(object sender, EventArgs e)    // ADATKEZELÉS/ADATFELVÉTEL
        {
            foreach (Form f in Application.OpenForms)
            {
                if (f is Form6_AddData)
                {
                    f.Focus();
                    return;
                }
            }

            Form6_AddData formAdatKezelolap = new Form6_AddData(label2_loggedIn.Text);
            formAdatKezelolap.MdiParent = this;
            formAdatKezelolap.Show();
        }
        private void szűrésToolStripMenuItem_Click(object sender, EventArgs e)  // ADATKEZELÉS/ADATSZŰRÉS - Export és Nyomtatás
        {
            foreach (Form f in Application.OpenForms)
            {
                if (f is Form7_FilterDataPrint)
                {
                    f.Focus();
                    return;
                }
            }

            Form7_FilterDataPrint formAdatSzurolap = new Form7_FilterDataPrint(label2_loggedIn.Text);
            formAdatSzurolap.MdiParent = this;
            formAdatSzurolap.Show();
        }

        // FÜGGVÉNYEIM //
        // Jogosultság ellenőrzése //
        public void groupCheck()
        {
            sqlKapcsolat.Open();
            MySqlCommand sqlParancs = sqlKapcsolat.CreateCommand();
            sqlParancs.CommandType = CommandType.Text;
            sqlParancs.CommandText = "SELECT * FROM Login WHERE username='" + label2_loggedIn + "' AND role='" + "admin" + "'";
            sqlParancs.ExecuteNonQuery();
            DataTable adatTabla = new DataTable();
            MySqlDataAdapter adatAdapter = new MySqlDataAdapter(sqlParancs);
            adatAdapter.Fill(adatTabla);  
            sqlKapcsolat.Close();

            // ALAP, AMI CSAK "admin" USERRE AUTHENTIKÁL ADMINHOZZÁFÉRÉST
            if (label2_loggedIn.Text == "admin")
            {
               karbantartásToolStripMenuItem.Enabled = true;
              label4_statusIn.Text = "admin";
            }
            else
            {
               label4_statusIn.Text = "client";
            }

            sqlKapcsolat.Close();
        }

        //PublikusIP
        public string getPublicIP()
        {
            string direction;
            WebRequest request = WebRequest.Create("http://checkip.dyndns.org/");
            WebResponse response = request.GetResponse();
            StreamReader stream = new StreamReader(response.GetResponseStream());
            direction = stream.ReadToEnd();
            stream.Close();
            response.Close();
            int first = direction.IndexOf("Address: ") + 9;
            int last = direction.LastIndexOf("</body></html>");
            direction = direction.Substring(first, last - first);
            return direction;
        }

    }
}
