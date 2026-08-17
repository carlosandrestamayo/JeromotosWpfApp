using JeromotosWpfApp.Controllers;
using JeromotosWpfApp.Models;
using JeromotosWpfApp.ViewModels;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace JeromotosWpfApp.Views.Referencias
{
    public partial class ReferenciasView : UserControl
    {
        private ReferenciaController referenciaController = new ReferenciaController();
        private MarcaController marcaController = new MarcaController();

        private List<Referencia> referenciasList = new List<Referencia>();
        private List<ReferenciaItemViewModel> referenciasViewList = new List<ReferenciaItemViewModel>();

        public ReferenciasView()
        {
            InitializeComponent();

            LoadReferencias();

            txtSearch.KeyDown += TxtSearch_KeyDown;
        }

        private void LoadReferencias()
        {
            referenciasList = referenciaController.GetAll();

            referenciasViewList = referenciasList
                .Select(r => new ReferenciaItemViewModel
                {
                    Id = r.Id,
                    MarcaId = r.MarcaId,
                    MarcaNombre = marcaController.Find(r.MarcaId)?.Nombre ?? "Sin marca",
                    Nombre = r.Nombre,
                    Cilindraje = r.Cilindraje,
                    Alimentacion = r.Alimentacion,
                    Activo = r.Activo
                })
                .ToList();

            tableReferencias.ItemsSource = null;
            tableReferencias.ItemsSource = referenciasViewList;
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            var addReferenciaWindow = new AddReferenciaWindow();

            addReferenciaWindow.ShowDialog();

            LoadReferencias();
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            var item = (sender as Button)?.DataContext as ReferenciaItemViewModel;

            if (item != null)
            {
                var referencia = referenciaController.Find(item.Id);

                if (referencia != null)
                {
                    //var editReferenciaWindow = new EditReferenciaWindow(referencia);

                    //editReferenciaWindow.ShowDialog();

                    LoadReferencias();
                }
            }
        }

        private void TxtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            string texto = txtSearch.Text.Trim();

            var filtered = referenciasViewList
                .Where(r =>
                    r.Nombre.Contains(texto, StringComparison.OrdinalIgnoreCase) ||
                    r.MarcaNombre.Contains(texto, StringComparison.OrdinalIgnoreCase))
                .ToList();

            tableReferencias.ItemsSource = null;
            tableReferencias.ItemsSource = filtered;
        }

        private void TxtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                txtSearch.Clear();

                tableReferencias.ItemsSource = null;
                tableReferencias.ItemsSource = referenciasViewList;
            }
        }
    }
}