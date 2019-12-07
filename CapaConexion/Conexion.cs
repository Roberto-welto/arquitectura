using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaConexion
{
    public class Conexion
    {
        
        private string nombreDB;
        private string nombreTabla;
        private string cadenaSQL;
        private string cadenaConexion;
        private bool isSelect;

        private SqlConnection dbConnection;
        private DataSet dbDataSet;
        private SqlDataAdapter dbDataAdapter;

        public string NombreDB { get => nombreDB; set => nombreDB = value; }
        public string NombreTabla { get => nombreTabla; set => nombreTabla = value; }
        public string CadenaSQL { get => cadenaSQL; set => cadenaSQL = value; }
        public string CadenaConexion { get => cadenaConexion; set => cadenaConexion = value; }
        public bool IsSelect { get => isSelect; set => isSelect = value; }
        public SqlConnection DbConnection { get => dbConnection; set => dbConnection = value; }
        public DataSet DbDataSet { get => dbDataSet; set => dbDataSet = value; }
        public SqlDataAdapter DbDataAdapter { get => dbDataAdapter; set => dbDataAdapter = value; }

        public void abrir()
        {
            try
            {
                this.DbConnection.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al abrir la conexion: {ex}", "Sistema");
            }
        }

            public void cerrar()
            {
                try
                {
                    this.DbConnection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cerrar la conexion: {ex}", "Sistema");
                }
            }

            public void conectar()
            {
                if (this.NombreDB.Length == 0)
                {
                    MessageBox.Show("Error nombre de base de datos", "Sistema");
                    return;
                }
                if (this.NombreTabla.Length == 0)
                {
                    MessageBox.Show("Error nombre de tabla", "Sistema");
                    return;
                }
                if (this.CadenaConexion.Length == 0)
                {
                    MessageBox.Show("Error cadena Conexion", "Sistema");
                    return;
                }
                if (this.CadenaSQL.Length == 0)
                {
                    MessageBox.Show("Error cadena SQL", "Sistema");
                    return;
                }
                try
                {
                    this.DbConnection = new SqlConnection(this.CadenaConexion);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error Al Instanciar la Conexion " + ex.Message, "Sistema");
                    return;
                }

                this.abrir();

                if (this.isSelect)
                {
                    this.DbDataSet = new DataSet();
                    try
                    {
                        this.DbDataAdapter = new SqlDataAdapter(this.CadenaSQL, this.DbConnection);
                        this.DbDataAdapter.Fill(this.DbDataSet, this.NombreTabla);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error Al cargar dataset " + ex.Message, "Sistema");
                        return;
                    }
                }
                else
                {
                    try
                    {
                        SqlCommand variableSQL = new SqlCommand(this.CadenaSQL, this.DbConnection);
                        variableSQL.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error Instruccion SQL " + ex.Message, "Sistema");
                        return;
                    }
                }
                this.cerrar();
            }
        }
    }



