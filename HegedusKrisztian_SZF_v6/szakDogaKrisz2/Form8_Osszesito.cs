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
    public partial class Form8_Osszesito : Form
    {
        MySqlConnection sqlKapcsolat = new MySqlConnection(@"Data Source=213.181.208.171;port=3306;Initial Catalog=sharpshark;User Id=sharpsharkuser;password='sh4rk$h4rp'"); // 2 - SQL kapcsolat
        MySqlDataAdapter SDA;
        DataTable dt;
        MySqlCommandBuilder builder;

        public Form8_Osszesito(string felhNev)
        {
            InitializeComponent();
            this.Text = "MasterP - Összesítő";
            label1.Text = felhNev;
            label1.Visible = false;
            tabPage1.Text = "Éves bevételek";
            tabPage2.Text = "2017 részletező";

            evesOsszes();
            listaBetolto();

        }

        //SAJÁT FÜGGVÉNYEK
        public void evesOsszes()
        {
            /// ezit-Netto-2017
            sqlKapcsolat.Open();    // 002 - kapcsolat nyitás
            String query = "SELECT Sum(Clients.Netto) AS SumOfNetto FROM Clients WHERE(((Clients.Elvegezve)Like '2017%')) GROUP BY Clients.Ceg HAVING(((Clients.Ceg) = 'EZIT'))";
            MySqlDataAdapter SDA = new MySqlDataAdapter(query, sqlKapcsolat);
            DataTable dt = new DataTable();
            SDA.Fill(dt);

            /// mh-Netto-2017
            String query2 = "SELECT Sum(Clients.Netto) AS SumOfNetto FROM Clients WHERE(((Clients.Elvegezve)Like '2017%')) GROUP BY Clients.Ceg HAVING(((Clients.Ceg) = 'MH'))";
            MySqlDataAdapter SDA2 = new MySqlDataAdapter(query2, sqlKapcsolat);
            DataTable dt2 = new DataTable();
            SDA2.Fill(dt2);

            /// vos-Netto-2017
            String query3 = "SELECT Sum(Clients.Netto) AS SumOfNetto FROM Clients WHERE(((Clients.Elvegezve)Like '2017%')) GROUP BY Clients.Ceg HAVING(((Clients.Ceg) = 'VOS'))";
            MySqlDataAdapter SDA3 = new MySqlDataAdapter(query3, sqlKapcsolat);
            DataTable dt3 = new DataTable();
            SDA3.Fill(dt3);

            /// ezit-Netto-2018
            String query4 = "SELECT Sum(Clients.Netto) AS SumOfNetto FROM Clients WHERE(((Clients.Elvegezve)Like '2018%')) GROUP BY Clients.Ceg HAVING(((Clients.Ceg) = 'EZIT'))";
            MySqlDataAdapter SDA4 = new MySqlDataAdapter(query4, sqlKapcsolat);
            DataTable dt4 = new DataTable();
            SDA4.Fill(dt4);

            /// mh-Netto-2018
            String query5 = "SELECT Sum(Clients.Netto) AS SumOfNetto FROM Clients WHERE(((Clients.Elvegezve)Like '2018%')) GROUP BY Clients.Ceg HAVING(((Clients.Ceg) = 'MH'))";
            MySqlDataAdapter SDA5 = new MySqlDataAdapter(query5, sqlKapcsolat);
            DataTable dt5 = new DataTable();
            SDA5.Fill(dt5);

            /// vos-Netto-2018
            String query6 = "SELECT Sum(Clients.Netto) AS SumOfNetto FROM Clients WHERE(((Clients.Elvegezve)Like '2018%')) GROUP BY Clients.Ceg HAVING(((Clients.Ceg) = 'VOS'))";
            MySqlDataAdapter SDA6 = new MySqlDataAdapter(query6, sqlKapcsolat);
            DataTable dt6 = new DataTable();
            SDA6.Fill(dt6);

            /// ezit-Netto-2019
            String query13 = "SELECT Sum(Clients.Netto) AS SumOfNetto FROM Clients WHERE(((Clients.Elvegezve)Like '2019%')) GROUP BY Clients.Ceg HAVING(((Clients.Ceg) = 'EZIT'))";
            MySqlDataAdapter SDA13 = new MySqlDataAdapter(query13, sqlKapcsolat);
            DataTable dt13 = new DataTable();
            SDA13.Fill(dt13);

            /// mh-Netto-2019
            String query14 = "SELECT Sum(Clients.Netto) AS SumOfNetto FROM Clients WHERE(((Clients.Elvegezve)Like '2019%')) GROUP BY Clients.Ceg HAVING(((Clients.Ceg) = 'MH'))";
            MySqlDataAdapter SDA14 = new MySqlDataAdapter(query14, sqlKapcsolat);
            DataTable dt14 = new DataTable();
            SDA14.Fill(dt14);

            /// vos-Netto-2019
            String query15 = "SELECT Sum(Clients.Netto) AS SumOfNetto FROM Clients WHERE(((Clients.Elvegezve)Like '2019%')) GROUP BY Clients.Ceg HAVING(((Clients.Ceg) = 'VOS'))";
            MySqlDataAdapter SDA15 = new MySqlDataAdapter(query15, sqlKapcsolat);
            DataTable dt15 = new DataTable();
            SDA15.Fill(dt15);

            /// ezit-db-2017
            String query7 = "SELECT Count(Clients.Ceg) AS CountOfCeg FROM Clients WHERE(((Clients.Elvegezve)Like '2017%')) GROUP BY Clients.Ceg HAVING(((Clients.Ceg) = 'EZIT'))";
            MySqlDataAdapter SDA7 = new MySqlDataAdapter(query7, sqlKapcsolat);
            DataTable dt7 = new DataTable();
            SDA7.Fill(dt7);

            /// mh-db-2017
            String query8 = "SELECT Count(Clients.Ceg) AS CountOfCeg FROM Clients WHERE(((Clients.Elvegezve)Like '2017%')) GROUP BY Clients.Ceg HAVING(((Clients.Ceg) = 'MH'))";
            MySqlDataAdapter SDA8 = new MySqlDataAdapter(query8, sqlKapcsolat);
            DataTable dt8 = new DataTable();
            SDA8.Fill(dt8);

            /// vos-db-2017
            String query9 = "SELECT Count(Clients.Ceg) AS CountOfCeg FROM Clients WHERE(((Clients.Elvegezve)Like '2017%')) GROUP BY Clients.Ceg HAVING(((Clients.Ceg) = 'VOS'))";
            MySqlDataAdapter SDA9 = new MySqlDataAdapter(query9, sqlKapcsolat);
            DataTable dt9 = new DataTable();
            SDA9.Fill(dt9);

            /// ezit-db-2018
            String query10 = "SELECT Count(Clients.Ceg) AS CountOfCeg FROM Clients WHERE(((Clients.Elvegezve)Like '2018%')) GROUP BY Clients.Ceg HAVING(((Clients.Ceg) = 'EZIT'))";
            MySqlDataAdapter SDA10 = new MySqlDataAdapter(query10, sqlKapcsolat);
            DataTable dt10 = new DataTable();
            SDA10.Fill(dt10);

            /// mh-db-2018
            String query11 = "SELECT Count(Clients.Ceg) AS CountOfCeg FROM Clients WHERE(((Clients.Elvegezve)Like '2018%')) GROUP BY Clients.Ceg HAVING(((Clients.Ceg) = 'MH'))";
            MySqlDataAdapter SDA11 = new MySqlDataAdapter(query11, sqlKapcsolat);
            DataTable dt11 = new DataTable();
            SDA11.Fill(dt11);

            /// vos-db-2018
            String query12 = "SELECT Count(Clients.Ceg) AS CountOfCeg FROM Clients WHERE(((Clients.Elvegezve)Like '2018%')) GROUP BY Clients.Ceg HAVING(((Clients.Ceg) = 'VOS'))";
            MySqlDataAdapter SDA12 = new MySqlDataAdapter(query12, sqlKapcsolat);
            DataTable dt12 = new DataTable();
            SDA12.Fill(dt12);

            /// ezit-db-2019
            String query16 = "SELECT Count(Clients.Ceg) AS CountOfCeg FROM Clients WHERE(((Clients.Elvegezve)Like '2019%')) GROUP BY Clients.Ceg HAVING(((Clients.Ceg) = 'EZIT'))";
            MySqlDataAdapter SDA16 = new MySqlDataAdapter(query16, sqlKapcsolat);
            DataTable dt16 = new DataTable();
            SDA16.Fill(dt16);

            /// mh-db-2019
            String query17 = "SELECT Count(Clients.Ceg) AS CountOfCeg FROM Clients WHERE(((Clients.Elvegezve)Like '2019%')) GROUP BY Clients.Ceg HAVING(((Clients.Ceg) = 'MH'))";
            MySqlDataAdapter SDA17 = new MySqlDataAdapter(query17, sqlKapcsolat);
            DataTable dt17 = new DataTable();
            SDA17.Fill(dt17);

            /// vos-db-2019
            String query18 = "SELECT Count(Clients.Ceg) AS CountOfCeg FROM Clients WHERE(((Clients.Elvegezve)Like '2019%')) GROUP BY Clients.Ceg HAVING(((Clients.Ceg) = 'VOS'))";
            MySqlDataAdapter SDA18 = new MySqlDataAdapter(query18, sqlKapcsolat);
            DataTable dt18 = new DataTable();
            SDA18.Fill(dt18);

            // összegek
            label8.Text = dt.Rows[0][0].ToString() + " Ft";
            label9.Text = dt2.Rows[0][0].ToString() + " Ft";
            label10.Text = dt3.Rows[0][0].ToString() + " Ft";
            label11.Text = dt4.Rows[0][0].ToString() + " Ft";
            label12.Text = dt5.Rows[0][0].ToString() + " Ft";
            label13.Text = dt6.Rows[0][0].ToString() + " Ft";
            //label21.Text = dt13.Rows[0][0].ToString() + " Ft";
            //label22.Text = dt14.Rows[0][0].ToString() + " Ft";
            //label23.Text = dt15.Rows[0][0].ToString() + " Ft";

            // darabok
            label14.Text = dt7.Rows[0][0].ToString() + " db";
            label15.Text = dt8.Rows[0][0].ToString() + " db";
            label16.Text = dt9.Rows[0][0].ToString() + " db";
            label17.Text = dt10.Rows[0][0].ToString() + " db";
            label18.Text = dt11.Rows[0][0].ToString() + " db";
            label19.Text = dt12.Rows[0][0].ToString() + " db";
            //label24.Text = dt16.Rows[0][0].ToString() + " db";
            //label25.Text = dt17.Rows[0][0].ToString() + " db";
            //label26.Text = dt18.Rows[0][0].ToString() + " db";

            sqlKapcsolat.Close();
        }

        public void tizenhetOsszes()
        {
            /// Feladatokra lebontva
            /// Költöztetés
            sqlKapcsolat.Open();
            String query = "SELECT Sum(Clients.Netto) AS SumOfNetto FROM Clients WHERE(((Clients.Elvegezve)Like '2017%')) GROUP BY Clients.Ceg HAVING(((Clients.Ceg) = 'EZIT'))";
            MySqlDataAdapter SDA = new MySqlDataAdapter(query, sqlKapcsolat);
            DataTable dt = new DataTable();
            SDA.Fill(dt);
        }

        private void listaBetolto()
        {
            sqlKapcsolat.Open();
            String query = "SELECT CegeinkNeve FROM cbcegek";
            MySqlDataAdapter SDA = new MySqlDataAdapter(query, sqlKapcsolat);
            DataTable dt = new DataTable();
            SDA.Fill(dt);
            listBox1.ValueMember = "CegeinkNeve";
            listBox1.DisplayMember = "CegeinkNeve";
            listBox1.DataSource = dt;
        }

    }
}
