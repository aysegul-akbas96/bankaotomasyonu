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
    public partial class Kategori : Form
    {
        public Kategori()
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
   

        private void kategoriEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into Kategori(VarlıkID,Tipi) values(@VarlıkID,@Tipi)", baglanti);

            komut.Parameters.AddWithValue("@VarlıkID", comboBox2.SelectedItem);
            komut.Parameters.AddWithValue("@Tipi", textBox2.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            Listele("select * from Kategori");
        }

        private void Kategori_Load(object sender, EventArgs e)
        {
          
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select KategoriID from Kategori", baglanti);
            SqlDataReader dr;
            dr = komut.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr["KategoriID"]);
            }
            baglanti.Close();

            baglanti.Open();
            SqlCommand komutt = new SqlCommand("select VarlıkID from Varlık", baglanti);
            SqlDataReader drr;
            drr = komutt.ExecuteReader();
            while (drr.Read())
            {
                comboBox2.Items.Add(drr["VarlıkID"]);
            }
            baglanti.Close();
        }

        private void kategoriListeleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            Listele("select * from Kategori");
            baglanti.Close();
        }

        private void kategoriSilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("delete from Kategori where KategoriID=@KategoriID", baglanti);
            komut.Parameters.AddWithValue("@KategoriID", comboBox1.SelectedItem);
            komut.ExecuteNonQuery();
            baglanti.Close();
            Listele("select * from Kategori");
        }

        private void güncelleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            baglanti.Open();

            SqlCommand komut = new SqlCommand("Update Kategori set VarlıkID='" + comboBox2.SelectedItem + "',Tipi='" + textBox2.Text.ToString()  + "'where KategoriID='" + comboBox1.SelectedItem+ "'", baglanti);

       
            komut.ExecuteNonQuery();

            baglanti.Close();
            Listele("select * from Kategori");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int sectim = dataGridView1.SelectedCells[0].RowIndex;
            comboBox1.Text = dataGridView1.Rows[sectim].Cells[0].Value.ToString();
            comboBox2.Text = dataGridView1.Rows[sectim].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.Rows[sectim].Cells[2].Value.ToString();
          
        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void araToolStripMenuItem_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut =new  SqlCommand("Select *from Kategori where KategoriID='"+comboBox1.SelectedItem+"'", baglanti);
            SqlDataAdapter da =new  SqlDataAdapter(komut);
            DataTable doldur = new DataTable();
            da.Fill(doldur);
            dataGridView1.DataSource = doldur;
            baglanti.Close();
        }

        private void anasayfaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 git = new Form1();
            git.Show();
            this.Hide();
        }
    }
}
