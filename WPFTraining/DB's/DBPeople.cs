using Microsoft.EntityFrameworkCore;
using WPFTraining.Models;

namespace WPFTraining.DB_s
{
    public class DBPeople : DbContext
    {

        public DBPeople()
        {
            DbPath = System.IO.Path.Join(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "DBPeople.db");
        }

        public DbSet<Person> People { get; set; }
        public string DbPath { get; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source={DbPath}");

            return;
        }
    }
}

//dotnet ef --project WPFTraining migrations add InitialCreate  WAS USED FOR CREATING THE DB WHILE PEOPLE AND PERSON CLASS HAD TO BE IN ORDER
// this includes [Table("People")]