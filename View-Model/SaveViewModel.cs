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

        public SaveViewModel(SaveView saveView)
        {
            this.saveView = saveView;
            new SaveModel(this);
            Console.WriteLine("SaveViewModel chargé");
        }
    }
}
