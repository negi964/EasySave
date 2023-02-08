﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace EasySave.Model
{
    public class DeleteModel
    {
        public DeleteModel()
        {

        }

        public List<string> GetListConfig()
        {
            List<string> listConfig = new List<string>();
            var backupConfigs = new List<Config>();
            
            string backupConfigFile = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Easysave";
            string file = Path.Combine(backupConfigFile, "config.json");

            if (File.Exists(file))
            {
                backupConfigs = JsonConvert.DeserializeObject<List<Config>>(File.ReadAllText(file));
            }

            for (int i = 0; i < backupConfigs.Count; i++)
            {
                listConfig.Add($"{i + 1}. {backupConfigs[i].BackupName}");
            }
            return listConfig;
        }

        public string DeleteSave(int configToDelete)
        {
            var backupConfigs = new List<Config>();
            string backupConfigFile = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Easysave";
            string file = Path.Combine(backupConfigFile, "config.json");

            if (File.Exists(file))
            {
                backupConfigs = JsonConvert.DeserializeObject<List<Config>>(File.ReadAllText(file));
            }

            if (configToDelete > 0 && configToDelete <= backupConfigs.Count)
            {
                backupConfigs.RemoveAt(configToDelete - 1);
                File.WriteAllText(file, JsonConvert.SerializeObject(backupConfigs, Formatting.Indented));
                Console.WriteLine("La configuration a été supprimée avec succès");
            }
            else
            {
                throw new Exception("La configuration n'a pas été trouvée");
            }

            return null;
        }


    }
}
