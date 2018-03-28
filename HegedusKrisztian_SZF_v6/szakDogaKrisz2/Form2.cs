using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient; // 2
using System.Net.Mail;   // 3
using System.Net;   // 4
using System.IO; // 5
// 1 - loginnév áthozása
// 2 - sqlKapcsolat
// 3 - Email küldés miatt
// 4 - IP-cím kiírása
// 5 - ipcím kiíráshoz steamreader

namespace szakDogaKrisz2
{
    public partial class Form2 : Form
    {
        MySqlConnection sqlKapcsolat = new MySqlConnection(@"Data Source=213.181.208.171;port=3306;Initial Catalog=sharpshark;User Id=sharpsharkuser;password='sh4rk$h4rp'"); // 2 - SQL kapcsolat

        public Form2(String UserName)   // 1 - Username string áthozása
        {
            InitializeComponent();
            label2_loggedIn.Text = UserName;    // 1
            label6_ipValue.Text = getPublicIP();    // 4
            this.Text = "MasterP - Vezérlőpult";

            karbantartásToolStripMenuItem.Enabled = false;
            groupCheck();
           
        }

        //--MENÜPONTOK--//
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
        private void felhasználókKezeléseToolStripMenuItem_Click(object sender, EventArgs e)    // KARBANTARTÁS/FELHASZNÁLÓ KEZELÉS
        {
            foreach (Form f in Application.OpenForms) // blokkolom a duplamegnyitást
            {
                if (f is Form4_userKezeles) // blokkolom a duplamegnyitást
                {
                    f.Focus(); // blokkolom a duplamegnyitást
                    return; // blokkolom a duplamegnyitást
                }
            }

            Form4_userKezeles formUserKezelolap = new Form4_userKezeles(label2_loggedIn.Text);
            formUserKezelolap.MdiParent = this;
            formUserKezelolap.Show();
        }
        private void adattáblákKezeléseToolStripMenuItem_Click_1(object sender, EventArgs e)      //KARBANTARTÁS/ADATTÁBLÁK KEZELÉSE
        {
            foreach (Form f in Application.OpenForms) // blokkolom a duplamegnyitást
            {
                if (f is Form5_tablaKezeles) // blokkolom a duplamegnyitást
                {
                    f.Focus(); // blokkolom a duplamegnyitást
                    return; // blokkolom a duplamegnyitást
                }
            }

            Form5_tablaKezeles formTablaKezelolap = new Form5_tablaKezeles(label2_loggedIn.Text);
            formTablaKezelolap.MdiParent = this;
            formTablaKezelolap.Show();
        }
        private void összesítőkToolStripMenuItem_Click(object sender, EventArgs e)  // VIZUÁLIS/Összesítők
        {
            foreach (Form f in Application.OpenForms) // blokkolom a duplamegnyitást
            {
                if (f is Form8_Osszesito) // blokkolom a duplamegnyitást
                {
                    f.Focus(); // blokkolom a duplamegnyitást
                    return; // blokkolom a duplamegnyitást
                }
            }

            Form8_Osszesito formOsszesitoke = new Form8_Osszesito(label2_loggedIn.Text);
            formOsszesitoke.MdiParent = this;
            formOsszesitoke.Show();
        }
        private void adatfelvételToolStripMenuItem_Click(object sender, EventArgs e)    // ADATFELVÉTEL
        {
            foreach (Form f in Application.OpenForms) // blokkolom a duplamegnyitást
            {
                if (f is Form6_AddData) // blokkolom a duplamegnyitást
                {
                    f.Focus(); // blokkolom a duplamegnyitást
                    return; // blokkolom a duplamegnyitást
                }
            }

            Form6_AddData formAdatKezelolap = new Form6_AddData(label2_loggedIn.Text);
            formAdatKezelolap.MdiParent = this;
            formAdatKezelolap.Show();
        }
        private void szűrésToolStripMenuItem_Click(object sender, EventArgs e)  // ADATSZŰRÉS - Export és Nyomtatás
        {
            foreach (Form f in Application.OpenForms) // blokkolom a duplamegnyitást
            {
                if (f is Form7_FilterDataPrint) // blokkolom a duplamegnyitást
                {
                    f.Focus(); // blokkolom a duplamegnyitást
                    return; // blokkolom a duplamegnyitást
                }
            }

            Form7_FilterDataPrint formAdatSzurolap = new Form7_FilterDataPrint(label2_loggedIn.Text);
            formAdatSzurolap.MdiParent = this;
            formAdatSzurolap.Show();
        }

        //--FÜGGVÉNYEIM--//
        public void groupCheck()
        {
            sqlKapcsolat.Open();// 000 - KÉSZ
            MySqlCommand sqlParancs = sqlKapcsolat.CreateCommand();// 000 - KÉSZ
            sqlParancs.CommandType = CommandType.Text;// 000 - KÉSZ
            sqlParancs.CommandText = "SELECT * FROM Login WHERE username='" + label2_loggedIn + "' AND role='" + "admin" + "'";// 000 - KÉSZ
            sqlParancs.ExecuteNonQuery();// 000 - KÉSZ
            DataTable adatTabla = new DataTable();// 000 - KÉSZ
            MySqlDataAdapter adatAdapter = new MySqlDataAdapter(sqlParancs);// 000 - KÉSZ
            adatAdapter.Fill(adatTabla);// 000 - KÉSZ            
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
            response.Close(); //Search for the ip in the html
            int first = direction.IndexOf("Address: ") + 9;
            int last = direction.LastIndexOf("</body></html>");
            direction = direction.Substring(first, last - first);
            return direction;
        }

        
    }
}
