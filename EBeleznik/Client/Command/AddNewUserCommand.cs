using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Command
{
    class AddNewUserCommand : ClientCommand
    {
        public event EventHandler CanExecuteChanged;
        

        public AddNewUserCommand()
        {
            if (CanExecuteChanged != null)
            {
                CanExecuteChanged(null, null);
            }
        }

        public override void Execute(object parameter)
        {
            // otvori prozor za dodavanje novog
        }
    }
}
