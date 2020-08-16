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
    public partial class Bütçe : Form
    {
        public Bütçe()
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

        private void Bütçe_Load(object sender, EventArgs e)
        {

            baglanti.Open();
            SqlCommand komut = new SqlCommand("select BütçeID from Bütçe", baglanti);
            SqlDataReader dr;
            dr = komut.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr["BütçeID"]);
            }
            baglanti.Close();

            baglanti.Open();
            SqlCommand komutt = new SqlCommand("select KategoriID from Kategori", baglanti);
            SqlDataReader drr;
            drr = komutt.ExecuteReader();
            while (drr.Read())
            {
                comboBox2.Items.Add(drr["KategoriID"]);
            }
            baglanti.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void bütçeListeleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            Listele("select * from Bütçe");
            baglanti.Close();
        }

        private void bütçeEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into Bütçe (KategoriID,Limit,BaşlangıçTarihi,BitişTarihi) values(@KategoriID,@Limit,@BaşlangıçTarihi,@BitişTarihi)",baglanti);
            komut.Parameters.AddWithValue("@KategoriID", comboBox2.SelectedItem);
            komut.Parameters.AddWithValue("@Limit",textBox1.Text);
            komut.Parameters.AddWithValue("@BaşlangıçTarihi", dateTimePicker1.Value);
            komut.Parameters.AddWithValue("@BitişTarihi", dateTimePicker2.Value);
            komut.ExecuteNonQuery();
            baglanti.Close();
            Listele("Select * from Bütçe");
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void bütçeSilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Delete from Bütçe where BütçeID='" + comboBox1.SelectedItem + "'", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            Listele("select * from Bütçe");
        }

        private void bütçeGüncelleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            baglanti.Open();

           
            SqlCommand komut = new SqlCommand("Update Bütçe set KategoriID='" + comboBox2.SelectedItem.ToString() + "',Limit='" + textBox1.Text.ToString() + "',BaşlangıçTarihi='" + dateTimePicker1.Value.ToString() + "',BitişTarihi='" + dateTimePicker2.Value.ToString()  + "'where BütçeID='" + comboBox1.SelectedItem.ToString() + "'", baglanti);

            komut.ExecuteNonQuery();

            baglanti.Close();
            Listele("select * from Bütçe");
        }

        private void araToolStripMenuItem_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select *from Bütçe where BütçeID='" + comboBox1.SelectedItem.ToString()+"'", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable doldur = new DataTable();
            da.Fill(doldur);
            dataGridView1.DataSource = doldur;
            baglanti.Close();
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int sectim = dataGridView1.SelectedCells[0].RowIndex;
            comboBox1.Text = dataGridView1.Rows[sectim].Cells[0].Value.ToString();
            comboBox2.Text = dataGridView1.Rows[sectim].Cells[1].Value.ToString();
            textBox1.Text = dataGridView1.Rows[sectim].Cells[2].Value.ToString();
            dateTimePicker1.Text = dataGridView1.Rows[sectim].Cells[3].Value.ToString();
            dateTimePicker2.Text = dataGridView1.Rows[sectim].Cells[4].Value.ToString();
        }

        private void anasayfaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 git = new Form1();
            git.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
