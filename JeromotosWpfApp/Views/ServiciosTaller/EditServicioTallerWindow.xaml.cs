using JeromotosWpfApp.Controllers;
using JeromotosWpfApp.Models;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace JeromotosWpfApp.Views.ServiciosTaller
{
    /// <summary>
    /// Lógica de interacción para EditServicioTallerWindow.xaml
    /// </summary>
    public partial class EditServicioTallerWindow : Window
    {
        private readonly ServicioTallerController servicioTallerController = new ServicioTallerController();

        private readonly ServicioTaller servicioTaller;
        public EditServicioTallerWindow(ServicioTaller servicioTaller )
        {
            InitializeComponent();

            this.servicioTaller = servicioTaller;

            LoadServicioTallerData();

            txtNombre.Focus();

            txtNombre.CaretIndex = txtNombre.Text.Length;

            txtNombre.KeyDown += TextBox_KeyDown;
        }

        private void LoadServicioTallerData()
        {
            txtNombre.Text = servicioTaller.Nombre;

            txtDescripcion.Text = servicioTaller.Descripcion;

            chkActivo.IsChecked = servicioTaller.Activo;

            chkMedible.IsChecked = servicioTaller.IsMedible;

        }

        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ServicioTaller updatedServicio = new ServicioTaller(
                    servicioTaller.Id,
                    txtNombre.Text,
                    txtDescripcion.Text,
                    chkMedible.IsChecked ?? false,
                    chkActivo.IsChecked ?? false
                );

                string message = servicioTallerController.Update(
                    updatedServicio,
                    updatedServicio.Id
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

                    return;
                }

                MessageBox.Show(
                    "Servicio actualizado correctamente.",
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
