using FlightSimulator.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FlightSimulator.ViewModels
{
    class CloseVM
    {
        private ICommand closeCommand;
        public ICommand CloseCommand
        {
            get
            {
                return closeCommand ?? (closeCommand = new CommandHandler(() => CloseClick()));
            }
        }
        private void CloseClick()
        {
            
            Console.WriteLine("endddd!!!");
        }
    }
}
