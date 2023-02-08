using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasySave.Model;
using EasySave.View;

namespace EasySave.View_Model
{
    public class CreateViewModel
    {
        public CreateViewModel()
        {
        }

        public void GetCreateModel(string backupName, string sourceDirectory, string targetDirectory, string backupType)
        {
            var createModel = new CreateModel();
            var message = createModel.CreateSave(backupName, sourceDirectory, targetDirectory, backupType);
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
