using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaGUI.Ventanas_Operario
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void venderProducto(object sender, EventArgs e)
        {
            //ServiceProducto.WebService3SoapClient auxNegocio = new ServiceProducto.WebService3SoapClient();
            try
            {
                //ServiceProducto.Producto auxProducto = auxNegocio.venderProducto(skuProducto.Text, cantidadProducto.Text);
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Ha ocurrido un error");
                Console.WriteLine(ex.ToString());
            }
        }
           
           
    }
}
