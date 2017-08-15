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
    class EditBeleskaCommand : BeleskaCommand
    {
        private EditBeleskaVM viewModel;
        public EditBeleskaCommand(EditBeleskaVM viewModel)
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
            if (parameters == null || parameters.Length != 5)
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

            if ((bool)parameters[2] == false && (bool)parameters[3] == false && (bool)parameters[4] == false)
            {
                MessageBox.Show("Odaberite grupu", "Odaberite grupu");
                return;
            }

            bool uspesno = viewModel.proxyBeleske.IzmeniBelesku(new Beleska()
            {
                Naslov = parameters[0].ToString(),
                Sadrzaj = parameters[1].ToString(),
                Grupe = "Sport"
            });

            if (uspesno)
            {
                MessageBox.Show("Beleska uspesno izmenjena", "Uspeh");
            }
            else MessageBox.Show("Beleska neuspesno izmenjena", "Neuspeh");
        }
    }
}
