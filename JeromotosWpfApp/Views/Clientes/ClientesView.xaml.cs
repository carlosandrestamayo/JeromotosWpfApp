using JeromotosWpfApp.Controllers;
using JeromotosWpfApp.Models;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace JeromotosWpfApp.Views.Clientes
{
    public partial class ClientesView : UserControl
    {
        private readonly ClienteController clienteController = new ClienteController();

        private List<Persona> clientesList = new List<Persona>();

        public ClientesView()
        {
            InitializeComponent();

            LoadClientes();

            txtSearch.KeyDown += TxtSearch_KeyDown;
        }

        private void LoadClientes()
        {
            clientesList = clienteController.GetAll();

            tableClientes.ItemsSource = null;
            tableClientes.ItemsSource = clientesList;
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            var addClienteWindow = new AddClienteWindow();

            addClienteWindow.ShowDialog();

            LoadClientes();
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            var persona = (sender as Button).DataContext as Persona;

            if (persona != null)
            {
                var editClienteWindow = new EditClienteWindow(persona);

                editClienteWindow.ShowDialog();

                LoadClientes();
            }
        }

        private void TxtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            string texto = txtSearch.Text.Trim();

            var filtered = clientesList
                .Where(p =>
                    p.Nombre.Contains(texto, StringComparison.OrdinalIgnoreCase) ||
                    p.Documento.Contains(texto, StringComparison.OrdinalIgnoreCase) ||
                    p.Telefono.Contains(texto, StringComparison.OrdinalIgnoreCase))
                .ToList();

            tableClientes.ItemsSource = null;
            tableClientes.ItemsSource = filtered;
        }

        private void TxtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                txtSearch.Clear();

                tableClientes.ItemsSource = null;
                tableClientes.ItemsSource = clientesList;
            }
        }
    }
}