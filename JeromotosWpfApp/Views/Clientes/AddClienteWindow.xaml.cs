using JeromotosWpfApp.Controllers;
using JeromotosWpfApp.Models;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace JeromotosWpfApp.Views.Clientes
{
    public partial class AddClienteWindow : Window
    {
        private readonly ClienteController clienteController = new ClienteController();

        public AddClienteWindow()
        {
            InitializeComponent();

            txtNombre.Focus();

            txtNombre.KeyDown += TextBox_KeyDown;

            txtDocumento.KeyDown += TextBox_KeyDown;

            txtTelefono.KeyDown += TextBox_KeyDown;

            txtEmail.KeyDown += TextBox_KeyDown;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Persona persona = new Persona(
                    Guid.NewGuid(),
                    txtNombre.Text,
                    txtDocumento.Text,
                    txtTelefono.Text,
                    txtEmail.Text,
                    txtDireccion.Text
                );

                string message = clienteController.Add(persona);

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
                    "Cliente guardado correctamente.",
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