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

namespace mailSenderandcolorfulboxes
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SmtpClient sc = new SmtpClient();
            sc.Port = 587;
            sc.Host = "smtp.gmail.com";
            sc.EnableSsl = true;
            sc.Credentials = new NetworkCredential("akifharmandar@gmail.com", "şifre");
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("akifharmandar@gmail.com");
            mail.To.Add( textBox1.Text.ToString());
            mail.Subject = textBox4.Text.ToString();
            mail.CC.Add(textBox2.Text.ToString());
            mail.Bcc.Add(textBox3.Text.ToString());
            mail.IsBodyHtml = true;
            mail.Body = textBox5.Text.ToString();
            sc.Send(mail);
            
                
            MessageBox.Show("iletildi");
        }
    }
}
