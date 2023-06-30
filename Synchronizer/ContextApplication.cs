using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Threading;
using System.Windows.Forms;
using Microsoft.WindowsAPICodePack.Taskbar;
using Synchronizer.ProgressWindow;
using Log = AZLog.Logger;
using Dic = AZDictionary.Dictionary;
using Type = AZLog.Type;

namespace az.Synchronizer
{
    public class ContextApplication : ApplicationContext
    {
        private NotifyIcon notifyIcon;
        private int filesToCopy = 0;
        private double sizeOfFiles = 0;
        private double sizeOfFilesInByte = 0;
        private bool cancelBackupBecauseOfWarning = false;
        private double alreadyCopiedBytes = 0;

        private ConfigWindow configWindow;
        private ProgressWindow progressWindow;

        private List<object> allObjects = new List<object>();

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
                    new MenuItem("Report Issue", ReportIssue),
                    new MenuItem("Exit", Exit)
                }),
                Visible = true,
            };

            notifyIcon.MouseDoubleClick += NotifyIcon_BalloonTipClicked;

            progressWindow = new ProgressWindow();
            progressWindow.Icon = new Icon("Properties\\sync.ico");

            configWindow = new ConfigWindow();
            Log.Log("ContextApplication.ContextApplication", "Initialization complete. Now waiting for events.");

            allObjects.Add(configWindow);
            allObjects.Add(progressWindow);
            allObjects.Add(this);
            allObjects.Add(notifyIcon);
        }

        private void NotifyIcon_BalloonTipClicked(object sender, EventArgs e)
        {
            configWindow.Show();
        }

        void StartBackup(object sender, EventArgs e)
        {
            Log.Log("ContextApplication", "Initiate backup process..", Type.Loading);

            bool pathsAreOk = true;
            cancelBackupBecauseOfWarning = true;

            Stopwatch stopWatch = new Stopwatch();
            allObjects.Add(stopWatch);
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
                Log.Log("ContextApplication.StartBackup", "Calling SyncDirectories()", Type.Processing);
                Log.Log("ContextApplication.StartBackup", "Calculating size and files of Backup");
                Stopwatch calculaterWatch = Stopwatch.StartNew();
                this.GetFileStats(sourceInfo, destinationInfo);
                calculaterWatch.Stop();
                allObjects.Add(calculaterWatch);
                Log.Log("ContextApplication.StartBackup", "Calculating complete took { "+calculaterWatch.Elapsed.Seconds+"sec "+calculaterWatch.Elapsed.Milliseconds+"ms }");

                sizeOfFilesInByte = sizeOfFiles;

                string sizeOfFilesFormatted = Functions.GetSizeOfFilesFormatted(sizeOfFiles, 0);

                string[] splittedSize = sizeOfFilesFormatted.Split(':');

                sizeOfFiles = Convert.ToDouble(splittedSize[0]);

                Log.Log("ContextApplication.StartBackup", "Backup size: " + sizeOfFiles + " " + splittedSize[1] + ".");
                Log.Log("ContextApplication.StartBackup", "Files to back up: " + filesToCopy);

                if (sizeOfFiles > 10 && splittedSize[1] == "GB" || splittedSize[1] == "TB")
                {
                    Log.Log("ContextApplication.StartBackup", "Size of backup exceeds the safe limit of 10GB!", Type.Warning);

                    if (Functions.ShowSizeWarning)
                    {
                        if (MessageBox.Show("Backup size is " + sizeOfFiles + splittedSize[1] + ".\nThis exceeds the recommended limit of 10GB. This can lead to a longer than average duration of the backup.\nDo you want to continue?", "Warning", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            cancelBackupBecauseOfWarning = false;
                            Log.Log("ContextApplication.StartBackup", "Backup starts anyway. User clicked {Yes}.", Type.Processing);
                        }
                        else
                        {
                            Log.Log("ContextApplication.StartBackup", "Backup will be skipped. User clicked {No}.",
                                Type.Processing);
                            cancelBackupBecauseOfWarning = true;
                        }
                    }
                    else
                    {
                        cancelBackupBecauseOfWarning = false;
                    }
                }

                if (!cancelBackupBecauseOfWarning || !Functions.ShowSizeWarning)
                {
                    if (Functions.ShowCurrentStatusProgressWindow)
                    {
                        this.progressWindow.Show();
                    }
                    SyncDirectories(sourceInfo, destinationInfo);
                    if (Functions.ShowCurrentStatusProgressWindow)
                    {
                        this.progressWindow.Close();
                        this.progressWindow = new ProgressWindow();
                        progressWindow.Icon = new Icon("Properties\\sync.ico");
                    }
                }
            }

            stopWatch.Stop();
            Log.Log("ContextApplication.StartBackup", "Synchronization completed.", Type.Success);
            Log.Log("ContextApplication.StartBackup", "Ran for { " + stopWatch.Elapsed.Minutes + "min " + stopWatch.Elapsed.Seconds + "sec }.");

            // Reset variables.
            filesToCopy = 0;
            sizeOfFiles = 0;
            cancelBackupBecauseOfWarning = false;
            alreadyCopiedBytes = 0;

            // Cleanup everything once finished.
            System.GC.Collect();
        }

        private void SyncDirectories(DirectoryInfo srcDir, DirectoryInfo trgtDir)
        {
            try
            {
                foreach (FileInfo file in srcDir.GetFiles())
                {
                    FileInfo trgtFile = new FileInfo(Path.Combine(trgtDir.FullName, file.Name));
                    // Check if the file exists in the destination directory and if it is older than the source file.
                    if (trgtFile.Exists && trgtFile.LastWriteTime < file.LastWriteTime)
                    {
                        // Overwrite file in destination directory.
                        File.Copy(file.FullName, trgtFile.FullName, true);
                        alreadyCopiedBytes += file.Length;
                        int currentProgress = CalculateProgress(alreadyCopiedBytes, sizeOfFilesInByte);

                        Log.Log("File Sync", "old file synced: " + file.Name + " -Size: " + Functions.GetSizeOfFilesFormatted(file.Length, 0).Replace(":", ""), Type.Processing);

                        Log.Log("Current Status of Backup", currentProgress + "%");
                        Log.Log("Current Status of Backup", alreadyCopiedBytes + "B / " + sizeOfFilesInByte+"B");

                        if (Functions.ShowCurrentStatusProgressWindow)
                        {
                            TaskbarManager.Instance.SetProgressValue(currentProgress, 100);
                            progressWindow.Text = "Progress: " + currentProgress.ToString() + "%";
                        }
                    }
                    else if (!trgtFile.Exists)
                    {
                        // First time copy.
                        File.Copy(file.FullName, trgtFile.FullName, true);
                        alreadyCopiedBytes += file.Length;
                        int currentProgress = CalculateProgress(alreadyCopiedBytes, sizeOfFilesInByte);

                        Log.Log("File Copy", "File copied: " + file.Name + " -Size: " + Functions.GetSizeOfFilesFormatted(file.Length, 0).Replace(":", ""), Type.Processing);

                        Log.Log("Current Status of Backup", currentProgress+ "%");
                        Log.Log("Current Status of Backup", alreadyCopiedBytes + "B / " + sizeOfFilesInByte+"B");

                        if (Functions.ShowCurrentStatusProgressWindow)
                        {
                            TaskbarManager.Instance.SetProgressValue(currentProgress, 100);
                            progressWindow.Text = "Progress: " + currentProgress.ToString() + "%";
                        }
                    }
                }

                foreach (DirectoryInfo sourceSubDir in srcDir.GetDirectories())
                {
                    Log.Log("Recursive Call", "Subfolder detected: " + sourceSubDir.FullName);
                    DirectoryInfo targetSubDir = trgtDir.CreateSubdirectory(sourceSubDir.Name);
                    SyncDirectories(sourceSubDir, targetSubDir);
                }
            }
            catch (Exception e)
            {
                Log.ExLog(e);
            }
        }

        private int CalculateProgress(double copied, double sizeOfFiles)
        {
            return Convert.ToInt32(Math.Round((alreadyCopiedBytes / sizeOfFilesInByte) * 100.0));
        }

        private void GetFileStats(DirectoryInfo rootDir, DirectoryInfo trgtDir)
        {
            foreach (FileInfo file in rootDir.GetFiles())
            {
                FileInfo trgtFile = new FileInfo(Path.Combine(trgtDir.FullName, file.Name));
                if (trgtFile.Exists && trgtFile.LastWriteTime < file.LastWriteTime)
                {
                    sizeOfFiles += file.Length;
                    filesToCopy++;
                }
                else if (!trgtFile.Exists)
                {
                    sizeOfFiles += file.Length;
                    filesToCopy++;
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
            Functions.GetConfigStrings();
            configWindow.Show();
        }

        void ReportIssue(object sender, EventArgs e)
        {
            ZipFile.CreateFromDirectory(Dic.SyncRoot, Environment.GetFolderPath(Environment.SpecialFolder.Desktop)+"\\IssueReport.zip");
            MessageBox.Show("IssueReport.zip was created to the Desktop. Please attach this archive to the report.");
            Process.Start(new ProcessStartInfo
            {
                FileName = "https://github.com/Chookees/Synchronizer/issues/new",
            });
        }

        void Exit(object sender, EventArgs e)
        {
            // We must manually tidy up and remove the icon before we exit.
            // Otherwise it will be left behind until the user mouses over.
            notifyIcon.Visible = false;

            Log.Log("ConextApplication"+".Exit", "Cleaning up objects.", Type.Closing);
            // Clean every object.
            for (int i = 0; i < allObjects.Count; i++)
            {
                if (allObjects[i] != null)
                {
                    Log.Log("ContextApplication.Exit.CleanObjects", allObjects[i].ToString() + " cleaned.", Type.Processing);
                    allObjects[i] = null;
                }
            }

            Log.Log("ContextApplication" + ".Exit", "Closing the Application.", Type.Closing);
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

            Log.Log("ContextApplication" + ".Initialize", "Check if Config file exists.");
            if (!File.Exists(Dic.SyncConfigFile))
            {
                Log.Log("ContextApplication" + ".Initialize", "Config file does not exist.");
                StreamWriter writer = new StreamWriter(Dic.SyncConfigFile);
                writer.Close();
                writer = null;

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
