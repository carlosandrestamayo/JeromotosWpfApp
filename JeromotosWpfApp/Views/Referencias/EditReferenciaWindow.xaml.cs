using JeromotosWpfApp.Controllers;
using JeromotosWpfApp.Models;
using JeromotosWpfApp.Models.Enums;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace JeromotosWpfApp.Views.Referencias
{
    public partial class EditReferenciaWindow : Window
    {
        private readonly Referencia referencia;

        private readonly ReferenciaController referenciaController =
            new ReferenciaController();

        private readonly MarcaController marcaController =
            new MarcaController();

        public EditReferenciaWindow(Referencia referencia)
        {
            InitializeComponent();

            this.referencia = referencia;

            LoadMarcas();
            LoadAlimentacion();
            LoadDatos();

            txtNombre.Focus();

            txtNombre.CaretIndex = txtNombre.Text.Length;

            txtNombre.KeyDown += TextBox_KeyDown;
            txtCilindraje.KeyDown += TextBox_KeyDown;
        }

        private void LoadMarcas()
        {
            cmbMarca.ItemsSource = marcaController
                .GetAll()
                .Where(m => m.Activo)
                .OrderBy(m => m.Nombre)
                .ToList();

            cmbMarca.SelectedValue = referencia.MarcaId;
        }

        private void LoadAlimentacion()
        {
            cmbAlimentacion.ItemsSource =
                Enum.GetValues(typeof(TipoAlimentacion));

            cmbAlimentacion.SelectedItem =
                referencia.Alimentacion;
        }

        private void LoadDatos()
        {
            txtNombre.Text = referencia.Nombre;

            txtCilindraje.Text =
                referencia.Cilindraje.ToString();

            chkActivo.IsChecked =
                referencia.Activo;
        }

        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!int.TryParse(
                        txtCilindraje.Text,
                        out int cilindraje))
                {
                    MessageBox.Show(
                        "El cilindraje debe ser un número entero.",
                        "Advertencia",
                        MessageBoxButton.OK,
                        MessageBoxImage.Warning);

                    txtCilindraje.Focus();

                    return;
                }

                if (cmbMarca.SelectedValue == null)
                {
                    MessageBox.Show(
                        "Debe seleccionar una marca.",
                        "Advertencia",
                        MessageBoxButton.OK,
                        MessageBoxImage.Warning);

                    cmbMarca.Focus();

                    return;
                }

                if (cmbAlimentacion.SelectedItem == null)
                {
                    MessageBox.Show(
                        "Debe seleccionar el tipo de alimentación.",
                        "Advertencia",
                        MessageBoxButton.OK,
                        MessageBoxImage.Warning);

                    cmbAlimentacion.Focus();

                    return;
                }

                Referencia updatedReferencia = new Referencia(
                    referencia.Id,
                    (Guid)cmbMarca.SelectedValue,
                    txtNombre.Text,
                    cilindraje,
                    (TipoAlimentacion)cmbAlimentacion.SelectedItem,
                    chkActivo.IsChecked == true
                );

                string message = referenciaController.Update(
                    updatedReferencia,
                    updatedReferencia.Id
                );

                if (!string.IsNullOrEmpty(message))
                {
                    MessageBox.Show(
                        message,
                        "Advertencia",
                        MessageBoxButton.OK,
                        MessageBoxImage.Warning);

                    txtNombre.Focus();

                    return;
                }

                MessageBox.Show(
                    "Referencia actualizada correctamente.",
                    "Éxito",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
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
