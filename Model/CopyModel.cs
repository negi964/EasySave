﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace EasySave.Model
{
    public class CopyModel
    {
        public void FullCopy(Config config)
        {
            string sourceFile = config.SourceDirectory;
            string targetFile = config.TargetDirectory;
            Stopwatch watch = new Stopwatch();
            watch.Start();
            if (sourceFile != null)
            {
                var dir = new DirectoryInfo(sourceFile);

                if (!dir.Exists)
                {


                    var fileinfo = new FileInfo(sourceFile);
                    string filename = Path.GetFileName(sourceFile);
                    var fileSize = fileinfo.Length;
                    targetFile = Path.Combine(targetFile, filename);
                    if (!fileinfo.Exists)
                        throw new FileNotFoundException($"{sourceFile} does not exist");
                    using (var source = new FileStream(sourceFile, FileMode.Open, FileAccess.Read))
                    {
                        using (var target = new FileStream(targetFile, FileMode.Create, FileAccess.Write))
                        {
                            // Allocation d'un buffer de lecture de 4 Ko
                            var buffer = new byte[4096];
                            int bytesRead;
                            int totalBytes = 0;

                            // Boucle de lecture et d'écriture
                            while ((bytesRead = source.Read(buffer, 0, buffer.Length)) > 0)
                            {
                                target.Write(buffer, 0, bytesRead);
                                totalBytes += bytesRead;

                                // Calcul de la progression
                                var progress = (int)((totalBytes / (double)fileSize) * 100);

                                // Affichage de la barre de progression
                                Console.Write("\r{0}% [{1}{2}]", progress, new string('#', progress), new string(' ', 100 - progress));
                            }
                        }
                    }
                    watch.Stop();
                    double timeElapsed = watch.Elapsed.TotalSeconds;
                    var logJsonModel = new LogJsonModel();
                    logJsonModel.SaveLog(fileSize, timeElapsed, config);

                }

                else
                {

                    var sourceFolderInfo = new DirectoryInfo(sourceFile);
                    long totalSize = GetDirectorySize(sourceFolderInfo);
                    long totalBytes = 0;
                    CopyDirectory(sourceFolderInfo, targetFile, totalSize, totalBytes);
                    watch.Stop();
                    double timeElapsed = watch.Elapsed.TotalSeconds;
                    var logJsonModel = new LogJsonModel();
                    logJsonModel.SaveLog(totalSize, timeElapsed, config);
                }

            }
        }

        private static void CopyDirectory(DirectoryInfo sourceDirectoryInfo, string targetFolder, long totalSize, long totalBytes)
        {
            // Création du dossier cible s'il n'existe pas
            Directory.CreateDirectory(targetFolder);


            // Boucle de copie des fichiers
            foreach (var fileInfo in sourceDirectoryInfo.GetFiles())
            {
                var sourceFile = fileInfo.FullName;
                var targetFile = Path.Combine(targetFolder, fileInfo.Name);

                // Copie du fichier
                using (var source = new FileStream(sourceFile, FileMode.Open, FileAccess.Read))
                {
                    using (var target = new FileStream(targetFile, FileMode.Create, FileAccess.Write))
                    {
                        var buffer = new byte[4096];
                        int bytesRead;

                        while ((bytesRead = source.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            target.Write(buffer, 0, bytesRead);
                            totalBytes += bytesRead;

                            // Calcul de la progression
                            var progress = (int)((totalBytes / (double)totalSize) * 100);

                            // Affichage de la barre de progression
                            Console.Write("\r{0}% [{1}{2}]", progress, new string('#', progress), new string(' ', 100 - progress));

                        }
                    }
                }
            }
            foreach (DirectoryInfo subDir in sourceDirectoryInfo.GetDirectories())
            {
                string newDestinationDir = Path.Combine(targetFolder, subDir.Name);
                CopyDirectory(subDir, newDestinationDir, totalSize, totalBytes);
            }
        }
        private static long GetDirectorySize(DirectoryInfo directoryInfo)
        {
            long size = 0;

            // Récuperation de la taille des fichiers dans le dossier
            foreach (var fileInfo in directoryInfo.GetFiles())
            {
                size += fileInfo.Length;
            }

            // Récuperation de la taille des sous-dossiers récursivement
            foreach (var subDirectoryInfo in directoryInfo.GetDirectories())
            {
                size += GetDirectorySize(subDirectoryInfo);
            }

            return size;
        }
        public void DifferentialCopy(Config config)
        {
            string sourceFolder = config.SourceDirectory;
            string targetFolder = config.TargetDirectory;
            foreach (var fileInfo in new DirectoryInfo(sourceFolder).GetFiles())
            {
                var sourceFile = fileInfo.FullName;
                var targetFile = Path.Combine(targetFolder, fileInfo.Name);

                // Vérification date dernière modification du fichier
                var sourceLastWriteTime = File.GetLastWriteTime(sourceFile);
                if (File.Exists(targetFile))
                {
                    var targetLastWriteTime = File.GetLastWriteTime(targetFile);
                    if (sourceLastWriteTime <= targetLastWriteTime)
                    {
                        continue;
                    }
                }

                File.Copy(sourceFile, targetFile, true);
            }
        }
    }
}
