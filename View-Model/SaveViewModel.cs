using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using NewtonsoftJson = Newtonsoft.Json;
using EasySave.Model;

//Import des éléments du namespace EasySave
using EasySave.View;
using System.Xml;

namespace EasySave.View_Model
{
    public class SaveViewModel
    {
        private SaveView saveView;
        private int numOption;
        class BackupConfig
        {
            public string Name { get; set; }
            public string SourceDirectory { get; set; }
            public string TargetDirectory { get; set; }
            public string BackupType { get; set; }
        }

        public SaveViewModel(SaveView saveView)
        {
            this.saveView = saveView;
            new SaveModel(this);
            string[] files = Directory.GetFiles(@"C:\Users\2216074\OneDrive - Association Cesi Viacesi mail\Bureau\Portfolio\FISA A3\C#\EasySave\BackupConfigurations\", "*.json");

            this.numOption = Int32.Parse(this.saveView.numOption);

            switch (this.numOption)
            {
                case 1: Console.WriteLine("choix du changement de langue");
                    break;
                case 2: Console.WriteLine("choix de la création de sauvegarde");

                    Console.WriteLine("Entrez une appellation pour la configuration de sauvegarde :");
                    string name = Console.ReadLine();

                    Console.WriteLine("\nEntrez le répertoire source :");
                    string sourceDirectory = Console.ReadLine();

                    Console.WriteLine("\nEntrez le répertoire cible :");
                    string targetDirectory = Console.ReadLine();

                    Console.WriteLine("\nEntrez le type de sauvegarde (complet/différentiel) :");
                    string backupType = Console.ReadLine();

                    BackupConfig config = new BackupConfig
                    {
                        Name = name,
                        SourceDirectory = sourceDirectory,
                        TargetDirectory = targetDirectory,
                        BackupType = backupType
                    };

                    string CreatePath = @"C:\Users\2216074\OneDrive - Association Cesi Viacesi mail\Bureau\Portfolio\FISA A3\C#\EasySave\BackupConfigurations\" + name + ".json";

                    try
                    {
                        using (StreamWriter writer = new StreamWriter(CreatePath))
                        {
                            string json = NewtonsoftJson.JsonConvert.SerializeObject(config, NewtonsoftJson.Formatting.Indented);
                            writer.WriteLine(json);
                        }
                        Console.WriteLine("\nLa configuration de sauvegarde a été enregistrée avec succès.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("\nUne erreur s'est produite lors de l'enregistrement de la configuration : " + ex.Message);
                    }


                    Console.ReadLine();
                    break;

                case 3: Console.WriteLine("choix de la modification de sauvegarde");

                    Console.WriteLine("Liste des configurations de sauvegarde existantes :");

                    for (int i = 0; i < files.Length; i++)
                    {
                        Console.WriteLine(i + 1 + ". " + Path.GetFileNameWithoutExtension(files[i]));
                    }

                    Console.WriteLine("\nEntrez le numéro de la configuration à modifier :");
                    int option = Convert.ToInt32(Console.ReadLine());
                    string ModifyPath = files[option - 1];
                    string[] configuration = File.ReadAllLines(ModifyPath);

                    Console.WriteLine("\nConfiguration actuelle :");
                    Console.WriteLine("Appellation : " + configuration[1]);
                    Console.WriteLine("Répertoire source : " + configuration[2]);
                    Console.WriteLine("Répertoire cible : " + configuration[3]);
                    Console.WriteLine("Type de sauvegarde : " + configuration[4]);

                    Console.WriteLine("\nEntrez le nouvel élément à modifier (1 = appellation, 2 = source, 3 = cible, 4 = type) :");
                    int ModifyOption = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Entrez la nouvelle valeur :");
                    string newValue = Console.ReadLine();

                    configuration[ModifyOption] = newValue;

                    try
                    {
                        File.WriteAllLines(ModifyPath, configuration);
                        Console.WriteLine("\nLa configuration a été modifiée avec succès.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("\nUne erreur s'est produite lors de la modification de la configuration : " + ex.Message);
                    }

                    Console.ReadLine();
                    break;

                case 4: Console.WriteLine("choix de la suppression de sauvegarde");

                    Console.WriteLine("Liste des configurations de sauvegarde existantes :");

                    for (int i = 0; i < files.Length; i++)
                    {
                        Console.WriteLine(i + 1 + ". " + Path.GetFileNameWithoutExtension(files[i]));
                    }

                    Console.WriteLine("\nEntrez le numéro de la configuration à supprimer :");
                    int DeleteOption = Convert.ToInt32(Console.ReadLine());
                    string DeletePath = files[DeleteOption - 1];

                    try
                    {
                        File.Delete(DeletePath);
                        Console.WriteLine("\nLa configuration a été supprimée avec succès.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("\nUne erreur s'est produite lors de la suppression de la configuration : " + ex.Message);
                    }

                    Console.ReadLine();
                    break;

                default:
                    this.saveView.Welcome();
                    break;
            }
        }
    }
}
