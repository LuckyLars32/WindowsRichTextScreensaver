using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RichTextScreensaver
{
    public partial class RTSForm : Form
    {
        public RTSForm()
        {
            InitializeComponent();
        }
        public RTSForm(IntPtr iPtr_HWND)
        {
            InitializeComponent();
            // Set the preview window as the parent of the RichTextScreensaver window
            User32Functions.SetParent(this.Handle, iPtr_HWND);
            // Make the RichTextScreensaver window a child of the preview window so it will close when the preview is closed
            User32Functions.SetWindowLong(this.Handle, -16, new IntPtr(User32Functions.GetWindowLong(this.Handle, -16) | 0x40000000));
            //Put the RichTextScreensaver window inside the parent (HWND) - Does not seem to work...
            Rectangle ParentRect;
            User32Functions.GetClientRect(iPtr_HWND, out ParentRect);
            Size = new Size(ParentRect.Size.Width + 1, ParentRect.Size.Height + 1);
            Location = new Point(-1, -1);
        }

        private void On_MouseMove(object sender, MouseEventArgs e)
        {
           this.Close();
        }

        private void On_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.Close();
        }
        private void On_Load(object sender, EventArgs e)
        {
            this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.ReadRtfFile();
            this.SetZoomFactor();
        }
        private void ReadRtfFile()
        {
            //Read the contents from the specified RTF file into the richTextBox1 and close the file (really importent, don't ask me how I know...).
            System.String RtfFileLocation = RTSFunctions.GetDataFromConfig("RtfFileLocation");
            if (RtfFileLocation != null)
            {
                System.IO.FileStream streamRTFtoTextbox = System.IO.File.Open(RtfFileLocation, System.IO.FileMode.Open);
                richTextBox1.LoadFile(streamRTFtoTextbox, RichTextBoxStreamType.RichText);
                streamRTFtoTextbox.Close();
            }
        }
        //Calculate and set the zoom factor of the richTextBox. This has to be done AFTER we read the contents of RTF file into the richTextBox.
        private void SetZoomFactor()
        {
            //int RTSFormHeight = this.Height;
            int RTSFormWidth = this.Width;
            if (RTSFormWidth > 2)
            {
                float calculatedZoomFactor = (float)RTSFormWidth / (float)1500;
                richTextBox1.ZoomFactor = calculatedZoomFactor;
            }
        }
    }


    internal static class User32Functions
    {
        [DllImport("user32.dll")]
        internal static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        [DllImport("user32.dll")]
        internal static extern int SetWindowLong(IntPtr hWnd, int nIndex, IntPtr dwNewLong);

        [DllImport("user32.dll", SetLastError = true)]
        internal static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll")]
        internal static extern bool GetClientRect(IntPtr hWnd, out Rectangle lpRect);
    }
}
