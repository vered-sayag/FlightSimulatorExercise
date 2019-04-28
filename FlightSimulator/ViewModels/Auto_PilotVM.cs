using FlightSimulator.Model;
using FlightSimulator.Views;
using FlightSimulator.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using FlightSimulator.ViewModels;

namespace FlightSimulator.ViewModels
{
    class Auto_PilotVM : BaseNotify
    {
        private bool sending = true;
        public bool Sending
        {
            get { return sending; }
            set
            {
                sending = value;
                NotifyPropertyChanged("Sending");
            }
        }
        
       
        private string setComendText;
        public string SetComendText
        {
            get { return setComendText; }
            set
            {
                setComendText = value;
                NotifyPropertyChanged("SetComendText");
                if (setComendText != "")
                {
                    Sending = false;
                }else
                {
                    Sending = true;
                }
            }
        }

        private ICommand okCommand;
        public ICommand OkCommand
        {
            get
            {
                return okCommand ?? (okCommand = new CommandHandler(() => OkClick()));
            }
        }

        private void OkClick()
        {
            if (!SettingsAndConnectVM.Is_connect)
            {
                return;
            }
            Sending = true;
            //using (StringReader reader = new StringReader(setComendText))
            //{
            //    string command;
            //    while ((command = reader.ReadLine()) != null)
            //    {
            //        TCPClient client = TCPClient.Instance;
            //        command = command + "\r\n"; // check if work
                   
            //    }
            //}
            TCPClient client = TCPClient.Instance;
            client.AutoWrite(setComendText);
        }

        private ICommand clearCommand;
        public ICommand ClearCommand
        {
            get
            {
                return clearCommand ?? (clearCommand = new CommandHandler(() => ClearClick()));
            }
        }

        private void ClearClick()
        {
            SetComendText = "";
            Sending = true;
        }

   
    }
}
