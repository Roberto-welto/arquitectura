using CapaConexion;
using CapaDTO;
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
   public class NegocioProducto
    {
        private Conexion conn;
        public Conexion Conn { get => conn; set => conn = value; }

        public void configurarConexion()
        {
            this.Conn = new Conexion();
            this.Conn.CadenaConexion = "Data Source=DESKTOP-VFCRG88; Initial Catalog=DoctorSami;Integrated Security=True";
            this.Conn.NombreDB = "DoctorSami";
            this.Conn.NombreTabla = "Producto";
        } 

    

        public Producto buscarProducto(string sku, string nombre)
        {
            this.configurarConexion();
            this.Conn.CadenaSQL = ($"SELECT * FROM {this.Conn.NombreTabla}" +
                $"  WHERE Sku = {sku} OR Nombre = {nombre};");
            this.Conn.IsSelect = true;
            this.Conn.conectar();
            DataTable dt = this.Conn.DbDataSet.Tables[this.Conn.NombreTabla];
            Producto auxProducto = new Producto();
            try
            {
                auxProducto.Sku = Convert.ToString(dt.Rows[0]["Sku"]);
                auxProducto.Nombre = Convert.ToString(dt.Rows[0]["Nombre"]);
                auxProducto.Descripcion = Convert.ToString(dt.Rows[0]["Descripcion"]);
                auxProducto.Precio = Convert.ToInt32(dt.Rows[0]["Precio"]);
                auxProducto.Stock = Convert.ToInt32(dt.Rows[0]["Stock"]);
            }
            catch(Exception ex)
            {
                auxProducto = null;
            }

            return auxProducto;
        }
        public void venderProducto(int stock, string sku)
        {
            this.configurarConexion();
            this.Conn.CadenaSQL = ($"UPDATE {this.Conn.NombreTabla}" +
                $"SET Stock = Stock - {stock}" +
                $"WHERE Sku = {sku}");
            this.Conn.IsSelect = false;
            this.Conn.conectar();
        }
        public DataSet getAllProductos()
        {
            this.configurarConexion();
            this.Conn.CadenaSQL = ($"SELECT * FROM {this.Conn.NombreTabla} ;");
            this.Conn.IsSelect = true;
            this.Conn.conectar();
            DataTable dt = this.Conn.DbDataSet.Tables[this.Conn.NombreTabla];
            DataSet ds = new DataSet();
            ds.Tables.Add(dt);

            return ds;
        }
    }
}
