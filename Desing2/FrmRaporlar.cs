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
    public partial class FrmRaporlar : Form
    {
        public FrmRaporlar()
        {
            InitializeComponent();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {

        }

        private void gridView2_DoubleClick(object sender, EventArgs e)
        {

        }

        private void FrmRaporlar_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'DboTicariOtomasyonDataSet4.TBL_FATURADETAY' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.TBL_FATURADETAYTableAdapter.Fill(this.DboTicariOtomasyonDataSet4.TBL_FATURADETAY);
            // TODO: Bu kod satırı 'DboTicariOtomasyonDataSet2.TBL_GIDERLER' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.TBL_GIDERLERTableAdapter.Fill(this.DboTicariOtomasyonDataSet2.TBL_GIDERLER);
            // TODO: Bu kod satırı 'DboTicariOtomasyonDataSet1.TBL_PERSONELLER' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.TBL_PERSONELLERTableAdapter.Fill(this.DboTicariOtomasyonDataSet1.TBL_PERSONELLER);
            // TODO: Bu kod satırı 'DboTicariOtomasyonDataSet.TBL_FIRMALAR' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.TBL_FIRMALARTableAdapter.Fill(this.DboTicariOtomasyonDataSet.TBL_FIRMALAR);

            this.reportViewer1.RefreshReport();
            this.reportViewer2.RefreshReport();
            this.reportViewer3.RefreshReport();
            this.reportViewer4.RefreshReport();
            this.reportViewer5.RefreshReport();
            this.reportViewer5.RefreshReport();
        }
    }
}
