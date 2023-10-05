//Copyright(c) 2023, LuckyLars32
//All rights reserved.

//This source code is licensed under the BSD-style license found in the
//LICENSE file in the root directory of this source tree. 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RichTextScreensaver
{
    public class RTSFunctions
    {
        //Get data from TextScreensaverConfig.ini file
        public static String GetDataFromConfig(string DefineData)
        {
            //opening the subkey  
            Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"SOFTWARE\RichTextScreensaver");
            //if it does exist, retrieve the stored values  
            if (key != null)
            {
                System.String SysStr_DataFromReg = key.GetValue(DefineData).ToString();
                key.Close();
                return SysStr_DataFromReg;
            }
            else
            {
                WriteToLog("Error in GetDataFromConfig. Registry key not found!", "ERROR");
                return null;
            }
        }

        //Write data to TextScreensaverConfig.ini file
        public static void WriteDataToConfig(string DefineData, String SysStr_DataToSave)
        {
            //accessing the CurrentUser root element and adding "RichTextScreensaver" subkey to the "SOFTWARE" subkey  
            Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(@"SOFTWARE\RichTextScreensaver");
            //storing the values  
            key.SetValue(DefineData, SysStr_DataToSave);
            key.Close();
        }

        //Log ERRORs to a Logfile
        public static void WriteToLog(string logMsg, string logLevel)
        {
            //get Localaappdata Path (Usually: C:\Users\%USERNAME%\AppData\Local)
            string LocalAppDataPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData);
            //Full Logfile path
            string LogfilePath = LocalAppDataPath + "\\RichTextScreensaver\\TSLog.txt";
            //Check if the file exists, if not check if the directory exists 
            if (System.IO.File.Exists(LogfilePath) == false)
            {
                try
                {
                    // Check if the directory exists 
                    if (System.IO.Directory.Exists(LocalAppDataPath + "\\RichTextScreensaver") == false)
                    {
                        try
                        {
                            //If the directory does not exist, try to create the directory.
                            System.IO.Directory.CreateDirectory(LocalAppDataPath + "\\RichTextScreensaver");
                        }
                        //Catch exeption if directory cannot be created for whatever reason, show error message as messagebox and close RichTextScreensaver.
                        catch (Exception e)
                        {
                            System.Windows.Forms.MessageBox.Show("RichTextScreensaver can't create Logfile directory", "FatalERROR");
                            System.Windows.Forms.Application.Exit();
                        }
                    }
                    //If the file does not exist, try to create the file.
                    System.IO.FileStream createFileStream = System.IO.File.Create(LogfilePath);
                    createFileStream.Close();
                }
                //Catch exeption if file cannot be created for whatever reason, show error message as messagebox and close RichTextScreensaver.
                catch (Exception e)
                {
                    System.Windows.Forms.MessageBox.Show("RichTextScreensaver can't create Logfile", "FatalERROR");
                    System.Windows.Forms.Application.Exit();
                }
            }
            //Actually write the message to the logfile
                System.IO.FileStream stream = System.IO.File.Open(LogfilePath, System.IO.FileMode.Append);
                if (!stream.CanWrite)
                {
                    System.Windows.Forms.MessageBox.Show("Rich TextScreensaver can't write to Logfile", "FatalERROR");
                }
                else
                {
                    logMsg.Replace("\r\n", "").Replace("\n", ""); //Remove new line swich if contained. We want each log message to be one line only!
                    System.IO.StreamWriter writer = new System.IO.StreamWriter(stream);
                    string LogMessage = logLevel + " " + logMsg + '\n';
                    writer.WriteLine(LogMessage);
                    writer.Close();
                }

        }
    }
}
