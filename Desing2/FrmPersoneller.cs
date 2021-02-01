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

namespace Desing2
{
    public partial class FrmPersoneller : Form
    {
        public FrmPersoneller()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();
        void personelListe()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from TBL_PERSONELLER", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }
        void sehirListesi()
        {
            SqlCommand komut = new SqlCommand("select SEHIR from TBL_ILLER", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();

            while (dr.Read())
            {
                cmbil.Properties.Items.Add(dr[0]);
                bgl.baglanti().Close();
            }

        }
        void temizle()
        {
            txtid.Text = "";
            txtad.Text = "";
            txtsoyad.Text = "";
            msktelefon1.Text = "";
            msktc.Text = "";
            cmbil.Text = "";
            cmbilce.Text = "";
            richtxtadres.Text = "";
            txtGorev.Text = "";
            txtmail.Text = "";
        }
        private void FrmPersoneller_Load(object sender, EventArgs e)
        {
            sehirListesi();
            personelListe();
        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into TBL_PERSONELLER (AD,SOYAD,TELEFON,TC,MAIL,IL,ILCE,ADRES,GOREV) VALUES (@P1,@P2,@P3,@P4,@P5,@P6,@P7,@P8,@P9)", bgl.baglanti());
            komut.Parameters.AddWithValue("@P1", txtad.Text);
            komut.Parameters.AddWithValue("@P2", txtsoyad.Text);
            komut.Parameters.AddWithValue("@P3", msktelefon1.Text);
            komut.Parameters.AddWithValue("@P4", msktc.Text);
            komut.Parameters.AddWithValue("@P5", txtmail.Text);
            komut.Parameters.AddWithValue("@P6", cmbil.Text);
            komut.Parameters.AddWithValue("@P7", cmbilce.Text);
            komut.Parameters.AddWithValue("@P8", richtxtadres.Text);
            komut.Parameters.AddWithValue("@P9", txtGorev.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Personel Bilgileri Kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            personelListe();
            temizle();
        }

        private void cmbil_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbilce.Text = "";
            cmbilce.Properties.Items.Clear();
            SqlCommand komut = new SqlCommand("select ILCE from TBL_ILCELER where SEHIR=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", cmbil.SelectedIndex + 1);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                cmbilce.Properties.Items.Add(dr[0]);
            }
            bgl.baglanti().Close();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                txtid.Text = dr["ID"].ToString();
                txtad.Text = dr["AD"].ToString();
                txtsoyad.Text = dr["SOYAD"].ToString();
                msktelefon1.Text = dr["TELEFON"].ToString();
                msktc.Text = dr["TC"].ToString();
                cmbil.Text = dr["IL"].ToString();
                cmbilce.Text = dr["ILCE"].ToString();
                richtxtadres.Text = dr["ADRES"].ToString();
                txtGorev.Text = dr["GOREV"].ToString();
            }
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komutsil = new SqlCommand("delete from TBL_PERSONELLER WHERE ID=@P1", bgl.baglanti());
            komutsil.Parameters.AddWithValue("@P1", txtid.Text);
            bgl.baglanti().Close();
            MessageBox.Show("Personel listesinden silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            personelListe();
            temizle();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update tbl_personeller set AD=@P1,SOYAD=@P2,TELEFON=@P3,TC=@P4,MAIL=@P5,IL=@P6,ILCE=@P7,ADRES=@P8,GOREV=@P9 WHERE ID=@P10", bgl.baglanti());
            komut.Parameters.AddWithValue("@P1", txtad.Text);
            komut.Parameters.AddWithValue("@P2", txtsoyad.Text);
            komut.Parameters.AddWithValue("@P3", msktelefon1.Text);
            komut.Parameters.AddWithValue("@P4", msktc.Text);
            komut.Parameters.AddWithValue("@P5", txtmail.Text);
            komut.Parameters.AddWithValue("@P6", cmbil.Text);
            komut.Parameters.AddWithValue("@P7", cmbilce.Text);
            komut.Parameters.AddWithValue("@P8", richtxtadres.Text);
            komut.Parameters.AddWithValue("@P9", txtGorev.Text);
            komut.Parameters.AddWithValue("@P10", txtid.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Personel Bilgileri Kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            personelListe();
            temizle();
        }
    }
}
