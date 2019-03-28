using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net.Mime;
using System.Threading;
using System.Threading.Tasks;
using System.ServiceProcess;

namespace Synchronizer
{
    class Program
    {
        private static string PathToFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/AZ Software Development";
        private static string SourcePath;
        private static string DestinationPath;
        private static Stopwatch StopWatch = new Stopwatch();
        private static List<Element> DestinationList = new List<Element>();
        private static List<Element> SourceList = new List<Element>();
        private static bool FirstTime = false;
        private static bool StartedWork = false;

        static void Main(string[] args)
        {
            Process thisProcess = Process.GetCurrentProcess();

            thisProcess.PriorityClass = ProcessPriorityClass.RealTime;

            if (!Directory.Exists(PathToFolder))
            {
                Directory.CreateDirectory(PathToFolder);
                Directory.CreateDirectory(PathToFolder + "/Synchronizer");
            }
            PathToFolder = PathToFolder + "/Synchronizer";

            if (!File.Exists(PathToFolder + "/SynchronizerTarget.txt") && !File.Exists(PathToFolder + "/SynchronizerSource.txt"))
            {
                FirstTime = true;

                StreamWriter writerTarget = new StreamWriter(PathToFolder + "/SynchronizerTarget.txt");
                StreamWriter writerSource = new StreamWriter(PathToFolder + "/SynchronizerSource.txt");

                Console.Write("Bitte Pfad mit STRG+V zur Quelle angeben: ");
                SourcePath = Console.ReadLine();
                writerSource.WriteLineAsync(SourcePath);

                Console.Write("\nBitte auf die selbe Weise den Pfad zur Ordner wo es gesichert werden soll angeben :\n");
                DestinationPath = Console.ReadLine();
                writerTarget.WriteLineAsync(DestinationPath);

                writerSource.Flush();
                writerSource.Close();

                writerTarget.Flush();
                writerTarget.Close();
            }
            else
            {
                StreamReader readTarget = new StreamReader(PathToFolder + "/SynchronizerTarget.txt");
                StreamReader readSource = new StreamReader(PathToFolder + "/SynchronizerSource.txt");

                SourcePath = readSource.ReadLine();
                DestinationPath = readTarget.ReadLine();

                readSource.Close();
                readTarget.Close();
            }

            //TODO Insert here USB Connected Event

            CallCopyAsync();
            CallCountFilesAsync();

            Thread.Sleep(1000);
            Thread.Sleep(SourceList.Count*6000);
        }

        private static async void CallCountFilesAsync()
        {
            await Task.Run(() => CountToCopyFiles());
        }

        private static async void CallCopyAsync()
        {

            await Task.Run(() => CreateList());
            Thread.Sleep(6000);
            await Task.Run(() => CopyFiles());
        }

        private static void CreateList()
        {
            ListA();
            ListB();
        }

        private static async void ListA()
        {
            await Task.Run(() => CreateSourceList());
        }

        private static async void ListB()
        {
            await Task.Run(() => CreateDestList());
        }

        private static void CreateSourceList()
        {
            foreach (string file in Directory.GetFiles(SourcePath, "*.*", SearchOption.AllDirectories))
            {
                FileInfo fileInfo = new FileInfo(file);

                SourceList.Add(new Element(fileInfo.Name, fileInfo.FullName, true, fileInfo.LastWriteTime));
            }
        }

        private static void CreateDestList()
        {
            foreach (string file in Directory.GetFiles(DestinationPath, "*.*", SearchOption.AllDirectories))
            {
                FileInfo fileInfo = new FileInfo(file);

                DestinationList.Add(new Element(fileInfo.Name, fileInfo.FullName, false, fileInfo.LastWriteTime));
            }
        }

        private static void CountToCopyFiles()
        {
            bool preparement = false;
            Int32 fileCount = Directory.GetFiles(SourcePath, "*", SearchOption.AllDirectories).Length;

            Int32 alreadyCopied = 0;

            while (alreadyCopied != fileCount)
            {
                if (StartedWork)
                {
                    alreadyCopied = Directory.GetFiles(DestinationPath, "*", SearchOption.AllDirectories).Length;
                    Console.WriteLine(alreadyCopied + "/" + fileCount);
                    Thread.Sleep(10);
                }
                else if (!preparement)
                {
                    Console.WriteLine("Vorbereitungen werden getroffen.");
                    preparement = true;
                }
            }

            Console.WriteLine("Alles kopiert. Benötigte Zeit: " + StopWatch.Elapsed.Minutes + "." + StopWatch.Elapsed.Seconds + "." + StopWatch.Elapsed.Milliseconds + " Minuten");
        }

        private static void CopyFiles()
        {
            Process thisProcess = Process.GetCurrentProcess();
            thisProcess.PriorityClass = ProcessPriorityClass.RealTime;

            Console.Clear();

            List<Element> diffList = new List<Element>();

            foreach (string dirPath in Directory.GetDirectories(SourcePath, "*",
                SearchOption.AllDirectories))
                Directory.CreateDirectory(dirPath.Replace(SourcePath, DestinationPath));

            StopWatch.Start();
            StartedWork = true;

            if (!FirstTime && DestinationList.Count != 0)
            {
                foreach (Element element in SourceList)
                {
                    bool found = false;

                    foreach (Element elementos in DestinationList)
                    {
                        if (elementos.FileName == element.FileName)
                        {
                            found = true;
                        }
                    }

                    if (!found)
                    {
                        diffList.Add(element);
                    }
                }
                if (diffList.Count != 0)
                {
                    foreach (Element element in diffList)
                    {
                        File.Copy(element.PathTo, element.PathTo.Replace(SourcePath, DestinationPath));
                    }
                }
                else if (SourceList.Count > DestinationList.Count)
                {
                    for (int i = DestinationList.Count; i < SourceList.Count; i++)
                    {
                        File.Copy(SourceList[i].PathTo, DestinationPath);
                    }
                }
                else
                {
                    foreach (string s in Directory.GetFiles(SourcePath, "*.*",
                        SearchOption.AllDirectories))
                    {
                        File.Copy(s, s.Replace(SourcePath, DestinationPath));
                    }
                }
            }
            else
            {
                //Copy all the files & Replaces any files with the same name
                foreach (string newPath in Directory.GetFiles(SourcePath, "*.*",
                    SearchOption.AllDirectories))
                {
                    File.Copy(newPath, newPath.Replace(SourcePath, DestinationPath), true);
                }
            }

            StopWatch.Stop();
        }
    }
}
