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
            viewModel.GetCopyModel(source, destination);
        }
    }
}
