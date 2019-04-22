
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using PresentationLayer.Model;
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
            Click = new RelayCommand<Issue>(UpdateClick);
        }
        public RelayCommand<Issue> Click { get; set; }
        private void UpdateClick(Issue param)
        {
            //IssueViewModel ivm = new IssueViewModel();
            //ivm.SolveThis(ivm.SelectedItem);
            //var myMessage = new NotificationMessage("change");
            Messenger.Default.Send<PresentationLayer.Model.Issue>(param);
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
