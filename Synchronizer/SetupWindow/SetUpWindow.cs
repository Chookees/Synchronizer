using System;
using System.IO;
using System.Windows.Forms;
using FBD = System.Windows.Forms.FolderBrowserDialog;
using Dic = AZDictionary.Dictionary;
using Log = AZLog.Logger;
using Type = AZLog.Type;

namespace az.Synchronizer
{
    public partial class SetUpWindow : Form
    {
        public SetUpWindow()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception e)
            {
                Log.ExLog(e);
            }
        }

        private void OpenFileDialog(object sender, EventArgs e)
        {
            Log.Log(this.Name+".OpenFileDialog", "Opening FolderBrowserDialog().", Type.Opening);
            FBD folderBrowser = new FBD()
            {
                Description = StringTable.SetupFolderBrowserDescription,
                RootFolder = Environment.SpecialFolder.MyComputer,
                SelectedPath = "",
                ShowNewFolderButton = true
            };

            folderBrowser.ShowDialog();

            string path = folderBrowser.SelectedPath;

            switch (((Button)sender).Name)
            {
                case ("sourceBtn"):
                    srcTxtBox.Text = path;
                    Log.Log(this.Name+ ".OpenFileDialog", "sourceBtn clicked.");
                    break;
                case ("targetBtn"):
                    targetTxtBox.Text = path;
                    Log.Log(this.Name + ".OpenFileDialog", "targetBtn clicked.");
                    break;
                default:
                    Log.Log(this.Name + ".OpenFileDialog", "Default triggered, something went wrong.", Type.Warning);
                    break;
            }

            Log.Log(this.Name + ".OpenFileDialog", "Closing FolderBrowserDialog().", Type.Closing);
        }

        private void continueBtn_Click(object sender, EventArgs e)
        {
            StreamWriter writer = new StreamWriter(Dic.SyncConfigFile);
            writer.WriteLine("src=" + srcTxtBox.Text+","+ "trgt=" + targetTxtBox.Text + ",");
            writer.Flush();
            Log.Log(this.Name + ".continueBtn_Click", "Saving Config File.", Type.Saving);
            writer.Close();
            Log.Log(this.Name + ".continueBtn_Click", "Closing Config File.", Type.Closing);
            Log.Log(this.Name + ".continueBtn_Click", "Showing 'Config is Created' message.");
            MessageBox.Show(StringTable.SetupConfigFileIsCreated);
            this.Close();
        }

        private void targetTxtBox_TextChanged(object sender, EventArgs e)
        {
            this.continueBtn.Enabled = CanBtnActivate();
        }

        private void srcTxtBox_TextChanged(object sender, EventArgs e)
        {
            this.continueBtn.Enabled = CanBtnActivate();
        }

        private bool CanBtnActivate()
        {
            if (Directory.Exists(srcTxtBox.Text) && Directory.Exists(targetTxtBox.Text) &&
                !String.IsNullOrEmpty(srcTxtBox.Text) && !String.IsNullOrEmpty(targetTxtBox.Text))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
