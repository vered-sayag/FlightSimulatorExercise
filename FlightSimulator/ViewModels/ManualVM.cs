using FlightSimulator.Model;
using FlightSimulator.ViewModels;
using FlightSimulator.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulator.ViewModels
{
    class ManualVM
    {
        private double rudder = 0;
        public double Rudder
        {
            set
            {
                rudder = value;
                if (!SettingsAndConnectVM.Is_connect)
                {
                    return;
                }
                TCPClient client = TCPClient.Instance;
                string command = "set controls/flight/rudder " + rudder;
                client.Write(command);
            }
                get
            { return rudder;}
        }
        private double throttle = 0;

        public double Throttle
        {
            set
            {
                throttle = value;
                if (!SettingsAndConnectVM.Is_connect)
                {
                    return;
                }
                TCPClient client = TCPClient.Instance;
                string command = "set controls/engines/current-engine/throttle " + rudder;
                client.Write(command);
            }
            get
            { return throttle;

            }
        }

        private double aileron = 0;

        public double Aileron
        {
            set
            {
                aileron = value;
                if (!SettingsAndConnectVM.Is_connect)
                {
                    return;
                }
                TCPClient client = TCPClient.Instance;
                string command = "set controls/flight/aileron " + rudder;
                client.Write(command);
            }
            get
            {
                return aileron;
            }
        }

        private double elevator = 0;

        public double Elevator
        {
            set
            {
                elevator = value;
                if (!SettingsAndConnectVM.Is_connect)
                {
                    return;
                }
                TCPClient client = TCPClient.Instance;
                string command = "set controls/flight/elevator " + rudder;
                client.Write(command);
            }
            get
            {
                return elevator;
            }
        }
    }
}
