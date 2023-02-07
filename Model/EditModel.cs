using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace EasySave.Model
{
    public class EditModel
    {
        public EditModel()
        {

        }

        /*public void EditSave()
        {
            var backupConfigs = new List<Config>();
            string backupConfigFile = @"C:\..\..\AppData\Roaming\backupconfigs.json";

            if (File.Exists(backupConfigFile))
            {
                backupConfigs = JsonConvert.DeserializeObject<List<Config>>(File.ReadAllText(backupConfigFile));
            }

            if (backupConfigs.Count == 0)
            {
                Console.WriteLine("Il n'y a aucune configuration à modifier");
                continue;
            }

            for (int i = 0; i < backupConfigs.Count; i++)
            {
                for (int k = 0; k < backupConfigs.Count; k++)
                {
                    Console.WriteLine($"{k + 1}. {backupConfigs[k].BackupName}");
                }

                if (configToModify > 0 && configToModify <= backupConfigs.Count)
                {
                    backupConfigs[configToModify - 1].BackupName = newBackupName;
                    backupConfigs[configToModify - 1].SourceDirectory = newSourceDirectory;
                    backupConfigs[configToModify - 1].TargetDirectory = newTargetDirectory;
                    backupConfigs[configToModify - 1].BackupType = newBackupType;

                    File.WriteAllText(backupConfigFile, JsonConvert.SerializeObject(backupConfigs, Formatting.Indented));
                }
                else
                {
                    Console.WriteLine("La configuration n'a pas été trouvée");
                }
            }
        }*/
    }
}
