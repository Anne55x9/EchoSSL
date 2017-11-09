using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientSLL
{
    class Program
    {
        private const int PORT = 7777;
        static void Main(string[] args)
        {
            ClientSLL client = new ClientSLL(PORT);
            client.StartClient();

            Console.ReadLine();
        }
    }
}
