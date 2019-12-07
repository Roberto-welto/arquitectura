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
    public partial class ConsultaUser : Form
    {
        public ConsultaUser()
        {
            InitializeComponent();
        }

        private void limpiarControles()
        {
            txtUsername.Text = "";
            txtRut.Text = "";
            txtPass.Text = "";
            cboCargo.SelectedIndex = 0;
        }
        private bool validarCampoUser()
        {
            if(txtUsername.Text.Length == 0)
            {
                MessageBox.Show("Debe ingresar el nombre de usuario");
                return false;
            }
           
            try
            {
                ServiceAdmin.WebService2SoapClient auxNegocio = new ServiceAdmin.WebService2SoapClient();
                ServiceAdmin.Usuario auxUser = auxNegocio.consulta_usuario_service(txtUsername.Text);
                if(auxUser == null)
                {
                    MessageBox.Show("No existe el usuario a buscar, pero te mostramos los usuarios registrados");
                    return false;
                }   
            }
            catch (Exception ex)
            {   

                MessageBox.Show(ex.Message);
            }
            return true;
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            if (validarCampoUser())
            {
                MessageBox.Show("Usuario encontrado");

                ServiceAdmin.WebService2SoapClient auxNegocio = new ServiceAdmin.WebService2SoapClient();
                ServiceAdmin.Usuario auxUser = auxNegocio.consulta_usuario_service(txtUsername.Text);

                txtRut.Text = auxUser.Rut;
                txtPass.Text = auxUser.Contraseña;
                cboCargo.SelectedIndex = auxUser.Cargo;
            }
            else
            {
                try
                {
                    ServiceAdmin.WebService2SoapClient auxNegocio = new ServiceAdmin.WebService2SoapClient();
                    this.dataGridViewUsuarios.DataSource = auxNegocio.listarUsuarios_service();
                    this.dataGridViewUsuarios.DataMember = "Usuario";
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (validarCampoUser())
            {
                ServiceAdmin.WebService2SoapClient auxNegocio = new ServiceAdmin.WebService2SoapClient();
                auxNegocio.eliminar_usuario_service(txtUsername.Text);
                MessageBox.Show($"Usuario {txtUsername.Text} eliminado exitosamente");
                limpiarControles();
                this.dataGridViewUsuarios.DataSource = auxNegocio.listarUsuarios_service();
                this.dataGridViewUsuarios.DataMember = "Usuario";


            }
        }

        private void Actualizar_Click(object sender, EventArgs e)
        {
            if (validarCampoUser())
            {
                try
                {
                    ServiceAdmin.WebService2SoapClient auxNegocio = new ServiceAdmin.WebService2SoapClient();
                    ServiceAdmin.Usuario auxUser = new ServiceAdmin.Usuario();

                    auxUser.Nombre = txtUsername.Text;
                    auxUser.Rut = txtRut.Text;
                    auxUser.Contraseña = txtPass.Text;
                    auxUser.Cargo = cboCargo.SelectedIndex;

                    auxNegocio.actualizar_usuario_service(auxUser);
                    MessageBox.Show("Usuario actualizado correctamente");

                    limpiarControles();
                    this.dataGridViewUsuarios.DataSource = auxNegocio.listarUsuarios_service();
                    this.dataGridViewUsuarios.DataMember = "Usuario";
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
                

            }
        }
    }
}
