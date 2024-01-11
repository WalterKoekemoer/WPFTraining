using WPFTraining.ViewModels;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WPFTraining.Models;
using WPFTraining.DB_s;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace WPFTraining.ViewModels
{
    public partial class MainViewModel : ViewModelBase
    {

        private Person _personToAdd = new Person();
        private string _personToFind;
        private List<Person> _peopleFound { get; set; } = new List<Person>();

        public List<Person> AllPeople { get; set; } = new List<Person>();

        public Person PersonToAdd { get { return _personToAdd; } set { _personToAdd = value; OnPropertyChanged(); } }

        public List<Person> PeopleFound
        {
            get
            {

                if (PersonToFind != null)
                {
                    return AllPeople.Where(x => ($"{x.Name}" + " " + $"{x.Surname}").Contains(PersonToFind)).ToList();
                }
                else
                {
                    return AllPeople.ToList();
                }
            }
            set
            {
                _peopleFound = value;
            }
        }
        public string PersonToFind
        {
            get
            {

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
            //AllPeople.Add(new Person { Name = "Ryno", Surname = "Donno", Cell = "072 Donno", Email = "Ryno@Donno.com" });
            //AllPeople.Add(new Person { Name = "Walter", Surname = "Donno", Cell = "072 Donno", Email = "Walter@Donno.com" });
            //AllPeople.Add(new Person { Name = "Adriaan", Surname = "Donno", Cell = "072 Donno", Email = "Adriaan@Donno.com" });
            //AllPeople.Add(new Person { Name = "Steyn", Surname = "Donno", Cell = "072 Donno", Email = "Steyn@Donno.com" });
            using (DBPeople dBContext = new DBPeople())
            {
                try
                {
                    dBContext.People.ToList().ForEach(x => AllPeople.Add(x));
                }
                catch (Exception ex) { }
            }
        }

        [RelayCommand]
        private void Save()
        {
            if (PersonToAdd.Cell != null)
            {
                AllPeople.Add(PersonToAdd);
                try
                {
                    using (DBPeople dBContext = new DBPeople())
                    {
                        _ = dBContext.Add(PersonToAdd);
                        _ = dBContext.SaveChanges();
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Exception during Save: {ex}");
                }
                // This updates the grid
                PersonToFind = "X";
                PersonToFind = "";
            }

        }
    }
}
