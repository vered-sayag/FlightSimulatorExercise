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
        private ICommand settingsCommand;
        public ICommand SettingsCommand
        {
            get
            {
                return settingsCommand ?? (settingsCommand = new CommandHandler(() => SettingsClick()));
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
            //TCPServer server = new TCPServer(txtServerIP);
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
            // call model to dis - connect
        }

    }
}
