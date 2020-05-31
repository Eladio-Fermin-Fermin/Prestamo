using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Prestamo.Entidades
{
    public class Prestamo
    {
        [Key]
        public int Prestamoid { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
        public int Personaid { get; set; }
        public int Concepto { get; set; }
        public double Monto { get; set; }
        public double Balance { get; set; }
    }
}
