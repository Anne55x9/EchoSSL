using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
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
            // string clientCertificateASW = "C:/Certificate/ServerSSL.cer";
            // bool clientCertificateRequired = false;
            // bool checkCertificateRevocation = true;
            // SslProtocols enabledSSLProtocols = SslProtocols.Tls;

            //X509Certificate ClientCertificate = new X509Certificate(clientCertificateASW, "Kylling123");

            ////Kør på kaspers IP:
            //TcpClient connectionSocket = new TcpClient("192.168.3.148", PORT);

            bool leaveInnerStreamOpen = false;
            ///Kør på min egen IP:
            using (TcpClient connectionSocket = new TcpClient(IPAddress.Loopback.ToString(), PORT))
   
                // using (Stream ns = connectionSocket.GetStream())

            using (Stream unsecureStream = connectionSocket.GetStream())
            using (SslStream secureStream = new SslStream(unsecureStream, leaveInnerStreamOpen))
            {
               
                secureStream.AuthenticateAsClient("FakeServerName");

                using (StreamReader sr = new StreamReader(secureStream))
                using (StreamWriter sw = new StreamWriter(secureStream))
                {
                    Console.WriteLine("Client have connected");
                    sw.AutoFlush = true;

                    Client3(sr, sw);
                    //Insert specifik clients

                    Console.WriteLine("Client finished");
                }
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
