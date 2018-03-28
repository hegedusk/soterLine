using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;   // 3 -
// 1 - fókusz menjen a username mezőre
// 2 - mySQL kapcsolat létrehozása
// 3 - sqlKapcsolat létrehozása
// 4 - login helyességének ellenőrzése
// 5 - form fejlécének elnevezése

namespace szakDogaKrisz2
{
    public partial class Form1 : Form
    {

        MySqlConnection sqlKapcsolat = new MySqlConnection(@"Data Source=213.181.208.171;port=3306;Initial Catalog=sharpshark;User Id=sharpsharkuser;password='sh4rk$h4rp'"); // 2 - SQL kapcsolat
        int i;  // 3 - elérhető változó a belépés helyességének ellenőrzéséhez
        public string userTipus;    // 4 - felhasználó típusának ellenőrzése

        public Form1()
        {
            InitializeComponent();
            textBox1_userName.Select(); // 1 - 
            this.Text = "MasterP - Jelentkezz be"; // 5 - 
        }

        //--GOMBOK--//
        private void button1_Belepes_Click(object sender, EventArgs e)  // BELÉPÉS gomb
        {
            i = 0; // 4
            sqlKapcsolat.Open();// 3
            MySqlCommand sqlParancs = sqlKapcsolat.CreateCommand();// 3
            sqlParancs.CommandType = CommandType.Text;// 3
            sqlParancs.CommandText = "SELECT * FROM Login WHERE username='" + textBox1_userName.Text + "' AND password='" + textBox2_password.Text + "'";// 3
            sqlParancs.ExecuteNonQuery();// 3
            DataTable dt = new DataTable();// 3
            MySqlDataAdapter da = new MySqlDataAdapter(sqlParancs);// 3
            da.Fill(dt);// 3
            i = Convert.ToInt32(dt.Rows.Count.ToString());// 3

            if (i == 0) // 4
            {
                label3_loginInfo.Visible = true;
                label3_loginInfo.Text = "Helytelen felhasználónév\n" + "vagy jelszó";// 4
            }
            else
            {
                userTipus = dt.Rows[0][4].ToString().Trim();    // 4
                if (userTipus == "registered")  // 4 
                {
                    this.Hide();    // 4
                    Form2 fm = new Form2(textBox1_userName.Text);    // 4 - user + A "username" átvitele miatt van a "textbox1.text" rész :)
                    fm.Show();    // 4
                }
                else    // 4
                {
                    label3_loginInfo.Visible = true;
                    label3_loginInfo.Text = "Helytelen felhasználónév\n" + "vagy jelszó";
                }

            } //

            sqlKapcsolat.Close();// 4
        }

        private void button2_Kilepes_Click(object sender, EventArgs e)  // KILÉPÉS gomb
        {
            Close();
        }

    }
}
