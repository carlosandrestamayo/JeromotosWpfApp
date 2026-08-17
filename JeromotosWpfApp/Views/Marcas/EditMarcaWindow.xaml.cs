using JeromotosWpfApp.Controllers;
using JeromotosWpfApp.Models;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace JeromotosWpfApp.Views.Marcas
{
    public partial class EditMarcaWindow : Window
    {
        private readonly MarcaController marcaController = new MarcaController();

        private readonly Marca marca;

        public EditMarcaWindow(Marca marca)
        {
            InitializeComponent();

            this.marca = marca;

            LoadMarcaData();

            txtNombre.Focus();
            
            txtNombre.CaretIndex = txtNombre.Text.Length;

            txtNombre.KeyDown += TextBox_KeyDown;
        }

        private void LoadMarcaData()
        {
            txtNombre.Text = marca.Nombre;
            chkActivo.IsChecked = marca.Activo;
        }

        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Marca updatedMarca = new Marca(
                    marca.Id,
                    txtNombre.Text,
                    chkActivo.IsChecked ?? false
                );

                string message = marcaController.Update(
                    updatedMarca,
                    updatedMarca.Id
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
                    "Marca actualizada correctamente.",
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