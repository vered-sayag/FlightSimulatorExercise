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
            }
        }
        private double throttle = 0;

        public double Throttle
        {
            set
            {
                throttle = value;
            }
        }
    }
}
