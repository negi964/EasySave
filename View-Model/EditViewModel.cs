﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasySave.Model;
using EasySave.View;

namespace EasySave.View_Model
{
    public class EditViewModel
    {
        private EditModel editModel;
        public EditViewModel()
        {
            var editModel = new EditModel();
        }

        public void GetEditModel(string newBackupName, string newSourceDirectory, string newTargetDirectory, string newBackupType, int configToModify)
        {
            //var editModel = new EditModel();
            var message = editModel.EditSave(newBackupName, newSourceDirectory, newTargetDirectory, newBackupType, configToModify);
            if (message != null)
            {
                var error = new ErrorView();
                error.ShowError(message);
                GetEditModel(newBackupName, newSourceDirectory, newTargetDirectory, newBackupType, configToModify);
            }
        }

        public void GetListConfig()
        {
            var message = editModel.GetListConfigToModify();
            if (message != null)
            {
                var error = new ErrorView();
                error.ShowError(message);
            }
        }
    }
}
