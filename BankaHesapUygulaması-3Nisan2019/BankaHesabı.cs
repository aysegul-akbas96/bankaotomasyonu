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
    public partial class BankaHesabı : Form
    {
        public BankaHesabı()
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
        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void anasayfaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 git = new Form1();
            git.Show();
            this.Hide();
        }

        private void BankaHesabı_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select BankaID from BankaHesabı", baglanti);
            SqlDataReader dr;
            dr = komut.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr["BankaID"]);
            }
            baglanti.Close();

            baglanti.Open();
            SqlCommand komut1 = new SqlCommand("select HesapID from Hesap", baglanti);
            SqlDataReader dr1;
            dr1 = komut1.ExecuteReader();
            while (dr1.Read())
            {
                comboBox2.Items.Add(dr1["HesapID"]);
            }
            baglanti.Close();
        }

        private void bütçeEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {

            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into BankaHesabı(HesapID,Tipi,Numara) values(@HesapID,@Tipi,@Numara)", baglanti);
            komut.Parameters.AddWithValue("@HesapID", comboBox2.SelectedItem);
            komut.Parameters.AddWithValue("@Tipi", textBox1.Text);
            komut.Parameters.AddWithValue("@Numara", textBox2.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            Listele("select *from BankaHesabı");
        }

        private void bütçeListeleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Listele("Select * from BankaHesabı");
        }

        private void bütçeSilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Delete from BankaHesabı where BankaID='" + comboBox1.SelectedItem + "'", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            Listele("select *from BankaHesabı");
        }

        private void araToolStripMenuItem_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select *from BankaHesabı where BankaID='" + comboBox1.SelectedItem.ToString() + "'", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable doldur = new DataTable();
            da.Fill(doldur);
            dataGridView1.DataSource = doldur;
            baglanti.Close();
        }

        private void bütçeGüncelleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            baglanti.Open();


            SqlCommand komut = new SqlCommand("Update BankaHesabı set HesapID='" + comboBox2.SelectedItem.ToString() + "',Tipi='" + textBox1.Text.ToString() + "',Numara='" + textBox2.Text.ToString() + "'where BankaID='" + comboBox1.SelectedItem.ToString() + "'", baglanti);

            komut.ExecuteNonQuery();

            baglanti.Close();
            Listele("select * from BankaHesabı");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int sectim = dataGridView1.SelectedCells[0].RowIndex;
            comboBox1.Text = dataGridView1.Rows[sectim].Cells[0].Value.ToString();
            comboBox2.Text = dataGridView1.Rows[sectim].Cells[1].Value.ToString();
            textBox1.Text = dataGridView1.Rows[sectim].Cells[2].Value.ToString();
            textBox2.Text = dataGridView1.Rows[sectim].Cells[3].Value.ToString();
        }
    }
}
