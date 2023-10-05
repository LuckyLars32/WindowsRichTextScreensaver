using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RichTextScreensaver
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void btn_selectFile_Click(object sender, EventArgs e)
        {
            if (openFileDlg1.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                System.String File = openFileDlg1.FileName;
                RTSFunctions.WriteDataToConfig("RtfFileLocation", File);
                textBox1.Text = File;
            }
        }

        private void openFileDlg1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void On_Load(object sender, EventArgs e)
        {
            string RtfFileLocation = RTSFunctions.GetDataFromConfig("RtfFileLocation");
            if (RtfFileLocation != null)
            {
                textBox1.Text = RtfFileLocation;
            }
            
        }
    }
}
