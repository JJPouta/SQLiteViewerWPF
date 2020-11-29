using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows;

namespace JariSQLiteViewer
{
    public static class Settings
    {

        public static string DbLocation { get; set; }
        

        public static void InitSettings()
        {
            string appRoot = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            JObject settings = JObject.Parse(File.ReadAllText(Path.Combine(appRoot,"appsettings.json")));
            DbLocation = settings["FilePaths"]["DbDefault"].ToString();

        }

    }
}
