using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Intrinsics.X86;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TCPServer
{
    class Start
    {
        public static int clientNumber = 1;

        public static void Starter()
        {
            Console.WriteLine("Starting convertering server...");

            int port = 9300;

            TcpListener serverSocket = new TcpListener(IPAddress.Loopback, port);

            serverSocket.Start();
            Console.WriteLine("Waiting for connection ");

            do
            {
                TcpClient connectionSocket = serverSocket.AcceptTcpClient();
                Console.WriteLine($"Connection establish {clientNumber} connected");
                Task.Run(() =>
                {
                    DoClient(connectionSocket, clientNumber++);
                });

                if (clientNumber < 1)
                {
                    break;
                }

            } while (clientNumber > 0);
        }

        public static void DoClient(TcpClient connectionSocket, int clientNumber)
        {
            Stream ns = connectionSocket.GetStream();
            StreamReader sr = new StreamReader(ns);
            StreamWriter sw = new StreamWriter(ns);
            sw.AutoFlush = true;

            sw.Write("Hej hvilken valuta til du konverter til danskekroner eller svenskekroner tryk x for at lukke programmet");
            Console.WriteLine();

            while (true)
            {

                string message = sr.ReadLine().ToLower();

                if (message.ToLower().Contains("x"))
                {
                    break;
                }

                switch (message)
                {
                    case "danskekroner":
                        sw.Write("intast beløb");
                        string amount = sr.ReadLine();
                        double svenskeKroner = double.Parse(amount);
                        double convertedAmount = Konvertering.Class1.TilDanskeKroner(svenskeKroner);
                        sw.Write($" danske kroner: {convertedAmount}");
                        break;

                    case "svenskekroner":
                        sw.Write("intast beløb");
                        string amount2 = sr.ReadLine();
                        double danskeKroner = double.Parse(amount2);
                        double convertedAmount2 = Konvertering.Class1.TilSvenskeKroner(danskeKroner);
                        sw.Write($"svenske kroner: {convertedAmount2}");
                        break;

                    default:
                        sw.Write("vælg danskekroner eller svenskekroner");
                        break;
                }

            }



            ns.Close();
            connectionSocket.Close();
        }
    }
}
