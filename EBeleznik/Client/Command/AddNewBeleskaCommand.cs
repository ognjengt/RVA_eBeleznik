using Client.ViewModel;
using Common.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Client.Command
{
    class AddNewBeleskaCommand : BeleskaCommand
    {
        private AddNewBeleskaVM viewModel;

        public AddNewBeleskaCommand(AddNewBeleskaVM viewModel)
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
            //if (parameters == null || parameters.Length != 5)
            //{
            //    MessageBox.Show("Uneti parametri nisu validni", "Neuspeh");
            //    return;
            //}


            foreach (var v in parameters)
            {
                if (v == null || v.ToString().Length == 0)
                {
                    MessageBox.Show("Uneti parametri nisu validni", "Neuspeh");
                    return;
                }
            }

            if ((bool)parameters[2] == false && (bool)parameters[3] == false && (bool)parameters[4] == false)
            {
                MessageBox.Show("Odaberite grupu", "Odaberite grupu");
                return;
            }

            // izvuci parametre
            string naslov = parameters[0].ToString();
            string sadrzaj = parameters[1].ToString();
            string grupe = "";
            if ((bool)parameters[2] == true)
            {
                grupe += ";Sport";
            }
            if ((bool)parameters[3] == true)
            {
                grupe += ";Nauka";
            }
            if ((bool)parameters[4] == true)
            {
                grupe += ";Programiranje";
            }

            bool uspesnoDodato = viewModel.proxyBeleske.DodajBelesku(new Beleska()
            {
                Naslov = naslov,
                Sadrzaj = sadrzaj,
                Grupe = grupe
            });

            if (uspesnoDodato)
            {
                MessageBox.Show("Uspesno dodato!", "Uspeh");
                viewModel.homeVM.RefreshBeleske();
                viewModel.view.Close();
            }
            else MessageBox.Show("Neuspesno dodato!", "Neuspeh");

        }
    }
}
