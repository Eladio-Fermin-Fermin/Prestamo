using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Prestamo.DAL;
using Prestamo.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Windows.Media.Animation;
using EntityState = Microsoft.EntityFrameworkCore.EntityState;

namespace Prestamo.BLL
{
    public class PrestamoBLL
    {
        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = contexto.Prestamo.Any(e => e.Prestamoid == id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return encontrado;
        }

        private static bool Insertar(Entidades.Prestamo cliente)
        {
            bool key = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Prestamo.Add(cliente);
                key = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return key;
        }

        private static bool Modificar(Entidades.Prestamo cliente)
        {
            bool key = false;
            Contexto contexto = new Contexto();

            try
            {

                contexto.Entry(cliente).State = EntityState.Modified;
                key = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return key;
        }

        public static bool Guardar(Entidades.Prestamo cliente)
        {
            if (!Existe(cliente.Prestamoid))
            {
                return Insertar(cliente);
            }
            else
            {
                return Modificar(cliente);
            }
        }

        public static bool Eliminar(int id)
        {
            bool key = false;
            Contexto contexto = new Contexto();

            try
            {

                var cliente = contexto.Prestamo.Find(id);

                if (cliente != null)
                {
                    contexto.Prestamo.Remove(cliente);
                    key = contexto.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return key;
        }

        public static Entidades.Prestamo Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Entidades.Prestamo cliente;

            try
            {
                cliente = contexto.Prestamo.Find(id);

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return cliente;
        }

        public static List<Entidades.Prestamo> GetList(Expression<Func<Entidades.Prestamo, bool>> criterio)
        {
            List<Entidades.Prestamo> lista = new List<Entidades.Prestamo>();
            Contexto contexto = new Contexto();

            try
            {
                lista = contexto.Prestamo.Where(criterio).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return lista;
        }
    }
}
