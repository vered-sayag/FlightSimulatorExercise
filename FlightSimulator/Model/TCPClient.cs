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
        private readonly object locker;
        private NetworkStream stream;

        

        public TCPClient()
        {
            locker = new object();
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
            byte[] send = Encoding.ASCII.GetBytes(command.ToString());
            stream.Write(send, 0, send.Length);
            //System.Threading.Thread.Sleep(2000);
        }

        public void AutoWrite(string command)
        {
            stream = client.GetStream();
            List<string> listString = command.Split('\r').ToList();
            for (int i = 0; i < listString.Count; i++)
            {
                string word = listString[i];
                if (word[0] == '\n')
                {
                    listString[i] = word.Replace("\n", "");
                }
                    listString[i] += "\r\n";
                }
                Thread threadClient = new Thread(() =>
                {
                    foreach (string oneCommand in listString)
                    {
                    lock (locker)
                    {
                        Console.WriteLine(oneCommand);
                        byte[] byteTime = System.Text.Encoding.ASCII.GetBytes(oneCommand);
                        stream.Write(byteTime, 0, byteTime.Length);
                     }
                    Thread.Sleep(2000);
                 }
            });
            threadClient.Start();
   

        }

        public void Close()
        {
            client.Close();
        }
    }
}
