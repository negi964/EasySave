using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasySave.View_Model;

namespace EasySave.View
{
    public class DeleteView
    {

        public void Show()
        {
            var deleteViewModel = new DeleteViewModel();
            List<string> listConfig;
            
            listConfig = deleteViewModel.GetListConfig();

            foreach (string x in listConfig)
            {
                Console.WriteLine(x);
            }

            Console.Write("Quelle configuration souhaitez-vous supprimer : ");

            int numConfig = Int32.Parse(Console.ReadLine());

            deleteViewModel.SetNumConfigModel(numConfig);
        }
    }
}
