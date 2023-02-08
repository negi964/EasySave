using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasySave.Model;
using EasySave.View;

namespace EasySave.View_Model
{
    public class DeleteViewModel
    {
        public DeleteModel deleteModel;
        public DeleteViewModel()
        {
            deleteModel = new DeleteModel();
        }

        public List<string> GetListConfig()
        {
            return deleteModel.GetListConfig();
        }

        public void SetNumConfigModel(int numConfig)
        {
            var message = deleteModel.DeleteSave(numConfig);
            if (message != null)
            {
                var error = new ErrorView();
                error.ShowError(message);
                var saveView = new SaveView();
                saveView.Welcome();
            }

        }
    }

    
}
