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
    public partial class Diğer : Form
    {
        public Diğer()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Server=.;Database=BankaVeritabanı;uid=sa;pwd=1234");

        private void Diğer_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
       
            SqlCommand komut = new SqlCommand(); 
            komut.Connection = baglanti; 
            komut.CommandType = CommandType.StoredProcedure; 
            komut.CommandText = "TabloBirleştir"; 
            SqlDataAdapter goruntule = new SqlDataAdapter(komut); 
            DataTable doldur = new DataTable();
            goruntule.Fill(doldur);
            dataGridView1.DataSource = doldur; 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand();
            komut.Connection = baglanti;
            komut.CommandType = CommandType.StoredProcedure;
            komut.CommandText = "MiktarArtıs";
            SqlDataAdapter goruntule = new SqlDataAdapter(komut);
            DataTable doldur = new DataTable();
            goruntule.Fill(doldur);
            dataGridView1.DataSource = doldur;
            
        }
    }
}
