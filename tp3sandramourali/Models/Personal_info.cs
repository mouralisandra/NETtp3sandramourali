using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.Sqlite;

namespace tp3sandramourali.Models
{
    public class Personal_info
    {
        public List<Person> GetAllPerson()
        {
            List<Person> list = new List<Person>();
            SqliteConnection dbCon = new SqliteConnection("Data Source=C:\\Users\\sandra\\Desktop\\2022 GL3 .NET Framework TP3 - SQLite database.db;");
            dbCon.Open();

            using (dbCon)
            {
                SqliteCommand cmd = new SqliteCommand("SELECT * FROM personal_info", dbCon);
                SqliteDataReader reader = cmd.ExecuteReader();
                using (reader)
                {
                    while (reader.Read())
                    {
                        int id = (int)reader["id"];
                        string first_name = (string)reader["first_name"];
                        string last_name = (string)reader["last_name"];
                        string email = (string)reader["email"];
                        //   DateTime date_birth = Convert.ToDateTime((string)reader["date_birth"].ToString());
                        string image = (string)reader["image"];
                        string country = (string)reader["country"];
                        list.Add(new Person(id, first_name, last_name, email, image, country));
                    }
                }
            }

            return list;
        }
        public Person GetPerson(int id)
        {
            List<Person> list = GetAllPerson();
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].id == id)
                {
                    return list[i];
                }
            }
            return null;

        }
    }
}
       
