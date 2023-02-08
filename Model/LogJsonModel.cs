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
using System.Net;
using System.Xml.Linq;

namespace EasySave.Model
{
    public class LogJsonModel
    {
        public string Name { get; set; }
        public string FileSource { get; set; }

        public string FileTarget { get; set; }

        public int FileSize { get; set; }

        public int TransfertTime { get; set; }

        public string TimeStamp { get; set; }
            


        public Config Config { get; set; }




        public List<Config> ReadJsonConfig(string path)
        {
           
            string fileContent = File.ReadAllText(path);

            List<Config> JsonConfig = JsonConvert.DeserializeObject<List<Config>>(fileContent);
            return JsonConfig;
        }



        public void SaveLog(long filesize, float transfertTime)
        {
           
            //A CHANGER IMMEDIATEMENT !
            var listConfig = new List<Config>();
            listConfig = ReadJsonConfig("C:\\AppData\\Roaming\\backupconfigs.json");
            var listLog = new List<LogJsonModel>();

            if (!File.Exists("log.json"))
            {

                try
                {
                  
                    foreach (var config in listConfig)
                    {

                        listLog.Add(new LogJsonModel
                        {
                            Name = config.BackupName,
                            FileSource = config.SourceDirectory,
                            FileTarget = config.TargetDirectory,
                            FileSize = (int)filesize,
                            TransfertTime = (int)transfertTime,
                            TimeStamp = DateTime.Now.ToString(),
                        });
                    }

                    string logjson = JsonConvert.SerializeObject(listLog);
                    File.WriteAllText("log.json", logjson);


                }
                catch (Exception ex)
                {
                    Console.WriteLine("\nUne erreur s'est produite lors de l'enregistrement du log journalier: " + ex.Message);
                }
            }
            else
            {

                // Lire le fichier log.json existant
                var json = File.ReadAllText("log.json");

                // Désérialiser le JSON en objet C#
                var log = JsonConvert.DeserializeObject<List<LogJsonModel>>(json);

                // Ajouter un nouvel objet à la liste
                log.Add(new LogJsonModel
                {
                    Name = Config.BackupName,
                    FileSource = Config.SourceDirectory,
                    FileTarget = Config.TargetDirectory,
                    FileSize = (int)filesize,
                    TransfertTime = TransfertTime,
                    TimeStamp = DateTime.Now.ToString()
                });

                // Sérialiser l'objet mis à jour en JSON
                var updatedJson = JsonConvert.SerializeObject(log, Formatting.Indented);

                // Écrire le JSON mis à jour dans le fichier
                File.WriteAllText("log.json", updatedJson);
            }



        }
    }

}
