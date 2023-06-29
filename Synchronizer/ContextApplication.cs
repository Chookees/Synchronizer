using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Log = AZLog.Logger;
using Dic = AZDictionary.Dictionary;
using Type = AZLog.Type;

namespace az.Synchronizer
{
    public class ContextApplication : ApplicationContext
    {
        private NotifyIcon notifyIcon;
        private int filesToCopied = 0;
        private double sizeOfFiles = 0;
        private double sizeOfFilesInByte = 0;
        private bool skipOnYes = false;
        private double onePercentFinished = 0;
        private double currentStatusOfCopy = 0;

        private ConfigWindow configWindow;

        public ContextApplication()
        {
            Initialize();

            Functions.GetConfigStrings();
            Functions.ReadSettingsFile();

            Log.Log("ContextApplication" + ".ContextApplication", "Initializing ContextApplication.");
            // Initialize Tray Icon
            notifyIcon = new NotifyIcon()
            {
                Icon = new Icon("Properties\\sync.ico"),
                ContextMenu = new ContextMenu(new MenuItem[] {
                    new MenuItem("Start Backup", StartBackup),
                    new MenuItem("Configuration", Configuration),
                    new MenuItem("Open Log", OpenLog),
                    new MenuItem("Exit", Exit)
                }),
                Visible = true
            };

            configWindow = new ConfigWindow();
            Log.Log("ContextApplication.ContextApplication", "Initialization complete. Now waiting for events.");
        }

        void StartBackup(object sender, EventArgs e)
        {
            Log.Log("ContextApplication", "Initiate backup process..", Type.Loading);

            bool pathsAreOk = true;
            skipOnYes = false;

            int filesThatChanged = 0;
            int fileDiff = 0;

            Stopwatch stopWatch = new Stopwatch();

            stopWatch.Start();
            string sourcePath = Functions.GetValueFromDictionary("src");
            string destinationPath = Functions.GetValueFromDictionary("trgt");

            DirectoryInfo sourceInfo = null;
            DirectoryInfo destinationInfo = null;

            if (DirectoryExistCheck(sourcePath))
            {
                sourceInfo = new DirectoryInfo(sourcePath);
            }
            else
            {
                pathsAreOk = false;
            }

            if (DirectoryExistCheck(destinationPath))
            {
                destinationInfo = new DirectoryInfo(destinationPath);
            }
            else
            {
                pathsAreOk = false;
            }

            if (pathsAreOk)
            {
                Log.Log("ContextApplication.StartBackup", "Calling SynDirectories()", Type.Processing);
                Log.Log("ContextApplication.StartBackup", "Calculating size and files of Backup");
                this.GetFileStats(sourceInfo, destinationInfo);
                Log.Log("ContextApplication.StartBackup", "Calculating complete");

                string sizeOfFilesFormatted = Functions.GetSizeOfFilesFormatted(sizeOfFiles, 0);
                sizeOfFilesInByte = sizeOfFiles;

                onePercentFinished = sizeOfFilesInByte / 100;

                string[] splittedSize = sizeOfFilesFormatted.Split(':');

                sizeOfFiles = Convert.ToDouble(splittedSize[0]);

                Log.Log("ContextApplication.StartBackup", "Backup size: " + sizeOfFiles + " " + splittedSize[1] + ".");
                Log.Log("ContextApplication.StartBackup", "Files to back up: " + filesToCopied);

                if (sizeOfFiles > 10 && splittedSize[1] == "GB" || splittedSize[1] == "TB")
                {
                    Log.Log("ContextApplication.StartBackup", "Size of backup exceeds the safe limit of 10GB!", Type.Warning);

                    if (Functions.ShowSizeWarning)
                    {
                        if (MessageBox.Show("Backup size is " + sizeOfFiles + splittedSize[1] + ".\nThis exceeds the recommended limit of 10GB. This can lead to a longer than average duration of the backup.\nDo you want to continue?", "Warning", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            skipOnYes = true;
                            Log.Log("ContextApplication.StartBackup", "Backup starts anyway. User clicked {Yes}.", Type.Processing);
                        }
                        else
                        {
                            Log.Log("ContextApplication.StartBackup", "Backup will be skipped. User clicked {No}.",
                                Type.Processing);
                        }
                    }
                }

                if (skipOnYes)
                {
                    SyncDirectories(sourceInfo, destinationInfo);
                }
            }

            stopWatch.Stop();
            Log.Log("ContextApplication.StartBackup", "Synchronization completed.", Type.Success);
            Log.Log("ContextApplication.StartBackup", "Ran for { " + stopWatch.Elapsed.Minutes + "min " + stopWatch.Elapsed.Seconds + "sec }.");

            // Reset variables.
            filesToCopied = 0;
            sizeOfFiles = 0;
            skipOnYes = false;
            currentStatusOfCopy = 0;
        }

        private void SyncDirectories(DirectoryInfo srcDir, DirectoryInfo trgtDir)
        {
            foreach (FileInfo file in srcDir.GetFiles())
            {
                FileInfo trgtFile = new FileInfo(Path.Combine(trgtDir.FullName, file.Name));

                // Check if the file exists in the destination directory and if it is older than the source file.
                if (trgtFile.Exists && trgtFile.LastWriteTime < file.LastWriteTime)
                {
                    Log.Log("File Sync", "old file synced: " + file.Name + " -Size: " + Functions.GetSizeOfFilesFormatted(file.Length, 0).Replace(":", ""), Type.Processing);

                    Log.Log("Current Status of Backup", CalculateProgress(file.Length)+"%");;
                    // Overwrite file in destination directory.
                    File.Copy(file.FullName, trgtFile.FullName, true);
                }
                else if (!trgtFile.Exists)
                {
                    Log.Log("File Copy", "File copied: " + file.Name+" -Size: "+Functions.GetSizeOfFilesFormatted(file.Length, 0).Replace(":",""), Type.Processing);

                    Log.Log("Current Status of Backup", CalculateProgress(file.Length) + "%"); ;
                    // First time copy of file.
                    File.Copy(file.FullName, trgtFile.FullName, true);
                }
            }

            foreach (DirectoryInfo sourceSubDir in srcDir.GetDirectories())
            {
                Log.Log("Recursive Call", "Subfolder detected: " + sourceSubDir.FullName);
                DirectoryInfo targetSubDir = trgtDir.CreateSubdirectory(sourceSubDir.Name);
                SyncDirectories(sourceSubDir, targetSubDir);
            }
        }

        private double CalculateProgress(double sizeOfFile)
        {
            return Math.Round(currentStatusOfCopy += sizeOfFile / onePercentFinished, 0);
        }

        private void GetFileStats(DirectoryInfo rootDir, DirectoryInfo trgtDir)
        {
            foreach (FileInfo file in rootDir.GetFiles())
            {
                FileInfo trgtFile = new FileInfo(Path.Combine(trgtDir.FullName, file.Name));
                if (trgtFile.Exists && trgtFile.LastWriteTime < file.LastWriteTime)
                {
                    sizeOfFiles += file.Length;
                    filesToCopied++;
                }
                else if (!trgtFile.Exists)
                {
                    sizeOfFiles += file.Length;
                    filesToCopied++;
                }
            }

            foreach (DirectoryInfo sourceSubDir in rootDir.GetDirectories())
            {
                DirectoryInfo targetSubDir = trgtDir.CreateSubdirectory(sourceSubDir.Name);
                GetFileStats(sourceSubDir, targetSubDir);
            }
        }


        private bool DirectoryExistCheck(string path)
        {
            if (Directory.Exists(path))
            {
                return true;
            }
            else
            {
                Log.Log("ContextApplication.DirectoryExistCheck", "Directory '" + path + "' does not exist!", Type.Warning);
                MessageBox.Show("The Path: " + path + " does not exist. Please check it and try again.", path + " does not exist.",
                    MessageBoxButtons.OK);
                Configuration(null, null);
                return false;
            }
        }

        #region Contextmenu items

        void OpenLog(object sender, EventArgs e)
        {
            Log.Log("ContextApplication" + ".OpenLog", "Opening Logfile", Type.Opening);
            Process.Start(Dic.SyncLogFile);
        }

        void Configuration(object sender, EventArgs e)
        {
            Log.Log("ContextApplication" + ".Configuration", "Starting the Configuration page.", Type.Opening);
            configWindow.Show();
        }

        void Exit(object sender, EventArgs e)
        {
            // We must manually tidy up and remove the icon before we exit.
            // Otherwise it will be left behind until the user mouses over.
            Log.Log("ContextApplication" + ".Exit", "Closing the Application.", Type.Closing);
            notifyIcon.Visible = false;
            Application.Exit();
        }

        #endregion

        /// <summary>
        /// Initializes the ContextApplication.
        /// </summary>
        private void Initialize()
        {
            if (!File.Exists(Dic.SyncConfigFile))
            {
                foreach (string path in Dic.SynchronizerPaths)
                {
                    Directory.CreateDirectory(path);
                }
            }

            Log.CallOnStart(Dic.SyncLogFile);

            Log.Log("ContextApplication" + ".Initialize", "Check if Config file exists.");
            if (!File.Exists(Dic.SyncConfigFile))
            {
                Log.Log("ContextApplication" + ".Initialize", "Config file does not exist.");
                SetUpWindow setup = new SetUpWindow();
                setup.Show();
            }
            else
            {
                Log.Log("ContextApplication" + ".Initialize", "Config file exists.");
            }
        }
    }
}
