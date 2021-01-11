using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace EchoClient
{
    class Client
    {
        public static void Start()
        {
            Console.WriteLine("Tryk på en tast for at forsætte");
            Console.ReadKey();

            int port = 9300;

            TcpClient clientSocket = new TcpClient("localhost", port);

            NetworkStream ns = clientSocket.GetStream();
            StreamReader sr = new StreamReader(ns);
            StreamWriter sw = new StreamWriter(ns);
            sw.AutoFlush = true;

            while (true)
            {
                string message = sr.ReadLine();

                Console.WriteLine(message);
                sw.Write(Console.ReadLine());
            }
        }
    }
}
