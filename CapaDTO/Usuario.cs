using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDTO
{
    public class Usuario
    {
        private int id;
        private String nombre;
        private String contraseña;
        private String rut;
        private int cargo;

        public string Nombre { get => nombre; set => nombre = value; }
        public string Contraseña { get => contraseña; set => contraseña = value; }
        public int Cargo { get => cargo; set => cargo = value; }
        public int Id { get => id; set => id = value; }
        public string Rut { get => rut; set => rut = value; }
    }
}
