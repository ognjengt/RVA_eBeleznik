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
    public class DeleteBeleskaCommand : BeleskaCommand
    {
        private HomeVM viewModel;
        private Beleska beleskaZaBrisanje;
        public DeleteBeleskaCommand(HomeVM homevm)
        {
            this.viewModel = homevm;
        }
        public DeleteBeleskaCommand() { }
        public override void Execute(object parameter)
        {
            int id = Int32.Parse(viewModel.Selektovana.Split('-')[0]);
            beleskaZaBrisanje = viewModel.proxyBeleske.GetBeleskaById(id);
            viewModel.proxyBeleske.ObrisiBelesku(id);
            viewModel.RefreshBeleske();

        }

        public override void UnExecute()
        {
            
        }
    }
}
