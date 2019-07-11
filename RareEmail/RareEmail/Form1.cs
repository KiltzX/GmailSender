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
    public partial class Form1 : Form
    {
        public string email, senha;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (!txtEmail.Text.Contains("@"))
            {
                MessageBox.Show("Email invalido");
                return;
            }
            if (txtSenha.Text == "")
            {
                MessageBox.Show("Senha nao pode ser vazia");
                return;
            }

            try
            {
                using (SmtpClient smtp = new SmtpClient())
                {
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential(txtEmail.Text,txtSenha.Text);
                }
                email = txtEmail.Text;
                senha = txtSenha.Text;
            }
            catch
            {
                MessageBox.Show("Email ou senha Invalidos");
                return;
            }
            transferir();

            this.Hide();
            Form f = new EnviarEmail(email,senha);
            f.Closed += (s, args) => this.Close();
            f.Show();
        }

        public void transferir()
        {
            EnviarEmail destino = new EnviarEmail(txtEmail.Text, txtSenha.Text);
        }

        
    }
}
