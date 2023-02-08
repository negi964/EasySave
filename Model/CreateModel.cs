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
                string backupConfigFile = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Easysave";

                if (!Directory.Exists(backupConfigFile))
                {
                    Directory.CreateDirectory(backupConfigFile);
                }

                string file = Path.Combine(backupConfigFile, "config.json");

                if (File.Exists(file))
                {
                    backupConfigs = JsonConvert.DeserializeObject<List<Config>>(File.ReadAllText(file));

                    if (backupConfigs.Count >= 5)
                    {
                        throw new Exception("Le nombre maximum de travaux de sauvegarde est atteint veuillez en supprimer un");
                    }
       
                }
                backupConfigs.Add(config);

                File.WriteAllText(file, JsonConvert.SerializeObject(backupConfigs, Formatting.Indented));
                Console.WriteLine("Le travaux de sauvegarde est créé !");

                return null;
            }
            catch (Exception ex) 
            {
                return ex.Message;
            }
        }
    }
}
