//Copyright(c) 2023, LuckyLars32
//All rights reserved.

//This source code is licensed under the BSD-style license found in the
//LICENSE file in the root directory of this source tree.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RichTextScreensaver
{
    static class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            //Arguments for any Windows screensaver:
            //TextScreensaver.scr				-> Show the Settings dialog box.
            //TextScreensaver.scr /c			-> Show the Settings dialog box, modal to the foreground window.
            //TextScreensaver.scr /p <HWND>	    -> Preview screensaver as child of window <HWND>.
            //TextScreensaver.scr /s			-> Run the screensaver.
            if (args.Length >= 1)
            {
                String sysStr_Arg = args[0].ToLower();

                //RUN SCREENSAVER
                if (sysStr_Arg == "/s")
                {
                    //Run the screensaver
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new RTSForm());
                }

                //SHOW SETTINGS
                else if (sysStr_Arg == "/c")
                {
                    //Show settings Window
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    RichTextScreensaver.SettingsForm settingsForm = new SettingsForm();
                    Application.Run(settingsForm);
                }

                //RUN SCREENSAVER PREVIEW
                else if (sysStr_Arg == "/p")
                {
                    if (args.Length >= 2)
                    {
                        //Preview window inside Windows scrensaver settings.
                        Application.EnableVisualStyles();
                        Application.SetCompatibleTextRenderingDefault(false);
                        IntPtr iPtr_HWND = new IntPtr(long.Parse(args[1].ToLower())); //parsing parent HWND from 2nd commandline argument
                        RTSFunctions.WriteToLog(iPtr_HWND.ToString(), "HWND"); //Logging HWND to Logfile (for Debug purpose only)
                        RichTextScreensaver.RTSForm mainForm = new RTSForm(iPtr_HWND);
                        Application.Run(mainForm);
                    }
                    else
                    {
                        RTSFunctions.WriteToLog("Second argument should contain HWND which it didn't!", "ERROR"); //Write Error to Logfile
                        Application.Exit(); //Close application
                    }
                }

                //SHOW SETTINGS
                else
                {
                    //Show settings Window
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    RichTextScreensaver.SettingsForm settingsForm = new SettingsForm();
                    Application.Run(settingsForm);
                }
            }
            else
            {
                //Show settings Window
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                RichTextScreensaver.SettingsForm settingsForm = new SettingsForm();
                Application.Run(settingsForm);
            }

        }
    }
}
