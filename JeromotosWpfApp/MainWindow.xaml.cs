using JeromotosWpfApp.Persistence;
using JeromotosWpfApp.Repositories;
using JeromotosWpfApp.Views;
using JeromotosWpfApp.Views.Clientes;
using JeromotosWpfApp.Views.Marcas;
using JeromotosWpfApp.Views.Referencias;
using JeromotosWpfApp.Views.ServiciosTaller;
using JeromotosWpfApp.Views.Shared;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace JeromotosWpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        NotificationControl notificationControl = new NotificationControl();
        
        public MainWindow()
        {
            InitializeComponent();

            Contenedor.Content = new DashBoardView();

            //using var db = new JeromotosDbContext();

            //db.Database.EnsureCreated();

            //LoadUserInfo();

            //ApplyPermissions();

        }

        private void BtnDashboard_Click(object sender, RoutedEventArgs e)
        {
            ActivateMenuButton(btnDashboard);
            Contenedor.Content = new DashBoardView();
            //notificationControl.ShowSuccess("Hello World!");
            //Notification.ShowSuccess(
            //    "La aplicación inició correctamente.");
        }

        private void BtnClientes_Click(object sender, RoutedEventArgs e)
        {
            ActivateMenuButton(btnClientes);
            Contenedor.Content = new ClientesView();
        }

        private void BtnMarcas_Click(object sender, RoutedEventArgs e)
        {
            ActivateMenuButton(btnMarcas);
            Contenedor.Content = new MarcasView();
            
            //var marcaRepository = new MarcaRepository();
            //marcaRepository.GetAll();
        }

        private void BtnServiciosTaller_Click(object sender, RoutedEventArgs e)
        {
            ActivateMenuButton(btnServiciosTaller);
            Contenedor.Content = new ServiciosTallerView();

            //var servicioTallerRepository = new ServicioTallerRepository();
            //servicioTallerRepository.GetAll();
        }

        private void BtnReferencias_Click(object sender, RoutedEventArgs e)
        {
            ActivateMenuButton(btnReferencias);
            Contenedor.Content = new ReferenciasView();
        }

        private void BtnMantenimientos_Click(object sender, RoutedEventArgs e)
        {
            ActivateMenuButton(btnMantenimientos);
            //Contenedor.Content = new MantenimientosView();
        }

        private void BtnUsuarios_Click(object sender, RoutedEventArgs e)
        {
            //ActivateMenuButton(btnUsuarios);
            //Contenedor.Content = new UsuariosView();
        }

        private void BtnChangePassword_Click(object sender, RoutedEventArgs e)
        {
            //ActivateMenuButton(btnChangePassword);
            //ChangeMyPasswordWindow changeMyPasswordWindow = new ChangeMyPasswordWindow();
            //changeMyPasswordWindow.ShowDialog();
        }

        private void BtnLogout_Click(object sender, RoutedEventArgs e)
        {
            //SessionManager.CurrentUser = null;

            //LoginWindow loginWindow = new LoginWindow();

            //loginWindow.Show();

            //Close();
        }

        private void LoadUserInfo()
        {
            //Usuario? usuario = SessionManager.CurrentUser;

            //if (usuario == null)
            //{
            //    return;
            //}

            //txtUserName.Text = usuario.Nombre;

            //txtUserRole.Text = usuario.Rol.ToString();
        }

        private void ApplyPermissions()
        {
            //Usuario? usuario = SessionManager.CurrentUser;

            //if (usuario == null)
            //{
            //    return;
            //}

            //if (usuario.Rol != RolUsuario.Administrador)
            //{
            //    btnUsuarios.Visibility = Visibility.Collapsed;
            //}

            //if (usuario.Rol != RolUsuario.Operador)
            //{
            //    btnChangePassword.Visibility = Visibility.Collapsed;
            //}
        }

        private void ActivateMenuButton(Button activeButton)
        {
            Brush sidebarColor = (Brush)Application.Current.Resources["SidebarBackground"];

            Brush primaryColor = (Brush)Application.Current.Resources["PrimaryColor"];

            //foreach (var control in LogicalTreeHelper.GetChildren(this))
            //{
            //    // No sirve para recorrer profundamente
            //}

            Button[] buttons =
            {
               btnDashboard,
               btnMarcas,
               btnServiciosTaller,
               btnClientes,
               btnReferencias,
               btnMantenimientos
            };


            //Button[] buttons =
            //{
            //    btnDashboard,
            //   
            //    btnMateriales,
            //    btnCotizaciones,
            //    btnReferencias,
            //    btnUsuarios,
            //    btnChangePassword
            //};

            foreach (Button button in buttons)
            {
                button.Background = sidebarColor;
            }

            activeButton.Background = primaryColor;
        }
    }
}
