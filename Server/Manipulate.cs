using Microsoft.Win32;
using System;
using System.Drawing;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public static class Manipulate
    {
        [DllImport("user.dll")]
        static extern int SystemParametersInfo(int uAction, int uParam, string lpvParam, int fuWinIni);

        const int SPI_SETDESKWALLPAPER = 0x0014;
        const int SPIF_UPDATEINIFILE = 0x01;

        public static int DoAction(string action)
        {
            switch (action)
            {
                
            }
            return 1;
        }

        public static void ChangeBackground(Image image)
        {
            string tempPath = Path.Combine(Path.GetTempPath(), "new_background.png");

            image.Save(tempPath, System.Drawing.Imaging.ImageFormat.Png);

            SystemParametersInfo(SPI_SETDESKWALLPAPER, 0, tempPath, SPIF_UPDATEINIFILE);
        }
    }
}
