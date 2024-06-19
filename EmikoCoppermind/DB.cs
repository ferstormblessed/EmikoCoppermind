using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmikoCoppermind
{
    class DB
    {
        static string connectionString = "Data Source=Emiko.sqlite;Version=3;";
        public SQLiteConnection connectToDB()
        {
            return new SQLiteConnection(connectionString);
        }

        public void populateDB()
        {

        }
    }
}
