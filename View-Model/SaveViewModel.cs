using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using EasySave.Model;

//Import des éléments du namespace EasySave
using EasySave.View;

namespace EasySave.View_Model
{
    public class SaveViewModel
    {
        private SaveView saveView;
        private int numOption;
        class Backup
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
            string[] files = Directory.GetFiles(@"C:\Users\2216074\OneDrive - Association Cesi Viacesi mail\Bureau\Portfolio\FISA A3\C#\EasySave\BackupConfigurations\", "*.txt");

            this.numOption = Int32.Parse(this.saveView.numOption);

            switch (this.numOption)
            {
                case 1: Console.WriteLine("choix du changement de langue");
                    break;
                case 2: Console.WriteLine("choix de la création de sauvegarde");

                    Console.WriteLine("Entrez l'appellation :");
                    string name = Console.ReadLine();

                    Console.WriteLine("Entrez le répertoire source :");
                    string sourceDirectory = Console.ReadLine();

                    Console.WriteLine("Entrez le répertoire cible :");
                    string targetDirectory = Console.ReadLine();

                    Console.WriteLine("Entrez le type de sauvegarde :");
                    string backupType = Console.ReadLine();

                    Console.WriteLine("\nConfiguration de sauvegarde créée avec succès :");
                    Console.WriteLine("Appellation : " + name);
                    Console.WriteLine("Répertoire source : " + sourceDirectory);
                    Console.WriteLine("Répertoire cible : " + targetDirectory);
                    Console.WriteLine("Type de sauvegarde : " + backupType);

                    try
                    {
                        string SaveConfiguration = name + "\n" + sourceDirectory + "\n" + targetDirectory + "\n" + backupType;
                        string FileName = @"C:\Users\2216074\OneDrive - Association Cesi Viacesi mail\Bureau\Portfolio\FISA A3\C#\EasySave\BackupConfigurations\" + name + ".txt";

                        if (!Directory.Exists(@"C:\Users\2216074\OneDrive - Association Cesi Viacesi mail\Bureau\Portfolio\FISA A3\C#\EasySave\BackupConfigurations\"))
                        {
                            Directory.CreateDirectory(@"C:\Users\2216074\OneDrive - Association Cesi Viacesi mail\Bureau\Portfolio\FISA A3\C#\EasySave\BackupConfigurations\");
                        }

                        File.WriteAllText(FileName, SaveConfiguration);
                        Console.WriteLine("\nLa configuration a été enregistrée avec succès dans " + FileName);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("\nUne erreur s'est produite lors de l'enregistrement de la configuration : " + ex.Message);
                    }

                    Console.ReadLine();
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
                    Console.WriteLine("Appellation : " + configuration[0]);
                    Console.WriteLine("Répertoire source : " + configuration[1]);
                    Console.WriteLine("Répertoire cible : " + configuration[2]);
                    Console.WriteLine("Type de sauvegarde : " + configuration[3]);

                    Console.WriteLine("\nEntrez le nouvel élément à modifier (1 = appellation, 2 = source, 3 = cible, 4 = type) :");
                    int modifyOption = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Entrez la nouvelle valeur :");
                    string newValue = Console.ReadLine();

                    configuration[modifyOption - 1] = newValue;

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
