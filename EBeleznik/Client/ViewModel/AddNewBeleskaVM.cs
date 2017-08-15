using Client.Command;
using Client.View;
using Common;
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
    class AddNewBeleskaVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public AddNewBeleskaCommand addNewBeleskaCommand { get; set; }
        public AddNewBeleskaView view;

        public HomeVM homeVM;
        public string Sadrzaj { get; set; }

        public IBeleskeDB proxyBeleske;

        public string sportEnabled { get; set; }
        public string naukaEnabled { get; set; }
        public string programiranjeEnabled { get; set; }

        public AddNewBeleskaVM(AddNewBeleskaView view, HomeVM homeVM)
        {
            this.homeVM = homeVM;
            this.addNewBeleskaCommand = new AddNewBeleskaCommand(this);
            this.view = view;

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

            // konekcija na beleske
            NetTcpBinding binding = new NetTcpBinding();
            binding.TransactionFlow = true;
            ChannelFactory<IBeleskeDB> factory = new ChannelFactory<IBeleskeDB>(binding, new EndpointAddress("net.tcp://localhost:50001/BeleskeConnection"));
            proxyBeleske = factory.CreateChannel();

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
