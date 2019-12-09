using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaGUI.Ventanas_Bodeguero
{
    public partial class Bodega : Form
    {
        public Bodega()
        {
            InitializeComponent();
            this.Bodega_Load();
        }

        private void Bodega_Load()
        {
            //ServiceProducto.WebService3SoapClient auxNegocio = new ServiceProducto.WebService3SoapClient();
            //ServiceProducto.Producto auxProductos = auxNegocio.getAllProductos();
            //listaProductos.DataSource = auxProductos;
        }


    }
}
