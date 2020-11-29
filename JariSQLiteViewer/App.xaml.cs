using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using JariSQLiteViewer.ViewModels;

namespace JariSQLiteViewer
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            Settings.InitSettings();
            MainWindow MainView = new MainWindow();
            MainViewViewModel vm = new MainViewViewModel();
            MainView.DataContext = vm;
            MainView.Show();
        }

    }
}
