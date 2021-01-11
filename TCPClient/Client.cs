using System;
using System.Net;

namespace TCPClient
{
    public class Client
    {
        public static void Start()
        {
            Console.WriteLine("tryk en tast for at forsætte");
            Console.ReadKey();

            int port = 4646;

            TCPClient clientSocket = new TCPClient(, port);
        }
    }
}