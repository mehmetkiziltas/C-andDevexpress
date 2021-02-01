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
    public partial class FrmFaturaUrunDuzenleme : Form
    {
        public FrmFaturaUrunDuzenleme()
        {
            InitializeComponent();
        }

        sqlbaglantisi bgl = new sqlbaglantisi();
        public string urunid;
        private void FrmFaturaUrunDuzenleme_Load(object sender, EventArgs e)
        {
            txtUrunId.Text = urunid;
            SqlCommand komut = new SqlCommand("select * from tbl_faturadetay where faturaUrunID=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", urunid);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                txtFiyat.Text = dr[3].ToString();
                txtMiktar.Text = dr[2].ToString();
                txtTutar.Text = dr[4].ToString();
                txtUrunAd.Text = dr[1].ToString();
                bgl.baglanti().Close();
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("delete from tbl_faturadetay where FATURAURUNID=@P1", bgl.baglanti());
            komut.Parameters.AddWithValue("@P1", txtUrunId.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Ürün Silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update tbl_faturadetay set URUNAD=@P1,MIKTAR=@P2,FIYAT=@P3,TUTAR=@P4 WHERE FATURAURUNID=@P5", bgl.baglanti());
            komut.Parameters.AddWithValue("@P1", txtUrunAd.Text);
            komut.Parameters.AddWithValue("@P2", txtMiktar.Text);
            komut.Parameters.AddWithValue("@P3", decimal.Parse(txtFiyat.Text));
            komut.Parameters.AddWithValue("@P4", decimal.Parse(txtTutar.Text));
            komut.Parameters.AddWithValue("@P5", txtUrunId.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Değişiklikler Kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //frm.Close();
        }

        private void txtFiyat_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                double miktar, tutar, fiyat;
                fiyat = Convert.ToDouble(txtFiyat.Text);
                miktar = Convert.ToDouble(txtMiktar.Text);
                tutar = miktar * fiyat;
                txtTutar.Text = tutar.ToString();
            }
            catch (Exception)
            {
                if (txtFiyat.Text == "")
                {
                    txtTutar.Text = "";
                }

            }
        }

        private void txtMiktar_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                double miktar, tutar, fiyat;
                fiyat = Convert.ToDouble(txtFiyat.Text);
                miktar = Convert.ToDouble(txtMiktar.Text);
                tutar = miktar * fiyat;
                txtTutar.Text = tutar.ToString();
            }
            catch (Exception)
            {
                if (txtMiktar.Text == "")
                {
                    txtTutar.Text = "";
                }

            }
        }
    }
}
