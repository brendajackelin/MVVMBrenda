using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace MVVMBrenda.Models
{
    public class Empleado
    {
        [PrimaryKey, AutoIncrement]
        public int IdEmpleado { get; set; }
        [MaxLength(50)]
        public string Nombre { get; set; }
        [MaxLength(50)]
        public string Apellidos { get; set; }
        [MaxLength(3)]
        public int Edad { get; set; }
        [MaxLength(50)]
        public string Direccion { get; set; }
        [MaxLength(50)]
        public string Puesto { get; set; }
    }
}
