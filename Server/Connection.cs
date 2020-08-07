using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Threading;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace Server
{
    class Connection
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool SystemParametersInfoW(uint uiAction, uint uiParam, string pvParam, uint fWinIni);
        const uint SPI_SETDESKWALLPAPER = 0x14;
        const uint SPIF_UPDATEINIFILE = 0x01;
        
        public TcpClient client;

        public Connection(TcpClient cl)
        {
            client = cl;
        }

        public void ReadInfo()
        {
            NetworkStream ns = client.GetStream();

            BinaryFormatter bf = new BinaryFormatter();
            byte[] info = (byte[])bf.Deserialize(ns);
            byte[] header = new byte[4];
            byte[] data = new byte[info.Length - header.Length];

            Array.Copy(info, header, 4);
            Array.Copy(info, 4, data, 0, data.Length);

            if (info.Length > 0)
            {
                if (Encoding.ASCII.GetString(header) == "img\n")
                {
                    try
                    {
                        ServerMain.service.SendMessage("img");
                        MemoryStream ms = new MemoryStream(data);
                        Image img = Image.FromStream(ms);
                        string filePath = Path.Combine(Path.GetTempPath() + "image.bmp");
                        img.Save(filePath, ImageFormat.Bmp);
                        ms.Close();
                    }
                    catch (Exception e)
                    {
                        ServerMain.service.SendMessage(e.Message);
                    }
                    
                    //var result = SystemParametersInfoW(SPI_SETDESKWALLPAPER, 0, filePath, SPIF_UPDATEINIFILE);
                    ServerMain.service.SendMessage(Marshal.GetLastWin32Error().ToString());
                }
                else if (Encoding.ASCII.GetString(header) == "txt\n")
                {
                    ServerMain.service.SendMessage("txt: " + Encoding.ASCII.GetString(data));
                }
            }
        }
    }
}
