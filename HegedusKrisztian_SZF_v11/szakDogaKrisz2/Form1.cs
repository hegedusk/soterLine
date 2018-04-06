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
    public partial class Form1 : Form
    {

        // DEKLARÁLÁSOK //
        MySqlConnection sqlKapcsolat = new MySqlConnection(@"Data Source=213.181.208.171;port=3306;Initial Catalog=sharpshark;User Id=sharpsharkuser;password='sh4rk$h4rp'");
        int i;
        public string userTipus;

        public Form1()
        {
            InitializeComponent();
            textBox1_userName.Select();
            this.Text = "MasterP - Authentikáció";
            label1.Text = this.Text;
        }

        // GOMBOK //
        private void button1_Belepes_Click(object sender, EventArgs e)  // BELÉPÉS gomb
        {
            i = 0;
            sqlKapcsolat.Open();
            MySqlCommand sqlParancs = sqlKapcsolat.CreateCommand();
            sqlParancs.CommandType = CommandType.Text;
            sqlParancs.CommandText = "SELECT * FROM Login WHERE username='" + textBox1_userName.Text + "' AND password='" + textBox2_password.Text + "'";
            sqlParancs.ExecuteNonQuery();
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(sqlParancs);
            da.Fill(dt);
            i = Convert.ToInt32(dt.Rows.Count.ToString());

            if (i == 0)
            {
                label3_loginInfo.Visible = true;
                label3_loginInfo.Text = "Helytelen felhasználónév\n" + "vagy jelszó";
            }
            else
            {
                userTipus = dt.Rows[0][4].ToString().Trim();
                if (userTipus == "registered")
                {
                    this.Hide();
                    Form2_main fm = new Form2_main(textBox1_userName.Text);
                    fm.Show();
                }
                else
                {
                    label3_loginInfo.Visible = true;
                    label3_loginInfo.Text = "Helytelen felhasználónév\n" + "vagy jelszó";
                }

            }

            sqlKapcsolat.Close();
        }
        private void button2_Kilepes_Click(object sender, EventArgs e)  // KILÉPÉS gomb
        {
            Close();
        }

        // MOZGATÓSÁV PANEL //
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
                mouseX = MousePosition.X - 194;
                mouseY = MousePosition.Y - 40;
                this.SetDesktopLocation(mouseX, mouseY);
            }
        }
        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

    }
}
