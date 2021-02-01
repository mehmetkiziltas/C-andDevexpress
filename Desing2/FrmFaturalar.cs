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
    public partial class FrmFaturalar : Form
    {
        public FrmFaturalar()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();
        void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from TBL_FATURABILGI", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }
        void temizle()
        {
            txtAlici.Text = "";
            txtid.Text = "";
            txtSeri.Text = "";
            txtSiraNo.Text = "";
            txtTAlan.Text = "";
            txtTEden.Text = "";
            txtVergiDaire.Text = "";
            mskSaat.Text = "";
            mskTarih.Text = "";
        }
        private void FrmFaturalar_Load(object sender, EventArgs e)
        {
            listele();
            temizle();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                txtid.Text = dr["FATURABILGIID"].ToString();
                txtSiraNo.Text = dr["SIRANO"].ToString();
                txtSeri.Text = dr["SERI"].ToString();
                mskTarih.Text = dr["TARIH"].ToString();
                mskSaat.Text = dr["SAAT"].ToString();
                txtAlici.Text = dr["ALICI"].ToString();
                txtTEden.Text = dr["TESLIMEDEN"].ToString();
                txtTAlan.Text = dr["TESLIMALAN"].ToString();
                txtVergiDaire.Text = dr["VERGIDAIRE"].ToString();
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("delete from TBL_FATURABILGI where FATURABILGIID=@P1", bgl.baglanti());
            komut.Parameters.AddWithValue("@P1", txtid.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Fatura Silindi.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            listele();
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update TBL_FATURABILGI SET SERI=@P1,SIRANO=@P2,TARIH=@P3,SAAT=@P4,VERGIDAIRE=@P5,ALICI=@P6,TESLIMEDEN=@P7,TESLIMALAN=@P8 WHERE FATURABILGIID=@P9", bgl.baglanti());
            komut.Parameters.AddWithValue("@P1", txtSeri.Text);
            komut.Parameters.AddWithValue("@P2", txtSiraNo.Text);
            komut.Parameters.AddWithValue("@P3", mskTarih.Text);
            komut.Parameters.AddWithValue("@P4", mskSaat.Text);
            komut.Parameters.AddWithValue("@P5", txtVergiDaire.Text);
            komut.Parameters.AddWithValue("@P6", txtAlici.Text);
            komut.Parameters.AddWithValue("@P7", txtTEden.Text);
            komut.Parameters.AddWithValue("@P8", txtTAlan.Text);
            komut.Parameters.AddWithValue("@P9", txtid.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Fatura Bilgisi Güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            listele();
        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            if (txtFaturaId.Text == "")
            {
                SqlCommand komut = new SqlCommand("insert into TBL_FATURABILGI (SERI,SIRANO,TARIH,SAAT,VERGIDAIRE,ALICI,TESLIMEDEN,TESLIMALAN) VALUES (@P1,@P2,@P3,@P4,@P5,@P6,@P7,@P8)", bgl.baglanti());
                komut.Parameters.AddWithValue("@P1", txtSeri.Text);
                komut.Parameters.AddWithValue("@P2", txtSiraNo.Text);
                komut.Parameters.AddWithValue("@P3", mskTarih.Text);
                komut.Parameters.AddWithValue("@P4", mskSaat.Text);
                komut.Parameters.AddWithValue("@P5", txtVergiDaire.Text);
                komut.Parameters.AddWithValue("@P6", txtAlici.Text);
                komut.Parameters.AddWithValue("@P7", txtTEden.Text);
                komut.Parameters.AddWithValue("@P8", txtTAlan.Text);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Fatura Bilgisi Sisteme Kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listele();
            }
            //Firma Carisi
            if (txtFaturaId.Text != "" && comboBox1.Text == "Firma")
            {
                double miktar, tutar, fiyat;
                fiyat = Convert.ToDouble(txtFiyat.Text);
                miktar = Convert.ToDouble(txtMiktar.Text);
                tutar = miktar * fiyat;
                txtTutar.Text = tutar.ToString();
                SqlCommand komut2 = new SqlCommand("insert into TBL_FATURADETAY (URUNADI,MIKTAR,FIYAT,TUTAR,FATURAID) VALUES (@P1,@P2,@P3,@P4,@P5)", bgl.baglanti());
                komut2.Parameters.AddWithValue("@P1", txtUrunAd.Text);
                komut2.Parameters.AddWithValue("@P2", txtMiktar.Text);
                komut2.Parameters.AddWithValue("@P3", decimal.Parse(txtFiyat.Text));
                komut2.Parameters.AddWithValue("@P4", decimal.Parse(txtTutar.Text));
                komut2.Parameters.AddWithValue("@P5", txtFaturaId.Text);
                komut2.ExecuteNonQuery();
                bgl.baglanti().Close();

                //Hareket Tablosuna Veri Girişi
                SqlCommand komut3 = new SqlCommand("insert into tbl_fırmahareketler  (urunıd,adet,personel,fırma,fıyat,toplam,faturaıd,tarıh) values (@h1,@h2,@h3,@h4,@h5,@h6,@h7,@h8) ", bgl.baglanti());
                komut3.Parameters.AddWithValue("@h1", txtUrunId.Text);
                komut3.Parameters.AddWithValue("@h2", txtMiktar.Text);
                komut3.Parameters.AddWithValue("@h3", txtPersonel.Text);
                komut3.Parameters.AddWithValue("@h4", txtFirma.Text);
                komut3.Parameters.AddWithValue("@h5", decimal.Parse(txtFiyat.Text));
                komut3.Parameters.AddWithValue("@h6", decimal.Parse(txtTutar.Text));
                komut3.Parameters.AddWithValue("@h7", txtFaturaId.Text);
                komut3.Parameters.AddWithValue("@h8", mskTarih.Text);
                komut3.ExecuteNonQuery();
                bgl.baglanti().Close();

                //Stok sayısını Azaltma
                SqlCommand komut4 = new SqlCommand("update tbl_urunler set adet=adet-@s1 where ıd=@s2", bgl.baglanti());
                komut4.Parameters.AddWithValue("@s1", txtMiktar.Text);
                komut4.Parameters.AddWithValue("@s2", txtUrunId.Text);
                komut4.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Fatura Ait Ürün Kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listele();
            }

            //Müşteri Carisi
            if (txtFaturaId.Text != "" && comboBox1.Text == "Müşteri")
            {
                double miktar, tutar, fiyat;
                fiyat = Convert.ToDouble(txtFiyat.Text);
                miktar = Convert.ToDouble(txtMiktar.Text);
                tutar = miktar * fiyat;
                txtTutar.Text = tutar.ToString();
                SqlCommand komut2 = new SqlCommand("insert into TBL_FATURADETAY (URUNADI,MIKTAR,FIYAT,TUTAR,FATURAID) VALUES (@P1,@P2,@P3,@P4,@P5)", bgl.baglanti());
                komut2.Parameters.AddWithValue("@P1", txtUrunAd.Text);
                komut2.Parameters.AddWithValue("@P2", txtMiktar.Text);
                komut2.Parameters.AddWithValue("@P3", decimal.Parse(txtFiyat.Text));
                komut2.Parameters.AddWithValue("@P4", decimal.Parse(txtTutar.Text));
                komut2.Parameters.AddWithValue("@P5", txtFaturaId.Text);
                komut2.ExecuteNonQuery();
                bgl.baglanti().Close();

                //Hareket Tablosuna Veri Girişi
                SqlCommand komut3 = new SqlCommand("insert into TBL_MUSTERIHAREKETLER(urunıd,adet,personel,musterı,fıyat,toplam,faturaıd,tarıh) values (@h1,@h2,@h3,@h4,@h5,@h6,@h7,@h8) ", bgl.baglanti());
                komut3.Parameters.AddWithValue("@h1", txtUrunId.Text);
                komut3.Parameters.AddWithValue("@h2", txtMiktar.Text);
                komut3.Parameters.AddWithValue("@h3", txtPersonel.Text);
                komut3.Parameters.AddWithValue("@h4", txtFirma.Text);
                komut3.Parameters.AddWithValue("@h5", decimal.Parse(txtFiyat.Text));
                komut3.Parameters.AddWithValue("@h6", decimal.Parse(txtTutar.Text));
                komut3.Parameters.AddWithValue("@h7", txtFaturaId.Text);
                komut3.Parameters.AddWithValue("@h8", mskTarih.Text);
                komut3.ExecuteNonQuery();
                bgl.baglanti().Close();

                //Stok sayısını Azaltma
                SqlCommand komut4 = new SqlCommand("update tbl_urunler set adet=adet-@s1 where ıd=@s2", bgl.baglanti());
                komut4.Parameters.AddWithValue("@s1", txtMiktar.Text);
                komut4.Parameters.AddWithValue("@s2", txtUrunId.Text);
                komut4.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Fatura Ait Ürün Kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listele();
            }
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            FrmFaturaUrunDetay fr = new FrmFaturaUrunDetay();
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                fr.id = dr["FATURABILGIID"].ToString();
            }
            fr.Show();
        }

        private void btnBul_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select ıd,satısfıyat from tbl_urunler where urunad=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtUrunAd.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                txtUrunId.Text = dr[0].ToString();
                txtFiyat.Text = dr[1].ToString();
            }
            bgl.baglanti().Close();
        }
    }
}
