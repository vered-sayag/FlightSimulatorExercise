using FlightSimulator.Model;
using FlightSimulator.Model.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FlightSimulator.ViewModels
{
    public class FlightBoardViewModel : BaseNotify
    {

        public FlightBoardViewModel()
        {
            TCPServer tcpServer = TCPServer.Instance;
            tcpServer.PropertyChanged += delegate (object sender, PropertyChangedEventArgs e)
             {
                 if (tcpServer == sender)
                 {
                     Lon = tcpServer.Lon;
                     Lat = tcpServer.Lat;
                     NotifyPropertyChanged("Lon");
                     NotifyPropertyChanged("Lat");
                 }
             };
        }
        private double lon;
        public double Lon
        {
            get { return lon; }
            set
            {
                lon = value;
            }
        }

        private double lat;
        public double Lat
        {
            get { return lat; }
            set
            {
                lat = value;  
            }
        }

    }
}
