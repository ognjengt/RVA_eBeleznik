using Client.Command;
using Client.Command.OpenDialogs;
using Common;
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

        public string showIfAdmin { get; set; }
        public string usernameText { get; set; }

        // Komande
        public OpenAddNewUserDialogCommand openAddNewUserDialogCommand { get; set; }
        public OpenAddNewBeleskaDialogCommand openAddNewBeleskaDialogCommand { get; set; }

        // Uopste ni ne treba, za sad, mozda nesto za kasnije
        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, e);
            }
        }

        public HomeVM()
        {
            this.openAddNewUserDialogCommand = new OpenAddNewUserDialogCommand();
            this.openAddNewBeleskaDialogCommand = new OpenAddNewBeleskaDialogCommand();
            this.usernameText = Globals.currentUser.Ime+ " " +Globals.currentUser.Prezime;

            if (Globals.currentUser.Admin)
            {
                showIfAdmin = "Visible";
            }
            else showIfAdmin = "Hidden";


            // Konekcija na beleske i klijenta

        }
    }
}
