using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;

//Import des éléments du namespace EasySave
using EasySave.View_Model;

namespace EasySave.View
{
    public class SaveView
    {
        public int _numOption { get; set; }

        private CopyView _copyView;
        public SaveView()
        {
            _copyView = new CopyView();

            this.Welcome();

            switch (_numOption)
            {
                case 1:
                    Console.WriteLine("choix du changement de langue");
                    break;
                case 2:
                    Console.WriteLine("choix de la création de sauvegarde");
                    _saveModel.CreateSave();
                    break;

                case 3:
                    Console.WriteLine("choix de la modification de sauvegarde");
                    _saveModel.EditSave();
                    break;

                case 4:
                    Console.WriteLine("choix de la suppression de sauvegarde");
                    _saveModel.DeleteSave();
                    break;

                case 5:
                    Console.WriteLine("Lancement d'une sauvegarde");
                    _copyView.Show();
                    break;

                default:
                    saveView.Welcome();
                    break;
            }
        }

        public void Welcome()
        {
            Console.Title = "EasySave";
            Console.Clear();

            ResourceManager rm = new ResourceManager("EasySave.Lang.Ressource", Assembly.GetExecutingAssembly());

            Console.WriteLine(" _______     ___           _______.____    ____  _______.     ___   ____    ____  _______ \r\n|   ____|   /   \\         /       |\\   \\  /   / /       |    /   \\  \\   \\  /   / |   ____|\r\n|  |__     /  ^  \\       |   (----` \\   \\/   / |   (----`   /  ^  \\  \\   \\/   /  |  |__   \r\n|   __|   /  /_\\  \\       \\   \\      \\_    _/   \\   \\      /  /_\\  \\  \\      /   |   __|  \r\n|  |____ /  _____  \\  .----)   |       |  | .----)   |    /  _____  \\  \\    /    |  |____ \r\n|_______/__/     \\__\\ |_______/        |__| |_______/    /__/     \\__\\  \\__/     |_______|\r\n\n                                                                                          ");
            Console.WriteLine($"{rm.GetString("Welcome", CultureInfo.CurrentUICulture)}\n");
            Console.WriteLine($"{rm.GetString("MenuSelectTitle", CultureInfo.CurrentUICulture)}\n");
            Console.Write($"{rm.GetString("FirstOption", CultureInfo.CurrentUICulture)}\n");
            Console.Write($"{rm.GetString("SecondOption", CultureInfo.CurrentUICulture)}\n");
            Console.Write($"{rm.GetString("ThirdOption", CultureInfo.CurrentUICulture)}\n");
            Console.Write($"{rm.GetString("FourthOption", CultureInfo.CurrentUICulture)}\n");
            Console.WriteLine($"{rm.GetString("FifthOption", CultureInfo.CurrentUICulture)}\n");
            Console.Write($"{rm.GetString("SelectOption", CultureInfo.CurrentUICulture)}");

            _numOption = Int32.Parse(Console.ReadLine());


            new SaveViewModel(this);

        }
    }
}
