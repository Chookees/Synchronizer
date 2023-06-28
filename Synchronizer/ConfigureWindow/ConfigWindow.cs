using System;
using System.IO;
using System.Windows.Forms;
using AZLog;
using Microsoft.Win32;
using Dic = AZDictionary.Dictionary;
using Type = AZLog.Type;

namespace Synchronizer
{
    public partial class ConfigWindow : Form
    {
        public ConfigWindow()
        {
            Logger.Log("ConfigWindow.ConfigWindow","Initializing..", AZLog.Type.Loading);
            InitializeComponent();

            this.checkBox3.Visible = false;
            this.backupAutoBox.Visible = false;
            this.checkBox4.Visible = false;

            // Cleanup strings
            foreach (string key in Functions.ConfigurationDictionary.Keys)
            {
                if (key == "src")
                {
                    Functions.ConfigurationDictionary.TryGetValue(key, out string text);
                    this.srcTxtBox.Text = text;
                    Logger.Log(this.Name + ".ConfigWindow", "Line of ConfigFile: " + key + "=" + text);
                }
                else if (key == "trgt")
                {
                    Functions.ConfigurationDictionary.TryGetValue(key, out string text);
                    this.targetTxtBox.Text = text;
                    Logger.Log(this.Name + ".ConfigWindow", "Line of ConfigFile: " + key + "=" + text);
                }
                else
                {
                    Logger.Log(this.Name + ".ConfigWindow", "Empty or Wrong line at Config File", Type.Warning);
                }
            }
            Logger.Log("ConfigWindow.ConfigWindow", "Initialization completed.", AZLog.Type.Success);
        }

        private void OpenFileDialog(object sender, EventArgs e)
        {
            Logger.Log(this.Name + ".OpenFileDialog", "Opening FolderBrowserDialog().", AZLog.Type.Opening);
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog()
            {
                Description = StringTable.SetupFolderBrowserDescription,
                RootFolder = Environment.SpecialFolder.MyComputer,
                SelectedPath = ((Button)sender).Name == "sourceBtn" ? srcTxtBox.Text : targetTxtBox.Text,
                ShowNewFolderButton = true
            };

            folderBrowser.ShowDialog();

            string path = folderBrowser.SelectedPath;

            switch (((Button)sender).Name)
            {
                case ("sourceBtn"):
                    srcTxtBox.Text = path;
                    Logger.Log(this.Name + ".OpenFileDialog", "sourceBtn clicked.");
                    break;
                case ("targetBtn"):
                    targetTxtBox.Text = path;
                    Logger.Log(this.Name + ".OpenFileDialog", "targetBtn clicked.");
                    break;
                default:
                    Logger.Log(this.Name + ".OpenFileDialog", "Default triggered, something went wrong.", AZLog.Type.Warning);
                    break;
            }

            Logger.Log(this.Name + ".OpenFileDialog", "Closing FolderBrowserDialog().", AZLog.Type.Closing);
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            #region Config file

            Logger.Log(this.Name + ".saveBtn_Click", "Updating Config File.", Type.Opening);
            StreamWriter writerConf = new StreamWriter(Dic.SyncConfigFile);
            writerConf.WriteLine("src=" + srcTxtBox.Text + ","+ "trgt=" + targetTxtBox.Text + ",");
            writerConf.Flush();
            Logger.Log(this.Name + ".saveBtn_Click", "Saving Config File.", Type.Saving);
            writerConf.Close();
            Logger.Log(this.Name + ".saveBtn_Click", "Closing Config File.", Type.Closing);
            Logger.Log(this.Name + ".saveBtn_Click", "Showing 'Config is updated' message.");
            MessageBox.Show(StringTable.ConfigConfigIsSaved);
            writerConf.Close();
            
            #endregion

            #region Settings

            Logger.Log(this.Name + ".saveBtn_Click", "Updating Settings file.", Type.Opening);
            StreamWriter writerSetting = new StreamWriter(Dic.SyncSettingFile);
            writerSetting.WriteLine(";startWithWindows=" + startAutoBox.Checked.ToString());
            //writerSetting.WriteLine(";autoStartBackup=" + backupAutoBox.Checked.ToString());
            //writer.WriteLine(";startWithWindows=" + startAutoBox.Checked.ToString());
            //writer.WriteLine(";startWithWindows=" + startAutoBox.Checked.ToString());
            Logger.Log(this.Name + ".saveBtn_Click", "Saving Setting File.", Type.Saving);
            writerSetting.Flush();
            Logger.Log(this.Name + ".saveBtn_Click", "Closing Setting File.", Type.Closing);
            Logger.Log(this.Name + ".saveBtn_Click", "Showing 'Setting is updated' message.");
            MessageBox.Show(StringTable.ConfigSettingIsSaved);
            writerSetting.Close();

            #endregion

            Logger.Log(this.Name + ".saveBtn_Click", "Closing Configuration Dialog", Type.Closing);

            Functions.GetConfigStrings();

            this.Close();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            Logger.Log(this.Name + ".cancelBtn_Click", "Closing Configuration Dialog", Type.Closing);
            this.Close();
        }

        private void startAutoBox_CheckedChanged(object sender, EventArgs e)
        {
            RegistryKey rk = Registry.CurrentUser.OpenSubKey
                ("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            if (startAutoBox.Checked)
            {
                rk.SetValue("ContextApplication", Application.ExecutablePath);
            }
            else
            {
                rk.DeleteValue("ContextApplication", false);
            }
            Logger.Log(this.Name + ".startAutoBox_CheckedChanged", "Automatic start with windows set to: " + startAutoBox.Checked + ".", Type.Saving);
        }
    }
}
