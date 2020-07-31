using Microsoft.Win32;
using System;
using System.Drawing;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;

namespace Server
{
    public static class Manipulate
    {
        [DllImport("user.dll")]
        static extern int SystemParametersInfo(int uAction, int uParam, string lpvParam, int fuWinIni);

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
    }
}
