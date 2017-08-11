using Client.Command;
using Common.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Client.ViewModel
{
    class LoginVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public LoginCommand loginCommand { get; set; }

        public IUserDB proxyKorisnik;

        public LoginVM()
        {
            this.loginCommand = new LoginCommand(this);

            NetTcpBinding binding = new NetTcpBinding();
            binding.TransactionFlow = true;
            ChannelFactory<IUserDB> factory = new ChannelFactory<IUserDB>(binding, new EndpointAddress("net.tcp://localhost:50000/UserConnection"));
            proxyKorisnik = factory.CreateChannel();
        }

        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, e);
            }
        }
    }
}
