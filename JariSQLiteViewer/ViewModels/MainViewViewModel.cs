using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.IO;
using System.Text;

namespace JariSQLiteViewer.ViewModels
{
    class MainViewViewModel: ViewModelBase
    {

        private string _selectedTable;

        public string SelectedTable
        {
            get { return _selectedTable; }
            set { _selectedTable = value;
                OnPropertyChanged();}
        }

        private ObservableCollection<string> _tables;

        public ObservableCollection<string> Tables
        {
            get { return _tables; }
            set { _tables = value;
                OnPropertyChanged();
            }
        }


        private string _databaseLocation;

        public string DatabaseLocation
        {
            get { return Path.GetFileName(_databaseLocation); }
            set { _databaseLocation = value;
                Settings.DbLocation = _databaseLocation;
                OnPropertyChanged();
            }
        }


        private DataView _listViewContent;

        public DataView ListViewContent
        {
            get { return _listViewContent; }
            set { _listViewContent = value;
                OnPropertyChanged();
            }
        }



        public MainViewViewModel()
        {
            DefaultCommand = new Commands.DefaultCommand(MainViewCommands);
            DatabaseLocation = Settings.DbLocation;
            Tables = DatabaseActions.GetTableNames(Settings.DbLocation);
            

        }

        private void MainViewCommands(object obj)
        {
            switch(obj.ToString())
            {
                case "fetchData":
                    ListViewContent = DatabaseActions.GetTableContent(Settings.DbLocation, SelectedTable);
                    break;

                case "changeDatasource":
                    OpenFileDialog fDialog = new OpenFileDialog();
                    if (fDialog.ShowDialog() == true)
                    {
                        DatabaseLocation = fDialog.FileName;
                        Settings.DbLocation = fDialog.FileName;
                        Tables = DatabaseActions.GetTableNames(Settings.DbLocation);
                    }
                    break;
            }
        }

        
    }
}
