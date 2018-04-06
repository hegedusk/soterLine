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
    public partial class Form4_userHandling : Form
    {
        // DEKLARÁLÁSOK //
        MySqlConnection sqlKapcsolat = new MySqlConnection(@"Data Source=213.181.208.171;port=3306;Initial Catalog=sharpshark;User Id=sharpsharkuser;password='sh4rk$h4rp'");
        MySqlDataAdapter SDA;
        DataTable dt;
        MySqlCommandBuilder builder;

        public Form4_userHandling(string felhNev)
        {
            InitializeComponent();
            this.Text = "MasterP - Felhasználók kezelése";
            label10.Text = this.Text;
            label7.Text = felhNev;
            label7.Visible = false;
            label8_infoLine1.Visible = false;
            this.MinimumSize = new Size(727, 380);
            tabPage1.Text = "Hozzáadás";
            tabPage2.Text = "Módosítás vagy Törlés";
            comboboxBetolto();
            comboboxBetolto2();
        }

        // GOMBOK //
        private void button3_Click(object sender, EventArgs e)  // MUTASD MIND - tab1
        {
            adatBetoltoUser();
        }
        private void button4_Click(object sender, EventArgs e)  // MUTASD MIND - tab2
        {
            adatBetoltoUser();
        }
        private void button3_hozzaad_Click(object sender, EventArgs e)  // ÚJ HOZZÁADÁSA- Hozzáadás gomb
        {
            if (textBox1.Text.Length == 0 || textBox2.Text.Length == 0 || comboBox2.Text.Length == 0)
            {
                MessageBox.Show("Új felhasználó felvételéhez MINDEN adatot adj meg!"); 
            }
            else
            {
                sqlKapcsolat.Open();
                string sqlParancs = "INSERT INTO Login (username, password, role, registered, addTime, addUser, modTime) VALUES('" + textBox1.Text + "','" + textBox2.Text + "','" + comboBox2.Text + "','" + label6_registered.Text + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "','" + label7.Text + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "')";
                MySqlDataAdapter SDA = new MySqlDataAdapter(sqlParancs, sqlKapcsolat);
                SDA.SelectCommand.ExecuteNonQuery();
                sqlKapcsolat.Close();
                MessageBox.Show("Adat felvéve!");
                kiurito();
                adatBetoltoUser();
            }
        }
        private void button1_Click(object sender, EventArgs e)  // MÓDOSÍTÁS-TÖRLÉS/MÓDOSÍTÁS gomb
        {
            if (label8.Text == "...")
            {
                MessageBox.Show("Kérlek, előbb válassz ki egy módosítandó felhasználót!");
            }
            else
            {
                sqlKapcsolat.Open();
                string sqlParancs = "UPDATE Login SET username='" + textBox4.Text + "',password='" + textBox3.Text + "',role='" + comboBox3.Text + "',registered='" + comboBox4.Text + "',modTime='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "',modUser='" + label7.Text + "' WHERE loginid='" + label8.Text + "'";
                MySqlDataAdapter SDA = new MySqlDataAdapter(sqlParancs, sqlKapcsolat);
                SDA.SelectCommand.ExecuteNonQuery();
                sqlKapcsolat.Close();
                MessageBox.Show("Az adatok módosítva!");
                adatBetoltoUser();
                kiurito();
            }
        }
        private void button2_Click(object sender, EventArgs e)  // MÓDOSÍTÁS-TÖRLÉS/TÖRLÉS gomb 
        {
            if (label8.Text == "")
            {
                MessageBox.Show("Törléshez válassz ki egy felhasználót, dupla klikkeléssel");
            }
            else
            {
                if (MessageBox.Show("Biztosan törölni akarod az adatokat?", "ADAT TÖRLÉSE?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    sqlKapcsolat.Open();
                    String sqlParancs = "DELETE FROM Login WHERE loginid='" + label8.Text + "'";
                    MySqlDataAdapter SDA = new MySqlDataAdapter(sqlParancs, sqlKapcsolat);
                    SDA.SelectCommand.ExecuteNonQuery();
                    sqlKapcsolat.Close();
                    MessageBox.Show("A rekord törlésre került!");
                    adatBetoltoUser();
                    kiurito();
                }
            }
        }

        // TABPAGE-EK //
        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (tabControl1.SelectedTab == tabPage1)
            {
                kiurito();
            }
            else if (tabControl1.SelectedTab == tabPage2)
            {
                kiurito();
            }
        }

        // FÜGGVÉNYEIM //
        // duplaklikk a táblázatban //
        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            label8.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox4.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            comboBox3.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            comboBox4.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
        }
        // adatbetöltés //
        private void adatBetoltoUser()
        {
            sqlKapcsolat.Open();
            String sqlParancs = "SELECT loginid, username, password, role, registered FROM Login";
            SDA = new MySqlDataAdapter(sqlParancs, sqlKapcsolat);
            dt = new DataTable();
            SDA.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            sqlKapcsolat.Close();
        }
        // adatürítés //
        private void kiurito()
        {
            dataGridView1.DataSource = null;
            textBox1.Text = "";
            textBox2.Text = "";
            comboBox2.Text = "";
            label8.Text = "";
            textBox4.Text = "";
            textBox3.Text = "";
            comboBox3.Text = "";
            comboBox4.Text = "";
        }
        // async futtatás 1, hogy ne akadjon össze a betöltés //
        private async Task comboboxBetolto()
        {
            await Task.Delay(1000);
            sqlKapcsolat.Open();
            String sqlParancs = "SELECT ugNeve FROM cbusergroup2";
            MySqlDataAdapter SDA = new MySqlDataAdapter(sqlParancs, sqlKapcsolat);
            DataTable dt = new DataTable();
            SDA.Fill(dt); 
            comboBox2.ValueMember = "ugNeve";
            comboBox2.DisplayMember = "ugNeve";
            comboBox2.DataSource = dt;
            sqlKapcsolat.Close();
        }
        // async futtatás 2, hogy ne akadjon össze a betöltés //
        private async Task comboboxBetolto2()
        {
            await Task.Delay(1000);
            sqlKapcsolat.Open();
            String sqlParancs1 = "SELECT ugNeve FROM cbusergroup2";
            MySqlDataAdapter SDA1 = new MySqlDataAdapter(sqlParancs1, sqlKapcsolat);
            DataTable dt1 = new DataTable();
            SDA1.Fill(dt1);
            comboBox3.ValueMember = "ugNeve";
            comboBox3.DisplayMember = "ugNeve";
            comboBox3.DataSource = dt1;

            String sqlParancs2 = "SELECT usAllapot FROM cbuserstatus";
            MySqlDataAdapter SDA2 = new MySqlDataAdapter(sqlParancs2, sqlKapcsolat);
            DataTable dt2 = new DataTable();
            SDA2.Fill(dt2);
            comboBox4.ValueMember = "usAllapot";
            comboBox4.DisplayMember = "usAllapot";
            comboBox4.DataSource = dt2;
            sqlKapcsolat.Close();
        }
        // adatfrissítés //
        private void adatFrissitoUser()
        {
            sqlKapcsolat.Open();
            builder = new MySqlCommandBuilder(SDA);
            SDA.Update(dt);
            MessageBox.Show("Sikeres!");
            sqlKapcsolat.Close();
        }
        // "X" - ablakBezárás
        private void label9_Click(object sender, EventArgs e)
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
