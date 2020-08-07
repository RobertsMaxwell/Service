
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
        const int SPI_SETDESKWALLPAPER = 0x14;
        const int SPIF_UPDATEINIFILE = 0x01;

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern bool SystemParametersInfo(int uiAction, int uiParam, string pvParam, int fWinIni);

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
    }
}
