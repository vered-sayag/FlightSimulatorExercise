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

        static private bool is_connect = false;
        static public bool Is_connect
        {
            get { return is_connect; }
            set
            {
                is_connect = value;
            }
        }

        private TCPServer server;
        private void ConnectClick()
        {
            is_connect = true;
            server = new TCPServer();
            TCPClient client = new TCPClient();
        }


        private ICommand disConnectCommand;
        public ICommand DisConnectCommand
        {
            get
            {
                return disConnectCommand ?? (disConnectCommand = new CommandHandler(() => DisConnectClick()));
            }
        }

        private void DisConnectClick()
        {
            TCPClient client = new TCPClient();
            client.Close();
            server.Stop();
        }

    }
}
