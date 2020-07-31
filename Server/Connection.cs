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

namespace Server
{
    class Connection
    {
        public TcpClient client;
        public Image lastImage;
        bool reading;

        public Connection(TcpClient cl)
        {
            client = cl;
        }

        public string ReadInfo()
        {
            reading = true;
            while (reading)
            {
                using (NetworkStream str = client.GetStream())
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    byte[] strInfo = (byte[])bf.Deserialize(str);

                    for (int i = 0; i < strInfo.Length; i++)
                    {
                        if ((char)Convert.ToInt32(strInfo[i]) == '\n')
                        {
                            byte[] action = new byte[i];
                            Array.Copy(strInfo, 0, action, 0, action.Length);

                            byte[] image = new byte[strInfo.Length - (i + 2)];
                            Array.Copy(strInfo, i + 2, image, 0, image.Length);

                            using (MemoryStream ms = new MemoryStream(image))
                            {
                                Image img = Image.FromStream(ms);
                                FileStream fs = new FileStream(Path.Combine(Path.GetTempPath(), "image.jpg"), FileMode.Create);
                                img.Save(fs, ImageFormat.Jpeg);
                            }

                            return Encoding.ASCII.GetString(action);
                        }
                    }

                    /*while (str.DataAvailable)
                    {
                        byte[] info = new byte[1];
                        str.Read(info, 0, info.Length);
                        streamData += (Encoding.ASCII.GetString(info));
                    }*/

                    str.Flush();
                }
            }
            return "";
        }
    }
}
