﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//NewtonsoftJson
using NewtonsoftJson = Newtonsoft.Json;
//serialisation
using System.IO;
using System.IO.Compression;
using System.Runtime.Serialization.Formatters.Binary;
using static EasySave.Model.SaveModel;
using Newtonsoft.Json;
using System.Security.Principal;
using System.Net;
using System.Xml.Linq;
using System.Reflection;
using System.Globalization;

namespace EasySave.Model
{
    public class LogJsonModel
    {
        LangHelper langHelper = new LangHelper();
        public string Name { get; set; }
        public string FileSource { get; set; }

        public string FileTarget { get; set; }

        public int FileSize { get; set; }

        public double TransfertTime { get; set; }

        public string TimeStamp { get; set; }
            

        public List<string> GetConfigFile(string path)
        {
            string fileContent = File.ReadAllText(path);

            List<Config> JsonConfig = JsonConvert.DeserializeObject<List<Config>>(fileContent);
            List<string> ConfigFiles = new List<string>();
            foreach(var config in JsonConfig)
            {
                ConfigFiles.Add($"{config.BackupName},\n Source : {config.SourceDirectory},\n Destination : {config.TargetDirectory}, \n Type : {config.BackupType}\n");
            }
            return ConfigFiles;
        }
        public Config ReadJsonConfig(string path, int index)
        {
           
            string fileContent = File.ReadAllText(path);

            List<Config> JsonConfig = JsonConvert.DeserializeObject<List<Config>>(fileContent);
            var obj = JsonConfig[index];
            return obj;
        }



        public void SaveLog(long filesize, double transfertTime,Config config)
        {
           
            //A CHANGER IMMEDIATEMENT !
            string backupConfigFile = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Easysave";
            string file = Path.Combine(backupConfigFile, "config.json");
            var listLog = new List<LogJsonModel>();

            if (!File.Exists("log.json"))
            {

                try
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

                    string logjson = JsonConvert.SerializeObject(listLog);
                    File.WriteAllText("log.json", logjson);


                }
                catch (Exception ex)
                {
                    Console.Write($"{langHelper._rm.GetString("Error Daily Logs", CultureInfo.CurrentUICulture)}" + ex.Message);
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
                    Name = config.BackupName,
                    FileSource = config.SourceDirectory,
                    FileTarget = config.TargetDirectory,
                    FileSize = (int)filesize,
                    TransfertTime = transfertTime,
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
