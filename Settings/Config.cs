using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace CreClient
{
    public static class Config
    {
        public static MainConfig Main => MainConfig.Instance;
    }
    /*public static void SaveAll()
    {
        //Main.Save();       
    }
    public static void Initialize()
    {
        //MainConfig.Load();         
    }*/
    public class MainConfig
    {
        public static MainConfig Instance;
        /*
        public static void Load()
        {
            if (!File.Exists(ModFiles.ConfigFile))
            {
                JsonManager.WriteToJsonFile(ModFiles.ConfigFile, new MainConfig());
            }
            Instance = JsonManager.ReadFromJsonFile<MainConfig>(ModFiles.ConfigFile);
        }

        public void Save()
        {
            JsonManager.WriteToJsonFile(ModFiles.ConfigFile, Instance);
        }
    }*/
    }
}