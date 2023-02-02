using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Import des éléments du namespace EasySave
using EasySave.Model;
using EasySave.View_Model;

namespace EasySave.View
{
    public class SaveView
    {
        private string numOption;
        public SaveView()
        {
            new SaveViewModel(this);

            Console.WriteLine(" _______     ___           _______.____    ____  _______.     ___   ____    ____  _______ \r\n|   ____|   /   \\         /       |\\   \\  /   / /       |    /   \\  \\   \\  /   / |   ____|\r\n|  |__     /  ^  \\       |   (----` \\   \\/   / |   (----`   /  ^  \\  \\   \\/   /  |  |__   \r\n|   __|   /  /_\\  \\       \\   \\      \\_    _/   \\   \\      /  /_\\  \\  \\      /   |   __|  \r\n|  |____ /  _____  \\  .----)   |       |  | .----)   |    /  _____  \\  \\    /    |  |____ \r\n|_______/__/     \\__\\ |_______/        |__| |_______/    /__/     \\__\\  \\__/     |_______|\r\n                                                                                          ");
            Console.WriteLine("");
            Console.WriteLine("Bienvenue !");
            Console.WriteLine("");
            Console.WriteLine("Choisissez un chiffre entre 1 et 4 : ");
            Console.WriteLine("");
            Console.WriteLine("[1]. Changer de langue");
            Console.WriteLine("[2]. Créer une sauvegarde");
            Console.WriteLine("[3]. Modifier une sauvegarde");
            Console.WriteLine("[4]. Supprimer une sauvegarde");
            Console.WriteLine("");
            Console.Write("Entrer un chiffre : ");
            numOption = Console.ReadLine();
        }
    }
}
