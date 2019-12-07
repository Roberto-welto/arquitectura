using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using CapaNegocio;
using CapaDTO;
using System.Data;

namespace CapaServicios
{
    /// <summary>
    /// Descripción breve de WebService2
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService2 : System.Web.Services.WebService
    {

        [WebMethod]
        public Usuario verificar_usuario_service(string rut, string user)
        {
            NegocioAdministrador auxNegocioAdm = new NegocioAdministrador();
            return auxNegocioAdm.verificar_usuario(rut, user);
        }
        [WebMethod]
        public void agregar_usuario_service(Usuario auxUsuario)
        {
            NegocioAdministrador auxNegocioAdm = new NegocioAdministrador();
            auxNegocioAdm.agregar_usuario(auxUsuario);
        }
        [WebMethod]
        public Usuario consulta_usuario_service(string user)
        {
            NegocioAdministrador auxNegocioAdm = new NegocioAdministrador();
            return auxNegocioAdm.consulta_usuario(user);
        }
        [WebMethod]
        public DataSet listarUsuarios_service()
        {
            NegocioAdministrador auxNegocioAdm = new NegocioAdministrador();
            return auxNegocioAdm.listarUsuarios();
        }
        [WebMethod]
        public void eliminar_usuario_service(string username)
        {
            NegocioAdministrador auxNegocioAdm = new NegocioAdministrador();
            auxNegocioAdm.eliminar_usuario(username);
        }
        [WebMethod]
        public void actualizar_usuario_service(Usuario auxUsuario)
        {
            NegocioAdministrador auxNegocioAdm = new NegocioAdministrador();
            auxNegocioAdm.actualizar_usuario(auxUsuario);
        }
    }
}
