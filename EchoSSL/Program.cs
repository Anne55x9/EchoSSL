using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace EchoSSL
{
    public class Program
    {
        private const int PORT = 7777;

        static void Main(string[] args)
        {
            ServerSLL server = new ServerSLL(PORT);
            server.StartServer();

            //Certificate SSL secure

            

            Console.ReadLine();

        }
    }
}
