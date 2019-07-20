using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    class TCPServer : INotifyPropertyChanged
    {
        TcpListener server;
        private ApplicationSettingsModel app;
        private NetworkStream stream;
        private IPEndPoint ep;
        private BinaryReader reader;
        private readonly object locker;
        private Thread t;
        private double lon;
        private double lat;
        public double Lon { set; get; }
        public double Lat { set; get; }

        public event PropertyChangedEventHandler PropertyChanged;
        #region Singleton
        private static TCPServer m_Instance = null;
        public static TCPServer Instance
        {
            get
            {
                if (m_Instance == null)
                {
                    m_Instance = new TCPServer();
                }
                return m_Instance;
            }
        }
        #endregion
        public TCPServer()
        {
            IPAddress localAddr = IPAddress.Parse(ApplicationSettingsModel.Instance.FlightServerIP);
            server = new TcpListener(localAddr, ApplicationSettingsModel.Instance.FlightInfoPort);
            locker = new object();
        }

        public void start()
        {


            t = new Thread(() =>
             {
                try
                {

                    server.Start();
                    TcpClient client = server.AcceptTcpClient();
                    //FlightBoardViewModel fbvm = FlightBoardViewModel.Instance;
                    while (true)

                    {
                        try
                        {
                            reader = new BinaryReader(client.GetStream());
                            string input = ""; // input will be stored here
                            char s;
                            while ((s = reader.ReadChar()) != '\n') input += s; // read untill \n
                            string[] param = input.Split(','); // split by comma

                            lock (locker)
                            {
                                 // take from the flight only the lon and the lat
                                 //fbvm.change(Convert.ToDouble(param[0]), );
                                 Lon= Convert.ToDouble(param[0]);
                                 Lat = Convert.ToDouble(param[1]);
                                 PropertyChanged(this, new PropertyChangedEventArgs("Lat&Lon"));
                             }
                        }
                        catch
                        {
                            break;
                        }
                    }
                    client.Close();
                }
                catch
                {

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
