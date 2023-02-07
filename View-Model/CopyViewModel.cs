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

        public void GetCopyModel(string source, string destination)
        {
            var copyModel = new CopyModel();
            copyModel.FullCopy(source, destination);
        }
    }
}
