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
        Image img;

        public Connection(TcpClient cl)
        {
            client = cl;
        }

        public string ReadInfo()
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
                        Array.Copy(strInfo, action, action.Length);

                        byte[] image = new byte[strInfo.Length - (action.Length + 1)];
                        Array.Copy(strInfo, action.Length + 1, image, 0, image.Length);

                        using (MemoryStream ms = new MemoryStream(image))
                        {
                            Image img = Image.FromStream(ms);
                        }

                        try
                        {
                            Manipulate.ChangeBackground(img);
                        }
                        catch (Exception e)
                        {
                            ServerMain.service.SendMessage("ERROR: " + e.Message);
                        }
                        
                        return Encoding.ASCII.GetString(action);
                    }
                }

                str.Flush();
            }
            return "";
        }
    }
}
