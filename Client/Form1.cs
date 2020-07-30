using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Linq;

namespace Client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        } 

        private void startButton_Click(object sender, EventArgs e)
        {
            if(targetIP.Text == "")
            {
                return;
            }

            try
            {
                Thread thread = new Thread(new ThreadStart(ConnectToServer));

                thread.Start();
            }
            catch(Exception)
            {
                Console.WriteLine("Connection Failed");
            }
        }

        private void ConnectToServer()
        {
            TcpClient client = new TcpClient();

            Console.WriteLine("Establishing Connection to {0}:1738", targetIP.Text);

            IPAddress ServiceIP = IPAddress.Parse(targetIP.Text);

            client.ConnectAsync(ServiceIP, 1738);
            Console.WriteLine("Connection established");
            NetworkStream networkStream;
            //var sw = new StreamWriter(ms);
            //sw.Write("Test String");
        }
    }
}
