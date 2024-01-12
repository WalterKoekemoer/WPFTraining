using CommunityToolkit.Mvvm.Input;
using Microsoft.Win32;
using System.Collections.ObjectModel;
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
using System;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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
        private IList<DataGridCellInfo> _selectedcells { get; set; }
        private ObservableCollection<DataGridColumn> _cellheaders { get; set; }
        private bool update = false;

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
            if (sender.GetType() == typeof(DataGrid))
            {
                _cellheaders = ((DataGrid)sender).Columns;
                _selectedcells = ((DataGrid)sender).SelectedCells;
                update = true;
            }

        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (sender.GetType() == typeof(Button))
            {
                if (((Button)sender).Content.ToString() == "Export" && viewModel.SharedDataModel.Protect == "Visible")
                {
                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = "csv file (*.csv)|*.csv|C# file (*.cs)|*.cs\"";
                    saveFileDialog.InitialDirectory = @"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}";
                    try
                    {
                        if (saveFileDialog.ShowDialog() == true && update)
                        {
                            update = false;
                            StreamWriter sWriter = new StreamWriter(saveFileDialog.FileName);
                            foreach (DataGridColumn column in _cellheaders)
                            {
                                sWriter.Write(column.Header);
                                if (column.Header != "Email")
                                {
                                    sWriter.Write(",");
                                }
                            }
                            sWriter.WriteLine();
                            foreach (DataGridCellInfo person_detail in _selectedcells)
                            {
                                Console.WriteLine(((Person)person_detail.Item).Name);
                                sWriter.Write(((Person)person_detail.Item).Name);
                                sWriter.Write(",");
                                sWriter.Write(((Person)person_detail.Item).Surname);
                                sWriter.Write(",");
                                sWriter.Write(((Person)person_detail.Item).Cell);
                                sWriter.Write(",");
                                sWriter.Write(((Person)person_detail.Item).Email);
                                sWriter.WriteLine();
                            }
                            sWriter.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine($"Exception during Export in Button Click: {ex}");
                    }
                }
            }
        }
    }
}