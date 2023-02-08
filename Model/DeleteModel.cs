using System;
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

        /*public void DeleteSave()
        {
            var backupConfigs = new List<Config>();
            string backupConfigFile = @"C:\..\..\AppData\Roaming""\backupconfigs.json";

            if (File.Exists(backupConfigFile))
            {
                backupConfigs = JsonConvert.DeserializeObject<List<Config>>(File.ReadAllText(backupConfigFile));
            }

            Console.WriteLine("Quelle configuration souhaitez-vous supprimer?");
            for (int i = 0; i < backupConfigs.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {backupConfigs[i].BackupName}");
            }

            int configToDelete = int.Parse(Console.ReadLine());

            if (configToDelete > 0 && configToDelete <= backupConfigs.Count)
            {
                backupConfigs.RemoveAt(configToDelete - 1);
                File.WriteAllText(backupConfigFile, JsonConvert.SerializeObject(backupConfigs, Formatting.Indented));
                Console.WriteLine("La configuration a été supprimée avec succès");
            }
            else
            {
                Console.WriteLine("La configuration n'a pas été trouvée");
            }
        }*/


    }
}
