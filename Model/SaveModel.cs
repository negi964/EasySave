using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

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

        public static string[] files = Directory.GetFiles(@"C:\..\..\AppData\Roaming\backupconfigs", "*.json");

        class BackupConfig
        {
            public string BackupName { get; set; }
            public string SourceDirectory { get; set; }
            public string TargetDirectory { get; set; }
            public string BackupType { get; set; }
        }
        public SaveModel(SaveViewModel saveViewModel)
        {
            this.saveViewModel = saveViewModel;
        }

        public void CreateSave()
        {
            var backupConfigs = new List<BackupConfig>();
            string backupConfigFile = @"C:\..\..\AppData\Roaming\backupconfigs.json";

            if (File.Exists(backupConfigFile))
            {
                backupConfigs = JsonConvert.DeserializeObject<List<BackupConfig>>(File.ReadAllText(backupConfigFile));
            }

            while (true)
            {
                Console.WriteLine("1. Créer une sauvegarde");
                Console.WriteLine("2. Quitter");
                Console.Write("Quel est votre choix : ");

                int choice = int.Parse(Console.ReadLine());
                if (choice == 2)
                {
                    break;
                }

                if (choice == 1)
                {
                    if (backupConfigs.Count == 5)
                    {
                        Console.WriteLine("Le nombre maximum est atteint veuillez en supprimer une");
                        continue;
                    }

                    Console.Write("Nom : ");
                    string backupName = Console.ReadLine();

                    Console.Write("Chemin source : ");
                    string sourceDirectory = Console.ReadLine();

                    Console.Write("Chemin destination : ");
                    string targetDirectory = Console.ReadLine();

                    Console.Write("Type de sauvegarde : ");
                    string backupType = Console.ReadLine();

                    backupConfigs.Add(new BackupConfig
                    {
                        BackupName = backupName,
                        SourceDirectory = sourceDirectory,
                        TargetDirectory = targetDirectory,
                        BackupType = backupType
                    });

                    File.WriteAllText(backupConfigFile, JsonConvert.SerializeObject(backupConfigs, Formatting.Indented));
                }
            }
        }

        public void EditSave()
        {
            var backupConfigs = new List<BackupConfig>();
            string backupConfigFile = @"C:\..\..\AppData\Roaming\backupconfigs.json";

            if (File.Exists(backupConfigFile))
            {
                backupConfigs = JsonConvert.DeserializeObject<List<BackupConfig>>(File.ReadAllText(backupConfigFile));
            }

            while (true)
            {
                Console.WriteLine("1. Modifier une sauvegarde");
                Console.WriteLine("2. Quitter");
                Console.Write("Quel est votre choix : ");

                int choice = int.Parse(Console.ReadLine());
                if (choice == 2)
                {
                    break;
                }

                if (choice == 1)
                {
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

                        Console.Write("Choisir le numéro de la configuration à modifier : ");

                        int configToModify = int.Parse(Console.ReadLine());

                        if (configToModify > 0 && configToModify <= backupConfigs.Count)
                        {
                            Console.Write("Nouveau nom : ");
                            string newBackupName = Console.ReadLine();

                            Console.Write("Nouveau chemin source : ");
                            string newSourceDirectory = Console.ReadLine();

                            Console.Write("Nouveau chemin destination : ");
                            string newTargetDirectory = Console.ReadLine();

                            Console.Write("Nouveau type de sauvegarde : ");
                            string newBackupType = Console.ReadLine();

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
                }

            }
        }
public void DeleteSave()
{
    var backupConfigs = new List<BackupConfig>();
    string backupConfigFile = @"C:\..\..\AppData\Roaming""\backupconfigs.json";

    if (File.Exists(backupConfigFile))
    {
        backupConfigs = JsonConvert.DeserializeObject<List<BackupConfig>>(File.ReadAllText(backupConfigFile));
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

        

