using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using EasySave.View;
using NewtonsoftJson = Newtonsoft.Json;

//Import des éléments du namespace EasySave
using EasySave.View_Model;
using Newtonsoft.Json;

namespace EasySave.Model
{
    public class SaveModel
    {
        public string Name { get; set; }
        public string SourceRepo { get; set; }
        public string DestinationRepo { get; set; }
        public SaveType Type { get; set; }

        private SaveViewModel saveViewModel;
        public CreateModel CreateModel { get; set; }

        public static string[] files = Directory.GetFiles(@"C:\..\..\AppData\Roaming\backupconfigs", "*.json");

        public SaveModel(SaveViewModel saveViewModel)
        {
            this.saveViewModel = saveViewModel;
        }

        

        
        public void DeleteSave()
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
        }
    }
}



