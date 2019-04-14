using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FlightSimulator.Model
{
    class TCPServer
    {
        private string IP;
        private int port;
        private TcpListener listener;
        private ClientHandler clientHandler;
        
        public TCPServer(string IP, int port)
        {
            this.IP = IP;
            this.port = port;
        }

        public void start()
        {
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse(IP), port);
            TcpListener server = new TcpListener(ep);

            try
            {
                server.Start();
            }
            catch (SocketException ex)
            {
                Console.WriteLine(ex.Message);
            }
            Thread t = new Thread(() =>
            {
                while (true)
                {
                    try
                    {
                        TcpClient client = listener.AcceptTcpClient();
                        Console.WriteLine("Got new connection");
                        clientHandler.HandleClient(client);
                    }
                    catch (SocketException)
                    {
                        break;
                    }

                }
            });
            t.Start();
            
        }



        
    }
}
