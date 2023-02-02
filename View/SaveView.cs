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
        public SaveView()
        {
            new SaveViewModel(this);
        }
    }
}
