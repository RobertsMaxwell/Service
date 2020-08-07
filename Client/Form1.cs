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
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;

namespace Client
{
    public partial class Form1 : Form
    {

        public static string serviceIP;

        public Form1()
        {
            InitializeComponent();
        }

        [DllImport("User32")]
        public static extern int SetForegroundWindow(IntPtr hwnd);

        [DllImport("user32.dll")]
        static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        private void startButton_Click(object sender, EventArgs e)
        {
            if(targetIP.Text == "")
            {
                MessageBox.Show("Please enter in a IP");
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
                return;
            }
        }

        private void ConnectToServer()
        {
            TcpClient client = new TcpClient();

            Console.WriteLine("Establishing Connection to {0}:1738", targetIP.Text);

            if(messageBox.Text == "")
            {
                MessageBox.Show("Please enter in a message");
                return;
            }

            IPAddress ServiceIP = IPAddress.Parse(serviceIP);
            try
            {
                
                client.Connect(ServiceIP, 1738);

                Console.WriteLine("Connection established");

                if(client.Connected)
                {
                    NetworkStream ns = client.GetStream();
                    BinaryFormatter bf = new BinaryFormatter();

                    byte[] messageArr = Encoding.ASCII.GetBytes("txt\n" + messageBox.Text);

                    bf.Serialize(ns, messageArr);
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
                return;
            }
        }

        private void backgroundButton_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.ShowDialog();
        }

        private void IPButton_Click(object sender, EventArgs e)
        {
            if (ipButton.Text == "Set IP")
            {
                ipButton.Text = "Change IP";
            }
            else if(ipButton.Text == "Change IP")
            {
                ipButton.Text = "Set IP";
            }
            serviceIP = targetIP.Text;
            targetIP.ReadOnly = !targetIP.ReadOnly;
        }
    }
}
