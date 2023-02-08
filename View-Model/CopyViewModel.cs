using EasySave.Model;
using EasySave.View;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySave.View_Model
{
    public class CopyViewModel
    {
        public CopyViewModel()
        {
        }

        public void GetCopyModel(string source, string destination, int type)
        {

            
                
            var copyModel = new CopyModel();
            switch (type)
            {
                case 1:
                    copyModel.FullCopy(source, destination);
                    break;
                case 2:
                    copyModel.DifferentialCopy(source, destination);
                    break;
            }
        }
    }
}
