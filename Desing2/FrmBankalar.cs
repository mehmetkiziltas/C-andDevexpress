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
    public partial class FrmBankalar : Form
    {
        public FrmBankalar()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();
        void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Execute BankaBilgileri", bgl.baglanti());
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
        void firmaListesi()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select ID,AD from Tbl_FIRMALAR", bgl.baglanti());
            da.Fill(dt);
            lkpFirma.Properties.ValueMember = "ID";
            lkpFirma.Properties.DisplayMember = "AD";
            lkpFirma.Properties.DataSource = dt;
        }
        void temizle()
        {
            txtBankaAd.Text = "";
            txtHesapTuru.Text = "";
            txtid.Text = "";
            txtSube.Text = "";
            txtYetkili.Text = "";
            mskTarih.Text = "";
            mskIban.Text = "";
            mskHesapNo.Text = "";
            msktelefon.Text = "";
            lkpFirma.Text = "";
            cmbil.Text = "";
            cmbilce.Text = "";

        }
        private void FrmBankalar_Load(object sender, EventArgs e)
        {
            firmaListesi();
            sehirListesi();
            listele();
        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into TBL_BANKALAR (BANKAADI,IL,ILCE,SUBE,IBAN,HESAPNO,YETKILI,TELEFON, TARIH, HESAPTURU, FIRMAID) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11)", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtBankaAd.Text);
            komut.Parameters.AddWithValue("@p2", cmbil.Text);
            komut.Parameters.AddWithValue("@p3", cmbilce.Text);
            komut.Parameters.AddWithValue("@p4", txtSube.Text);
            komut.Parameters.AddWithValue("@p5", mskIban.Text);
            komut.Parameters.AddWithValue("@p6", mskHesapNo.Text);
            komut.Parameters.AddWithValue("@p7", txtYetkili.Text);
            komut.Parameters.AddWithValue("@p8", msktelefon.Text);
            komut.Parameters.AddWithValue("@p9", mskTarih.Text);
            komut.Parameters.AddWithValue("@p10", txtHesapTuru.Text);
            komut.Parameters.AddWithValue("@p11", lkpFirma.EditValue);
            komut.ExecuteNonQuery();
            listele();
            bgl.baglanti().Close();
            temizle();
            MessageBox.Show("Banka Bilgisi Sistame Kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                //DataTable dt = new DataTable();
                //SqlDataAdapter da = new SqlDataAdapter("select ID,AD from Tbl_FIRMALAR", bgl.baglanti());
                //da.Fill(dt);
                //lkpFirma.Properties.ValueMember = "ID";
                //lkpFirma.Properties.DisplayMember = "AD";

                txtid.Text = dr["ID"].ToString();
                txtBankaAd.Text = dr["BANKAADI"].ToString();
                cmbil.Text = dr["IL"].ToString();
                cmbilce.Text = dr["ILCE"].ToString();
                txtSube.Text = dr["SUBE"].ToString();
                mskIban.Text = dr["IBAN"].ToString();
                mskHesapNo.Text = dr["HESAPNO"].ToString();
                txtYetkili.Text = dr["YETKILI"].ToString();
                msktelefon.Text = dr["TELEFON"].ToString();
                mskTarih.Text = dr["TARIH"].ToString();
                txtHesapTuru.Text = dr["HESAPTURU"].ToString();
                //lkpFirma.EditValue = lkpFirma.Properties.DisplayMember;
            }
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update tbl_bankalar set BANKAADI=@P1,IL=@P2,ILCE=@P3,SUBE=@P4,IBAN=@P5,HESAPNO=@P6,YETKILI=@P7,TELEFON=@P8,TARIH=@P9,HESAPTURU=@P10,FIRMAID=@P11 where ID=@P12", bgl.baglanti());
            komut.Parameters.AddWithValue("@P1", txtBankaAd.Text);
            komut.Parameters.AddWithValue("@P2", cmbil.Text);
            komut.Parameters.AddWithValue("@P3", cmbilce.Text);
            komut.Parameters.AddWithValue("@P4", txtSube.Text);
            komut.Parameters.AddWithValue("@P5", mskIban.Text);
            komut.Parameters.AddWithValue("@P6", mskHesapNo.Text);
            komut.Parameters.AddWithValue("@P7", txtYetkili.Text);
            komut.Parameters.AddWithValue("@P8", msktelefon.Text);
            komut.Parameters.AddWithValue("@P9", mskTarih.Text);
            komut.Parameters.AddWithValue("@P10", txtHesapTuru.Text);
            komut.Parameters.AddWithValue("@P11", lkpFirma.EditValue);
            komut.Parameters.AddWithValue("@P12", txtid.Text);
            komut.ExecuteNonQuery();
            listele();
            bgl.baglanti().Close();
            temizle();
            MessageBox.Show("Banka Bilgisi Güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komutsil = new SqlCommand("delete from tbl_bankalar where ID=@p1", bgl.baglanti());
            komutsil.Parameters.AddWithValue("@p1", txtid.Text);
            komutsil.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Banka Bilgisi Sistemden Silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            listele();
            temizle();
        }
    }
}
