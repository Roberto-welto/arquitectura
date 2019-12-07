using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaDTO;
using CapaNegocio;


namespace CapaGUI.Ventanas_Administrador
{
    public partial class AgregarUser : Form
    {
        public AgregarUser()
        {
            InitializeComponent();
            cboCargo.SelectedIndex = 0;
        }
        private bool validar(){
           
            if (txtNombreUser.Text.Length ==  0)
            {
                MessageBox.Show("Ingrese nombre de usuario");
                return false;
            }
            if (txtPassword.Text.Length == 0)
            {
                MessageBox.Show("Ingrese la contraseña");
                return false;
            }
            if (txtRut.Text.Length == 0) {

                MessageBox.Show("Ingrese Rut");
                return false;
            }
            if(cboCargo.SelectedIndex == 0)
            {
                MessageBox.Show("Seleccione el cargo");
                return false;
            }
            try
            {
                
                ServiceAdmin.WebService2SoapClient auxNegocio = new ServiceAdmin.WebService2SoapClient();
                ServiceAdmin.Usuario auxUsuario = auxNegocio.verificar_usuario_service(txtRut.Text, txtNombreUser.Text);
                if(auxUsuario == null)
                {
                    MessageBox.Show("Todo ok");
                    return true;
                }
                else
                {
                    MessageBox.Show("Rut o nombre de usuario ya existe");
                    return false;
                }
                
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            return true;
            
         }
        private void button1_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                ServiceAdmin.Usuario auxUsuario = new ServiceAdmin.Usuario();
                ServiceAdmin.WebService2SoapClient auxNegocio = new ServiceAdmin.WebService2SoapClient();

                auxUsuario.Nombre = txtNombreUser.Text;
                auxUsuario.Rut = txtRut.Text;
                auxUsuario.Contraseña = txtPassword.Text;
                auxUsuario.Cargo = cboCargo.SelectedIndex;

                auxNegocio.agregar_usuario_service(auxUsuario);
                MessageBox.Show("Usuario agregado correctamente");
                limpiarControles();
                
            }
            else
            {
                MessageBox.Show("Casi master");
            }
        }

        private void limpiarControles()
        {
            txtNombreUser.Text = "";
            txtPassword.Text = "";
            txtRut.Text = "";
            cboCargo.SelectedIndex = 0;
        }
    }
}
