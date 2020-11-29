using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace JariSQLiteViewer
{
    public static class Settings
    {

        public static string DbLocation { get; set; }
        
        private static string _appRoot;

        public static void InitSettings()
        {
            _appRoot = Assembly.GetExecutingAssembly().Location;


        }

    }
}
