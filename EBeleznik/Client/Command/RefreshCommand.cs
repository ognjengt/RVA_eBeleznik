using Client.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Command
{
    public class RefreshCommand : BeleskaCommand
    {
        private HomeVM viewModel;
        public RefreshCommand(HomeVM homeVM)
        {
            viewModel = homeVM;
        }
        public override void Execute(object parameter)
        {
            viewModel.RefreshBeleske();
        }

        public override void UnExecute()
        {
            
        }
    }
}
