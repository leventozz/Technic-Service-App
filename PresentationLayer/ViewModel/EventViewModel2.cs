using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.ViewModel
{
    public class EventViewModel2: INotifyPropertyChanged
    {
        public EventViewModel2()
        {
            Click = new RelayCommand(UpdateClick);
        }
        public RelayCommand Click { get; set; }
        private void UpdateClick()
        {
            IssueViewModel ivm = new IssueViewModel();
            ivm.SolveThis(ivm.SelectedItem);
        }
        

        #region NotifyLogic
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion 
    }
}
