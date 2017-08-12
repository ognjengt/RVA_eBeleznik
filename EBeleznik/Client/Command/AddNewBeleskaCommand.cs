using Client.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            // dodaj belesku
        }
    }
}
