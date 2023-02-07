﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySave.Model
{
    public class Config
    {
        public string BackupName { get; set; }
        public string SourceDirectory { get; set; }
        public string TargetDirectory { get; set; }
        public string BackupType { get; set; }
    }
}
