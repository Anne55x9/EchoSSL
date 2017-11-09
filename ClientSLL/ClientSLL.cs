using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ClientSLL
{
    internal class ClientSLL
    {
        private int PORT;

        public ClientSLL(int port)
        {
            this.PORT = port;
        }

        public void StartClient()
        {
            using (TcpClient connectionSocket = new TcpClient(IPAddress.Loopback.ToString(),PORT))
            using (Stream ns = connectionSocket.GetStream())
            using (StreamReader sr = new StreamReader(ns))
            using (StreamWriter sw = new StreamWriter(ns))
            {
                Console.WriteLine("Client have connected");
                sw.AutoFlush = true;

                Client3(sr,sw);
                //Insert specifik clients

                Console.WriteLine("Client finished");
            }
        }

        //send 100 messages to server
        private void Client3(StreamReader sr, StreamWriter sw)
        {
            for (int i = 0; i < 100; i++)
            {
                string message = "Moses " + i;
                sw.WriteLine(message);
                string serverAnswer = sr.ReadLine();
                Console.WriteLine("Server: " + serverAnswer);
            }
            
        }

        //read 5 lines and send to server

        private void Client2(StreamReader sr, StreamWriter sw)
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Type a line");
                string message = Console.ReadLine();
                sw.WriteLine(message);
                string serverAnswer = sr.ReadLine();
                Console.WriteLine("Server: " + serverAnswer);
            }
        }

        // read 1 line from console and send to server
        private void Client1(StreamReader sr, StreamWriter sw)
        {
            
            Console.WriteLine("Type a line");
            string message = Console.ReadLine();
            sw.WriteLine(message);

            string serverAnswer = sr.ReadLine();
            Console.WriteLine("Server: " + serverAnswer);

        }
    }
}
