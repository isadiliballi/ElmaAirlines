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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        public static string a, b, isa,diliballı;
        int fiyat1, fiyat2, toplam;
        Button secilenKoltuk;
       


        OleDbConnection bağlantı = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=bilet.accdb");
        OleDbCommand kmt = new OleDbCommand();
        DataTable tablo = new DataTable();


       


        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            tablo.Clear();

            label1.Text = comboBox1.Text;
            label2.Text = comboBox2.Text;



            if (comboBox1.Text == comboBox2.Text)
            {
                MessageBox.Show("Lütfen Şehirleri Farklı Seçin!", "ELMA AİRLİNES!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            else if (radioButton1.Checked == false && radioButton2.Checked == false)
            {
                MessageBox.Show("Lütfen Tek Yön yada Gidiş Dönüş Seçeneğini İşaretleyin!", "ELMA AİRLİNES!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


            else
            {
                Elma.SelectedIndex = 1;
            }

            try
            {
                bağlantı.Open();
                string tarih = dateTimePicker1.Value.ToString("dd.MM.yyyy");
                isa = "SELECT * FROM Ucuslar WHERE Nereden LIKE '%" + comboBox1.Text + "%' AND Nereye LIKE '%" + comboBox2.Text + "%' AND Tarih LIKE '%" + tarih + "%'";
                OleDbDataAdapter da = new OleDbDataAdapter(isa, bağlantı);
                da.Fill(tablo);
                bağlantı.Close();
                dataGridView1.DataSource = tablo;




            }
            catch (Exception hata)
            {

                MessageBox.Show("Eksik Alan Bıraktın, Lütfen Geri Giderek Eksik Yerleri Doldur!", "ELMA AİRLİNES!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            if (radioButton2.Checked == true)
            {
                label93.Visible = true;
            }
            else
            {
                label93.Visible = false;
            }

            if (radioButton2.Checked == true)
            {
                label94.Visible = true;
            }
            else
            {
                label94.Visible = false;
            }



        }

        private void Form2_Load(object sender, EventArgs e)  // FORM2 LOAD


        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            {
                DataTable dt = new DataTable();
                OleDbDataAdapter da = new OleDbDataAdapter("SELECT * FROM Sehirler ORDER BY il ASC ", bağlantı);
                da.Fill(dt);

                a = comboBox1.DisplayMember = "il";
                comboBox1.DataSource = dt;
            }
            {
                DataTable dtable = new DataTable();
                OleDbDataAdapter dadap = new OleDbDataAdapter("SELECT * FROM Sehirler ORDER BY il ASC ", bağlantı);
                dadap.Fill(dtable);

                b = comboBox2.DisplayMember = "il";
                comboBox2.DataSource = dtable;

            }
           


            // DATAGRİDVİEW FONT SEÇİMİ (A2)

            this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.DefaultCellStyle.Font = new Font("Arial Black", 15);
            this.dataGridView1.GridColor = Color.White;

            this.dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView2.DefaultCellStyle.Font = new Font("Arial Black", 15);
            this.dataGridView2.GridColor = Color.White;

            // A2 SON


            comboBox4.Items.Add("Kadın");
            comboBox4.Items.Add("Erkek");
            comboBox3.Items.Add("Nakit");
            comboBox3.Items.Add("Kredi Kartı");


            
        }

        

        private void comboBox1_Click(object sender, EventArgs e)
        {
            comboBox1.Text = "";
        }

        private void comboBox2_Click(object sender, EventArgs e)
        {
            comboBox2.Text = "";
        }

       
       

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            // DATAGRİDVİEW'DEN SEÇİLEN SATIRDAKİ VERİYİ TEXTBOX'A AKTARMA

            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Elma.SelectedIndex = 0;
        }

       

        private void button3_Click(object sender, EventArgs e)
        {
            DataTable tab = new DataTable();
            tab.Clear();

            label23.Text = comboBox2.Text;
            label24.Text = comboBox1.Text;

            try
            {
                bağlantı.Open();
                
                string tarih2 = dateTimePicker3.Value.ToString("dd.MM.yyyy");
                diliballı = "SELECT * FROM Ucuslar WHERE Nereden LIKE '%" + comboBox2.Text + "%' AND Nereye LIKE '%" + comboBox1.Text + "%' AND Tarih LIKE '%" + tarih2 + "%'";
                OleDbDataAdapter da = new OleDbDataAdapter(diliballı, bağlantı);
                da.Fill(tab);
                bağlantı.Close();
                dataGridView2.DataSource = tab;




            }
            catch (Exception hata)
            {

                MessageBox.Show("Eksik Alan Bıraktın, Lütfen Geri Giderek Eksik Yerleri Doldur!", "ELMA AİRLİNES!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            if (textBox1.Text == "")
            {
                MessageBox.Show("Lütfen Seçim Yapın!", "ELMA AİRLİNES!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            else if (radioButton2.Checked == true)
            {
                Elma.SelectedIndex = 6;
            }
            else
            {
                Elma.SelectedIndex = 2;
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Elma.SelectedIndex = 1;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox8.Text == "")
            {
                MessageBox.Show("Lütfen Ad Kısmını Boş Bırakmayın!", "ELMA AİRLİNES!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            else if (textBox9.Text == "")
            {
                MessageBox.Show("Lütfen Soyad Kısmını Boş Bırakmayın!", "ELMA AİRLİNES!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            else if (comboBox4.Text == "")
            {
                MessageBox.Show("Lütfen Cinsiyet Kısmını Boş Bırakmayın!", "ELMA AİRLİNES!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            else if (textBox10.Text == "")
            {
                MessageBox.Show("Lütfen TC No Kısmını Boş Bırakmayın!", "ELMA AİRLİNES!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            else if (textBox10.TextLength < 11)
            {
                MessageBox.Show("TC No Eksik Girdiniz!", "ELMA AİRLİNES!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            else
            {
                Elma.SelectedIndex = 3;
            }

            textBox11.Text = textBox8.Text;
            textBox12.Text = textBox9.Text;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Elma.SelectedIndex = 2;
        }

        private void button7_Click(object sender, EventArgs e)
        {
             if (textBox11.Text == "")
            {
                MessageBox.Show("Lütfen Ad Kısmını Boş Bırakmayın!", "ELMA AİRLİNES!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            else if (textBox12.Text == "")
            {
                MessageBox.Show("Lütfen Soyad Kısmını Boş Bırakmayın!", "ELMA AİRLİNES!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            else if (textBox13.Text == "")
            {
                MessageBox.Show("Lütfen Telefon Kısmını Boş Bırakmayın!", "ELMA AİRLİNES!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

             else if (textBox13.TextLength < 10)
             {
                 MessageBox.Show("Telefon Numarasını Eksik Girdiniz!", "ELMA AİRLİNES!", MessageBoxButtons.OK, MessageBoxIcon.Information);
             }

            else if (textBox14.Text == "")
            {
                MessageBox.Show("Lütfen E-Posta Kısmını Boş Bırakmayın!", "ELMA AİRLİNES!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

             else if (textBox7.Text == "")
             {
                 MessageBox.Show("Lütfen Adres Kısmını Boş Bırakmayın!", "ELMA AİRLİNES!", MessageBoxButtons.OK, MessageBoxIcon.Information);
             }

             else
             {
                 Elma.SelectedIndex = 4;
             }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Elma.SelectedIndex = 3;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (textBox27.Text == "")
            {
                MessageBox.Show("Lütfen Koltuk Seçin!", "ELMA AİRLİNES!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            else if (radioButton2.Checked == true)
            {
                Elma.SelectedIndex = 7;

                label18.Text = textBox8.Text;
                label19.Text = textBox9.Text;
                label21.Text = textBox3.Text;
                label90.Text = textBox4.Text;

                fiyat1 = Convert.ToInt32(textBox6.Text);
                fiyat2 = Convert.ToInt32(textBox25.Text);
                toplam = fiyat1 + fiyat2;
                label91.Text = toplam.ToString();
            }
            else
            {
                Elma.SelectedIndex = 5;

                label18.Text = textBox8.Text;
                label19.Text = textBox9.Text;
                label21.Text = textBox3.Text;
                label90.Text = textBox4.Text;
                label91.Text = textBox6.Text;
            }

            if (radioButton2.Checked == true)
            {

                button76.Visible = true;

            }
            else
            {
                button76.Visible = false;
            }

            if (radioButton1.Checked == true)
            {

                button10.Visible = true;

            }

            else
            {
                button10.Visible = false;
            }
           
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Elma.SelectedIndex = 4;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {


            label22.Visible = true;
            dateTimePicker3.Visible = true;
            pictureBox15.Visible = true;

            radioButton1.Location = new Point(117, 140);
            radioButton2.Location = new Point(117, 182);
            comboBox1.Location = new Point(117, 244);
            pictureBox2.Location = new Point(108, 233);
            pictureBox4.Location = new Point(491, 222);
            comboBox2.Location = new Point(621, 244);
            pictureBox3.Location = new Point(612, 233);
            label3.Location = new Point(111, 315);
            dateTimePicker1.Size = new Size(359, 40);
            dateTimePicker1.Location = new Point(117, 359);
            pictureBox5.Size = new Size(377, 60);
            pictureBox5.Location = new Point(108, 350);
           
            label22.Location = new Point(615, 315);
            dateTimePicker3.Location = new Point(621, 359);
            pictureBox15.Location = new Point(612, 350);
            button1.Size = new Size(133, 41);
            button1.Location = new Point(484, 503);
            pictureBox7.Size = new Size(146, 35);
            pictureBox7.Location = new Point(477, 520);
            

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            label22.Visible = false;
            dateTimePicker3.Visible = false;
            pictureBox15.Visible = false;

            radioButton1.Location = new Point(117, 107);
            radioButton2.Location = new Point(117, 141);
            comboBox1.Location = new Point(117, 199);
            pictureBox2.Location = new Point(108, 188);
            pictureBox4.Location = new Point(491, 182);
            comboBox2.Location = new Point(621, 199);
            pictureBox3.Location = new Point(612, 188);
            label3.Location = new Point(469, 305);
            dateTimePicker1.Size = new Size(239, 41);
            dateTimePicker1.Location = new Point(424, 349);
            pictureBox5.Size = new Size(258, 60);
            pictureBox5.Location = new Point(414, 340);
           
            label22.Location = new Point(615, 315);
            dateTimePicker3.Location = new Point(621, 359);
            pictureBox15.Location = new Point(612, 350);
            button1.Size = new Size(133, 41);
            button1.Location = new Point(484, 503);
            pictureBox7.Size = new Size(146, 35);
            pictureBox7.Location = new Point(477, 520);
           


        }

        private void pictureBox18_Click(object sender, EventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (button14.Enabled == false)
            {
                MessageBox.Show("Koltuk Satın Alınmıştır!", "ELMA AİRLİNES!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                renkDegistir(button14);
                textBox27.Text = button14.Text;
            }
        }

        private void renkDegistir(Button button)
        {
            if(secilenKoltuk != null) {
                secilenKoltuk.BackColor = Color.Transparent;
            }

            button.BackColor = Color.Red;
            secilenKoltuk = button;
            // textBox27.Text = button.Text;
        }


        private void button15_Click(object sender, EventArgs e)
        {
            renkDegistir(button15);
            textBox27.Text = button15.Text;
        }

        private void button18_Click(object sender, EventArgs e)
        {
            renkDegistir(button18);
            textBox27.Text = button18.Text;
        }

        private void button19_Click(object sender, EventArgs e)
        {
            renkDegistir(button19);
            textBox27.Text = button19.Text;
        }

        private void button20_Click(object sender, EventArgs e)
        {
            renkDegistir(button20);
            textBox27.Text = button20.Text;
        }

        private void button17_Click(object sender, EventArgs e)
        {
            renkDegistir(button17);
            textBox27.Text = button17.Text;
        }

        private void button40_Click(object sender, EventArgs e)
        {
            renkDegistir(button40);
            textBox27.Text = button40.Text;
        }

        private void button39_Click(object sender, EventArgs e)
        {
            renkDegistir(button39);
            textBox27.Text = button39.Text;
        }

        private void button38_Click(object sender, EventArgs e)
        {
            renkDegistir(button38);
            textBox27.Text = button38.Text;
        }

        private void button37_Click(object sender, EventArgs e)
        {
            renkDegistir(button37);
            textBox27.Text = button37.Text;
        }

        private void button36_Click(object sender, EventArgs e)
        {
            renkDegistir(button36);
            textBox27.Text = button36.Text;
        }

        private void button33_Click(object sender, EventArgs e)
        {
            renkDegistir(button33);
            textBox27.Text = button33.Text;
        }

        private void button31_Click(object sender, EventArgs e)
        {
            renkDegistir(button31);
            textBox27.Text = button31.Text;
        }

        private void button30_Click(object sender, EventArgs e)
        {
            renkDegistir(button30);
            textBox27.Text = button30.Text;
        }

        private void button29_Click(object sender, EventArgs e)
        {
            renkDegistir(button29);
            textBox27.Text = button29.Text;
        }

        private void button28_Click(object sender, EventArgs e)
        {
            renkDegistir(button28);
            textBox27.Text = button28.Text;
        }

        private void button27_Click(object sender, EventArgs e)
        {
            renkDegistir(button27);
            textBox27.Text = button27.Text;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            renkDegistir(button16);
            textBox27.Text = button16.Text;
        }

        private void button45_Click(object sender, EventArgs e)
        {
            renkDegistir(button45);
            textBox27.Text = button45.Text;
        }

        private void button44_Click(object sender, EventArgs e)
        {
            renkDegistir(button44);
            textBox27.Text = button44.Text;
        }

        private void button43_Click(object sender, EventArgs e)
        {
            renkDegistir(button43);
            textBox27.Text = button43.Text;
        }

        private void button42_Click(object sender, EventArgs e)
        {
            renkDegistir(button42);
            textBox27.Text = button42.Text;
        }

        private void button41_Click(object sender, EventArgs e)
        {
            renkDegistir(button41);
            textBox27.Text = button41.Text;
        }

        private void button32_Click(object sender, EventArgs e)
        {
            renkDegistir(button32);
            textBox27.Text = button32.Text;
        }

        private void button26_Click(object sender, EventArgs e)
        {
            renkDegistir(button26);
            textBox27.Text = button26.Text;
        }

        private void button25_Click(object sender, EventArgs e)
        {
            renkDegistir(button25);
            textBox27.Text = button25.Text;
        }

        private void button24_Click(object sender, EventArgs e)
        {
            renkDegistir(button24);
            textBox27.Text = button24.Text;
        }

        private void button23_Click(object sender, EventArgs e)
        {
            renkDegistir(button23);
            textBox27.Text = button23.Text;
        }

        private void button22_Click(object sender, EventArgs e)
        {
            renkDegistir(button22);
            textBox27.Text = button22.Text;
        }

        private void button21_Click(object sender, EventArgs e)
        {
            renkDegistir(button21);
            textBox27.Text = button21.Text;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (textBox20.Text == "")
            {
                MessageBox.Show("Lütfen Seçim Yapın!", "ELMA AİRLİNES!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Elma.SelectedIndex = 2;
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Elma.SelectedIndex = 1;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (comboBox3.Text == "")
            {
                MessageBox.Show("Lütfen Ödeme Tipini Seçin!", "ELMA AİRLİNES!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {


                bağlantı.Open();
                kmt.Connection = bağlantı;
                kmt.CommandText = "Insert Into Biletler (Nereden,Nereye,Tarih,Saat,Fiyat,Ad,Soyad,Telefon,Adres,Koltuk,Mail,Cinsiyet,TCNo) Values ('" + comboBox1.Text + "','" + comboBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox6.Text + "','" + textBox8.Text + "','" + textBox9.Text + "','" + textBox13.Text + "','" + textBox7.Text + "','" + textBox27.Text + "','" + textBox14.Text + "','" + comboBox4.Text + "','" + textBox10.Text + "')";
                kmt.ExecuteNonQuery();
                kmt.Dispose();
                bağlantı.Close();
                MessageBox.Show("Bilet Satın Alındı!", "ELMA AİRLİNES!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
               
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            textBox10.MaxLength = 11;

            if (textBox10.TextLength == 11)
            {
                MessageBox.Show("11 Karakterden Fazla Giremezsiniz!", "ELMA AİRLİNES!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {
            textBox13.MaxLength = 10;
           
           
            if (textBox13.TextLength == 10)
            {
               
                MessageBox.Show("10 Karakterden Fazla Giremezsiniz, Numarasının Başına 0 Koymadığınızdan Emin Olun!", "ELMA AİRLİNES!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button76_Click(object sender, EventArgs e)
        {
            if (comboBox3.Text == "")
            {
                MessageBox.Show("Lütfen Ödeme Tipini Seçin!", "ELMA AİRLİNES!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {


                bağlantı.Open();
                kmt.Connection = bağlantı;
                kmt.CommandText = "Insert Into GidisGelisBiletleri (Nereden,Nereye,Nereden2,Nereye2,GidisTarihi,GidisSaati,GelisTarihi,GelisSaati,Fiyat,Ad,Soyad,Telefon,Adres,GidisKoltuk,GelisKoltuk,Mail,Cinsiyet,TCNo) Values ('" + comboBox1.Text + "','" + comboBox2.Text + "','" + comboBox2.Text + "','" + comboBox1.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox22.Text + "','" + textBox23.Text + "','" + label91.Text + "','" + label18.Text + "','" + label19.Text + "','" + textBox13.Text + "','" + textBox7.Text + "','" + textBox27.Text + "','" + textBox16.Text + "','" + textBox14.Text + "','" + comboBox4.Text + "','" + textBox10.Text + "')";
                kmt.ExecuteNonQuery();
                kmt.Dispose();
                bağlantı.Close();
                MessageBox.Show("Bilet Satın Alındı!", "ELMA AİRLİNES!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void button75_Click(object sender, EventArgs e)
        {
            if (textBox16.Text == "")
            {
                MessageBox.Show("Lütfen Koltuk Seçin!", "ELMA AİRLİNES!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Elma.SelectedIndex = 5;
            }
        }

        private void button74_Click(object sender, EventArgs e)
        {
            Elma.SelectedIndex = 4;
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // DATAGRİDVİEW'DEN SEÇİLEN SATIRDAKİ VERİYİ TEXTBOX'A AKTARMA

            textBox20.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
            textBox21.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
            textBox22.Text = dataGridView2.CurrentRow.Cells[2].Value.ToString();
            textBox23.Text = dataGridView2.CurrentRow.Cells[3].Value.ToString();
            textBox24.Text = dataGridView2.CurrentRow.Cells[4].Value.ToString();
            textBox25.Text = dataGridView2.CurrentRow.Cells[5].Value.ToString();
        }

        private void textBox10_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                MessageBox.Show("Lütfen Sadece Sayı Girin!", "ELMA AİRLİNES!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void textBox13_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                MessageBox.Show("Lütfen Sadece Sayı Girin!", "ELMA AİRLİNES!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button73_Click(object sender, EventArgs e)
        {
            renkDegistir(button73);
            textBox16.Text = button73.Text;
        }

        private void button72_Click(object sender, EventArgs e)
        {
            renkDegistir(button72);
            textBox16.Text = button72.Text;
        }

        private void button70_Click(object sender, EventArgs e)
        {
            renkDegistir(button70);
            textBox16.Text = button70.Text;
        }

        private void button71_Click(object sender, EventArgs e)
        {
            renkDegistir(button71);
            textBox16.Text = button71.Text;
        }

        private void button60_Click(object sender, EventArgs e)
        {
            renkDegistir(button60);
            textBox16.Text = button60.Text;
        }

        private void button59_Click(object sender, EventArgs e)
        {
            renkDegistir(button59);
            textBox16.Text = button59.Text;
        }

        private void button58_Click(object sender, EventArgs e)
        {
            renkDegistir(button58);
            textBox16.Text = button58.Text;
        }

        private void button57_Click(object sender, EventArgs e)
        {
            renkDegistir(button57);
            textBox16.Text = button57.Text;
        }

        private void button56_Click(object sender, EventArgs e)
        {
            renkDegistir(button56);
            textBox16.Text = button56.Text;
        }

        private void button54_Click(object sender, EventArgs e)
        {
            renkDegistir(button54);
            textBox16.Text = button54.Text;
        }

        private void button53_Click(object sender, EventArgs e)
        {
            renkDegistir(button53);
            textBox16.Text = button53.Text;
        }

        private void button52_Click(object sender, EventArgs e)
        {
            renkDegistir(button52);
            textBox16.Text = button52.Text;
        }

        private void button51_Click(object sender, EventArgs e)
        {
            renkDegistir(button51);
            textBox16.Text = button51.Text;
        }

        private void button50_Click(object sender, EventArgs e)
        {
            renkDegistir(button50);
            textBox16.Text = button50.Text;
        }

        private void button49_Click(object sender, EventArgs e)
        {
            renkDegistir(button49);
            textBox16.Text = button49.Text;
        }

        private void button69_Click(object sender, EventArgs e)
        {
            renkDegistir(button69);
            textBox16.Text = button69.Text;
        }

        private void button68_Click(object sender, EventArgs e)
        {
            renkDegistir(button68);
            textBox16.Text = button68.Text;
        }

        private void button67_Click(object sender, EventArgs e)
        {
            renkDegistir(button67);
            textBox16.Text = button67.Text;
        }

        private void button66_Click(object sender, EventArgs e)
        {
            renkDegistir(button66);
            textBox16.Text = button66.Text;
        }

        private void button65_Click(object sender, EventArgs e)
        {
            renkDegistir(button65);
            textBox16.Text = button65.Text;
        }

        private void button64_Click(object sender, EventArgs e)
        {
            renkDegistir(button64);
            textBox16.Text = button64.Text;
        }

        private void button63_Click(object sender, EventArgs e)
        {
            renkDegistir(button63);
            textBox16.Text = button63.Text;
        }

        private void button62_Click(object sender, EventArgs e)
        {
            renkDegistir(button62);
            textBox16.Text = button62.Text;
        }

        private void button61_Click(object sender, EventArgs e)
        {
            renkDegistir(button61);
            textBox16.Text = button61.Text;
        }

        private void button55_Click(object sender, EventArgs e)
        {
            renkDegistir(button55);
            textBox16.Text = button55.Text;
        }

        private void button48_Click(object sender, EventArgs e)
        {
            renkDegistir(button48);
            textBox16.Text = button48.Text;
        }

        private void button47_Click(object sender, EventArgs e)
        {
            renkDegistir(button47);
            textBox16.Text = button47.Text;
        }

        private void button46_Click(object sender, EventArgs e)
        {
            renkDegistir(button46);
            textBox16.Text = button46.Text;
        }

        private void button35_Click(object sender, EventArgs e)
        {
            renkDegistir(button35);
            textBox16.Text = button35.Text;
        }

        private void button34_Click(object sender, EventArgs e)
        {
            renkDegistir(button34);
            textBox16.Text = button34.Text;
        }

    }
}
