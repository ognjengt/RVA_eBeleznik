using Client.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Command
{
    public class OdbaciSvojeIzmeneCommand : BeleskaCommand
    {
        public ConflictVM conflictVM;
        public OdbaciSvojeIzmeneCommand(ConflictVM viewModel)
        {
            conflictVM = viewModel;
        }
        public override void Execute(object parameter)
        {
            conflictVM.view.Close();
            conflictVM.viewModel.view.Close();
            conflictVM.viewModel.homeVM.RefreshBeleske();
        }

        public override void UnExecute()
        {
            
        }
    }
}
