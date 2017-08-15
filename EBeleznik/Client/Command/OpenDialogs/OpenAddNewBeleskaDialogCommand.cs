using Client.View;
using Client.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Command.OpenDialogs
{
    public class OpenAddNewBeleskaDialogCommand : BeleskaCommand
    {
        public HomeVM caller;
        public OpenAddNewBeleskaDialogCommand(HomeVM homevm)
        {
            caller = homevm;
        }
        public override void Execute(object parameter)
        {
            AddNewBeleskaView v = new AddNewBeleskaView(caller);
            v.ShowDialog();
        }
    }
}
