using Prestamo.BLL;
using Prestamo.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Prestamo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Entidades.Prestamo cliente = new Entidades.Prestamo();
        public MainWindow()
        {
            InitializeComponent();

            this.DataContext = cliente;
        }

        private void Limpiar()
        {
            this.cliente = new Entidades.Prestamo();
            this.DataContext = cliente;
        }

        private bool Validacion()
        {
            bool valido = true;

            if (Prestamoid.Text.Length == 0 || PersonalIdTextBox.Text.Length == 0 ||
                ConceptoTextBox.Text.Length == 0 || MontoTextBox.Text.Length == 0 || BalanceTextBox.Text.Length == 0 || fechaNDatePicker.Text.Length == 0)
            {
                valido = false;
                MessageBox.Show("Debe llenar todos los campos.", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else if (PersonalIdTextBox.Text.Length == 0 || PersonalIdTextBox.Text.Length < 2)
            {
                valido = false;
                MessageBox.Show("Ingrese un Nombre valido.", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            return valido;
        }

        private void buscarButton_Click(object sender, RoutedEventArgs e)
        {
            var cliente = ClienteBLL.Buscar(int.Parse(Prestamoid.Text));

            if (cliente != null)
            {
                this.cliente = cliente;
            }
            else
            {
                this.cliente = new Entidades.Prestamo();
            }

            this.DataContext = this.cliente;

        }

        private void guardarbotton_Click(object sender, RoutedEventArgs e)
        {
            if (!Validacion())
            {
                return;
            }

            var key = ClienteBLL.Guardar(cliente);

            if (key)
            {
                Limpiar();
                MessageBox.Show("Se Guardo con Exitosamente ", "Excelente!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("ERROR.", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void editarbotton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void eliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (ClienteBLL.Eliminar(int.Parse(Prestamoid.Text)))
            {
                Limpiar();
                MessageBox.Show("Se a Eliminado." + Prestamoid , "Exitosamente!",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("No se pudo eliminar el registro" + Prestamoid, "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

    }
}
