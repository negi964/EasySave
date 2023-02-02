using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Import des éléments du namespace EasySave
using EasySave.Model;
using EasySave.View;
using EasySave.View_Model;

namespace EasySave.Model
{
    public class SaveModel
    {
        public string Name { get; set; }
        public string SourceRepo { get; set; }
        public string DestinationRepo { get; set; } 
        public SaveType Type { get; set; }

        private SaveViewModel saveViewModel;
        public SaveModel(SaveViewModel saveViewModel)
        {
            this.saveViewModel = saveViewModel;
            Console.WriteLine("SaveModel chargé");
        }
    }
}
