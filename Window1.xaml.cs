using Prestamo.DAL;
using Prestamo.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Prestamo
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        private Estudiante Estudiante = new Estudiante();

        public Window1()
        {
            InitializeComponent();
            this.DataContext = Estudiante;
        }

        private void btnbuscar_Click(object sender, RoutedEventArgs e)
        {

            Contexto contexto = new Contexto();

            var estudiante = contexto.Estudiante.Find(IdTextBox.Text);
            /*var estudiante = EstudiantesBLL.Buscar(Utilidades.ToInt(txbID.Text));*/

            if (Estudiante == null)
                MessageBox.Show("El Estudiante no fue encontrado");
            //this.Estudiante = estudiante;
            else
                MessageBox.Show("El Estudiante no fue encontrado");
            //this.Estudiante = new Estudiantes();
            this.DataContext = this.Estudiante;
        }

        private void btnnuevo_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnguardar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btneliminar_Click(object sender, RoutedEventArgs e)
        {

        }

    }
}