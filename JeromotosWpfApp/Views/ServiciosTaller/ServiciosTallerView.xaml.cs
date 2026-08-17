using JeromotosWpfApp.Controllers;
using JeromotosWpfApp.Models;
using JeromotosWpfApp.Views.Marcas;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace JeromotosWpfApp.Views.ServiciosTaller
{
    /// <summary>
    /// Lógica de interacción para ServiciosTallerView.xaml
    /// </summary>
    public partial class ServiciosTallerView : UserControl
    {
        private readonly ServicioTallerController servicioTallerController = 
            new ServicioTallerController();

        private List<ServicioTaller> serviciosTallerList = new List<ServicioTaller>();

        
        public ServiciosTallerView()
        {
            InitializeComponent();

            LoadServiciosTaller();

            txtSearch.KeyDown += TxtSearch_KeyDown;
        }

        private void LoadServiciosTaller()
        {
            serviciosTallerList = servicioTallerController.GetAll();

            tableServiciosTaller.ItemsSource = null;

            tableServiciosTaller.ItemsSource = serviciosTallerList;
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            var addServicioTallerWindow = new AddServicioTallerWindow();

            addServicioTallerWindow.ShowDialog();

            LoadServiciosTaller();
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            var servicioTaller = (sender as Button).DataContext as ServicioTaller;

            if (servicioTaller != null)
            {
                var editServicioTallerWindow = new EditServicioTallerWindow(servicioTaller);

                editServicioTallerWindow.ShowDialog();

                LoadServiciosTaller();
            }
        }

        private void TxtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            string texto = txtSearch.Text.Trim();

            var filtereds = serviciosTallerList
                .Where(s =>
                    s.Nombre.Contains(
                        texto,
                        StringComparison.OrdinalIgnoreCase) ||
                    s.Descripcion.Contains(
                        texto,
                        StringComparison.OrdinalIgnoreCase))
                .ToList();

            tableServiciosTaller.ItemsSource = null;
            tableServiciosTaller.ItemsSource = filtereds;
        }

        private void TxtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                txtSearch.Clear();

            }
        }

    }
}
