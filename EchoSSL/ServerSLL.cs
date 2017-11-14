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
            TcpListener serverSocket = new TcpListener(IPAddress.Loopback, PORT);
            serverSocket.Start();
            Console.WriteLine("Server Started");

            string serverCertificateASW = "C:/Certificates/ServerSSL.pfx";
            //bool clientCertificateRequired = false;
            //bool checkCertificateRevocation = true;
            //SslProtocols enabledSSLProtocols = SslProtocols.Tls;

            X509Certificate serverCertificate = new X509Certificate2(serverCertificateASW, "mysecret");

            bool leaveInnerStreamOpen = false;

            using (TcpClient connectionSocket = serverSocket.AcceptTcpClient())
            using (Stream unsecureStream = connectionSocket.GetStream())

            using (SslStream secureStream = new SslStream(unsecureStream, leaveInnerStreamOpen))
            {
                secureStream.AuthenticateAsServer(serverCertificate);

                //using (Stream ns = connectionSocket.GetStream())
                using (StreamReader sr = new StreamReader(secureStream))
                using (StreamWriter sw = new StreamWriter(secureStream))
                {
                    Console.WriteLine("Server started");

                    sw.AutoFlush = true;

                    string message = sr.ReadLine();
                    string answer = "";

                    while (!string.IsNullOrEmpty(message))
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
}
