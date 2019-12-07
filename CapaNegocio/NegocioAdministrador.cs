using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaConexion;
using CapaDTO;

namespace CapaNegocio
{
    public class NegocioAdministrador
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
        public Usuario verificar_usuario(string rut, string user )
        {
            this.configurarConexion();
            this.Conn.CadenaSQL = ($"SELECT * FROM {this.Conn.NombreTabla} " +
                                   $"WHERE nombre_usuario = '{user}' OR rut_usuario = '{rut}';");
            this.Conn.IsSelect = true;
            this.Conn.conectar();

            DataTable dt = this.Conn.DbDataSet.Tables[this.Conn.NombreTabla];
            Usuario auxUsuario= new Usuario();
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

        public Usuario consulta_usuario(string user)
        {
            this.configurarConexion(); 
            this.Conn.CadenaSQL = ($"SELECT * FROM {this.Conn.NombreTabla} " +
                                   $"WHERE nombre_usuario = '{user}';");
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

        public void agregar_usuario(Usuario auxUsuario)
        {
            this.configurarConexion();
            this.Conn.CadenaSQL = ($"INSERT INTO {this.Conn.NombreTabla} VALUES" +
                                   $"(NEXT VALUE FOR seq_usuario, '{auxUsuario.Rut}', '{auxUsuario.Nombre}' , '{auxUsuario.Contraseña}',{auxUsuario.Cargo});");
            this.Conn.IsSelect = false;
            this.Conn.conectar();
        }

        public void eliminar_usuario(string username)
        {
            this.configurarConexion();
            this.Conn.CadenaSQL = ($"DELETE FROM {this.Conn.NombreTabla} WHERE " +
                                   $"nombre_usuario ='{username}';");
            this.Conn.IsSelect = false;
            this.Conn.conectar();
        }
        public void actualizar_usuario(Usuario auxUsuario)
        {
            this.configurarConexion();
            this.Conn.CadenaSQL = ($"UPDATE {this.Conn.NombreTabla} SET rut_usuario = '{auxUsuario.Rut}', nombre_usuario = '{auxUsuario.Nombre}', pass_usuario = '{auxUsuario.Contraseña}', id_cargo = {auxUsuario.Cargo} WHERE nombre_usuario = '{auxUsuario.Nombre}' ;");
            this.Conn.IsSelect = false;
            this.Conn.conectar();
        }

        public DataSet listarUsuarios()
        {
            this.configurarConexion();
            this.Conn.CadenaSQL = $"SELECT u.nombre_usuario, c.desc_cargo from Usuario u join Cargo c on u.id_cargo= c.id_cargo";
            this.Conn.IsSelect = true;
            this.Conn.conectar();
            return this.Conn.DbDataSet;
        }


    }


}
