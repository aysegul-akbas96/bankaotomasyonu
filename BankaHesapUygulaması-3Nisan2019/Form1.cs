using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankaHesapUygulaması_3Nisan2019
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void kategoriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Kategori git =new Kategori();
            git.Show();
            this.Hide();
        }

        private void bütçeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bütçe git = new Bütçe();
            git.Show();
            this.Hide();
        }

        private void varlıkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Varlık git = new Varlık();
            git.Show();
            this.Hide();
        }

        private void operasyonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Operasyon git = new Operasyon();
            git.Show();
            this.Hide();
        }

        private void hesapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hesap git = new Hesap();
            git.Show();
            this.Hide();
        }

        private void kerdiKartıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KrediKartı git = new KrediKartı();
            git.Show();
            this.Hide();
        }

        private void bankaHesabıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BankaHesabı git = new BankaHesabı();
            git.Show();
            this.Hide();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void diğerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Diğer git = new Diğer();
            git.Show();
            this.Hide();
        }
    }
}
