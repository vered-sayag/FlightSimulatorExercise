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
            server =TCPServer.Instance;
            server.start();
            TCPClient client =TCPClient.Instance;
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
            if (is_connect)
            {
                TCPClient client = TCPClient.Instance;
                client.Close();
                server.Stop();
                is_connect = false;
            }
        }
    }
}
