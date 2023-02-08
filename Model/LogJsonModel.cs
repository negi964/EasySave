using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//NewtonsoftJson
using NewtonsoftJson = Newtonsoft.Json;
using EasySave.Model;
//serialisation
using System.IO;
using System.IO.Compression;
using System.Runtime.Serialization.Formatters.Binary;
using static EasySave.Model.SaveModel;
using Newtonsoft.Json;
using System.Security.Principal;

namespace EasySave.Model
{
    public class LogJsonModel
    {
        public string Name { get; set; }
        public DateTime TimeStamp { get; set; }
        public string FileSource { get; set; }
        public string FileTarget { get; set; }
        public float FileSize  { get; set; }
        public int TransfertTime { get; set;}

        public Config config { get; set; }

        public LogJsonModel() { }

        public LogJsonModel(string name, string fileSource, string fileTarget, float fileSize, int transfertTime)
        {
            name = config.BackupName;
             TimeStamp = DateTime.Now;
            FileSource = config.SourceDirectory;
            FileTarget = config.TargetDirectory;
            FileSize = fileSize;
            TransfertTime = transfertTime;
        }

        public Config ReadJsonConfig(string path)
        {
            string fileContent = File.ReadAllText(path);

            Config JsonConfig = JsonConvert.DeserializeObject<Config>(fileContent);
            return JsonConfig;
        }
        
        

        public void savelog(Config config)
        {
            
            try
            {
                using (StreamWriter writer = new StreamWriter(FileTarget))
                {
                    string logjson = ("Name : " +Name + "\n FileSource : " +FileSource + "\n FileTarget : " + FileTarget + "\n FileSize :"+FileSize + "\n TransfertTime :"+TransfertTime); 
                     writer.WriteLine(logjson);
                }
            
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nUne erreur s'est produite lors de l'enregistrement du log journalier: " + ex.Message);
            }

        }
    }

}
