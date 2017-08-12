using Client.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Data;
using System.Windows;

namespace Client.Command
{
    class AddNewUserCommand : ClientCommand
    {
        private AddNewUserVM viewModel;

        public AddNewUserCommand(AddNewUserVM viewModel)
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
            if (parameters == null || parameters.Length != 4)// promeniti, kad dodam grupe 
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

            bool success = viewModel.proxyKorisnik.AddUser(new User()
            {
                Username = parameters[0].ToString(),
                Ime = parameters[1].ToString(),
                Prezime = parameters[2].ToString(),
                Password = parameters[3].ToString(),
                Admin = false,
                Grupe = ""
            });

            if (success)
            {
                MessageBox.Show("Uspesno dodat korisnik " + parameters[0].ToString(), "Uspeh");
                viewModel.view.Close();
            }
            else
            {
                MessageBox.Show("Korisnik sa ovim username-om vec postoji", "Neuspeh");
                return;
            } 
        }
    }
}
