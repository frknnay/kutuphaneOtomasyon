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

namespace kutuphaneOtomasyon
{
    public partial class frmKiyapListele : Form
    {
        private DataBase db = new DataBase();

        public frmKiyapListele()
        {
            InitializeComponent();
        }


        private void frmKiyapListele_Load(object sender, EventArgs e)
        {
            veriGetir();
        }

        private void veriGetir()
        {
            db.Open();
            string command = "select kitap_id, kitap_adi as Adı from kitap";
            var adapter = db.Adapter(command);
            try
            {
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
                dataGridView1.Columns["kitap_id"].Visible = false;
                dataGridView1.Sort(this.dataGridView1.Columns["Adı"], ListSortDirection.Ascending);

            }
            catch (MySqlException myEx)
            {
                string hata = string.Format("Kayıtlar listelenirken bir hata oluştu.\n{0}", myEx.Message);
                MessageBox.Show(hata);
                this.Close();
            }
            finally { db.Close(); }
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnKitapSil_Click(object sender, EventArgs e)
        {

        }

    }
}
