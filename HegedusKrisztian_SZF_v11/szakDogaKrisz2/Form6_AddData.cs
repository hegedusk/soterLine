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
    public partial class Form6_AddData : Form
    {
        // DEKLARÁLÁSOK //
        MySqlConnection sqlKapcsolat = new MySqlConnection(@"Data Source=213.181.208.171;port=3306;Initial Catalog=sharpshark;User Id=sharpsharkuser;password='sh4rk$h4rp'");

        public Form6_AddData(String felhNev)
        {
            InitializeComponent();
            this.Text = "MasterP - Adatfelvétel";
            label31.Text = this.Text;
            label26.Text = felhNev;
            label26.Visible = false;
            this.MinimumSize = new Size(1264, 628);
            ComboboxBehivo();
            KeyPreview = true;
        }

        // GOMBOK //
        private void button1_Click(object sender, EventArgs e)  // GOMBOK - Cellák Ürítése
        {
            kiurito();
        }
        private void button6_Click(object sender, EventArgs e)  // GOMBOK - Mutasd MIND
        {
            mutasdMind();
            kiurito();
        }
        private void button3_Click(object sender, EventArgs e)  // GOMBOK - Hozzáadás
        {
            if (richTextBox1.Text.Length == 0)
            {
                MessageBox.Show("A Mentéshez MINDEN adatot adj meg!");
            }
            else
            {
                sqlKapcsolat.Open();
                String query = "INSERT INTO Clients (Ceg,Netto,Brutto,Elvegezve,FeladatTipus,FeladatTipusID,FeladatSystemA,FeladatSystemB,FeladatSystemC,UserID,Username,UserCompany,TicketURL,InvoiceURL,Domains,WorkTime,LearnTime,FullTime,paidTime,TimeRate,Megjegyzes,LetrehozasIdeje,LetrehozoUser) VALUES('" + comboBox1.Text + "','" + textBox2.Text + "','" + Convert.ToInt32(label6.Text) + "','" + dateTimePicker1.Value.Date.ToString("yyyy.MM.dd") + "','" + comboBox2.Text + "','" + label10.Text + "','" + comboBox3.Text + "','" + comboBox4.Text + "','" + comboBox5.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + textBox8.Text + "','" + textBox9.Text + "','" + label27.Text + "','" + label28.Text + "','" + label29.Text + "','" + richTextBox1.Text + "','" + DateTime.Now + "','" + label26.Text + "')";
                MySqlDataAdapter SDA = new MySqlDataAdapter(query, sqlKapcsolat);
                SDA.SelectCommand.ExecuteNonQuery();
                sqlKapcsolat.Close();
                MessageBox.Show("Adatok felvéve!");
                kiurito();
                button6.PerformClick();
            }
        }
        private void button7_Click(object sender, EventArgs e)  // GOMBOK - Kiszámol - nyomj meg
        {
            string csekkolo;
            csekkolo = "";
            if ((textBox1.Text == csekkolo && textBox8.Text == csekkolo && textBox9.Text == csekkolo))
            {
                MessageBox.Show("Kérlek add meg a NETTO értéket a kiszámításhoz");
            }
            else if (textBox9.Text.Length == 0)
            {
                MessageBox.Show("Add meg a munkaidő adatait is!");
            }
            else
            {
                // FULLTIME LABEL kiszámolása
                int a;
                a = Convert.ToInt32(textBox8.Text);
                int b;
                b = Convert.ToInt32(textBox9.Text);
                label27.Text = (a + b).ToString();

                // PAIDTIME LABEL kiszámolása
                double c;
                c = Convert.ToDouble(textBox1.Text);
                double percdij;
                percdij = 150;
                label28.Text = (c / percdij).ToString();

                //TIMERATE LABEL kiszámolása
                double d;
                d = Convert.ToDouble(label28.Text);
                double f;
                f = Convert.ToDouble(label27.Text);
                label29.Text = (d / f).ToString();
            }
        }
        private void button4_Click(object sender, EventArgs e)  // GOMBOK - Frissítés
        {
            if (label2.Text == "")
            {
                MessageBox.Show("Kérlek előbb válaszd ki a módosítandó adatot duplaklikkeléssel!");
            }
            else
            {
                sqlKapcsolat.Open();
                String query = "UPDATE Clients SET Ceg='" + comboBox1.Text + "',Netto='" + textBox1.Text + "', Brutto='" + label6.Text + "',Elvegezve='" + dateTimePicker1.Value.Date.ToString("yyyy.MM.dd") + "',FeladatTipus='" + comboBox2.Text + "',FeladatTipusID='" + label10.Text + "',FeladatSystemA='" + comboBox3.Text + "',FeladatSystemB='" + comboBox4.Text + "',FeladatSystemC='" + comboBox5.Text + "',UserID='" + textBox2.Text + "',UserName='" + textBox3.Text + "',UserCompany='" + textBox4.Text + "',TicketURL='" + textBox5.Text + "',InvoiceURL='" + textBox6.Text + "',Domains='" + textBox7.Text + "',WorkTime='" + textBox8.Text + "',LearnTime='" + textBox9.Text + "',FullTime='" + label27.Text + "',PaidTime='" + label28.Text + "',TimeRate='" + label29.Text + "',Megjegyzes='" + richTextBox1.Text + "',UtolsoModositas='" + DateTime.Now + "',UtolsoModUser='" + label26.Text + "' WHERE ID='" + label2.Text + "'";
                MySqlDataAdapter SDA = new MySqlDataAdapter(query, sqlKapcsolat);
                SDA.SelectCommand.ExecuteNonQuery();
                sqlKapcsolat.Close();
                MessageBox.Show("Az adatok módosítva!");
                kiurito();
                button6.PerformClick();
            }
        }
        private void button5_Click(object sender, EventArgs e)  // GOMBOK - Törlés
        {
            string vagy1 = "...";
            string vagy2 = "";
            if (label2.Text == vagy1 || label2.Text==vagy2)
            {
                MessageBox.Show("Csak akkor törölhetsz adatot, ha kiválasztod azt");
            }
            else
            {
                if (MessageBox.Show("Biztosan törölni akarod az adatokat?", "ADAT TÖRLÉSE?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    sqlKapcsolat.Open();
                    String sqlParancs = "DELETE FROM Clients WHERE ID='" + label2.Text + "'";
                    MySqlDataAdapter SDA = new MySqlDataAdapter(sqlParancs, sqlKapcsolat);
                    SDA.SelectCommand.ExecuteNonQuery();
                    sqlKapcsolat.Close();
                    MessageBox.Show("A rekord törlésre került!");
                    kiurito();
                    mutasdMind();
                }
            }
        }

        // DINAMIKUS MEZŐK //
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)   // "Nettó" mező feltétel
        {
            e.Handled = !(char.IsDigit(e.KeyChar));
        }
        private void textBox1_TextChanged(object sender, EventArgs e)   // "Nettó" mező - bevitel 01
        {
            double vat = 1.27;
            double anDouble;
            anDouble = double.Parse(textBox1.Text) * vat;
            label6.Text = Convert.ToString(anDouble);
        }
        
        // TÁBLÁZAT
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            label2.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            comboBox1.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            label6.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            comboBox2.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            label10.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
            comboBox3.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
            comboBox4.Text = dataGridView1.SelectedRows[0].Cells[8].Value.ToString();
            comboBox5.Text = dataGridView1.SelectedRows[0].Cells[9].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[10].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[11].Value.ToString();
            textBox4.Text = dataGridView1.SelectedRows[0].Cells[12].Value.ToString();
            textBox5.Text = dataGridView1.SelectedRows[0].Cells[13].Value.ToString();
            textBox6.Text = dataGridView1.SelectedRows[0].Cells[14].Value.ToString();
            textBox7.Text = dataGridView1.SelectedRows[0].Cells[15].Value.ToString();
            textBox8.Text = dataGridView1.SelectedRows[0].Cells[16].Value.ToString();
            textBox9.Text = dataGridView1.SelectedRows[0].Cells[17].Value.ToString();
            label27.Text = dataGridView1.SelectedRows[0].Cells[18].Value.ToString();
            label28.Text = dataGridView1.SelectedRows[0].Cells[19].Value.ToString();
            label29.Text = dataGridView1.SelectedRows[0].Cells[20].Value.ToString();
            richTextBox1.Text = dataGridView1.SelectedRows[0].Cells[21].Value.ToString();
        }

        // FÜGGVÉNYEIM //
        // tábla betöltése //
        public void mutasdMind()
        {
            sqlKapcsolat.Open();
            String query = "SELECT * FROM Clients";
            MySqlDataAdapter SDA = new MySqlDataAdapter(query, sqlKapcsolat);
            DataTable dt = new DataTable();
            SDA.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            sqlKapcsolat.Close();
        }
        // adatbetöltések //
        public void ComboboxBehivo()
        {
            sqlKapcsolat.Open();
            String query = "SELECT CegeinkNeve FROM cbcegek";
            MySqlDataAdapter SDA = new MySqlDataAdapter(query, sqlKapcsolat);
            DataTable dt = new DataTable();
            SDA.Fill(dt);
            comboBox1.ValueMember = "CegeinkNeve";
            comboBox1.DisplayMember = "CegeinkNeve";
            comboBox1.DataSource = dt;

            String query2 = "SELECT FeladatTipusNeve FROM cbfeladattipus";
            MySqlDataAdapter SDA2 = new MySqlDataAdapter(query2, sqlKapcsolat); 
            DataTable dt2 = new DataTable();
            SDA2.Fill(dt2);
            comboBox2.ValueMember = "FeladatTipusNeve";
            comboBox2.DisplayMember = "FeladatTipusNeve";
            comboBox2.DataSource = dt2;

            String query3 = "SELECT fsaNeve FROM cbfeladatsystemA";
            MySqlDataAdapter SDA3 = new MySqlDataAdapter(query3, sqlKapcsolat);
            DataTable dt3 = new DataTable();
            SDA3.Fill(dt3);
            comboBox3.ValueMember = "fsaNeve";
            comboBox3.DisplayMember = "fsaNeve";
            comboBox3.DataSource = dt3;

            String query4 = "SELECT fsbNeve FROM cbfeladatsystemB";
            MySqlDataAdapter SDA4 = new MySqlDataAdapter(query4, sqlKapcsolat);
            DataTable dt4 = new DataTable();
            SDA4.Fill(dt4);
            comboBox4.ValueMember = "fsbNeve";
            comboBox4.DisplayMember = "fsbNeve";
            comboBox4.DataSource = dt4;

            String query5 = "SELECT fscNeve FROM cbfeladatsystemC";
            MySqlDataAdapter SDA5 = new MySqlDataAdapter(query5, sqlKapcsolat);
            DataTable dt5 = new DataTable();
            SDA5.Fill(dt5);
            comboBox5.ValueMember = "fscNeve";
            comboBox5.DisplayMember = "fscNeve";
            comboBox5.DataSource = dt5;

            sqlKapcsolat.Close();
        }
        // adatürités //
        public void kiurito()
        {
            label2.Text = "";
            label6.Text = "";
            label10.Text = "";
            label27.Text = "";
            label28.Text = "";
            label29.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
            comboBox4.Text = "";
            comboBox5.Text = "";
            textBox1.Text = "0";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            dateTimePicker1.Text = "";
            richTextBox1.Text = "";
        }
        // F-re adatürítés //
        private void Form6_AddData_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                kiurito();
            }
        }
        // "X" - ablakBezárás
        private void label30_Click(object sender, EventArgs e)
        {
            Close();
        }

        // MOZGATÁSI PANEL
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
