using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.Model
{
    public class Issue : INotifyPropertyChanged
    {
        private int issueID;
        private string solvedBy;
        private string subject;
        private string description;
        private string productName;
        private bool solved;
        public int IssueID
        {
            get
            {
                return issueID;
            }
            set
            {
                issueID = value;
                OnPropertyChanged("IssueID");
            }
        }
        public string SolvedBy
        {
            get
            {
                return solvedBy;
            }
            set
            {
                solvedBy = value;
                OnPropertyChanged("SolvedBy");
            }
        }
        public string Subject
        {
            get
            {
                return subject;
            }
            set
            {
                subject = value;
                OnPropertyChanged("Subject");
            }
        }
        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                description = value;
                OnPropertyChanged("Description");
            }
        }
        public string ProductName
        {
            get
            {
                return productName;
            }
            set
            {
                productName = value;
                OnPropertyChanged("ProductName");
            }
        }
        public bool Solved
        {
            get
            {
                return solved;
            }
            set
            {
                solved = value;
                OnPropertyChanged("Solved");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
