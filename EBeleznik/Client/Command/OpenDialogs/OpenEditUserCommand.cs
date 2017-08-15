using Client.View;
using Client.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Command.OpenDialogs
{
    public class OpenEditUserCommand : ClientCommand
    {
        private HomeVM caller;
        public OpenEditUserCommand(HomeVM homevm)
        {
            caller = homevm;
        }
        public override void Execute(object parameter)
        {
            EditUserView ev = new EditUserView(caller);
            ev.ShowDialog();
        }
    }
}
