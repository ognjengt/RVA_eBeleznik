using Client.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.ViewModel
{
    class HomeVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string showAdmin { get; set; }

        // Komande
        public AddNewUserCommand addNewUserCommand { get; set; }

        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, e);
            }
        }

        public HomeVM()
        {
            this.addNewUserCommand = new AddNewUserCommand();

            // ako je Globals.currentUser.admin == true
        }
    }
}
