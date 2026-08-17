using JeromotosWpfApp.Controllers;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace JeromotosWpfApp.Views
{
    /// <summary>
    /// Lógica de interacción para DashBoardView.xaml
    /// </summary>
    public partial class DashBoardView : UserControl
    {
        private readonly ClienteController clienteController = new ClienteController();
        private readonly MarcaController marcaController = new MarcaController();
        private readonly ServicioTallerController servicioTallerController = new ServicioTallerController();
        public DashBoardView()
        {
            InitializeComponent();

            LoadDashboard();
        }

        private void LoadDashboard()
        {
            int totalClientes = clienteController.GetAll().Count;
            int totalMarcas = marcaController.GetAll().Count;
            int totalServicios = servicioTallerController.GetAll().Count;

            txtTotalClientes.Text = totalClientes.ToString();
            txtTotalMarcas.Text = totalMarcas.ToString();
            txtTotalServicios.Text = totalServicios.ToString();

            txtResumenClientes.Text = totalClientes.ToString();
            txtResumenMarcas.Text = totalMarcas.ToString();
            txtResumenServicios.Text = totalServicios.ToString();
        }
    }
}
