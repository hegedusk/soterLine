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

namespace szakDogaKrisz2
{
    public partial class Form9_Diagramms : Form
    {
        // DEKLARÁLÁSOK //
        MySqlConnection sqlKapcsolat = new MySqlConnection(@"Data Source=213.181.208.171;port=3306;Initial Catalog=sharpshark;User Id=sharpsharkuser;password='sh4rk$h4rp'");
        MySqlDataAdapter SDA;
        DataTable dt;
        MySqlCommandBuilder builder;

        public Form9_Diagramms(String felhNev)
        {
            InitializeComponent();
            this.Text = "MasterP - Diagrammok";
            label3.Text = this.Text;
            label1.Text = felhNev;
            label1.Visible = false;
            this.MinimumSize = new Size(641, 589);

            // CHART beállítása //
            string constring = "Data Source=213.181.208.171;port=3306;Initial Catalog=sharpshark;User Id=sharpsharkuser;password='sh4rk$h4rp'";
            MySqlConnection conDataBase = new MySqlConnection(constring);
            MySqlCommand cmDataBase = new MySqlCommand("SELECT * FROM nettoOsszesito",conDataBase);
            MySqlDataReader myReader;
            try
            {
                conDataBase.Open();
                myReader = cmDataBase.ExecuteReader();

                while (myReader.Read())
                {
                    this.chart1.Series["Cegek"].Points.AddXY(myReader.GetString("Ceg"), myReader.GetInt32("SumOfNetto"));
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }


        // FÜGGVÉNYEIM //
        // KILÉPÉSI GOMB //
        private void label2_Click(object sender, EventArgs e)
        {
            Close();
        }

        //MOZGATÁSI PANEL //
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
                mouseX = MousePosition.X - 365;
                mouseY = MousePosition.Y - 100;
                this.SetDesktopLocation(mouseX, mouseY);
            }
        }
        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }
        

    }
}
