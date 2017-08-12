using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Client.View;
using Client.ViewModel;
using System.ServiceModel;
using Common;
using Common.Interfaces;
using Common.Data;

namespace Client.Command
{
    class LoginCommand : ClientCommand
    {
        private LoginVM viewModel;

        public LoginCommand(LoginVM viewModel)
        {
            this.viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            if (parameter == null ||
                !(parameter is Object[]))
                return;

            Object[] parameters = parameter as Object[];
            if (parameters == null || parameters.Length != 2)
                return;

            foreach (var v in parameters)
            {
                if (v == null || v.ToString().Length == 0)
                    return;
            }

            string username = parameters[0].ToString();
            string password = parameters[1].ToString();

            User korisnik = viewModel.proxyKorisnik.UlogujKorisnika(username, password);

            if (korisnik != null)
            {
                Globals.currentUser = korisnik;
                HomeView hw = new HomeView();

                MainWindow.glavni.Close();
                hw.ShowDialog();
            }
        }
    }
}
