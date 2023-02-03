using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySave.Model
{
        public enum SaveType
        {
            Complete,
            Differential
        }
    public enum Lang
    {

        [Description ("English")]
        en,

        [Description("French")]
        fr

    }
}
