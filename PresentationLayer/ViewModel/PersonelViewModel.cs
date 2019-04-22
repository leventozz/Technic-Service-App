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
    public class PersonelViewModel:INotifyPropertyChanged
    {
        public ObservableCollection<PresentationLayer.Model.Personel> personelList { get; set; }
        public ObservableCollection<PresentationLayer.Model.Personel> scoreList { get; set; }
        public PersonelViewModel()
        {
            DataAccessService service = new DataAccessService();
            var result = service.GetAllPersonels();
            var scoreResult = service.ScoreBoard();
            personelList = new ObservableCollection<Model.Personel>(result);
            scoreList = new ObservableCollection<Personel>(scoreResult);
        }
        
        public static Personel loggedPersonel;
        
        public Personel LoggedPersonel
        {
            get
            {
                return loggedPersonel;
            }
            set
            {
                loggedPersonel = value;
                OnPropertyChanged("LoggedPersonel");
            }
        }
        private int count;

        public int Count
        {
            get
            {
                return count;
            }
            set
            {
                count = value;
                OnPropertyChanged("Count");
            }
        }
        public void Increase()
        {

        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        public int SolvedCountIncrease()
        {
            PersonelViewModel pvm = new PersonelViewModel();
            Personel temp = scoreList.FirstOrDefault(x => x.PersonelID == LoggedPersonel.PersonelID);
            if (temp != null)
            {
                Count = temp.SolvedCount++;
            }
            //var t = int.Parse(temp.SolvedCount);
            return count;
        }



    }
}
