using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Import des éléments du namespace EasySave
using EasySave.View;

namespace EasySave
{ 
    class Startup
    {
        static void Main(string[] args)
        {
            new SaveView();
            Console.WriteLine("SaveView chargé");
        }
    }
}