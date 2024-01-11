using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using System.Diagnostics;
namespace WPFTraining.Models
{
    public partial class SharedDataModel : ObservableObject
    {
        private static readonly object _lock = new();
        private static SharedDataModel _instance;


        private string _protect = "Hidden";

        public string Protect { get { return _protect; } set { _protect = value; OnPropertyChanged(); } }

        public static SharedDataModel Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        _instance ??= new SharedDataModel();
                    }
                }
                return _instance;
            }
        }
    }
}
