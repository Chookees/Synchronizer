using System;
using System.IO;
using System.IO.Compression;
using System.Windows.Forms;
using AZDictionary;
using AZLog;

namespace az.Synchronizer
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            DirectoryInfo logDirectory = new DirectoryInfo(Dictionary.SyncRoot + "archive.log");

            if (File.Exists(Dictionary.SyncLogFile))
            {
                if (!Directory.Exists(Dictionary.SyncRoot + "archive.log"))
                {
                    Directory.CreateDirectory(Dictionary.SyncRoot + "archive.log");
                }

                File.Copy(Dictionary.SyncLogFile, Dictionary.SyncRoot + "archive.log\\" + DateTime.Today.Day + "-" + DateTime.Today.Month + "-" + DateTime.Today.Year + " log.log", true);
                File.Delete(Dictionary.SyncLogFile);

                if (logDirectory.GetFiles().Length > 4)
                {
                    ZipFile.CreateFromDirectory(logDirectory.FullName, logDirectory.FullName + "\\" + DateTime.Today.Date + " logs.zip");
                }
            }

            if (!Directory.Exists(Dictionary.SyncRoot))
            {
                Directory.CreateDirectory(Dictionary.SyncRoot);
            }

            Logger.CallOnStart(AZDictionary.Dictionary.SyncLogFile);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ContextApplication());
        }
    }
}
