using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WPFTraining.Models
{
    [Table("People")]
    public class Person : ObservableObject
    {
        public Person()
        {

        }


        private string _name;
        private string _surname;
        private string _cell;
        private string _email;

        public Person(Person person)
        {
            Name = person.Name;
            Surname = person.Surname;
            Cell = person.Cell;
            Email = person.Email;
        }

        public string Name { get { return _name; } set { _name = value; OnPropertyChanged(); } }
        public string Surname { get { return _surname; } set { _surname = value; OnPropertyChanged(); } }
        [Key]
        public string Cell { get { return _cell; } set { _cell = value; OnPropertyChanged(); } }
        public string Email { get { return _email; } set { _email = value; OnPropertyChanged(); } }
    }
}
