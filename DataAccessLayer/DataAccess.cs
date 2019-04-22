using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DataAccess : IDataAccess
    {
        string connectionString = "Data Source=ASUS-PC\\SQLEXPRESS;Initial Catalog=TechnicService;Integrated Security=True";
        public void Add()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Issue> GetIssues()
        {
            var issueList = new List<Issue>();
            using (var connection = new SqlConnection(connectionString))
            {
                var command = new SqlCommand();
                command.CommandText = "select * from Issue";
                command.Connection = connection;
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        issueList.Add(new Issue()
                        {
                            IssueID = (int)reader["IssueID"],
                            SolvedBy = (string)reader["SolvedBy"],
                            Solved = (bool)reader["Solved"],
                            ProductName = (string)reader["ProductName"],
                            Subject = (string)reader["Subject"],
                            Description = (string)reader["Description"]
                        });
                    }
                }
            }
            return issueList;
        }

        public IEnumerable<Personel> GetPersonels()
        {
            var personelList = new List<Personel>();
            using (var connection = new SqlConnection(connectionString))
            {
                var command = new SqlCommand();
                command.CommandText = "select * from Personel";
                command.Connection = connection;
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        personelList.Add(new Personel()
                        {
                            PersonelID = (int)reader["PersonelID"],
                            Password = (int)reader["Password"],
                            PersonelName = (string)reader["PersonelName"],
                            SolvedCount = (int)reader["SolvedCount"]
                        });
                    }
                }
            }
            return personelList;
        }
        
        public void Update()
        {
            throw new NotImplementedException();
        }

        public Issue Selected(int? id)
        {
            Issue issue = null;
            using (var connection = new SqlConnection(connectionString))
            {
                var command = new SqlCommand();
                command.CommandText = "Select * from Issue where IssueID=@Id";
                command.Connection = connection;
                command.Parameters.AddWithValue("@Id", id);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        issue = new Issue()
                        {
                            IssueID = (int)reader["IssueID"],
                            ProductName = (string)reader["ProductName"],
                            Solved = (bool)reader["Solved"],
                            SolvedBy = (string)reader["SolvedBy"],
                            Description = (string)reader["Description"],
                            Subject = (string)reader["Subject"]
                        };
                    }
                }
            }
            return issue;
        }
        public void SelectedUpdate(int? id, string name)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var command = new SqlCommand();
                command.CommandText = "update Issue set Solved=1, SolvedBy=@Name where IssueID=@Id";
                command.Connection = connection;
                command.Parameters.AddWithValue("@Id", id);
                command.Parameters.AddWithValue("@Name", name);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
        public void PersonelUpdate(int? id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var command = new SqlCommand();
                command.CommandText = "update Personel set SolvedCount=SolvedCount+1 where PersonelID=@Id";
                command.Connection = connection;
                command.Parameters.AddWithValue("@Id", id);
                connection.Open();
                command.ExecuteNonQuery();
            }

        }
        public IEnumerable<Personel> ScoreBoard()
        {
            var personelList = new List<Personel>();
            using (var connection = new SqlConnection(connectionString))
            {
                var command = new SqlCommand();
                command.CommandText = "select PersonelID, PersonelName, SolvedCount from Personel order by SolvedCount DESC";
                command.Connection = connection;
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        personelList.Add(new Personel()
                        {
                            PersonelID = (int)reader["PersonelID"],
                            PersonelName = (string)reader["PersonelName"],
                            SolvedCount = (int)reader["SolvedCount"]
                        });
                    }
                }
            }
            return personelList;
        }

    }
}

        
