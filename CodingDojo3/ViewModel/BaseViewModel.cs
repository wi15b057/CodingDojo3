using System.ComponentModel;

namespace CodingDojo3.ViewModel
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged Members   

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnChange(string propertyname)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }

        #endregion
    }
}