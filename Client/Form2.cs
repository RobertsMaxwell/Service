using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        public string file;
        OpenFileDialog ofd = new OpenFileDialog();

        private void browseButton_Click(object sender, EventArgs e)
        {
            if(ofd.ShowDialog() == DialogResult.OK)
            {
                filePath.Text = ofd.FileName;
                file = ofd.FileName;
            }
        }

        private void setButton_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(new ThreadStart(ConnectToServer));
            thread.Start();
        }

        private void ConnectToServer()
        {
            TcpClient client = new TcpClient();

            IPAddress ServiceIP = IPAddress.Parse(targetIP.Text);
            try
            {
                Console.WriteLine("Connecting...");
                var result = client.BeginConnect(ServiceIP, 1738, null, client);
                //client.Connect(ServiceIP, 1738);
                Console.WriteLine("Connected!");

                if (result.AsyncWaitHandle.WaitOne(2000))
                {
                    while (client.Connected)
                    {
                        NetworkStream ns = client.GetStream();
                        BinaryFormatter bf = new BinaryFormatter();

                        Image backgroundImg = Image.FromFile(filePath.Text);

                        byte[] action = Encoding.ASCII.GetBytes("img\n");
                        byte[] image = ImageToByteArray(backgroundImg);
                        byte[] combined = action.Concat(image).ToArray();

                        bf.Serialize(ns, action);

                        client.Close();
                    }
                }
            }
            catch (Exception e)
            {
                client.Close();
                Console.WriteLine(e.ToString());
                return;
            }
            client.Close();
        }

        public byte[] ImageToByteArray(Image image)
        {
            using (var ms = new MemoryStream())
            {
                image.Save(ms, ImageFormat.Jpeg);
                return ms.ToArray();
            }
        }
    }
}
