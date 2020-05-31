using Microsoft.EntityFrameworkCore;
using Prestamo.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prestamo.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Entidades.Prestamo> Prestamo{ get; set; }
        public DbSet<Estudiante> Estudiante { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source= DATA\PrestamoCliente.db");
        }
        /*
       
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source = DATA\RegistroEstudiante.db");
        }*/
    }
}
