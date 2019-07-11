using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net.Mime;
using System.Net.Configuration;
using System.Net;

namespace RareEmail
{
    public partial class EnviarEmail : Form
    {

        string login, senhalogin;

        public EnviarEmail(string email, string senha)
        {
            InitializeComponent();
            login = email;
            senhalogin = senha;
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            string conteudo = "<html><head><style>p {  margin-right: 150px;  margin-left: 80px;}</style></head><body>    <div class='gallery'>         <a target='_blank' href='img_5terre.jpg'>         <img src='https://i.ibb.co/N94F4pP/rare-1.jpg'                alt='Rare_image1' width='600' height='400'> </a>        <div class='desc'></div>    </div>    <p>        <font size='10' face='Times'>" + txtPin.Text + "</font>    </p>    <div class='responsive'>        <div class='gallery'> <a target='_blank' href='img_forest.jpg'> <img src='https://i.ibb.co/MVC0TsP/rare-2.jpg'                    alt='Rare_image2' width='600' height='400'> </a>            <div class='desc'></div>        </div>    </div>    <div class='clearfix'></div></body></html>";

            Form1 frmLogin = new Form1();

            SmtpClient smtp = new SmtpClient();         
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential(login, senhalogin);

            MailMessage mail = new MailMessage();        
            mail.From = new MailAddress(login);

            if (!string.IsNullOrWhiteSpace(txtPara.Text))
            {
                mail.To.Add(new MailAddress(txtPara.Text));
            }
            else
            {
                    MessageBox.Show("Campo 'para' é obrigatório.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
            }                
            mail.Subject = txtAssunto.Text;

            mail.Body = conteudo;
            mail.IsBodyHtml = true;


            try
            {
                smtp.Send(mail);
                MessageBox.Show("Email enviado com sucesso.");
                txtPara.Text = "";
                txtPin.Text = "";
            }
            catch(Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

        private void EnviarEmail_Load(object sender, EventArgs e)
        {
            
            
        }

        

    }
}
