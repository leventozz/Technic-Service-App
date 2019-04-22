using GalaSoft.MvvmLight.Command;
using PresentationLayer.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.ViewModel
{
    public class IssueViewModel :INotifyPropertyChanged 
    {
        public ObservableCollection<PresentationLayer.Model.Issue> issueList { get; set; }
        public IssueViewModel()
        {
            DataAccessService service = new DataAccessService();
            var result = service.GetAllIssues();
            issueList = new ObservableCollection<Model.Issue>(result);   
        }
        public static Issue selectedItem;
        public Issue SelectedItem
        {
            get
            {
                return selectedItem;
            }
            set
            {
                selectedItem = value;
                OnPropertyChanged("SelectedItem");
            }   
        }
 
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }


        public Issue SolveThis(Issue selectedItem)
        {
            PersonelViewModel pvm = new PersonelViewModel();
            var t = pvm.LoggedPersonel;
            DataAccessService da = new DataAccessService();
            var temp = selectedItem;
            //service.SelectedUpdate(selectedItem.IssueID);
            if (temp.Solved!=true)
            {
                temp.Solved = true;
                temp.SolvedBy = t.PersonelName;
                selectedItem = temp;
                da.SelectedUpdate(selectedItem.IssueID, t.PersonelName);
                da.UpdatePersonel(t.PersonelID);
                da.ScoreBoard();
                pvm.SolvedCountIncrease();
            }
            return selectedItem;
        }

    }
}
