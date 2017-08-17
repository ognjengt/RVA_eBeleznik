using Client.View;
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
    public class EditBeleskaCommand : BeleskaCommand
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
            if (parameters == null || parameters.Length != 6)
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

            // Proveri u bazi da li je izmenjena
            Beleska beleskaZaPoklapanje = viewModel.proxyBeleske.GetBeleskaById(viewModel.prvobitnaBeleska.Id);
            if (beleskaZaPoklapanje.Naslov != viewModel.prvobitnaBeleska.Naslov || beleskaZaPoklapanje.Sadrzaj != viewModel.prvobitnaBeleska.Sadrzaj || beleskaZaPoklapanje.Grupe != viewModel.prvobitnaBeleska.Grupe)
            {
                ConflictView conflictV = new ConflictView(viewModel);
                conflictV.ShowDialog();
                return;
            }

            bool uspesno = viewModel.proxyBeleske.IzmeniBelesku(new Beleska()
            {
                Id = Int32.Parse(parameters[5].ToString()),
                Naslov = parameters[0].ToString(),
                Sadrzaj = parameters[1].ToString(),
                Grupe = grupe
            });

            if (uspesno)
            {
                MessageBox.Show("Beleska uspesno izmenjena", "Uspeh");
                viewModel.view.Close();
                viewModel.homeVM.RefreshBeleske();
            }
            else MessageBox.Show("Beleska neuspesno izmenjena", "Neuspeh");
        }

        public override void UnExecute()
        {
            throw new NotImplementedException();
        }
    }
}
