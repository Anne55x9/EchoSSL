using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EchoSSL
{
    class Program
    {
        private const int PORT = 7777;

        static void Main(string[] args)
        {
            ServerSLL server = new ServerSLL(PORT);
            server.StartServer();

            Console.ReadLine();

        }
    }
}
