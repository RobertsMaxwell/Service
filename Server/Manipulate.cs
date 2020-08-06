using Microsoft.Win32;
using System;
using System.Drawing;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.Windows;
using System.Windows.Forms;
using System.Threading;

namespace Server
{
    public static class Manipulate
    {
        [DllImport("user32.dll")]
        static extern int SystemParametersInfo(int uAction, int uParam, string lpvParam, int fuWinIni);

        [DllImport("User32")]
        public static extern int SetForegroundWindow(IntPtr hwnd);

        [DllImport("user32.dll")]
        static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        static int SPI_SETDESKWALLPAPER = 0x0014;
        static int SPIF_UPDATEINIFILE = 0x01;

        public static int DoAction(string action)
        {
            switch (action)
            {
                
            }
            return 1;
        }

        public static void ChangeBackground(Image image)
        {
            string tempPath = Path.Combine(Path.GetTempPath(), "new_background.jpeg");

            image.Save(tempPath, ImageFormat.Jpeg);

            SystemParametersInfo(SPI_SETDESKWALLPAPER, 0, tempPath, SPIF_UPDATEINIFILE);
        }

        public static void OpenNotePad(string message)
        {
            Process.Start("notepad");
            IntPtr notepad = FindWindow("notepad", null);
            SetForegroundWindow(notepad);
            Thread.Sleep(100);
            SendKeys.SendWait("Test");
        }
    }
}
