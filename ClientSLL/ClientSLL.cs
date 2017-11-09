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



            }
            
                
            
        }
    }
}
