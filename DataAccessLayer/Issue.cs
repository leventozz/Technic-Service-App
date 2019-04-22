using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Issue
    {
        public int IssueID { get; set; }
        public string SolvedBy { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public string ProductName { get; set; }
        public bool Solved { get; set; }
    }
}
