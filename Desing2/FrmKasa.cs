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
    public partial class FrmKasa : Form
    {
        public FrmKasa()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();
        public string ad;
        void musteri_hareket()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("exec MusteriHareketler", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }
        void Firma_Hareket()
        {
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("exec FirmaHareketler", bgl.baglanti());
            da2.Fill(dt2);
            gridControl3.DataSource = dt2;
        }
        void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from tbl_GIDERler", bgl.baglanti());
            da.Fill(dt);
            gridControl2.DataSource = dt;
        }
        private void gridView1_DoubleClick(object sender, EventArgs e)
        {

        }

        private void gridView2_DoubleClick(object sender, EventArgs e)
        {

        }

        private void FrmKasa_Load(object sender, EventArgs e)
        {
            lblAktifKullanici.Text = ad;
            musteri_hareket();
            Firma_Hareket();
            listele();

            //Toplam tutar Haesaplama

            SqlCommand komut1 = new SqlCommand("select sum(tutar) from Tbl_Faturadetay", bgl.baglanti());
            SqlDataReader dr1 = komut1.ExecuteReader();
            while (dr1.Read())
            {
                lblKasaToplam.Text = dr1[0].ToString() + " TL";
            }
            bgl.baglanti().Close();

            //Son ayın Faturaları

            SqlCommand komut2 = new SqlCommand("select (ELEKTRIK+SU+DOGALGAZ+INTERNET+MAASLAR+EKSTRA) FROM TBL_GIDERLER ORDER BY ID ASC", bgl.baglanti());
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                lblOdemeler.Text = dr2[0].ToString() + " TL";
            }
            bgl.baglanti().Close();

            //sON AYIN PERSONEL MAASLARI 

            SqlCommand komut3 = new SqlCommand("select MAASLAR FROM TBL_GIDERLER ORDER BY ID ASC", bgl.baglanti());
            SqlDataReader dr3 = komut3.ExecuteReader();
            while (dr3.Read())
            {
                lblPersonelMaas.Text = dr3[0].ToString() + " TL";
            }
            bgl.baglanti().Close();

            //Toplam Müşteri sayısı

            SqlCommand komut4 = new SqlCommand("select count(*) from tbl_musterıler", bgl.baglanti());
            SqlDataReader dr4 = komut4.ExecuteReader();
            while (dr4.Read())
            {
                lblMusteriSayisi.Text = dr4[0].ToString();
            }
            bgl.baglanti().Close();

            //toplam Firma Sayısı

            SqlCommand komut5 = new SqlCommand("select count(*) from tbl_FIRMALAR", bgl.baglanti());
            SqlDataReader dr5 = komut5.ExecuteReader();
            while (dr5.Read())
            {
                lblFirmaSayisi.Text = dr5[0].ToString();
            }
            bgl.baglanti().Close();

            //toplam Firma şehir Sayısı

            SqlCommand komut6 = new SqlCommand("select count(distinct(IL)) from tbl_FIRmalar", bgl.baglanti());
            SqlDataReader dr6 = komut6.ExecuteReader();
            while (dr6.Read())
            {
                lblSehirSayisi.Text = dr6[0].ToString();
            }
            bgl.baglanti().Close();

            //toplam müşteri şehir Sayısı

            SqlCommand komut9 = new SqlCommand("select count(distinct(IL)) from tbl_MUSteRILER", bgl.baglanti());
            SqlDataReader dr9 = komut9.ExecuteReader();
            while (dr9.Read())
            {
                lblSehirSayisi2.Text = dr9[0].ToString();
            }
            bgl.baglanti().Close();

            //toplam personel Sayısı

            SqlCommand komut7 = new SqlCommand("select count(*) from tbl_personeller ", bgl.baglanti());
            SqlDataReader dr7 = komut7.ExecuteReader();
            while (dr7.Read())
            {
                lblPersonelSayisi.Text = dr7[0].ToString();
            }
            bgl.baglanti().Close();

            //toplam stok Sayısı

            SqlCommand komut8 = new SqlCommand("select sum(adet) from tbl_urunler", bgl.baglanti());
            SqlDataReader dr8 = komut8.ExecuteReader();
            while (dr8.Read())
            {
                lblStokSayisi.Text = dr8[0].ToString();
            }
            bgl.baglanti().Close();
        }
        int sayac = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            sayac++;
            if (sayac > 0 && sayac <= 5)
            {
                groupControl11.Text = "Elektrik";
                SqlCommand komut10 = new SqlCommand("select top 4 Ay,elektrık from tbl_gıderler order by ID desc", bgl.baglanti());
                SqlDataReader dr10 = komut10.ExecuteReader();
                while (dr10.Read())
                {
                    chartControl1.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr10[0], dr10[1]));
                }
                bgl.baglanti().Close();
            }
            //Su
            if (sayac > 5 && sayac <= 10)
            {
                groupControl11.Text = "Su";
                chartControl1.Series["Aylar"].Points.Clear();

                SqlCommand komut12 = new SqlCommand("select top 4 Ay,Su from tbl_gıderler order by ID desc", bgl.baglanti());
                SqlDataReader dr12 = komut12.ExecuteReader();
                while (dr12.Read())
                {
                    chartControl1.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr12[0], dr12[1]));
                }
                bgl.baglanti().Close();
            }
            //Doğalgaz
            if (sayac > 10 && sayac <= 15)
            {
                groupControl11.Text = "Doğalgaz";
                chartControl1.Series["Aylar"].Points.Clear();

                SqlCommand komut12 = new SqlCommand("select top 4 Ay,dogalgaz from tbl_gıderler order by ID desc", bgl.baglanti());
                SqlDataReader dr12 = komut12.ExecuteReader();
                while (dr12.Read())
                {
                    chartControl1.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr12[0], dr12[1]));
                }
                bgl.baglanti().Close();
            }
            //İnternet
            if (sayac > 15 && sayac <= 20)
            {
                groupControl11.Text = "Internet";
                chartControl1.Series["Aylar"].Points.Clear();

                SqlCommand komut12 = new SqlCommand("select top 4 Ay,INTERNET from tbl_gıderler order by ID desc", bgl.baglanti());
                SqlDataReader dr12 = komut12.ExecuteReader();
                while (dr12.Read())
                {
                    chartControl1.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr12[0], dr12[1]));
                }
                bgl.baglanti().Close();
            }
            //Ekstra
            if (sayac > 15 && sayac <= 20)
            {
                groupControl11.Text = "Ekstra";
                chartControl1.Series["Aylar"].Points.Clear();

                SqlCommand komut12 = new SqlCommand("select top 4 Ay,Ekstra from tbl_gıderler order by ID desc", bgl.baglanti());
                SqlDataReader dr12 = komut12.ExecuteReader();
                while (dr12.Read())
                {
                    chartControl1.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr12[0], dr12[1]));
                }
                bgl.baglanti().Close();
            }
            if (sayac == 26)
            {
                sayac = 0;
            }
        }
        int sayac2;
        private void timer2_Tick(object sender, EventArgs e)
        {
            //Elektrik
            sayac2++;
            if (sayac2 > 0 && sayac2 <= 5)
            {
                groupControl12.Text = "Elektrik";
                SqlCommand komut10 = new SqlCommand("select top 4 Ay,elektrık from tbl_gıderler order by ID desc", bgl.baglanti());
                SqlDataReader dr10 = komut10.ExecuteReader();
                while (dr10.Read())
                {
                    chartControl2.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr10[0], dr10[1]));
                }
                bgl.baglanti().Close();
            }
            //Su
            if (sayac2 > 5 && sayac2 <= 10)
            {
                groupControl12.Text = "Su";
                chartControl2.Series["Aylar"].Points.Clear();

                SqlCommand komut12 = new SqlCommand("select top 4 Ay,Su from tbl_gıderler order by ID desc", bgl.baglanti());
                SqlDataReader dr12 = komut12.ExecuteReader();
                while (dr12.Read())
                {
                    chartControl2.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr12[0], dr12[1]));
                }
                bgl.baglanti().Close();
            }
            //Doğalgaz
            if (sayac2 > 10 && sayac2 <= 15)
            {
                groupControl12.Text = "Doğalgaz";
                chartControl2.Series["Aylar"].Points.Clear();

                SqlCommand komut12 = new SqlCommand("select top 4 Ay,dogalgaz from tbl_gıderler order by ID desc", bgl.baglanti());
                SqlDataReader dr12 = komut12.ExecuteReader();
                while (dr12.Read())
                {
                    chartControl2.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr12[0], dr12[1]));
                }
                bgl.baglanti().Close();
            }
            //İnternet
            if (sayac2 > 15 && sayac2 <= 20)
            {
                groupControl12.Text = "Internet";
                chartControl2.Series["Aylar"].Points.Clear();

                SqlCommand komut12 = new SqlCommand("select top 4 Ay,INTERNET from tbl_gıderler order by ID desc", bgl.baglanti());
                SqlDataReader dr12 = komut12.ExecuteReader();
                while (dr12.Read())
                {
                    chartControl2.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr12[0], dr12[1]));
                }
                bgl.baglanti().Close();
            }
            //Ekstra
            if (sayac2 > 15 && sayac2 <= 20)
            {
                groupControl12.Text = "Ekstra";
                chartControl2.Series["Aylar"].Points.Clear();

                SqlCommand komut12 = new SqlCommand("select top 4 Ay,Ekstra from tbl_gıderler order by ID desc", bgl.baglanti());
                SqlDataReader dr12 = komut12.ExecuteReader();
                while (dr12.Read())
                {
                    chartControl2.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr12[0], dr12[1]));
                }
                bgl.baglanti().Close();
            }
            if (sayac2 == 26)
            {
                sayac2 = 0;
            }
        }
    }
}
