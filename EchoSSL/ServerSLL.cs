using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace EchoSSL
{
    internal class ServerSLL
    {
        private int PORT;

        public ServerSLL(int port)
        {
            this.PORT = port;
        }

        public void StartServer()
        {
            TcpListener serverSocket = new TcpListener(IPAddress.Any,PORT);

            serverSocket.Start();

            Console.WriteLine("Server Started");

            using (TcpClient connectionSocket = serverSocket.AcceptTcpClient())
            using (Stream ns = connectionSocket.GetStream())
            using (StreamReader sr = new StreamReader(ns))
            using (StreamWriter sw = new StreamWriter(ns))
            {
                Console.WriteLine("Server started");

                sw.AutoFlush = true;

                string message = sr.ReadLine();
                string answer = "";

                while (string.IsNullOrEmpty(message))
                {
                    Console.WriteLine("Client: " + message);
                    answer = message.ToUpper();
                    sw.WriteLine(answer);

                    message = sr.ReadLine();
                }
            }
   
            
        }
    }
}
