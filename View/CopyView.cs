using EasySave.Model;
using EasySave.View_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace EasySave.View
{
    public class CopyView
    {
        public CopyView()
        {
        }
        public void Show()
        {

            Console.WriteLine("Choisissez le type de sauvegarde : \n [1] - Complète \n [2] - Différentielle \n ");
            string sType = Console.ReadLine();
            int iType = 0;
            bool isParsed = int.TryParse(sType, out iType);
            while (isParsed == false || !Enum.IsDefined(typeof(SaveType), iType))
            {
                    Console.WriteLine("Renseignez une valeur existante :");
                    sType = Console.ReadLine();
                    isParsed = int.TryParse(sType, out iType);

            }
             iType = Int32.Parse(sType); 

                Console.WriteLine("Choisissez le dossier ou ficher à copier\n ");
            string? source = Console.ReadLine();
            while (source == null)
            {
                Console.WriteLine("Renseignez un chemin :");
                source = Console.ReadLine();
            }
            Console.WriteLine("Renseignez le chemin de destination");
            string? destination = Console.ReadLine();
            while (destination == null)
            {
                Console.WriteLine("Renseignez une destination :");
                destination = Console.ReadLine();
            }
            var viewModel = new CopyViewModel();
            viewModel.GetCopyModel(source, destination, iType);
        }
    }
}
