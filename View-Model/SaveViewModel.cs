using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public SaveViewModel(SaveView saveView)
        {
            this.saveView = saveView;
            new SaveModel(this);
            Console.WriteLine("SaveViewModel chargé");

            this.numOption = this.saveView.numOption;

            switch (this.numOption)
            {
                case 1: Console.WriteLine("choix du changement de langue");
                    break;
                case 2: Console.WriteLine("choix de la création de sauvegarde");
                    break;
                case 3: Console.WriteLine("choix de la modification de sauvegarde");
                    break;
                case 4: Console.WriteLine("choix de la suppression de sauvegarde");
                    break;

                default:
                    Console.WriteLine("Aucun");
                    break;
            }
        }
    }
}
