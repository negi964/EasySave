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
using System.Security.Cryptography.X509Certificates;



namespace EasySave.View_Model
{
    public class SaveViewModel
    {
        private SaveView _saveView;
        private int _numOption;
        private SaveModel _saveModel;
        private CopyView _copyView;

        public SaveViewModel(SaveView saveView)
        {
            _saveView = saveView;
            _saveModel = new SaveModel(this);
            _copyView = new CopyView();
            
            
            _numOption = Int32.Parse(saveView.numOption);

            switch (_numOption)
            {
                case 1: Console.WriteLine("choix du changement de langue");
                    break;
                case 2: Console.WriteLine("choix de la création de sauvegarde");
                    _saveModel.CreateSave();
                    break;

                case 3: Console.WriteLine("choix de la modification de sauvegarde");
                    _saveModel.EditSave();
                    break;

                case 4: Console.WriteLine("choix de la suppression de sauvegarde");
                    _saveModel.DeleteSave();
                    break;

                case 5: Console.WriteLine("Lancement d'une sauvegarde");
                    _copyView.Show();
                    break;

                default:
                    saveView.Welcome();
                    break;
            }
        }
    }
}
