using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using System.Windows.Controls;
using Prestamo.Entidades;
using Prestamo.DAL;

namespace Prestamo.BLL
{
    public class EstudiantesBLL
    {
        ///<sumary>
        ///</sumary>
        ///<param name="estudiante"></param>
        public static bool Guardar(Estudiante estudiante)
        {
            if (!Existe(estudiante.Id))
                return Insertar(estudiante);
            else
                return Modificar(estudiante);
        }

        ///<sumary>
        ///</sumary>
        ///<param name="estudiante"></param>
        private static bool Insertar(Estudiante estudiante)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                contexto.Estudiante.Add(estudiante);
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }

        ///<sumary>
        ///</sumary>
        ///<param name="estudiante"></param>
        public static bool Modificar(Estudiante estudiante)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Entry(estudiante).State = EntityState.Modified;
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }

        ///<sumary>
        ///</sumary>
        ///<param name="id"></param>
        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                var estudiante = contexto.Estudiante.Find(id);
                if (estudiante != null)
                {
                    contexto.Estudiante.Remove(estudiante);
                    paso = contexto.SaveChanges() > 0;
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
            return paso;
        }

        ///<sumary>
        ///</sumary>
        ///<param name="id"></param>
        public static Estudiante Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Estudiante estudiante;
            try
            {
                estudiante = contexto.Estudiante.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return estudiante;
        }

        ///<sumary>
        ///</sumary>
        ///<param name="criterio"></param>
        ///<returns></returns>
        public static List<Estudiante> GetList(Expression<Func<Estudiante, bool>> criterio)
        {
            List<Estudiante> Lista = new List<Estudiante>();
            Contexto contexto = new Contexto();

            try
            {
                Lista = contexto.Estudiante.Where(criterio).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return Lista;
        }

        ///<sumary>
        ///</sumary>
        ///<param name="id"></param>
        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = contexto.Estudiante
                    .Any(e => e.Id == id);
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
    }
}

