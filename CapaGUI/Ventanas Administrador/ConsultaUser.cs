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
                NegocioAdministrador auxNegocio = new NegocioAdministrador();
                Usuario auxUser = auxNegocio.consulta_usuario(txtUsername.Text);
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

                NegocioAdministrador auxNegocio = new NegocioAdministrador();
                Usuario auxUser = auxNegocio.consulta_usuario(txtUsername.Text);

                txtRut.Text = auxUser.Rut;
                txtPass.Text = auxUser.Contraseña;
                cboCargo.SelectedIndex = auxUser.Cargo;
            }
            else
            {
                try
                {
                    NegocioAdministrador auxNegocio = new NegocioAdministrador();
                    this.dataGridViewUsuarios.DataSource = auxNegocio.listarUsuarios();
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
                NegocioAdministrador auxNegocio = new NegocioAdministrador();
                auxNegocio.eliminar_usuario(txtUsername.Text);
                MessageBox.Show($"Usuario {txtUsername} eliminado exitosamente");
                limpiarControles();
                this.dataGridViewUsuarios.DataSource = auxNegocio.listarUsuarios();
                this.dataGridViewUsuarios.DataMember = "Usuario";


            }
        }

        private void Actualizar_Click(object sender, EventArgs e)
        {
            if (validarCampoUser())
            {
                try
                {
                    NegocioAdministrador auxNegocio = new NegocioAdministrador();
                    Usuario auxUser = new Usuario();

                    auxUser.Nombre = txtUsername.Text;
                    auxUser.Rut = txtRut.Text;
                    auxUser.Contraseña = txtPass.Text;
                    auxUser.Cargo = cboCargo.SelectedIndex;

                    auxNegocio.actualizar_usuario(auxUser);
                    MessageBox.Show("Usuario actualizado correctamente");

                    limpiarControles();
                    this.dataGridViewUsuarios.DataSource = auxNegocio.listarUsuarios();
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
