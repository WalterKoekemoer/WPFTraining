using WPFTraining.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using WPFTraining.DB_s;

namespace WPFTraining.ViewModels
{
    public class ViewModelBase : ObservableObject
    {
        public ViewModelBase()
        {
            SharedDataModel = SharedDataModel.Instance;
            PeopleDB = new DBPeople();
        }

        #region Public properties
        public SharedDataModel SharedDataModel { get; set; }

        public DBPeople PeopleDB { get; set; }
        #endregion
    }
}
