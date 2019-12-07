using CapaConexion;
using CapaDTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class NegocioLogin
    {
        private Conexion conn;
        public Conexion Conn { get => conn; set => conn = value; }

        public void configurarConexion()
        {
            this.Conn = new Conexion();
            this.Conn.CadenaConexion = "Data Source=DESKTOP-K7P6J82; Initial Catalog=DoctorSami;Integrated Security=True";
            this.Conn.NombreDB = "DoctorSami";
            this.Conn.NombreTabla = "Usuario";
        }

        public Usuario login_user(string nombre, string contraseña)
        {
            this.configurarConexion();
            this.Conn.CadenaSQL = ($"SELECT * FROM {this.Conn.NombreTabla} " +
                                   $"WHERE nombre_usuario = '{nombre}' AND pass_usuario = '{contraseña}';");
            this.Conn.IsSelect = true;
            this.Conn.conectar();

            DataTable dt = this.Conn.DbDataSet.Tables[this.Conn.NombreTabla];

            Usuario auxUsuario = new Usuario();
            try
            {
                auxUsuario.Nombre = Convert.ToString(dt.Rows[0]["nombre_usuario"]);
                auxUsuario.Contraseña = Convert.ToString(dt.Rows[0]["pass_usuario"]);
                auxUsuario.Id = Convert.ToInt32(dt.Rows[0]["id_usuario"]);
                auxUsuario.Rut = Convert.ToString(dt.Rows[0]["rut_usuario"]);
                auxUsuario.Cargo = Convert.ToInt32(dt.Rows[0]["id_cargo"]);
            }
            catch (Exception ex)
            {
                auxUsuario = null;
            }

            return auxUsuario;
        }
    }
}

