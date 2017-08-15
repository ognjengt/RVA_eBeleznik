using Client.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Client.Command
{
    public class DeleteBeleskaCommand : BeleskaCommand
    {
        private HomeVM viewModel;
        public DeleteBeleskaCommand(HomeVM homevm)
        {
            this.viewModel = homevm;
        }
        public override void Execute(object parameter)
        {
            int id = Int32.Parse(viewModel.Selektovana.Split('-')[0]);
            viewModel.proxyBeleske.ObrisiBelesku(id);
            viewModel.RefreshBeleske();
        }
    }
}
