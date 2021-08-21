using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Examen3PMO2.Models
{
   public class Personas
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        [MaxLength(200)]
        public int pago { get; set; }
        [MaxLength(200)]
        public string descripcion { get; set; }
        public double monto { get; set; }
        [MaxLength(100)]

        public string fecha { get; set; }

    }
}
