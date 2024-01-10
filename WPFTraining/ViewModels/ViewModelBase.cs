using WPFTraining.Models;
using CommunityToolkit.Mvvm.ComponentModel;

namespace WPFTraining.ViewModels
{
    public class ViewModelBase : ObservableObject
    {
        public ViewModelBase()
        {
            SharedDataModel = SharedDataModel.Instance;
        }

        #region Public properties
        public SharedDataModel SharedDataModel { get; set; }
        #endregion
    }
}
