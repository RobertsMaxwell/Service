using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            Console.WriteLine("Establishing Connection to {0}:1738", targetIP.Text);
            s.Connect(targetIP.Text, 1738);
            Console.WriteLine("Connection established");
        }
    }
}
