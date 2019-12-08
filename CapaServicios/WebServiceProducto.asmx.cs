using System;
using CapaDTO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace CapaServicios
{
    /// <summary>
    /// Summary description for WebServiceProducto
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebServiceProducto : System.Web.Services.WebService
    {

        [WebMethod]
        public Producto buscarProducto(string sku, string nombre)
        {
            CapaNegocio.NegocioProducto auxProductoBusqueda = new CapaNegocio.NegocioProducto();
            return auxProductoBusqueda.buscarProducto(sku, nombre);
            
        }
    }
}
