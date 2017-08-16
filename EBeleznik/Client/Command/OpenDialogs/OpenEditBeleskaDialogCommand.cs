using Client.View;
using Client.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Command.OpenDialogs
{
    public class OpenEditBeleskaDialogCommand : BeleskaCommand
    {
        public HomeVM caller;
        public OpenEditBeleskaDialogCommand(HomeVM homeVM)
        {
            caller = homeVM;
        }
        public override void Execute(object parameter)
        {
            EditBeleskaView ev = new EditBeleskaView(caller);
            ev.ShowDialog();
        }

        public override void UnExecute()
        {
            
        }
    }
}
