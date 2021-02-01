using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;


namespace Desing2
{
    public partial class FrmMail : Form
    {
        public FrmMail()
        {
            InitializeComponent();
        }
        public string mail;
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                MailMessage mesajim = new MailMessage();
                SmtpClient istemci = new SmtpClient();
                istemci.Credentials = new System.Net.NetworkCredential("Email", "EmailPass");
                istemci.Port = 587;
                istemci.Host = "smtp.gmail.com";
                istemci.EnableSsl = true;
                mesajim.To.Add(txtMailAdres.Text);
                mesajim.From = new MailAddress("Email");
                mesajim.Subject = txtKonu.Text;
                mesajim.Body = rchMesaj.Text;
                istemci.Send(mesajim);
                MessageBox.Show("Mail Gönderildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Mail Gönderilemedi.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmMail_Load(object sender, EventArgs e)
        {
            txtMailAdres.Text = mail;
        }
    }
}
