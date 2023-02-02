using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;

//Import des éléments du namespace EasySave
using EasySave.Model;
using EasySave.View_Model;

namespace EasySave.View
{
    public class SaveView
    {
        public int numOption { get; set; }
        public SaveView()
        {
            ResourceManager rm = new ResourceManager("EasySave.Lang.Ressource", Assembly.GetExecutingAssembly());


            Console.WriteLine(" _______     ___           _______.____    ____  _______.     ___   ____    ____  _______ \r\n|   ____|   /   \\         /       |\\   \\  /   / /       |    /   \\  \\   \\  /   / |   ____|\r\n|  |__     /  ^  \\       |   (----` \\   \\/   / |   (----`   /  ^  \\  \\   \\/   /  |  |__   \r\n|   __|   /  /_\\  \\       \\   \\      \\_    _/   \\   \\      /  /_\\  \\  \\      /   |   __|  \r\n|  |____ /  _____  \\  .----)   |       |  | .----)   |    /  _____  \\  \\    /    |  |____ \r\n|_______/__/     \\__\\ |_______/        |__| |_______/    /__/     \\__\\  \\__/     |_______|\r\n\n                                                                                          ");
            Console.WriteLine($"{rm.GetString("Welcome", CultureInfo.CurrentUICulture)}\n");
            Console.WriteLine($"{rm.GetString("MenuSelectTitle", CultureInfo.CurrentUICulture)}\n");
            Console.Write($"{rm.GetString("FirstOption", CultureInfo.CurrentUICulture)}\n");
            Console.Write($"{rm.GetString("SecondOption", CultureInfo.CurrentUICulture)}\n");
            Console.Write($"{rm.GetString("ThirdOption", CultureInfo.CurrentUICulture)}\n");
            Console.WriteLine($"{rm.GetString("FourthOption", CultureInfo.CurrentUICulture)}\n");
            Console.Write($"{rm.GetString("SelectOption", CultureInfo.CurrentUICulture)}");

            numOption = Int32.Parse(Console.ReadLine());

            new SaveViewModel(this);

        }
    }
}
