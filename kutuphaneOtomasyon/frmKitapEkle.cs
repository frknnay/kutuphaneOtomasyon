﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using MySql.Data.MySqlClient;

namespace kutuphaneOtomasyon
{
    public partial class frmKitapEkle : Form
    {
        public frmKitapEkle()
        {
            InitializeComponent();
        }
        DataBase db = new DataBase();
        private Dictionary<string, int> yazar = new Dictionary<string, int>();

        private void frmKitapEkle_Load(object sender, EventArgs e)
        {

            db.Open();
            var cmd = db.Command();
            cmd.CommandText = "select * from yazar";
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                cmbYazar.Items.Add(reader.GetString("yazar_adi_soyadi"));
                yazar[reader.GetString("yazar_adi_soyadi")] = reader.GetInt32("yazar_id");
            }
            reader.Close();
            db.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            db.Open();
            var cmd = db.Command();
            cmd.CommandText = "insert into kitap (kitap_adi,yazar_id,kitap_sayfa_sayisi) values(@kitapAdi,@yazarId,@sayfaSayisi)";
            cmd.Prepare();
            cmd.Parameters.AddWithValue("@kitapAdi", txtKitapAdi.Text);
            cmd.Parameters.AddWithValue("@yazarId", yazar[cmbYazar.Text]);
            cmd.Parameters.AddWithValue("@sayfaSayisi", int.Parse(txtSayfaSayisi.Text));
            cmd.ExecuteNonQuery();
            db.Close();
            MessageBox.Show("Kitap ekleme işlemi başarılı.");

        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
