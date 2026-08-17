using JeromotosWpfApp.Controllers;
using JeromotosWpfApp.Models;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace JeromotosWpfApp.Views.Marcas
{
    /// <summary>
    /// Lógica de interacción para AddMarcaWindow.xaml
    /// </summary>
    public partial class AddMarcaWindow : Window
    {
       
        MarcaController marcaController = new MarcaController();
        public AddMarcaWindow()
        {
            InitializeComponent();
            txtNombre.Focus();

            txtNombre.KeyDown += TextBox_KeyDown;
         }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Marca marca = new Marca(
                    Guid.NewGuid(),
                    txtNombre.Text
                );

                string message = marcaController.Add(marca);

                if (!string.IsNullOrEmpty(message))
                {
                    MessageBox.Show(
                        message,
                        "Advertencia",
                        MessageBoxButton.OK,
                        MessageBoxImage.Warning
                    );

                    txtNombre.Focus();

                    return;
                }

                MessageBox.Show(
                    "Marca guardada correctamente.",
                    "Éxito",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information
                );

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error
                );
            }
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                TextBox textBox = sender as TextBox;

                if (textBox != null)
                {
                    textBox.Clear();
                }
            }
        }

     }
}
