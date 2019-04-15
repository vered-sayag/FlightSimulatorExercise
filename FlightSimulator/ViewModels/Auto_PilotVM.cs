using FlightSimulator.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FlightSimulator.ViewModels
{
    class Auto_PilotVM : BaseNotify
    {
        private bool sending = false;
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
            Sending = true;
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
        }

   
    }
}
