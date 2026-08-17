using JeromotosWpfApp.Controllers;
using JeromotosWpfApp.Models;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace JeromotosWpfApp.Views.Marcas
{
    public partial class MarcasView : UserControl
    {
        private readonly MarcaController marcaController =
            new MarcaController();

        private List<Marca> marcasList =
            new List<Marca>();

        public MarcasView()
        {
            InitializeComponent();

            LoadMarcas();

            txtSearch.KeyDown += TxtSearch_KeyDown;
        }

        private void LoadMarcas()
        {
            marcasList = marcaController.GetAll();

            tableMarcas.ItemsSource = null;
            
            tableMarcas.ItemsSource = marcasList;
        }

        private void BtnAdd_Click(
            object sender,
            RoutedEventArgs e)
        {
            var addMarcaWindow = new AddMarcaWindow();

            addMarcaWindow.ShowDialog();

            LoadMarcas();
        }

        private void BtnEdit_Click(
            object sender,
            RoutedEventArgs e)
        {
            var marca = (sender as Button)?.DataContext as Marca;

            if (marca != null)
            {
                var editMarcaWindow =
                    new EditMarcaWindow(marca);

                editMarcaWindow.ShowDialog();

                LoadMarcas();
            }
        }

        private void TxtSearch_TextChanged(
            object sender,
            TextChangedEventArgs e)
        {
            string texto = txtSearch.Text.Trim();

            var filtereds = marcasList
                .Where(m => m.Nombre.Contains(
                    texto,
                    StringComparison.OrdinalIgnoreCase))
                .ToList();

            tableMarcas.ItemsSource = null;
            tableMarcas.ItemsSource = filtereds;
        }

        private void TxtSearch_KeyDown(
            object sender,
            KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                txtSearch.Clear();
            }
        }
    }
}