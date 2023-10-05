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
            string LogfilePath = "C:\\Scripte\\TSLog.txt";
            System.IO.FileStream stream = System.IO.File.Open(LogfilePath, System.IO.FileMode.Append);
            if (!stream.CanWrite)
            {
                System.Windows.Forms.MessageBox.Show("TextScreensaver can't write to Logfile", "FatalERROR");
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
