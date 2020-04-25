using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace InterfaceManager
{
    public class Settings
    {
        private const string SETTING_FILEPATH = @"C:\Data\settings.json";
        private Settings() { }

        private static Settings _instance;

        public static Settings Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = GetInstance();
                }

                return _instance;
            }
        }

        private static Settings GetInstance()
        {
            if (!File.Exists(SETTING_FILEPATH))
            {
                CreateDefault();
            }

            try
            {
                var instance = JsonConvert.DeserializeObject<Settings>(File.ReadAllText(SETTING_FILEPATH));
            }
            catch
            {
                CreateDefault();
            }

            return JsonConvert.DeserializeObject<Settings>(File.ReadAllText(SETTING_FILEPATH));

        }

        private static void CreateDefault()
        {
            var settings = new Settings()
            {
                ITestDistribution = "",
                ITestplan = ""
            };
            settings.Save();
        }

        public void Save()
        {
            Directory.CreateDirectory(Path.GetDirectoryName(SETTING_FILEPATH));
            File.WriteAllText(SETTING_FILEPATH, JsonConvert.SerializeObject(this,Formatting.Indented));
        }

        public string ITestDistribution { get; set; }
        public string ITestplan { get; set; }
    }
}
