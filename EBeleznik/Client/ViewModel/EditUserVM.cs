using Client.Command;
using Client.View;
using Common;
using Common.Data;
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
    public class EditUserVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public HomeVM homeVM;
        public EditUserView view;

        public EditUserCommand editUserCommand { get; set; }
        public User KorisnikZaIzmenu { get; set; }

        public IUserDB proxyUser;
        public EditUserVM(EditUserView view, HomeVM homeVM)
        {
            this.editUserCommand = new EditUserCommand(this);
            this.homeVM = homeVM;
            this.view = view;
            KorisnikZaIzmenu = Globals.currentUser;

            NetTcpBinding binding = new NetTcpBinding();
            binding.TransactionFlow = true;
            ChannelFactory<IUserDB> factory = new ChannelFactory<IUserDB>(binding, new EndpointAddress("net.tcp://localhost:50000/UserConnection"));
            proxyUser = factory.CreateChannel();
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
