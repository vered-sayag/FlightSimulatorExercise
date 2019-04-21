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
        TcpListener server;
        private ApplicationSettingsModel app;
        private NetworkStream stream;
        private IPEndPoint ep;

        public TCPServer()
        {
            app = new ApplicationSettingsModel();
            ep = new IPEndPoint(IPAddress.Parse(app.FlightServerIP), app.FlightInfoPort);
            server = new TcpListener(ep);
        }

        public void start()
        {
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
                        TcpClient client = server.AcceptTcpClient();
                        Console.WriteLine("Got new connection");
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
