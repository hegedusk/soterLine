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
    public partial class Form5_tableHandling : Form
    {
        // DEKLARÁLÁSOK //
        MySqlConnection sqlKapcsolat = new MySqlConnection(@"Data Source=213.181.208.171;port=3306;Initial Catalog=sharpshark;User Id=sharpsharkuser;password='sh4rk$h4rp'");
        MySqlDataAdapter SDA;
        DataTable dt;
        MySqlCommandBuilder builder;


        public Form5_tableHandling(String felhNev)
        {
            InitializeComponent();
            this.Text = "MasterP - Adattáblák kezelése";
            label3.Text = this.Text;
            label1.Text = felhNev;
            this.MinimumSize = new Size(751, 380);
            tabPage1.Text = "Cégeink kezelése";
            tabPage2.Text = "RendszerNeveink kezelése";
            tabPage3.Text = "RendszerTípus neve";
            tabPage4.Text = "RendszerAltípus";
            tabPage5.Text = "FeladatTípus";
            tabPage6.Text = "User-csoportok";
        }

        // TAB KIVÁLASZTÁS ESETÉN //
        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (tabControl1.SelectedTab == tabPage1)
            {
                kiurito();
                textBox1.Focus();
            }
            else if (tabControl1.SelectedTab == tabPage2)
            {
                kiurito();
                textBox2.Focus();
            }
            else if (tabControl1.SelectedTab == tabPage3)
            {
                kiurito();
                textBox3.Focus();
            }
            else if (tabControl1.SelectedTab == tabPage4)
            {
                kiurito();
                textBox4.Focus();
            }
            else if (tabControl1.SelectedTab == tabPage5)
            {
                kiurito();
                textBox5.Focus();
            }
            else if (tabControl1.SelectedTab == tabPage6)
            {
                kiurito();
            }
        }

        // GOMBOK //
        private void button19_Click(object sender, EventArgs e) // CÉGEINK - MUTASD MIND
        {
            adatBetoltoCegeink();
        }
        private void button1_Click(object sender, EventArgs e)  // CÉGEINK - Hozzáadás
        {
            if (textBox1.Text.Length == 0)
            {
                MessageBox.Show("Adj meg helyes Cégnevet!");
            }
            else
            {
                sqlKapcsolat.Open();
                string sqlParancs = "INSERT INTO cbcegek (CegeinkNeve, addTime, addUser, modTime) VALUES('" + textBox1.Text + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "','" + label1.Text + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "')";
                MySqlDataAdapter SDA = new MySqlDataAdapter(sqlParancs, sqlKapcsolat);
                SDA.SelectCommand.ExecuteNonQuery();
                sqlKapcsolat.Close();
                MessageBox.Show("Adat felvéve!");
                kiurito();
                adatBetoltoCegeink();
                textBox1.Focus();
            }
        }
        private void button2_Click(object sender, EventArgs e)  // CÉGEINK - Módosítás
        {
            if (label5.Text == "...")
            {
                MessageBox.Show("Kérlek, előbb válassz ki egy módosítandó céget!");
            }
            else
            {
                sqlKapcsolat.Open();
                string sqlParancs = "UPDATE cbcegek SET CegeinkNeve='" + textBox1.Text + "',modTime='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "',modUser='" + label1.Text + "' WHERE CegeinkID='" + label5.Text + "'";
                MySqlDataAdapter SDA = new MySqlDataAdapter(sqlParancs, sqlKapcsolat);
                SDA.SelectCommand.ExecuteNonQuery();
                sqlKapcsolat.Close();
                MessageBox.Show("Az adatok módosítva!");
                adatBetoltoCegeink();
                kiurito();
                textBox1.Focus();
            }
        }
        private void button3_Click(object sender, EventArgs e)  // CÉGEINK - Törlés
        {
            if (label5.Text == "...")
            {
                MessageBox.Show("Törléshez válassz ki egy céget, dupla klikkeléssel");
            }
            else
            {
                if (MessageBox.Show("Biztosan törölni akarod az adatokat?", "ADAT TÖRLÉSE?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    sqlKapcsolat.Open();
                    String sqlParancs = "DELETE FROM cbcegek WHERE CegeinkID='" + label5.Text + "'";
                    MySqlDataAdapter SDA = new MySqlDataAdapter(sqlParancs, sqlKapcsolat);
                    SDA.SelectCommand.ExecuteNonQuery();
                    sqlKapcsolat.Close();
                    MessageBox.Show("A rekord törlésre került!");
                    kiurito();
                    adatBetoltoCegeink();
                }
            }
        }

        private void button20_Click(object sender, EventArgs e) //RENDSZER-NEVEINK - MUTASD MIND
        {
            adatBetoltoRendszernevek();
        }
        private void button4_Click(object sender, EventArgs e)  //RENDSZER-NEVEINK - Hozzáadás
        {
            if (textBox2.Text.Length == 0)
            {
                MessageBox.Show("Adj meg helyes RendszerNevet!");
            }
            else
            {
                sqlKapcsolat.Open();
                string sqlParancs = "INSERT INTO cbfeladatsystemA (fsaNeve, addTime, addUser, modTime) VALUES('" + textBox2.Text + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "','" + label1.Text + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "')";
                MySqlDataAdapter SDA = new MySqlDataAdapter(sqlParancs, sqlKapcsolat);
                SDA.SelectCommand.ExecuteNonQuery();
                sqlKapcsolat.Close();
                MessageBox.Show("Adat felvéve!");
                kiurito();
                adatBetoltoRendszernevek();
                textBox2.Focus();
            }
        }
        private void button5_Click(object sender, EventArgs e)  //RENDSZER-NEVEINK - Módosítás
        {
            if (label8.Text == "...")
            {
                MessageBox.Show("Kérlek, előbb válassz ki egy módosítandó feladatevet!");
            }
            else
            {
                sqlKapcsolat.Open();
                string sqlParancs = "UPDATE cbfeladatsystemA SET fsaNeve='" + textBox2.Text + "',modTime='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "',modUser='" + label1.Text + "' WHERE fsaID='" + label8.Text + "'";
                MySqlDataAdapter SDA = new MySqlDataAdapter(sqlParancs, sqlKapcsolat);
                SDA.SelectCommand.ExecuteNonQuery();
                SDA.SelectCommand.ExecuteNonQuery();
                sqlKapcsolat.Close();
                MessageBox.Show("Az adatok módosítva!");
                adatBetoltoCegeink();
                kiurito();
                textBox2.Focus();
            }
        }
        private void button6_Click(object sender, EventArgs e)  //RENDSZER-NEVEINK - Törlés
        {
            if (label8.Text == "...")
            {
                MessageBox.Show("Törléshez válassz ki egy RendszerNevetr, dupla klikkeléssel");
            }
            else
            {
                if (MessageBox.Show("Biztosan törölni akarod az adatokat?", "ADAT TÖRLÉSE?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    sqlKapcsolat.Open();
                    String sqlParancs = "DELETE FROM cbfeladatsystemA WHERE fsaID='" + label8.Text + "'";
                    MySqlDataAdapter SDA = new MySqlDataAdapter(sqlParancs, sqlKapcsolat);
                    SDA.SelectCommand.ExecuteNonQuery();
                    sqlKapcsolat.Close();
                    MessageBox.Show("A rekord törlésre került!");
                    kiurito();
                    adatBetoltoRendszernevek();
                    textBox2.Focus();
                }
            }
        }

        private void button21_Click(object sender, EventArgs e) //RENDSZER-TÍPUSNEVEK - MUTASD MIND
        {
            adatBetoltoRendszerTipusnevek();
        }
        private void button7_Click(object sender, EventArgs e)  //RENDSZER-TÍPUSNEVEK - Hozzáadás
        {
            if (textBox3.Text.Length == 0)
            {
                MessageBox.Show("Adj meg helyes RendszerTípusNevet!");
            }
            else
            {
                sqlKapcsolat.Open();
                string sqlParancs = "INSERT INTO cbfeladatsystemB (fsbNeve, addTime, addUser, modTime) VALUES('" + textBox3.Text + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "','" + label11.Text + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "')";
                MySqlDataAdapter SDA = new MySqlDataAdapter(sqlParancs, sqlKapcsolat);
                SDA.SelectCommand.ExecuteNonQuery();
                sqlKapcsolat.Close();
                MessageBox.Show("Adat felvéve!");
                kiurito();
                adatBetoltoRendszerTipusnevek();
                textBox3.Focus();
            }
        }
        private void button8_Click(object sender, EventArgs e)  //RENDSZER-TÍPUSNEVEK - Módosítás
        {
            if (label11.Text == "...")
            {
                MessageBox.Show("Kérlek, előbb válassz ki egy módosítandó feladatTípusevet!");
            }
            else
            {
                sqlKapcsolat.Open();
                string sqlParancs = "UPDATE cbfeladatsystemB SET fsbNeve='" + textBox3.Text + "',modTime='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "',modUser='" + label1.Text + "' WHERE fsbID='" + label11.Text + "'";
                MySqlDataAdapter SDA = new MySqlDataAdapter(sqlParancs, sqlKapcsolat);
                SDA.SelectCommand.ExecuteNonQuery();
                sqlKapcsolat.Close();
                MessageBox.Show("Az adatok módosítva!");
                adatBetoltoRendszerTipusnevek();
                kiurito();
                textBox3.Focus();
            }
        }
        private void button9_Click(object sender, EventArgs e)  //RENDSZER-TÍPUSNEVEK - Törlés
        {
            if (label11.Text == "...")
            {
                MessageBox.Show("Törléshez válassz ki egy RendszerTípusNevet, dupla klikkeléssel");
            }
            else
            {
                if (MessageBox.Show("Biztosan törölni akarod az adatokat?", "ADAT TÖRLÉSE?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    sqlKapcsolat.Open();
                    String sqlParancs = "DELETE FROM cbfeladatsystemB WHERE fsbID='" + label11.Text + "'";
                    MySqlDataAdapter SDA = new MySqlDataAdapter(sqlParancs, sqlKapcsolat);
                    SDA.SelectCommand.ExecuteNonQuery();
                    sqlKapcsolat.Close();
                    MessageBox.Show("A rekord törlésre került!");
                    kiurito();
                    adatBetoltoRendszerTipusnevek();
                    textBox3.Focus();
                }
            }
        }

        private void button22_Click(object sender, EventArgs e) //RENDSZER-ALTÍPUSOK - MUTASD MIND
        {
            adatBetoltoRendszerAltipusok();
        }
        private void button10_Click(object sender, EventArgs e) //RENDSZER-ALTÍPUSOK - Hozzáadás
        {
            if (textBox4.Text.Length == 0)
            {
                MessageBox.Show("Adj meg helyes RendszerAltípust!");
            }
            else
            {
                sqlKapcsolat.Open();
                string sqlParancs = "INSERT INTO cbfeladatsystemC (fscNeve, addTime, addUser, modTime) VALUES('" + textBox4.Text + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "','" + label14.Text + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "')";
                MySqlDataAdapter SDA = new MySqlDataAdapter(sqlParancs, sqlKapcsolat);
                SDA.SelectCommand.ExecuteNonQuery();
                sqlKapcsolat.Close();
                MessageBox.Show("Adat felvéve!");
                kiurito();
                adatBetoltoRendszerAltipusok();
                textBox4.Focus();
            }
        }
        private void button11_Click(object sender, EventArgs e) //RENDSZER-ALTÍPUSOK - Módosítás
        {
            if (label14.Text == "...")
            {
                MessageBox.Show("Kérlek, előbb válassz ki egy módosítandó rendszerAltípust!");
            }
            else
            {
                sqlKapcsolat.Open();
                string sqlParancs = "UPDATE cbfeladatsystemC SET fscNeve='" + textBox4.Text + "',modTime='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "',modUser='" + label1.Text + "' WHERE fscID='" + label14.Text + "'";
                MySqlDataAdapter SDA = new MySqlDataAdapter(sqlParancs, sqlKapcsolat);
                SDA.SelectCommand.ExecuteNonQuery();
                sqlKapcsolat.Close();
                MessageBox.Show("Az adatok módosítva!");
                adatBetoltoRendszerAltipusok();
                kiurito();
                textBox4.Focus();
            }
        }
        private void button12_Click(object sender, EventArgs e) //RENDSZER-ALTÍPUSOK - Törlés
        {
            if (label14.Text == "...")
            {
                MessageBox.Show("Törléshez válassz ki egy RendszerAltípust, dupla klikkeléssel");
            }
            else
            {
                if (MessageBox.Show("Biztosan törölni akarod az adatokat?", "ADAT TÖRLÉSE?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    sqlKapcsolat.Open();
                    String sqlParancs = "DELETE FROM cbfeladatsystemC WHERE fscID='" + label14.Text + "'";
                    MySqlDataAdapter SDA = new MySqlDataAdapter(sqlParancs, sqlKapcsolat);
                    SDA.SelectCommand.ExecuteNonQuery();
                    sqlKapcsolat.Close();
                    MessageBox.Show("A rekord törlésre került!");
                    kiurito();
                    adatBetoltoRendszerAltipusok();
                    textBox4.Focus();
                }
            }
        }

        private void button23_Click(object sender, EventArgs e) //FELADATTÍPUS - MUTASD MIND
        {
            adatBetoltoFeladattipusok();
        }
        private void button13_Click(object sender, EventArgs e) //FELADATTÍPUS - Hozzáadás
        {
            if (textBox5.Text.Length == 0 || textBox6.Text.Length == 0)
            {
                MessageBox.Show("Adj meg helyes Feladattípust!");
            }
            else
            {
                sqlKapcsolat.Open();
                string sqlParancs = "INSERT INTO cbfeladattipus (FeladatTipusNeve, FeladatTipusID, addTime, addUser, modTime) VALUES('" + textBox5.Text + "','" + textBox6.Text + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "','" + label17.Text + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "')";
                MySqlDataAdapter SDA = new MySqlDataAdapter(sqlParancs, sqlKapcsolat);
                SDA.SelectCommand.ExecuteNonQuery();
                sqlKapcsolat.Close();
                MessageBox.Show("Adat felvéve!");
                kiurito();
                adatBetoltoFeladattipusok();
                textBox5.Focus();
            }
        }
        private void button14_Click(object sender, EventArgs e) //FELADATTÍPUS - Módosítás
        {
            if (label17.Text == "...")
            {
                MessageBox.Show("Kérlek, előbb válassz ki egy módosítandó Feladattípust!");
            }
            else
            {
                sqlKapcsolat.Open();
                string sqlParancs = "UPDATE cbfeladattipus SET FeladatTipusNeve='" + textBox5.Text + "',FeladatTipusID='" + textBox6.Text + "',modTime='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "',modUser='" + label1.Text + "' WHERE FelTipID='" + label17.Text + "'";
                MySqlDataAdapter SDA = new MySqlDataAdapter(sqlParancs, sqlKapcsolat);
                SDA.SelectCommand.ExecuteNonQuery();
                sqlKapcsolat.Close();
                MessageBox.Show("Az adatok módosítva!");
                adatBetoltoFeladattipusok();
                kiurito();
                textBox5.Focus();
            }
        }
        private void button15_Click(object sender, EventArgs e) //FELADATTÍPUS - Törlés
        {
            if (label17.Text == "...")
            {
                MessageBox.Show("Törléshez válassz ki egy Feladattípust, dupla klikkeléssel");
            }
            else
            {
                if (MessageBox.Show("Biztosan törölni akarod az adatokat?", "ADAT TÖRLÉSE?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    sqlKapcsolat.Open();
                    String sqlParancs = "DELETE FROM cbfeladattipus WHERE FelTipID='" + label17.Text + "'";
                    MySqlDataAdapter SDA = new MySqlDataAdapter(sqlParancs, sqlKapcsolat);
                    SDA.SelectCommand.ExecuteNonQuery();
                    sqlKapcsolat.Close();
                    MessageBox.Show("A rekord törlésre került!");
                    kiurito();
                    adatBetoltoFeladattipusok();
                    textBox5.Focus();
                }
            }
        }

        private void button24_Click(object sender, EventArgs e) //ÜGYFÉLCSOPORT - MUTASD MIND
        {
            adatBetoltoUsercsoportok();
        }
        private void button16_Click(object sender, EventArgs e) //ÜGYFÉLCSOPORT - Hozzáadás
        {
            if (textBox7.Text.Length == 0)
            {
                MessageBox.Show("Adj meg helyes Ügyfélcsoportot!");
            }
            else
            {
                sqlKapcsolat.Open();
                string sqlParancs = "INSERT INTO cbusergroup2 (ugNeve, addTime, addUser, modTime) VALUES('" + textBox7.Text + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "','" + label21.Text + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "')";
                MySqlDataAdapter SDA = new MySqlDataAdapter(sqlParancs, sqlKapcsolat);
                SDA.SelectCommand.ExecuteNonQuery();
                sqlKapcsolat.Close();
                MessageBox.Show("Adat felvéve!");
                kiurito();
                adatBetoltoUsercsoportok();
                textBox7.Focus();
            }
        }
        private void button17_Click(object sender, EventArgs e) //ÜGYFÉLCSOPORT - Módosítás
        {
            if (label21.Text == "...")
            {
                MessageBox.Show("Kérlek, előbb válassz ki egy módosítandó Ügyfélcsoportot!");
            }
            else
            {
                sqlKapcsolat.Open();
                string sqlParancs = "UPDATE cbusergroup2 SET ugNeve='" + textBox7.Text + "',modTime='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "',modUser='" + label1.Text + "' WHERE FelTipID='" + label21.Text + "'";
                MySqlDataAdapter SDA = new MySqlDataAdapter(sqlParancs, sqlKapcsolat);
                SDA.SelectCommand.ExecuteNonQuery();
                sqlKapcsolat.Close();
                MessageBox.Show("Az adatok módosítva!");
                kiurito();
                adatBetoltoUsercsoportok();
                textBox7.Focus();
            }
        }

        // FÜGGVÉNYEIM //
        // duplaklikk a táblázatban //
        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            label5.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            label8.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            label11.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            label14.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            label17.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            label21.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox4.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox5.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            // ez problémás, mert máshol nincs második teszbox :( így itt eltörik a többi, ami nem duplaboxos
            //textBox6.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            // ez a probléma vége
            textBox7.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
        }
        // adatbetöltések //
        private void adatBetoltoCegeink()
        {
            sqlKapcsolat.Open();
            String sqlParancs = "SELECT CegeinkID, CegeinkNeve FROM cbcegek";
            SDA = new MySqlDataAdapter(sqlParancs, sqlKapcsolat);
            dt = new DataTable();
            SDA.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            sqlKapcsolat.Close();
        }
        private void adatBetoltoRendszernevek()
        {
            sqlKapcsolat.Open();
            String sqlParancs = "SELECT fsaID, fsaNeve FROM cbfeladatsystemA";
            SDA = new MySqlDataAdapter(sqlParancs, sqlKapcsolat);
            dt = new DataTable();
            SDA.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            sqlKapcsolat.Close();
        }
        private void adatBetoltoRendszerTipusnevek()
        {
            sqlKapcsolat.Open();
            String sqlParancs = "SELECT fsbID, fsbNeve FROM cbfeladatsystemB";
            SDA = new MySqlDataAdapter(sqlParancs, sqlKapcsolat);
            dt = new DataTable();
            SDA.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            sqlKapcsolat.Close();
        }
        private void adatBetoltoRendszerAltipusok()
        {
            sqlKapcsolat.Open();
            String sqlParancs = "SELECT fscID, fscNeve FROM cbfeladatsystemC";
            SDA = new MySqlDataAdapter(sqlParancs, sqlKapcsolat);
            dt = new DataTable();
            SDA.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            sqlKapcsolat.Close();
        }
        private void adatBetoltoFeladattipusok()
        {
            sqlKapcsolat.Open();
            String sqlParancs = "SELECT felTipID, FeladatTipusNeve, FeladatTipusID FROM cbfeladattipus";
            SDA = new MySqlDataAdapter(sqlParancs, sqlKapcsolat);
            dt = new DataTable();
            SDA.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            sqlKapcsolat.Close();
        }
        private void adatBetoltoUsercsoportok()
        {
            sqlKapcsolat.Open();
            String sqlParancs = "SELECT ugID, ugNeve FROM cbusergroup2";
            SDA = new MySqlDataAdapter(sqlParancs, sqlKapcsolat);
            dt = new DataTable();
            SDA.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            sqlKapcsolat.Close();
        }
        //  adatürítés //
        private void kiurito()
        {
            dataGridView1.DataSource = null;
            label5.Text = "...";
            textBox1.Text = "";
            label8.Text = "...";
            textBox2.Text = "";
            label11.Text = "...";
            textBox3.Text = "";
            label14.Text = "...";
            textBox4.Text = "";
            label17.Text = "...";
            textBox5.Text = "";
            textBox6.Text = "";
            label21.Text = "...";
            textBox7.Text = "";
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
