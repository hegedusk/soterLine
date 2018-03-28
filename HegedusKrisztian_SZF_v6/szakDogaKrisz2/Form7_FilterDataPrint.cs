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
using System.IO;

namespace szakDogaKrisz2
{
    public partial class Form7_FilterDataPrint : Form
    {
        MySqlConnection sqlKapcsolat = new MySqlConnection(@"Data Source=213.181.208.171;port=3306;Initial Catalog=sharpshark;User Id=sharpsharkuser;password='sh4rk$h4rp'"); // 2 - SQL kapcsolat
        MySqlDataAdapter SDA;
        DataTable dt;
        MySqlCommandBuilder builder;

        public Form7_FilterDataPrint(string felhNev)
        {
            InitializeComponent();
            this.Text = "MasterP - Adatszűrés - Export és Nyomtatás";
            label1.Text = felhNev;
            label1.Visible = false;
            label15.Visible = false;
            this.MinimumSize = new Size(1280, 628);
            ComboboxBehivo();
        }

        // GOMBOK
        private void button1_Click(object sender, EventArgs e)  // SZŰRÉS gomb
        {
            if ((comboBox1.Text.Length == 0) && (textBox1.Text.Length == 0) && (textBox2.Text.Length == 0))
            {
                MessageBox.Show("Add meg a CÉG-et és a Nettó '-tól -ig' határértékeket!");
            }
            else
            {
                Mutasd();
            }
        }
        private void button2_Click(object sender, EventArgs e)  // MUTASD MIND gomb
        {
            MutasdMind();
        }
        private void button3_Click(object sender, EventArgs e)  // EXPORTÁLÁS gomb
        {
            saveFileDialog1.InitialDirectory = "C:";
            saveFileDialog1.Title = "Adathalmaz mentése fájlként";
            saveFileDialog1.FileName = "masterp-adatexport";
            saveFileDialog1.Filter = "Excel fájl 2016(*.xls)|*.xlsx|Excel fájl 2003(*.xls)|*.xls|CSV adatfájl(*.csv)|*.csv";

            if (saveFileDialog1.ShowDialog() != DialogResult.Cancel)
            {
                label15.Visible = true;

                Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
                ExcelApp.Application.Workbooks.Add(Type.Missing); 

                // a lementett excel file stíluslapja módosítható
                ExcelApp.Columns.ColumnWidth = 20;

                // storing header part in excell
                for (int i = 1; i < dataGridView1.Columns.Count + 1; i++)
                {
                    ExcelApp.Cells[1, i] = dataGridView1.Columns[i - 1].HeaderText;
                }

                // sorting each row and column to excel sheet
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridView1.Columns.Count; j++)
                    {
                        ExcelApp.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString();
                    }
                }
                
                // MENTÉS maga
                ExcelApp.ActiveWorkbook.SaveCopyAs(saveFileDialog1.FileName.ToString());
                ExcelApp.ActiveWorkbook.Saved = true;
                ExcelApp.Quit();

                label15.Visible = false;
                MessageBox.Show("Exportálás elkészült!");
            }
        }
        private void button4_Click(object sender, EventArgs e)  //NYOMTATÁS gomb
        {
            printPreviewDialog1.Document = printDocument1;
            printDocument1.DefaultPageSettings.Landscape = true;    // lap fektetése
            // printDocument1.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("Custom", 794,1123);
            printPreviewDialog1.ShowDialog();
        }

        // SAJÁT FÜGGVÉNYEK
        public void ComboboxBehivo()
        {
            sqlKapcsolat.Open();
            String query = "SELECT CegeinkNeve FROM cbcegek";
            MySqlDataAdapter SDA = new MySqlDataAdapter(query, sqlKapcsolat);
            System.Data.DataTable dt = new System.Data.DataTable();
            SDA.Fill(dt);
            comboBox1.ValueMember = "CegeinkNeve";
            comboBox1.DisplayMember = "CegeinkNeve";
            comboBox1.DataSource = dt;

            String query2 = "SELECT FeladatTipusNeve FROM cbfeladattipus";
            MySqlDataAdapter SDA2 = new MySqlDataAdapter(query2, sqlKapcsolat);
            System.Data.DataTable dt2 = new System.Data.DataTable();
            SDA2.Fill(dt2);
            comboBox2.ValueMember = "FeladatTipusNeve";
            comboBox2.DisplayMember = "FeladatTipusNeve";
            comboBox2.DataSource = dt2;

            String query3 = "SELECT fsaNeve FROM cbfeladatsystemA";
            MySqlDataAdapter SDA3 = new MySqlDataAdapter(query3, sqlKapcsolat);
            System.Data.DataTable dt3 = new System.Data.DataTable();
            SDA3.Fill(dt3);
            comboBox3.ValueMember = "fsaNeve";
            comboBox3.DisplayMember = "fsaNeve";
            comboBox3.DataSource = dt3;

            String query4 = "SELECT fsbNeve FROM cbfeladatsystemB";
            MySqlDataAdapter SDA4 = new MySqlDataAdapter(query4, sqlKapcsolat);
            System.Data.DataTable dt4 = new System.Data.DataTable();
            SDA4.Fill(dt4);
            comboBox4.ValueMember = "fsbNeve";
            comboBox4.DisplayMember = "fsbNeve";
            comboBox4.DataSource = dt4;

            String query5 = "SELECT fscNeve FROM cbfeladatsystemC";
            MySqlDataAdapter SDA5 = new MySqlDataAdapter(query5, sqlKapcsolat);
            System.Data.DataTable dt5 = new System.Data.DataTable();
            SDA5.Fill(dt5);
            comboBox5.ValueMember = "fscNeve";
            comboBox5.DisplayMember = "fscNeve";
            comboBox5.DataSource = dt5;

            sqlKapcsolat.Close();
        }

        public void Mutasd()
        {
            sqlKapcsolat.Open();  // 4 - 
            System.Data.DataTable dt = new System.Data.DataTable();  // 4 - 

            if (comboBox1.Text.Length > 0)  // 4 - 
            {
                String query = "SELECT * FROM Clients WHERE Ceg LIKE '" + comboBox1.Text + "' AND Netto > '" + textBox1.Text + "%' AND Netto < '" + textBox2.Text + "%'  AND Elvegezve LIKE '" + textBox7.Text + "%' AND FeladatTipus LIKE '%" + comboBox2.Text + "%' AND FeladatSystemA LIKE '%" + comboBox3.Text + "%' AND FeladatSystemB LIKE '%" + comboBox4.Text + "%' AND FeladatSystemC LIKE '%" + comboBox5.Text + "%' AND UserID LIKE '" + textBox3.Text + "%' AND UserName LIKE '" + textBox4.Text + "%' AND UserCompany LIKE '" + textBox5.Text + "%' AND Domains LIKE '" + textBox6.Text + "%'";
                MySqlDataAdapter SDA = new MySqlDataAdapter(query, sqlKapcsolat);
                SDA.Fill(dt);
            }

            dataGridView1.DataSource = dt;  // 4 - 
            dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            dataGridView1.Columns["ID"].Visible = false;
            dataGridView1.Columns["FeladatTipusID"].Visible = false;
            dataGridView1.Columns["TicketURL"].Visible = false;
            dataGridView1.Columns["InvoiceURL"].Visible = false;
            dataGridView1.Columns["WorkTime"].Visible = false;
            dataGridView1.Columns["LearnTime"].Visible = false;
            dataGridView1.Columns["FullTime"].Visible = false;
            dataGridView1.Columns["PaidTime"].Visible = false;
            dataGridView1.Columns["TimeRate"].Visible = false;
            dataGridView1.Columns["Megjegyzes"].Visible = false;
            dataGridView1.Columns["LetrehozasIdeje"].Visible = false;
            dataGridView1.Columns["LetrehozoUser"].Visible = false;
            dataGridView1.Columns["UtolsoModositas"].Visible = false;
            dataGridView1.Columns["UtolsoModUser"].Visible = false;
            dataGridView1.Columns[1].HeaderText = "Cég";
            dataGridView1.Columns[2].HeaderText = "Nettó";
            dataGridView1.Columns[3].HeaderText = "Bruttó";
            dataGridView1.Columns[4].HeaderText = "Elvégezve";
            dataGridView1.Columns[5].HeaderText = "Feladat";
            dataGridView1.Columns[7].HeaderText = "Rendszer";
            dataGridView1.Columns[8].HeaderText = "Típus";
            dataGridView1.Columns[9].HeaderText = "Séma";
            dataGridView1.Columns[10].HeaderText = "WHMCSID";
            dataGridView1.Columns[11].HeaderText = "Ügyfél";
            dataGridView1.Columns[12].HeaderText = "ÜgyfélCég";
            dataGridView1.Columns[15].HeaderText = "Domain";
            dataGridView1.Columns[22].HeaderText = "Létrehozva";
            dataGridView1.Columns[23].HeaderText = "Létrehozó";
            dataGridView1.Columns[24].HeaderText = "Utolsó módosítás";
            dataGridView1.Columns[25].HeaderText = "Utolsó módosító";
            sqlKapcsolat.Close();
        }

        public void MutasdMind()
        {
            sqlKapcsolat.Open();
            String query = "SELECT * FROM Clients";
            MySqlDataAdapter SDA = new MySqlDataAdapter(query, sqlKapcsolat);
            System.Data.DataTable dt = new System.Data.DataTable();
            SDA.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            dataGridView1.Columns["ID"].Visible = false;
            dataGridView1.Columns["FeladatTipusID"].Visible = false;
            dataGridView1.Columns["TicketURL"].Visible = false;
            dataGridView1.Columns["InvoiceURL"].Visible = false;
            dataGridView1.Columns["WorkTime"].Visible = false;
            dataGridView1.Columns["LearnTime"].Visible = false;
            dataGridView1.Columns["FullTime"].Visible = false;
            dataGridView1.Columns["PaidTime"].Visible = false;
            dataGridView1.Columns["TimeRate"].Visible = false;
            dataGridView1.Columns["Megjegyzes"].Visible = false;
            dataGridView1.Columns["LetrehozasIdeje"].Visible = false;
            dataGridView1.Columns["LetrehozoUser"].Visible = false;
            dataGridView1.Columns["UtolsoModositas"].Visible = false;
            dataGridView1.Columns["UtolsoModUser"].Visible = false;
            dataGridView1.Columns[1].HeaderText = "Cég";
            dataGridView1.Columns[2].HeaderText = "Nettó";
            dataGridView1.Columns[3].HeaderText = "Bruttó";
            dataGridView1.Columns[4].HeaderText = "Elvégezve";
            dataGridView1.Columns[5].HeaderText = "Feladat";
            dataGridView1.Columns[7].HeaderText = "Rendszer";
            dataGridView1.Columns[8].HeaderText = "Típus";
            dataGridView1.Columns[9].HeaderText = "Séma";
            dataGridView1.Columns[10].HeaderText = "WHMCSID";
            dataGridView1.Columns[11].HeaderText = "Ügyfél";
            dataGridView1.Columns[12].HeaderText = "ÜgyfélCég";
            dataGridView1.Columns[15].HeaderText = "Domain";
            dataGridView1.Columns[22].HeaderText = "Létrehozva";
            dataGridView1.Columns[23].HeaderText = "Létrehozó";
            dataGridView1.Columns[24].HeaderText = "Utolsó módosítás";
            dataGridView1.Columns[25].HeaderText = "Utolsó módosító";
            sqlKapcsolat.Close();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            int totalnumber = 0;
            int itemperpage = 0;
            int BalMargo = 20, FelsoMargo = 30;
            Font f_sor = new Font("Times New Roman", 12, FontStyle.Regular);
            Font f_bold = new Font("Times New Roman", 12, FontStyle.Bold);
            Font f_boldnagy = new Font("Times New Roman", 14, FontStyle.Bold);
            SolidBrush ecset = new SolidBrush(Color.Black);
            SolidBrush ecset2 = new SolidBrush(Color.Gray);
            e.Graphics.DrawString("Adatkivonat - MasterP", f_boldnagy, ecset, BalMargo + 450, FelsoMargo);
            e.Graphics.DrawString("Készítette: " + label1.Text + " - " + DateTime.Now.ToShortDateString(), f_sor, ecset2, BalMargo + 450, FelsoMargo + 780);
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                e.Graphics.DrawString(dataGridView1.Rows[i].Cells[1].Value.ToString() + "", f_sor, ecset, BalMargo, FelsoMargo + 40 + (i * 30));
                e.Graphics.DrawString(dataGridView1.Rows[i].Cells[2].Value.ToString() + " Ft", f_sor, ecset, BalMargo + 50, FelsoMargo + 40 + (i * 30));
                e.Graphics.DrawString(dataGridView1.Rows[i].Cells[3].Value.ToString() + " Ft", f_sor, ecset, BalMargo + 150, FelsoMargo + 40 + (i * 30));
                e.Graphics.DrawString(dataGridView1.Rows[i].Cells[4].Value.ToString() + "", f_sor, ecset, BalMargo + 250, FelsoMargo + 40 + (i * 30));
                e.Graphics.DrawString(dataGridView1.Rows[i].Cells[5].Value.ToString() + "", f_sor, ecset, BalMargo + 350, FelsoMargo + 40 + (i * 30));
                e.Graphics.DrawString(dataGridView1.Rows[i].Cells[10].Value.ToString() + "", f_sor, ecset, BalMargo + 500, FelsoMargo + 40 + (i * 30));
                e.Graphics.DrawString(dataGridView1.Rows[i].Cells[11].Value.ToString() + "", f_sor, ecset, BalMargo + 550, FelsoMargo + 40 + (i * 30));
                e.Graphics.DrawString(dataGridView1.Rows[i].Cells[12].Value.ToString() + "", f_sor, ecset, BalMargo + 700, FelsoMargo + 40 + (i * 30));
                e.Graphics.DrawString(dataGridView1.Rows[i].Cells[15].Value.ToString() + "", f_sor, ecset, BalMargo + 900, FelsoMargo + 40 + (i * 30));
            }
            //e.Graphics.VisibleClipBounds;
            //e.HasMorePages = true; //<- több oldalas nyomtatáshoz
        }
    }
}
