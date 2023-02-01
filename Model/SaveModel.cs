using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasySave.Model.Enums;

namespace EasySave.Model
{
    public class SaveModel
    {
        public string Name { get; set; }
        public string SourceRepo { get; set; }
        public string DestinationRepo { get; set; } 
        public SaveType Type { get; set; }
    }
}
