using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Prestamo.Entidades
{
    public class Estudiantes
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Telefono { get; set; }
        public int Cedula { get; set; }
        public string Direccion { get; set; }
        public DateTime FechaNacimiento { get; set; } = DateTime.Now;

        /*[ForeignKey("Id")]
        public virtual Estudiantes Id { get; set; }*/
    }
}
