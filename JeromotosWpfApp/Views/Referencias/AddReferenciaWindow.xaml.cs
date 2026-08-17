using JeromotosWpfApp.Controllers;
using JeromotosWpfApp.Models;
using JeromotosWpfApp.Models.Enums;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace JeromotosWpfApp.Views.Referencias
{
    public partial class AddReferenciaWindow : Window
    {
        private ReferenciaController referenciaController = new ReferenciaController();
        private MarcaController marcaController = new MarcaController();

        public AddReferenciaWindow()
        {
            InitializeComponent();

            LoadMarcas();
            LoadAlimentacion();

            txtNombre.Focus();

            //txtNombre.CaretIndex = txtNombre.Text.Length;

            txtNombre.KeyDown += TextBox_KeyDown;

            txtCilindraje.KeyDown += TextBox_KeyDown;
        }

        private void LoadMarcas()
        {
            cmbMarca.ItemsSource = marcaController.GetAll()
                .Where(m => m.Activo)
                .ToList();
        }

        private void LoadAlimentacion()
        {
            cmbAlimentacion.ItemsSource = Enum.GetValues<TipoAlimentacion>();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (cmbMarca.SelectedValue == null)
                {
                    MessageBox.Show(
                        "Debe seleccionar una marca.",
                        "Advertencia",
                        MessageBoxButton.OK,
                        MessageBoxImage.Warning
                    );

                    cmbMarca.Focus();

                    return;
                }

                if (cmbAlimentacion.SelectedItem == null)
                {
                    MessageBox.Show(
                        "Debe seleccionar el tipo de alimentación.",
                        "Advertencia",
                        MessageBoxButton.OK,
                        MessageBoxImage.Warning
                    );

                    cmbAlimentacion.Focus();

                    return;
                }

                if (!int.TryParse(txtCilindraje.Text, out int cilindraje))
                {
                    MessageBox.Show(
                        "El cilindraje debe ser un número válido.",
                        "Advertencia",
                        MessageBoxButton.OK,
                        MessageBoxImage.Warning
                    );

                    txtCilindraje.Focus();

                    return;
                }

                Referencia referencia = new Referencia(
                    Guid.NewGuid(),
                    (Guid)cmbMarca.SelectedValue,
                    txtNombre.Text,
                    cilindraje,
                    (TipoAlimentacion)cmbAlimentacion.SelectedItem
                );

                string message = referenciaController.Add(referencia);

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
                    "Referencia guardada correctamente.",
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