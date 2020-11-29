using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
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
            Tables = DatabaseActions.GetTableNames();

        }

        private void MainViewCommands(object obj)
        {
            switch(obj.ToString())
            {
                case "fetchData":
                    ListViewContent = DatabaseActions.GetTableContent(SelectedTable);
                    break;


            }
        }

        
    }
}
