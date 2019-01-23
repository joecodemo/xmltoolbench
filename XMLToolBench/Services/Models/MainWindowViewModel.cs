using System.ComponentModel;

namespace Services.Models
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private string _xmlFilePath;
        public string XMLFilePath
        {
            get => _xmlFilePath;
            set
            {
                _xmlFilePath = value;
                OnPropertyChanged(nameof(XMLFilePath));
            }
        }

        private string _xslFilePath;
        public string XSLFilePath
        {
            get => _xslFilePath;
            set
            {
                _xslFilePath = value;
                OnPropertyChanged(nameof(XSLFilePath));
            }
        }





        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion // INotifyPropertyChanged Members
    }
}