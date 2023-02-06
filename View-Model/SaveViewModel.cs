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
        private SaveModel saveModel;

        public SaveViewModel(SaveView saveView)
        {
            this.saveView = saveView;
            this.saveModel = new SaveModel(this);
            this.numOption = Int32.Parse(this.saveView.numOption);

            switch (this.numOption)
            {
                case 1: Console.WriteLine("choix du changement de langue");
                    break;
                case 2: Console.WriteLine("choix de la création de sauvegarde");
                    this.saveModel.CreerUneSauvegarde();
                    break;

                case 3: Console.WriteLine("choix de la modification de sauvegarde");
                    this.saveModel.ModifierSauvegarde();
                    break;

                case 4: Console.WriteLine("choix de la suppression de sauvegarde");
                    this.saveModel.SuppressionSauvegarde();
                    break;

                default:
                    this.saveView.Welcome();
                    break;
            }
        }
    }
}
