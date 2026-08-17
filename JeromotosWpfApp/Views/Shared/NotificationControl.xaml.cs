using System.Windows;
using System.Windows.Controls;

namespace JeromotosWpfApp.Views.Shared
{
    public partial class NotificationControl : UserControl
    {
        public NotificationControl()
        {
            InitializeComponent();
        }

        public void ShowSuccess(string message)
        {
            ShowNotification(
                "Éxito",
                message,
                "✓");
        }

        public void ShowError(string message)
        {
            ShowNotification(
                "Error",
                message,
                "✕");
        }

        public void ShowWarning(string message)
        {
            ShowNotification(
                "Advertencia",
                message,
                "⚠");
        }

        public void ShowInfo(string message)
        {
            ShowNotification(
                "Información",
                message,
                "ℹ");
        }

        private void ShowNotification(
            string title,
            string message,
            string icon)
        {
            txtTitle.Text = title;
            txtMessage.Text = message;
            txtIcon.Text = icon;

            Visibility = Visibility.Visible;
        }

        private void BtnClose_Click(
            object sender,
            RoutedEventArgs e)
        {
            Visibility = Visibility.Collapsed;
        }
    }
}