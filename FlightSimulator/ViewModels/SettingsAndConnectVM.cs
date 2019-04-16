using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Input;
using FlightSimulator.Model;


namespace FlightSimulator.Views
{
    class SettingsAndConnectVM
    {
        private ICommand setingCommand;
        public ICommand SetingCommand
        {
            get
            {
                return setingCommand ?? (setingCommand = new CommandHandler(() => SettingsClick()));
            }
        }

        private void SettingsClick()
        {
            SettingsWin s = new SettingsWin();
            s.ShowDialog();
        }

        private ICommand connectCommand;
        public ICommand ConnectCommand
        {
            get
            {
                return connectCommand ?? (connectCommand = new CommandHandler(() => ConnectClick()));
            }
        }

        private void ConnectClick()
        {
        // TO-DO!!!
        // call modal to conect
        }


        private ICommand disConnectCommand;
        public ICommand DisConnectCommand
        {
            get
            {
                return connectCommand ?? (connectCommand = new CommandHandler(() => DisConnectClick()));
            }
        }

        private void DisConnectClick()
        {
            // TO-DO!!!
            // call modal to dis - conect
        }

    }
}
