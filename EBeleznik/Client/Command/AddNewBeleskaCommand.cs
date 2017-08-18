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
    class AddNewBeleskaCommand : BeleskaCommand
    {
        private AddNewBeleskaVM viewModel;
        private Beleska beleskaZaDodavanje;

        public AddNewBeleskaCommand(AddNewBeleskaVM viewModel)
        {
            this.viewModel = viewModel;
        }

        public AddNewBeleskaCommand() { }

        public override void Execute(object parameter)
        {
            if (parameter == null ||
                !(parameter is Object[]))
            {
                MessageBox.Show("Uneti parametri nisu validni", "Neuspeh");
                return;
            }

            Object[] parameters = parameter as Object[];


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

            beleskaZaDodavanje = new Beleska()
            {
                Naslov = naslov,
                Sadrzaj = sadrzaj,
                Grupe = grupe
            };

            Beleska dodataBeleska = viewModel.proxyBeleske.DodajBelesku(beleskaZaDodavanje);
            viewModel.homeVM.UndoHistory.Add(this);
            Globals.listaBeleskiUndo.Add(dodataBeleska);

            if (dodataBeleska != null)
            {
                MessageBox.Show("Uspesno dodato!", "Uspeh");
                viewModel.homeVM.RefreshBeleske();
                viewModel.view.Close();
            }
            else MessageBox.Show("Neuspesno dodato!", "Neuspeh");

        }

        public override void UnExecute()
        {
            // Delete
            viewModel.homeVM.proxyBeleske.ObrisiBelesku(Globals.listaBeleskiUndo[Globals.listaBeleskiUndo.Count - 1].Id);
            viewModel.homeVM.RefreshBeleske();
            viewModel.homeVM.RedoHistory.Add(this);
            Globals.listaBeleskiRedo.Add(beleskaZaDodavanje);
        }
    }
}
