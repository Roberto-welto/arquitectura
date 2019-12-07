using CapaDTO;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaGUI
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            ServiceLogin.WebService1SoapClient auxNegocio = new ServiceLogin.WebService1SoapClient();
            ServiceLogin.Usuario auxUsuario = auxNegocio.login_user_service(txtUser.Text, txtPassword.Text);

            try
            {
                if (auxUsuario.Nombre == txtUser.Text && auxUsuario.Contraseña == txtPassword.Text)
                {
                    MessageBox.Show($"Login correcto, bienvenido {txtUser.Text}");
                    if (auxUsuario.Cargo == 1)
                    {

                        Ventanas_Administrador.Admin ventanaAdmin = new Ventanas_Administrador.Admin();
                        ventanaAdmin.Show();
                        this.Close();

                    }
                    if (auxUsuario.Cargo == 2)
                    {

                        Ventana_Farmaceutico.Gestion ventanaFarma = new Ventana_Farmaceutico.Gestion();
                        ventanaFarma.Show();
                        this.Close();

                    }
                    if (auxUsuario.Cargo == 3)
                    {

                        Ventana_Farmaceutico.Gestion ventanaFarma = new Ventana_Farmaceutico.Gestion();
                        ventanaFarma.Show();
                        this.Close();

                    }
                    if (auxUsuario.Cargo == 4)
                    {
                        Ventanas_Bodeguero.Bodega ventanaBodega = new Ventanas_Bodeguero.Bodega();
                        ventanaBodega.Show();
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Login Incorrecto");
            }
            
        
            
        }

      
    }
}
