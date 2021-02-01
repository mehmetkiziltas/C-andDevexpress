using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desing2
{
    public partial class FrmAnaModul : Form
    {
        public FrmAnaModul()
        {
            InitializeComponent();
        }
        
        FrmUrunler fr;
        private void BtnUrunler_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr == null)
            {
                fr = new FrmUrunler();
                fr.MdiParent = this;
                fr.Show();
            }
        }
        FrmAnaSayfa fr2;
        private void BtnAnaSayfa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr2 == null)
            {
                fr2 = new FrmAnaSayfa();
                fr2.MdiParent = this;
                fr2.Show();
            }
        }
        FrmStoklar fr3;
        private void BtnStokler_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr3 == null)
            {
                fr3 = new FrmStoklar();
                fr3.MdiParent = this;
                fr3.Show();
            }
        }
        FrmMusteriler fr4;
        private void BtnMusteriler_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr4 == null)
            {
                fr4 = new FrmMusteriler();
                fr4.MdiParent = this;
                fr4.Show();
            }
        }
        FrmFirmalar fr5;
        private void BtnFirmalar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr5 == null)
            {
                fr5 = new FrmFirmalar();
                fr5.MdiParent = this;
                fr5.Show();
            }
        }
        FrmPersoneller fr6;
        private void BtnPersoneller_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr6 == null)
            {
                fr6 = new FrmPersoneller();
                fr6.MdiParent = this;
                fr6.Show();
            }
        }
        FrmRehber fr7;
        private void BtnRehber_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr7 == null)
            {
                fr7 = new FrmRehber();
                fr7.MdiParent = this;
                fr7.Show();
            }
        }
        FrmGiderler fr8;
        private void BtnGiderler_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr8 == null)
            {
                fr8 = new FrmGiderler();
                fr8.MdiParent = this;
                fr8.Show();
            }
        }
        FrmBankalar fr9;
        private void BtnBankalar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr9 == null)
            {
                fr9 = new FrmBankalar();
                fr9.MdiParent = this;
                fr9.Show();
            }
        }
        FrmFaturalar fr10;
        private void BtnFaturalar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr10 == null)
            {
                fr10 = new FrmFaturalar();
                fr10.MdiParent = this;
                fr10.Show();
            }
        }
        FrmHareketler fr11;
        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr11 == null)
            {
                fr11 = new FrmHareketler();
                fr11.MdiParent = this;
                fr11.Show();
            }
        }

        FrmRaporlar fr12;
        private void btnRaporlar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr12 == null)
            {
                fr12 = new FrmRaporlar();
                fr12.MdiParent = this;
                fr12.Show();
            }
        }
        FrmAyarlar fr13;
        private void BtnAyarlar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
                fr13 = new FrmAyarlar();
                fr13.Show();
        }

        private void FrmAnaModul_Load(object sender, EventArgs e)
        {
            if (fr2 == null)
            {
                fr2 = new FrmAnaSayfa();
                fr2.MdiParent = this;
                fr2.Show();
            }
        }
        FrmKasa fr14;
        private void BtnKasa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr14 == null)
            {
                fr14 = new FrmKasa();
                fr14.MdiParent = this;
                fr14.Show();
            }
        }
        FrmNotlar fr15;
        private void BtnNotlar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr15 == null)
            {
                fr15 = new FrmNotlar();
                fr15.MdiParent = this;
                fr15.Show();
            }
        }

        private void FrmAnaModul_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
