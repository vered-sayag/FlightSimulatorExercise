using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;

using System.Threading.Tasks;

namespace FlightSimulator.Model
{
    class TCPClient
    {
        #region Singleton
        private static TCPClient m_Instance = null;
        public static TCPClient Instance
        {
            get
            {
                if (m_Instance == null)
                {
                    m_Instance = new TCPClient();
                }
                return m_Instance;
            }
        }
        #endregion
        TcpClient client;
        private ApplicationSettingsModel app;
        private IPEndPoint ep;

        private NetworkStream stream;

        

        public TCPClient()
        {
            app = new ApplicationSettingsModel();
            client = new TcpClient();
            ep = new IPEndPoint(IPAddress.Parse(app.FlightServerIP), app.FlightCommandPort);
            try
            {
                while (!client.Connected)
                {
                    client.Connect(ep);
                }
            }
            catch (Exception e){}
        }

        public void Write(string command)
        {
            stream = client.GetStream();
            Console.Out.WriteLine(command.ToString());
            //using (BinaryWriter writer = new BinaryWriter(stream))
            byte[] send = Encoding.ASCII.GetBytes(command.ToString());
            
            stream.Write(send, 0, send.Length);
            Console.WriteLine(send);
            //System.Threading.Thread.Sleep(2000);
        }

        public void Close()
        {
            client.Close();
        }
    }
}
