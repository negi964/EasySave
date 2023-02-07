using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace EasySave.View
{
    public class BackupConfig
    {
        public string BackupName { get; set; }
        public string SourceDirectory { get; set; }
        public string TargetDirectory { get; set; }
        public string BackupType { get; set; }
    }
    public class CreateSaveView
    {
        private BackupConfig BackupConfig { get; set; }
        public CreateSaveView() { }

        public void Show()
        {
            while (true)
            {
                Console.WriteLine("1. Créer une sauvegarde");
                Console.WriteLine("2. Quitter");
                Console.WriteLine("");
                Console.Write("Quel est votre choix : ");

                int choice = int.Parse(Console.ReadLine());

                if (choice == 2)
                {
                    break;
                }

                if (choice == 1)
                {
                    Console.Write("Nom : ");
                    string backupName = Console.ReadLine();

                    Console.Write("Chemin source : ");
                    string sourceDirectory = Console.ReadLine();

                    Console.Write("Chemin destination : ");
                    string targetDirectory = Console.ReadLine();

                    Console.Write("Type de sauvegarde : ");
                    string backupType = Console.ReadLine();

                    BackupConfig = new BackupConfig
                    {
                        BackupName = backupName,
                        SourceDirectory = sourceDirectory,
                        TargetDirectory = targetDirectory,
                        BackupType = backupType
                    };
                }
            }
        }
    }

}
