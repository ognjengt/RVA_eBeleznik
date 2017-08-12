using Client.Command;
using Client.View;
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
    class AddNewUserVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public AddNewUserCommand addNewUserCommand { get; set; }
        public AddNewUserView view;

        public IUserDB proxyKorisnik;

        // Uopste ni ne treba, za sad, mozda nesto za kasnije
        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, e);
            }
        }

        public AddNewUserVM(AddNewUserView view)
        {
            this.addNewUserCommand = new AddNewUserCommand(this);
            this.view = view;

            NetTcpBinding binding = new NetTcpBinding();
            binding.TransactionFlow = true;
            ChannelFactory<IUserDB> factory = new ChannelFactory<IUserDB>(binding, new EndpointAddress("net.tcp://localhost:50000/UserConnection"));
            proxyKorisnik = factory.CreateChannel();
        }
    }
}
