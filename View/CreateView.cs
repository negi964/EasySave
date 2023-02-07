using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasySave.Model;
using EasySave.View_Model;
using Newtonsoft.Json;

namespace EasySave.View
{

    public class CreateView
    {

        public CreateView() { }

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


                    var createViewModel = new CreateViewModel();
                    createViewModel.GetCreateModel(backupName, sourceDirectory, targetDirectory, backupType);
                }
            }
        }
    }

}
