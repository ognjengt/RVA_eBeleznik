using Client.Command;
using Client.Command.OpenDialogs;
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
    public class HomeVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string showIfAdmin { get; set; }
        public string usernameText { get; set; }
        public List<Beleska> Beleske { get; set; }

        public List<string> ListaNazivaBeleski { get; set; }
        public string Selektovana { get; set; }

        public IBeleskeDB proxyBeleske;

        // Komande
        public OpenAddNewUserDialogCommand openAddNewUserDialogCommand { get; set; }
        public OpenAddNewBeleskaDialogCommand openAddNewBeleskaDialogCommand { get; set; }
        public OpenEditBeleskaDialogCommand openEditBeleskaDialogCommand { get; set; }
        public OpenEditUserCommand openEditUserCommand { get; set; }
        public DeleteBeleskaCommand deleteBeleskaCommand { get; set; }
        public OpenEditGroupsCommand openEditGroupsCommand { get; set; }
        public CloneBeleskaCommand cloneBeleskaCommand { get; set; }

        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, e);
            }
        }

        public void RefreshBeleske()
        {
            Beleske = proxyBeleske.GetBeleskeByUser(Globals.currentUser);

            ListaNazivaBeleski = new List<string>();
            foreach (Beleska beleska in Beleske)
            {
                ListaNazivaBeleski.Add(beleska.Id+"-"+beleska.Naslov + " (" + beleska.Grupe.Substring(1) + ") ");
            }
            OnPropertyChanged(new PropertyChangedEventArgs("ListaNazivaBeleski"));
        }

        public void RefreshUserData()
        {
            this.usernameText = Globals.currentUser.Ime + " " + Globals.currentUser.Prezime;
            OnPropertyChanged(new PropertyChangedEventArgs("usernameText"));
        }

        public HomeVM()
        {
            this.openAddNewUserDialogCommand = new OpenAddNewUserDialogCommand();
            this.openAddNewBeleskaDialogCommand = new OpenAddNewBeleskaDialogCommand(this); // saljem ovaj VM, da bih mogao da refreshujem kasnije
            this.openEditBeleskaDialogCommand = new OpenEditBeleskaDialogCommand(this); // i ovde kasnije slati da bi se moglo refreshovati
            this.openEditUserCommand = new OpenEditUserCommand(this); // da bi se moglo refeshovati
            this.deleteBeleskaCommand = new DeleteBeleskaCommand(this);
            this.openEditGroupsCommand = new OpenEditGroupsCommand();
            this.cloneBeleskaCommand = new CloneBeleskaCommand(this);

            this.usernameText = Globals.currentUser.Ime+ " " +Globals.currentUser.Prezime;

            if (Globals.currentUser.Admin)
            {
                showIfAdmin = "Visible";
            }
            else showIfAdmin = "Hidden";


            NetTcpBinding binding = new NetTcpBinding();
            binding.TransactionFlow = true;
            ChannelFactory<IBeleskeDB> factory = new ChannelFactory<IBeleskeDB>(binding, new EndpointAddress("net.tcp://localhost:50001/BeleskeConnection"));
            proxyBeleske = factory.CreateChannel();
            RefreshBeleske();
        }
    }
}
