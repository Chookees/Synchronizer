using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using Log = AZLog.Logger;
using Type = AZLog.Type;

namespace az.Synchronizer
{
    public static class Functions
    {
        // Current Config keys are: src, trgt
        public static Dictionary<string, string> ConfigurationDictionary = new Dictionary<string, string>();

        // Current Setting keys are: startWithWindows ,settingShowWarning
        public static Dictionary<string,string> SettingsDictionary = new Dictionary<string, string>();
        
        private static List<string> fileTypeList = new List<string>()
        {
            "B",  // Byte
            "KB", // KiloByte
            "MB", // MegaByte
            "GB", // GigaByte
            "TB", // TerraByte
        };

        public static bool ShowSizeWarning = false;

        /// <summary>
        /// Reads the Config File and returns the lines separated in a dictionary.
        /// Current keys are: 'src', 'trgt'.
        /// </summary>
        /// <returns>Dictionary<string,string></string></returns>
        public static void GetConfigStrings()
        {
            Dictionary<string, string> configStrings = new Dictionary<string, string>();

            try
            {
                Log.Log("Functions.GetConfigStrings", "Reading Config file..", Type.Opening);

                StreamReader reader = new StreamReader(AZDictionary.Dictionary.SyncConfigFile);
                string lineOfConfig = reader.ReadToEnd();

                Log.Log("Functions.GetConfigStrings", "Done reading.", Type.Success);

                Log.Log("Functions.GetConfigStrings", "Closing Config file.", AZLog.Type.Closing);
                reader.Close();

                Log.Log("Functions.GetConfigStrings", "Splitting lines.", AZLog.Type.Processing);
                string[] linesOfConfig = lineOfConfig.Split(',');

                foreach (string line in linesOfConfig)
                {
                    if (line.Contains("="))
                    {
                        string[] splitted = line.Split('=');
                        string key = splitted[0];
                        string value = splitted[1];

                        configStrings.Add(key, value);
                        Log.Log("Functions.GetConfigStrings", "Adding to Dictionary " + key + " and " + value, Type.Saving);
                    }
                }
            }
            catch (Exception e)
            {
                Log.ExLog(e);
            }

            Log.Log("Functions.GetConfigStrings", "Finished processing Config File.", Type.Success);
            ConfigurationDictionary = configStrings;
        }

        public static string GetValueFromDictionary(string key)
        {
            string returnValue = "";

            if (Functions.ConfigurationDictionary.TryGetValue(key, out returnValue))
            {
                Log.Log("Functions.GetValueFromDictionary", "Found "+key+" in Dictionary", Type.Success);
            }
            else
            {
                Log.Log("Functions.GetValueFromDictionary", "Could not find any key '"+key+"' in Dictionary!", Type.Error);
            }

            return returnValue;
        }

        public static string GetSizeOfFilesFormatted(double size, int counter)
        {
            const double dividerOfSize = 1000;

            // Starts in Byte
            // Iterates through 
            while (size/dividerOfSize > 1)
            {
                size /= dividerOfSize;
                counter++;
            }

            return Math.Round(size,2) + ":" + fileTypeList[counter];
        }

        public static void ReadSettingsFile()
        {
            string[] splittedSettings = File.ReadAllLines(AZDictionary.Dictionary.SyncSettingFile);

            foreach (string splittedSetting in splittedSettings)
            {
                string cleanedsplittedSetting = splittedSetting.Replace(";","");
                string[] nameValue = cleanedsplittedSetting.Split('=');
                SettingsDictionary.Add(nameValue[0], nameValue[1]);
            }
        }
    }
}
