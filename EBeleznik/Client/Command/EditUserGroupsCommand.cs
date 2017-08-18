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
    public class EditUserGroupsCommand : ClientCommand
    {
        private EditGroupsVM viewModel;
        public EditUserGroupsCommand(EditGroupsVM viewModel)
        {
            this.viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            if (viewModel.Selektovan == null || viewModel.Selektovan == "")
            {
                MessageBox.Show("Selektujte korisnika za izmenu");
                return;
            }
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

            if ((bool)parameters[0] == false && (bool)parameters[1] == false && (bool)parameters[2] == false)
            {
                MessageBox.Show("Odaberite grupu", "Odaberite grupu");
                return;
            }

            string grupe = "nijedna";

            if ((bool)parameters[0] == true)
            {
                grupe += ";Sport";
            }
            if ((bool)parameters[1] == true)
            {
                grupe += ";Nauka";
            }
            if ((bool)parameters[2] == true)
            {
                grupe += ";Programiranje";
            }


            string selektovanKorisnik = viewModel.Selektovan;
            bool success = viewModel.proxyKorisnik.PromeniGrupe(new User()
            {
                Username = selektovanKorisnik,
                Grupe = grupe
            });

            if (success)
            {
                MessageBox.Show("Korisnik uspesno izmenjen", "Uspeh");
                viewModel.view.Close();
            }
        }
    }
}
