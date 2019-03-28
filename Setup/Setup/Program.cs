using System;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace Setup
{
    class Program
    {
        static void Main(string[] args)
        {
            Start();
        }

        private static void Start()
        {
            string pathToDocuments = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) +
                                     "/AZ Software Development";

            string[] settings = new string[2];

            settings[0] = "StartWithUSB:false";
            settings[1] = "ShowProgession:false";

            if (!Directory.Exists(pathToDocuments))
            {
                Console.WriteLine("Creating folder 'AZ Software Development' in Documents");
                Directory.CreateDirectory(pathToDocuments);
            }
            if (!Directory.Exists(pathToDocuments + "/Synchronizer"))
            {
                Console.WriteLine("Creating folder 'Synchronizer'");
                Directory.CreateDirectory(pathToDocuments + "/Synchronizer");
                
            }
            pathToDocuments += "/Synchronizer";

            if (!Directory.Exists(pathToDocuments+"/Setup") || !Directory.Exists(pathToDocuments + "/ReadMe") || !Directory.Exists(pathToDocuments + "/Log") || !Directory.Exists(pathToDocuments + "/Settings"))
            {
                Console.WriteLine("Creating folders 'Setup', 'ReadMe', 'Log', 'Settings'");
                Directory.CreateDirectory(pathToDocuments + "/Setup");
                Directory.CreateDirectory(pathToDocuments + "/ReadMe");
                Directory.CreateDirectory(pathToDocuments + "/Log");
                Directory.CreateDirectory(pathToDocuments + "/Settings");
            }

            StreamWriter settingsWriter;

            if (!File.Exists(pathToDocuments+"/Settings/Settings.cfg"))
            {
                Console.WriteLine("Creating file 'Settings.cfg'");
                settingsWriter = new StreamWriter(pathToDocuments + "/Settings/Settings.cfg");
                Thread.Sleep(1500);

                if (new FileInfo(pathToDocuments + "/Settings/Settings.cfg").Length == 0)
                {
                    Console.WriteLine("Writing default values to Setting.cfg");
                    foreach (string setting in settings)
                    {
                        settingsWriter.WriteLine(setting);
                    }
                }

                settingsWriter.Flush();
                settingsWriter.Close();
            }

            StreamWriter writerSource = new StreamWriter(pathToDocuments + "/SynchronizerSource.txt",true);
            StreamWriter writerTarget = new StreamWriter(pathToDocuments + "/SynchronizerTarget.txt",true);

            string source = string.Empty;
            string target = string.Empty;

            if (File.Exists(pathToDocuments + "/SynchronizerSource.txt") && File.Exists(pathToDocuments + "/SynchronizerTarget.txt"))
            {
                if (new FileInfo(pathToDocuments + "/SynchronizerSource.txt").Length == 0 || new FileInfo(pathToDocuments + "/SynchronizerTarget.txt").Length == 0)
                {
                    Console.Write("Bitte Pfad zur Quelle angeben: ");
                    source = Console.ReadLine();

                    Console.Write("\nBitte nun Pfad zum Ziel angeben: ");
                    target = Console.ReadLine();

                    Console.WriteLine("Creating 'SynchronizerSource.txt' and 'SynchronizerTarget.txt'");
                }
            }

            writerSource.WriteLine(source);
            writerTarget.WriteLine(target);
            Thread.Sleep(200);

            writerTarget.Flush();
            writerSource.Flush();

            writerTarget.Close();
            writerSource.Close();

            Console.WriteLine("Initialize Setup..");
            Thread.Sleep(2000);
            string path = "/Files/setup.exe";

            try
            {
                Process.Start(Environment.CurrentDirectory+path);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }

            File.Copy("Setup.exe",pathToDocuments+"/Setup/Setup.exe",true);
            File.Copy("ReadMe.txt",pathToDocuments+"/ReadMe/ReadMe.txt",true);
            File.Copy("ChangeLog.txt", pathToDocuments + "/ReadMe/ChangeLog.txt", true);

            Thread.Sleep(7000);
            Console.WriteLine("Das Setup ist abgeschlossen. Drücken Sie eine beliebige Taste um dieses Fenster zu schließen.");
            Console.ReadKey();
        }
    }
}
