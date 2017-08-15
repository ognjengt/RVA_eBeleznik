using Client.ViewModel;
using Common;
using Common.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Client.Command
{
    public class EditUserCommand : ClientCommand
    {
        private EditUserVM viewModel;
        public EditUserCommand(EditUserVM viewModel)
        {
            this.viewModel = viewModel;
        }
        public override void Execute(object parameter)
        {
            if (parameter == null ||
                !(parameter is Object[]))
            {
                MessageBox.Show("Uneti parametri nisu validni", "Neuspeh");
                return;
            }

            Object[] parameters = parameter as Object[];
            if (parameters == null || parameters.Length != 3)
            {
                MessageBox.Show("Uneti parametri nisu validni", "Neuspeh");
                return;
            }


            foreach (var v in parameters)
            {
                if (v == null || v.ToString().Length == 0)
                {
                    MessageBox.Show("Uneti parametri nisu validni", "Neuspeh");
                    return;
                }
            }

            bool uspesno = viewModel.proxyUser.UpdateUser(new User()
            {
                Username = parameters[0].ToString(),
                Ime = parameters[1].ToString(),
                Prezime = parameters[2].ToString()
            });

            if (uspesno)
            {
                MessageBox.Show("Korisnik uspesno izmenjen", "Uspeh");
                viewModel.view.Close();
                Globals.currentUser.Ime = parameters[1].ToString();
                Globals.currentUser.Prezime = parameters[2].ToString();
                viewModel.homeVM.RefreshUserData();
            }
            else MessageBox.Show("Korisnik neuspesno izmenjen", "Neuspeh");
        }
    }
}
