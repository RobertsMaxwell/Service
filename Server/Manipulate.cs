
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
        const int SPI_SETDESKWALLPAPER = 0x14;
        const int SPIF_UPDATEINIFILE = 0x01;

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern bool SystemParametersInfo(int uiAction, int uiParam, string pvParam, int fWinIni);

        [DllImport("User32")]
        public static extern int SetForegroundWindow(IntPtr hwnd);

        [DllImport("user32.dll")]
        static extern IntPtr FindWindow(string lpClassName, string lpWindowName);


        public static int DoAction(string action)
        {
            switch (action)
            {
                
            }
            return 1;
        }

        public static void ChangeBackground(Image img)
        {
            try
            {
                string bmpImgPath;

                bmpImgPath = Path.Combine(Path.GetTempPath(), "image.bmp");
                img.Save(bmpImgPath, ImageFormat.Bmp);

                ServerMain.service.SendMessage(SystemParametersInfo(SPI_SETDESKWALLPAPER, 0, bmpImgPath, SPIF_UPDATEINIFILE).ToString());
            }
            catch (Exception e)
            {
                ServerMain.service.SendMessage(e.Message);
            }
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
