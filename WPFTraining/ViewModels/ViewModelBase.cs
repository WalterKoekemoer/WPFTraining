using WPFTraining.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using WPFTraining.DB_s;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace WPFTraining.ViewModels
{
    public class ViewModelBase : ObservableObject
    {
        public ViewModelBase()
        {
            SharedDataModel = SharedDataModel.Instance;
            PeopleDB = new DBPeople();
            try
            {
                PeopleDB.Database.Migrate();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Tried to migrate: {ex}");
            }
        }

        #region Public properties
        public SharedDataModel SharedDataModel { get; set; }

        public DBPeople PeopleDB { get; set; }
        #endregion
    }
}
