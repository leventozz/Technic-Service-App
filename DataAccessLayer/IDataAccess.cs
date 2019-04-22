using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public interface IDataAccess
    {
        IEnumerable<Issue> GetIssues();
        IEnumerable< Personel> GetPersonels();
        void Add();
        void Update();
        Issue Selected(int? id);
        void SelectedUpdate(int? id, string name);
        void PersonelUpdate(int? id);
        IEnumerable<Personel> ScoreBoard();
    }
}
