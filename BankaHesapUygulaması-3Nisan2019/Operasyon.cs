using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace BankaHesapUygulaması_3Nisan2019
{
    public partial class Operasyon : Form
    {
        public Operasyon()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Server=.;Database=BankaVeritabanı;uid=sa;pwd=1234");
        public void Listele(string ulas)
        {
            SqlDataAdapter goster = new SqlDataAdapter(ulas, baglanti);
            DataTable doldur = new DataTable();
            goster.Fill(doldur);
            dataGridView1.DataSource = doldur;
        }

        private void anasayfaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 git = new Form1();
            git.Show();
            this.Hide();
        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Operasyon_Load(object sender, EventArgs e)
        {

            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("select OperasyonID from Operasyon", baglanti);
            SqlDataReader dr2;
            dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                comboBox1.Items.Add(dr2["OperasyonID"]);
            }
            baglanti.Close();



            baglanti.Open();
            SqlCommand komut = new SqlCommand("select VarlıkID from Varlık", baglanti);
            SqlDataReader dr;
            dr = komut.ExecuteReader();
            while (dr.Read())
            {
                comboBox2.Items.Add(dr["VarlıkID"]);
            }
            baglanti.Close();


            baglanti.Open();
            SqlCommand komut1 = new SqlCommand("select HesapID from Hesap", baglanti);
            SqlDataReader dr1;
            dr1 = komut1.ExecuteReader();
            while (dr1.Read())
            {
                comboBox3.Items.Add(dr1["HesapID"]);
            }
            baglanti.Close();


            baglanti.Open();
            SqlCommand komut3 = new SqlCommand("select KategoriID from Kategori", baglanti);
            SqlDataReader dr3;
            dr3 = komut3.ExecuteReader();
            while (dr3.Read())
            {
                comboBox4.Items.Add(dr3["KategoriID"]);
            }
            baglanti.Close();
        }

        private void bütçeEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into Operasyon(VarlıkID,HesapID,KategoriID,Tarih,GeçerlilikDurumu,Miktar) values(@VarlıkID,@HesapID,@KategoriID,@Tarih,@GeçerlilikDurumu,@Miktar)", baglanti);


            komut.Parameters.AddWithValue("@VarlıkID", comboBox2.SelectedItem);
            komut.Parameters.AddWithValue("@HesapID", comboBox3.SelectedItem);
            komut.Parameters.AddWithValue("@KategoriID", comboBox3.SelectedItem);
            komut.Parameters.AddWithValue("@Tarih", dateTimePicker1.Value);
            komut.Parameters.AddWithValue("@GeçerlilikDurumu", textBox1.Text);

            komut.Parameters.AddWithValue("@Miktar", textBox2.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            Listele("select * from Operasyon");
        }

        private void araToolStripMenuItem_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select *from Operasyon where OperasyonID='" + comboBox1.SelectedItem + "'", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable doldur = new DataTable();
            da.Fill(doldur);
            dataGridView1.DataSource = doldur;
            baglanti.Close();

           
        }

        private void bütçeListeleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            Listele("select * from Operasyon");
            baglanti.Close();
        }

        private void bütçeSilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select *from Operasyon where OperasyonID='" + comboBox1.SelectedItem + "'", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable doldur = new DataTable();
            da.Fill(doldur);
            dataGridView1.DataSource = doldur;
            baglanti.Close();
        }

        private void bütçeGüncelleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            baglanti.Open();

            SqlCommand komut = new SqlCommand("Update Operasyon set VarlıkID='" + comboBox2.SelectedItem.ToString() + "',HesapID='" + comboBox3.SelectedItem.ToString() + "',KategoriID='" + comboBox4.SelectedItem.ToString() + "',Tarih='" + dateTimePicker1.Value.ToString() + "',GeçerlilikDurumu='" + textBox1.Text.ToString() + "',Miktar='" + textBox2.Text.ToString() + "'where OperasyonID='" + comboBox1.SelectedItem.ToString() + "'", baglanti);

            komut.ExecuteNonQuery();
            baglanti.Close();
            Listele("select * from Operasyon");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int sectim = dataGridView1.SelectedCells[0].RowIndex;
            comboBox1.Text = dataGridView1.Rows[sectim].Cells[0].Value.ToString();
            comboBox2.Text = dataGridView1.Rows[sectim].Cells[1].Value.ToString();
            comboBox3.Text = dataGridView1.Rows[sectim].Cells[2].Value.ToString();
            comboBox4.Text = dataGridView1.Rows[sectim].Cells[3].Value.ToString();
            dateTimePicker1.Text = dataGridView1.Rows[sectim].Cells[4].Value.ToString();
            textBox1.Text = dataGridView1.Rows[sectim].Cells[5].Value.ToString();
            textBox2.Text = dataGridView1.Rows[sectim].Cells[6].Value.ToString();
        }
    }
}
