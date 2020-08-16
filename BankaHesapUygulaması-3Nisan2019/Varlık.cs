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
    public partial class Varlık : Form
    {
        public Varlık()
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

        private void Varlık_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select VarlıkID from Varlık", baglanti);
            SqlDataReader dr;
            dr = komut.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr["VarlıkID"]);
            }
            baglanti.Close();
        }

        private void bütçeListeleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            Listele("select * from Varlık");
            baglanti.Close();
        }

        private void araToolStripMenuItem_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select *from Varlık where VarlıkID='" + comboBox1.SelectedItem + "'", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable doldur = new DataTable();
            da.Fill(doldur);
            dataGridView1.DataSource = doldur;
            baglanti.Close();
        }

        private void bütçeSilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("delete from Varlık where VarlıkID=@VarlıkID", baglanti);
            komut.Parameters.AddWithValue("@VarlıkID", comboBox1.SelectedItem);
            komut.ExecuteNonQuery();
            baglanti.Close();
            Listele("select * from Varlık");
        }

        private void bütçeEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into Varlık(VarlıkAdı,Açıklama) values(@VarlıkAdı,@Açıklama)", baglanti);

           
            komut.Parameters.AddWithValue("@VarlıkAdı", textBox1.Text);

            komut.Parameters.AddWithValue("@Açıklama", textBox2.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            Listele("select * from Varlık");
        }

        private void bütçeGüncelleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            baglanti.Open();

            SqlCommand komut = new SqlCommand("Update Varlık set VarlıkAdı='" + textBox1.Text.ToString() + "',Açıklama='" + textBox2.Text.ToString() + "'where VarlıkID='" + comboBox1.SelectedItem + "'", baglanti);


            komut.ExecuteNonQuery();

            baglanti.Close();
            Listele("select * from Varlık");
        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int sectim = dataGridView1.SelectedCells[0].RowIndex;
            comboBox1.Text = dataGridView1.Rows[sectim].Cells[0].Value.ToString();
            textBox1.Text = dataGridView1.Rows[sectim].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.Rows[sectim].Cells[2].Value.ToString();
          
        }
    }
}
