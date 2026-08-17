using JeromotosWpfApp.Controllers;
using JeromotosWpfApp.Models;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace JeromotosWpfApp.Views.Clientes
{
    public partial class EditClienteWindow : Window
    {
        private readonly ClienteController clienteController = new ClienteController();

        private readonly Persona persona;

        public EditClienteWindow(Persona persona)
        {
            InitializeComponent();

            this.persona = persona;

            LoadPersonaData();

            txtNombre.Focus();
            txtNombre.CaretIndex = txtNombre.Text.Length;
        }

        private void LoadPersonaData()
        {
            txtNombre.Text = persona.Nombre;
            txtDocumento.Text = persona.Documento;
            txtTelefono.Text = persona.Telefono;
            txtEmail.Text = persona.Email;
            txtDireccion.Text = persona.Direccion;
            chkActivo.IsChecked = persona.Activo;
        }

        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Persona updatedPersona = new Persona(
                    persona.Id,
                    txtNombre.Text,
                    txtDocumento.Text,
                    txtTelefono.Text,
                    txtEmail.Text,
                    txtDireccion.Text,
                    chkActivo.IsChecked ?? false
                );

                string message = clienteController.Update(
                    updatedPersona,
                    updatedPersona.Id
                );

                if (!string.IsNullOrEmpty(message))
                {
                    MessageBox.Show(
                        message,
                        "Advertencia",
                        MessageBoxButton.OK,
                        MessageBoxImage.Warning
                    );

                    txtNombre.Focus();
                    txtNombre.CaretIndex = txtNombre.Text.Length;

                    return;
                }

                MessageBox.Show(
                    "Cliente actualizado correctamente.",
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