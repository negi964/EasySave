using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySave.Model
{
    public class CreateModel
    {
      
        public CreateModel()
        {

        }

        public string CreateSave (string backupName, string sourceDirectory, string targetDirectory, string backupType)
        {
            try
            {
                var config = new Config();
                config.BackupName = backupName;
                config.SourceDirectory = sourceDirectory;
                config.TargetDirectory = targetDirectory;
                config.BackupType = backupType;

                var backupConfigs = new List<Config>();
                string backupConfigFile = @"C:\..\..\AppData\Roaming\backupconfigs.json";

                if (File.Exists(backupConfigFile))
                {
                    backupConfigs = JsonConvert.DeserializeObject<List<Config>>(File.ReadAllText(backupConfigFile));
                }

                if (backupConfigs.Count == 5)
                {
                    throw new Exception("Le nombre maximum est atteint veuillez en supprimer une"); 
                }

                File.WriteAllText(backupConfigFile, JsonConvert.SerializeObject(backupConfigs, Formatting.Indented));

                return null;
            }
            catch (Exception ex) 
            {
                return ex.Message;
            }
        }
    }
}
