using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer
{
    public class DataAccessService
    {
        public IEnumerable<PresentationLayer.Model.Issue> GetAllIssues()
        {
            List<PresentationLayer.Model.Issue> issueList = new List<PresentationLayer.Model.Issue>();
            var da = new DataAccess();
            foreach (var item in da.GetIssues())
            {
                PresentationLayer.Model.Issue temp = new Model.Issue();
                temp.IssueID = item.IssueID;
                temp.ProductName = item.ProductName;
                temp.Solved = item.Solved;
                temp.SolvedBy = item.SolvedBy;
                temp.Subject = item.Subject;
                temp.Description = item.Description;
                issueList.Add(temp);
            }
            return issueList;
        }
        public IEnumerable<PresentationLayer.Model.Personel> GetAllPersonels()
        {
            List<PresentationLayer.Model.Personel> personelList = new List<PresentationLayer.Model.Personel>();
            var da = new DataAccess();
            foreach (var item in da.GetPersonels())
            {
                PresentationLayer.Model.Personel temp = new Model.Personel();
                temp.PersonelID = item.PersonelID;
                temp.Password = item.Password;
                temp.PersonelName = item.PersonelName;
                temp.SolvedCount = item.SolvedCount;
                personelList.Add(temp);
            }
            return personelList;
        }
        //public PresentationLayer.Model.Issue Selected(int? id)
        //{
        //    PresentationLayer.Model.Issue temp = new Model.Issue();
        //    var da = new DataAccess();
        //    temp.IssueID = da.Selected(id).IssueID;
        //    temp.ProductName= da.Selected(id).ProductName;
        //    temp.Solved = da.Selected(id).Solved;
        //    temp.SolvedBy = da.Selected(id).SolvedBy;
        //    temp.Subject = da.Selected(id).Subject;
        //    return temp;
        //}
        public void SelectedUpdate(int? id,string name)
        {
            DataAccess da = new DataAccess();
            da.SelectedUpdate(id, name);
        }
        public void UpdatePersonel(int? id)
        {
            DataAccess da = new DataAccess();
            da.PersonelUpdate(id);
        }
        public IEnumerable<PresentationLayer.Model.Personel> ScoreBoard()
        {
            List<PresentationLayer.Model.Personel> scoreList = new List<PresentationLayer.Model.Personel>();
            DataAccess da = new DataAccess();
            foreach (var item in da.ScoreBoard())
            {
                PresentationLayer.Model.Personel temp = new Model.Personel();
                temp.PersonelID = item.PersonelID;
                temp.PersonelName = item.PersonelName;
                temp.SolvedCount = item.SolvedCount;
                scoreList.Add(temp);
            }
            return scoreList;
        }
    }
}
