using Client.Command;
using Client.View;
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
    public class EditGroupsVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public EditGroupsView view;

        public EditUserGroupsCommand editUserGroupsCommand { get; set; }
        public string Selektovan { get; set; }
        public List<string> ListaKorisnika { get; set; }

        public IUserDB proxyKorisnik;

        public EditGroupsVM(EditGroupsView view)
        {
            this.editUserGroupsCommand = new EditUserGroupsCommand(this);

            this.ListaKorisnika = new List<string>();
            this.view = view;

            NetTcpBinding binding = new NetTcpBinding();
            binding.TransactionFlow = true;
            ChannelFactory<IUserDB> factory = new ChannelFactory<IUserDB>(binding, new EndpointAddress("net.tcp://localhost:50000/UserConnection"));
            proxyKorisnik = factory.CreateChannel();

            List<User> sviKorisnici = proxyKorisnik.GetAllUsers();
            ListaKorisnika = sviKorisnici.Select(x => x.Username).ToList();
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
