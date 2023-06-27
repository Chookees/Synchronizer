using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Synchronizer.Properties;
using Log = AZLog.Logger;
using Dic = AZDictionary.Dictionary;
using Type = AZLog.Type;

namespace Synchronizer
{
    public class ContextApplication:ApplicationContext
    {
        private NotifyIcon notifyIcon;

        public ContextApplication()
        {
            Initialize();

            Log.Log("ContextApplication", "Initializing ContextApplication");
            // Initialize Tray Icon
            notifyIcon = new NotifyIcon()
            {
                Icon = new Icon("Properties\\sync.ico"),
                ContextMenu = new ContextMenu(new MenuItem[] {
                    new MenuItem("Configuration", Configuration),
                    new MenuItem("Exit", Exit)
                }),
                Visible = true
            };
        }

        void Configuration(object sender, EventArgs e)
        {
            Log.Log("ContextApplication", "Starting the Configuration page.", Type.Opening);
            ConfigWindow configWindow = new ConfigWindow();
            configWindow.Show();
        }

        void Exit(object sender, EventArgs e)
        {
            // We must manually tidy up and remove the icon before we exit.
            // Otherwise it will be left behind until the user mouses over.
            Log.Log("ContextApplication", "Closing the Application.", Type.Closing);
            notifyIcon.Visible = false;
            Application.Exit();
        }

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

            Log.Log("ContextApplication", "Check if Config file exists.");
            if (!File.Exists(Dic.SyncConfigFile))
            {
                Log.Log("ContextApplication", "Config file does not exist.");
                SetUpWindow setup = new SetUpWindow();
                setup.Show();
            }
            else
            {
                Log.Log("ContextApplication", "Config file exists.");
            }
        }
    }
}
