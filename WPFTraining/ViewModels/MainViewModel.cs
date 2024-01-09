using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WPFTraining.Models;

namespace WPFTraining.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {

        public Person _personToAdd = new Person();

        public string _personToFind;

        public string _password;
        public string _protect;
        public List<Person> People { get; set; } = new List<Person>();

        public List<Person> _peopleFound { get; set; } = new List<Person>();

        public Person PersonToAdd { get { return _personToAdd; } set { _personToAdd = value; OnPropertyChanged(); } }

        public string Protect { get { return _protect; } set { _protect = value; } }
        public string Password { get { 
                if (_password == "12345678" && _password.Length < 7) {
                    Protect = "Visible";
                    return _password; 
                } else {
                    return "Password"; 
                } 
            } set {
                _password = value; OnPropertyChanged(); 
            } 
        }

        public List<Person> PeopleFound
        {
            get
            { 

                if (PersonToFind != null)
                {
                    return People.Where(x => ($"{x.Name}" +  " " + $"{x.Surname}").Contains(PersonToFind)).ToList(); 
                }
                else
                {
                    return People;
                }
            }
            set
            { 
                _peopleFound = value; 
            } 
        }
        public string PersonToFind { get {

                return _personToFind;
            }
            set
            {
                _personToFind = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(PeopleFound));
            }
        }
        public MainViewModel()
        {
            People.Add(new Person { Name = "Ryno", Surname = "Donno", Cell = "072 Donno", Email = "Ryno@Donno.com" });
            People.Add(new Person { Name = "Walter", Surname = "Donno", Cell = "072 Donno", Email = "Walter@Donno.com" });
            People.Add(new Person { Name = "Adriaan", Surname = "Donno", Cell = "072 Donno", Email = "Adriaan@Donno.com" });
            People.Add(new Person { Name = "Steyn", Surname = "Donno", Cell = "072 Donno", Email = "Steyn@Donno.com" });

        }

        [RelayCommand]  
        private void Save()
        {
            People.Add(new Person(PersonToAdd));

            // This updates the grid
            PersonToFind = "X";
            PersonToFind = "";
        }
    }
}
