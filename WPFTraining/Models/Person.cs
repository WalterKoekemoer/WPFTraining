using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFTraining.Models
{
    public class Person : ObservableObject
    {   
        public Person() { 
            
        }

        public string _name;
        public string _surname;
        public string _cell;
        public string _email;

        public Person(Person person)
        {
            _name = person.Name;
            _surname = person.Surname;
            _cell = person.Cell;
            _email = person.Email;
        }

        public string Name { get { return _name; } set { _name = value; OnPropertyChanged(); } }
        public string Surname { get { return _surname; } set { _surname = value; OnPropertyChanged(); } }
        public string Cell { get { return _cell; } set { _cell = value; OnPropertyChanged(); } }
        public string Email { get { return _email; } set { _email = value; OnPropertyChanged(); } }

    }
}
