using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaGUI.Ventanas_Administrador
{
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void agregarUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ventanas_Administrador.AgregarUser Agregar = new Ventanas_Administrador.AgregarUser();
            Agregar.Show();
        }

        private void eliminarUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ventanas_Administrador.ConsultaUser Consultar = new Ventanas_Administrador.ConsultaUser();
            Consultar.Show();
        }

        private void agregarUsuario(object sender, EventArgs e)
        {
            Ventanas_Administrador.AgregarUser Agregar = new Ventanas_Administrador.AgregarUser();
            Agregar.Show();
        }

        private void consultarUsuario(object sender, EventArgs e)
        {
            Ventanas_Administrador.ConsultaUser Consultar = new Ventanas_Administrador.ConsultaUser();
            Consultar.Show();
        }
    }
}
