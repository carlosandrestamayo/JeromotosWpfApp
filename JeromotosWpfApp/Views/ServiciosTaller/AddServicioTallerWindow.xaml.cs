using JeromotosWpfApp.Controllers;
using JeromotosWpfApp.Models;
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

namespace JeromotosWpfApp.Views.ServiciosTaller
{
    /// <summary>
    /// Lógica de interacción para AddServicioTallerWindow.xaml
    /// </summary>
    public partial class AddServicioTallerWindow : Window
    {

        ServicioTallerController servicioTallerController = new ServicioTallerController();
        public AddServicioTallerWindow()
        {
            InitializeComponent();
            txtNombre.Focus();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ServicioTaller servicioTaller = new ServicioTaller(
                    Guid.NewGuid(),
                    txtNombre.Text,
                    txtDescripcion.Text,
                    chkMedible.IsChecked ?? false
                );

                string message = servicioTallerController.Add(servicioTaller);

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
                    "Servicio guardado correctamente.",
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
