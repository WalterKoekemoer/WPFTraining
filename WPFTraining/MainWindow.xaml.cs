using CommunityToolkit.Mvvm.Input;
using System.Configuration;
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
using WPFTraining.Models;
using WPFTraining.ViewModels;

namespace WPFTraining
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        MainViewModel viewModel { get; set; } = new MainViewModel();
        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (ProtectPassword.Password == "1234"){
                viewModel.SharedDataModel.Protect = "Visible"; 
            } 
            else {
                viewModel.SharedDataModel.Protect = "Hidden"; 
            }
        }
    }
}