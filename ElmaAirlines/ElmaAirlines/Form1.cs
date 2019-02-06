using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace ElmaAirlines
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        OleDbConnection baglanti;
        OleDbCommand al;
        OleDbDataReader oku;

        private void Form1_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            // TEXTBOX'A YAZILAN YAZIYI YILDIZ ŞEKLİNDE GÖSTER (A1)

            if (checkBox1.Checked)
            {
                textBox1.PasswordChar = '*';
                
            }
            else
            {
                textBox1.PasswordChar = '\0';
            }

            // A1 SON
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // GİRİŞ SAYFASINDA KULLANICI ADINI VE ŞİFREYİ VERİTABANINDAN EŞLEŞTİR VE DİĞER FORMA GEÇİŞ YAP (A2)

            string ad = textBox2.Text;
            string sifre = textBox1.Text;
            baglanti = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=bilet.accdb");
            al = new OleDbCommand();
            baglanti.Open();
            al.Connection = baglanti;
            al.CommandText = "SELECT * FROM Kullanicilar where Kullanici_Adi='" + textBox2.Text + "' AND Sifre='" + textBox1.Text + "'";
            oku = al.ExecuteReader();
            if (oku.Read())
            {
                Form2 flm = new Form2();
                flm.Show();
                this.Hide();

               
            }
            else
            {
                MessageBox.Show("Kullanıcı Adı Yada Şifreyi Yanlış Girdiniz, Lütfen Bilgileri Kontrol Edin!", "ELMA AİRLİNES!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

            baglanti.Close();
        }

        // A2 SON
    }
}
