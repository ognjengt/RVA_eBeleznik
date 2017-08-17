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
    public class EditBeleskaVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public EditBeleskaCommand editBeleskaCommand { get; set; }
        public string ifAdmin { get; set; }

        public EditBeleskaView view;
        public HomeVM homeVM;
        private int Id;
        public Beleska BeleskaZaIzmenu { get; set; }
        public Beleska prvobitnaBeleska { get; set; }

        public string sportEnabled { get; set; }
        public string naukaEnabled { get; set; }
        public string programiranjeEnabled { get; set; }

        public string sportChecked { get; set; }
        public string naukaChecked { get; set; }
        public string programiranjeChecked { get; set; }

        public IBeleskeDB proxyBeleske;

        public EditBeleskaVM(EditBeleskaView view, HomeVM homeVM)
        {
            this.editBeleskaCommand = new EditBeleskaCommand(this);
            this.view = view;
            this.homeVM = homeVM;
            if (Globals.currentUser.Admin)
            {
                ifAdmin = "Visible";
            }
            else ifAdmin = "Hidden";

            Id = Int32.Parse(homeVM.Selektovana.Split('-')[0]);

            NetTcpBinding binding = new NetTcpBinding();
            binding.TransactionFlow = true;
            ChannelFactory<IBeleskeDB> factory = new ChannelFactory<IBeleskeDB>(binding, new EndpointAddress("net.tcp://localhost:50001/BeleskeConnection"));
            proxyBeleske = factory.CreateChannel();

            prvobitnaBeleska = new Beleska();

            BeleskaZaIzmenu = proxyBeleske.GetBeleskaById(Id);
            prvobitnaBeleska.Id = BeleskaZaIzmenu.Id;
            prvobitnaBeleska.Naslov = BeleskaZaIzmenu.Naslov;
            prvobitnaBeleska.Sadrzaj = BeleskaZaIzmenu.Sadrzaj;

            // Checkovanje
            if (BeleskaZaIzmenu.Grupe.Contains("Sport"))
            {
                sportChecked = "True";
            }
            else sportChecked = "False";

            if (BeleskaZaIzmenu.Grupe.Contains("Nauka"))
            {
                naukaChecked = "True";
            }
            else naukaChecked = "False";

            if (BeleskaZaIzmenu.Grupe.Contains("Programiranje"))
            {
                programiranjeChecked = "True";
            }
            else programiranjeChecked = "False";


            // Enablovanje
            if (Globals.currentUser.Grupe.Contains("Sport"))
            {
                sportEnabled = "True";
            }
            else sportEnabled = "False";

            if (Globals.currentUser.Grupe.Contains("Nauka"))
            {
                naukaEnabled = "True";
            }
            else naukaEnabled = "False";

            if (Globals.currentUser.Grupe.Contains("Programiranje"))
            {
                programiranjeEnabled = "True";
            }
            else programiranjeEnabled = "False";
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
