using CommunityToolkit.Mvvm.Input;
using System.Configuration;
using System.Diagnostics;
using System.IO;
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
            if (ProtectPassword.Password == "1234")
            {
                viewModel.SharedDataModel.Protect = "Visible";
            }
            else
            {
                viewModel.SharedDataModel.Protect = "Hidden";
            }
        }

        private void DataGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            string path = System.IO.Path.Join(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "People.csv");
            StreamWriter sWriter = new StreamWriter(path);
            foreach (DataGridColumn column in ((DataGrid)sender).Columns)
            {
                sWriter.Write(column.Header);
                if (column.Header != "Email")
                {
                    sWriter.Write(",");
                }
            }
            sWriter.WriteLine();
            foreach (DataGridCellInfo person_detail in e.AddedCells)
            {
                sWriter.Write(((Person)person_detail.Item).Name);
                sWriter.Write(((Person)person_detail.Item).Surname);
                sWriter.Write(((Person)person_detail.Item).Cell);
                sWriter.Write(((Person)person_detail.Item).Email);
                sWriter.WriteLine();
            }
            sWriter.Close();
            MessageBox.Show($"Exported Succesfully to {path}");
        }
    }
}