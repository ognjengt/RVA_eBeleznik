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
    public class PregaziTudjeIzmeneCommand : BeleskaCommand
    {
        private ConflictVM viewModel;
        public PregaziTudjeIzmeneCommand(ConflictVM vm)
        {
            viewModel = vm;
        }
        public override void Execute(object parameter)
        {
            bool uspesno = viewModel.viewModel.homeVM.proxyBeleske.IzmeniBelesku(viewModel.viewModel.BeleskaZaIzmenu);
            if (uspesno)
            {
                MessageBox.Show("Uspesno pregazene izmene", "Uspeh");
                viewModel.view.Close();
                viewModel.viewModel.view.Close();
                viewModel.viewModel.homeVM.RefreshBeleske();
            }
            else {
                MessageBox.Show("Neuspesno pregazene izmene", "Neuspeh");
                viewModel.view.Close();
                viewModel.viewModel.view.Close();
                viewModel.viewModel.homeVM.RefreshBeleske();
            }
        }

        public override void UnExecute()
        {
            
        }
    }
}
