using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SQLite;
using System.Text;

namespace JariSQLiteViewer
{
    public static class DatabaseActions
    {
        
        public static ObservableCollection<string> GetTableNames(string dbLocation)
        {
            ObservableCollection<string> tableNames = new ObservableCollection<string>();
            
            
            string connString = $"Data Source={dbLocation};Version=3;";

            using (var connection = new SQLiteConnection(connString))
            {
                connection.Open();
                SQLiteCommand cmd;
                cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT name FROM sqlite_master WHERE type = 'table' ORDER BY name";
                var reader = cmd.ExecuteReader();
                while(reader.Read())
                {
                    tableNames.Add(reader[0].ToString());
                }
            }

            return tableNames;
        }


        public static DataView GetTableContent(string dbLocation,string selectedTable)
        {
            DataTable dt = new DataTable();
            string connString = $"Data Source={dbLocation};Version=3;";

            using (var connection = new SQLiteConnection(connString))
            {
                connection.Open();
                SQLiteCommand cmd;
                cmd = connection.CreateCommand();
                cmd.CommandText = $"SELECT * FROM {selectedTable}";
                var reader = cmd.ExecuteReader();
                dt.Load(reader);
                


            }



            return dt.AsDataView();
        }

    }
}
