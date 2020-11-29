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
        private static string connString = $"Data Source={Settings.DbLocation};Version=3;";
        
        public static ObservableCollection<string> GetTableNames()
        {
            ObservableCollection<string> tableNames = new ObservableCollection<string>();

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


        public static DataView GetTableContent(string selectedTable)
        {
            DataTable dt = new DataTable();

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
