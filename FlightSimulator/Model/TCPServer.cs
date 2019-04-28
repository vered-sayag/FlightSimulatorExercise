using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FlightSimulator.ViewModels;


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
                FlightBoardViewModel fbvm = FlightBoardViewModel.Instance;
                string prop;
                double temp_lon, temp_lat;
                double[] numbers;
                while (true)
                {
                    try
                    {
                        TcpClient client = server.AcceptTcpClient();
                        using (BinaryReader reader = new BinaryReader(stream))
                        {
                            prop = Convert.ToString(reader.Read());
                            numbers = prop.Split(',').Select(n => double.Parse(n)).ToArray();
                            temp_lon = numbers[0];
                            temp_lat = numbers[1];
                            fbvm.Lon = temp_lon;
                            fbvm.Lat = temp_lat;
                        }
                    }
                    catch (SocketException)
                    {
                        break;
                    }
                }
            });
            t.Start();   
        }

        public void Stop()
        {
            server.Stop();
        }
    }
}
