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
    public class CloneBeleskaCommand : BeleskaCommand
    {
        private HomeVM viewModel;
        public CloneBeleskaCommand(HomeVM homevm)
        {
            this.viewModel = homevm;
        }
        public override void Execute(object parameter)
        {
            if (viewModel.Selektovana == null || viewModel.Selektovana == "")
            {
                MessageBox.Show("Selektujte belesku za kloniranje");
                return;
            }

            int id = Int32.Parse(viewModel.Selektovana.Split('-')[0]);
            Beleska b = viewModel.proxyBeleske.GetBeleskaById(id);
            Beleska clone = b.Clone();
            Beleska dodataBeleska = viewModel.proxyBeleske.DodajBelesku(clone);

            if (dodataBeleska != null)
            {
                MessageBox.Show("Beleska uspesno klonirana", "Uspeh");
                viewModel.RefreshBeleske();
            }
            else MessageBox.Show("Beleska neuspesno klonirana", "Neuspeh");
        }

        public override void UnExecute()
        {
            throw new NotImplementedException();
        }
    }
}
