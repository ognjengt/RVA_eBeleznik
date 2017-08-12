using Client.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Command.OpenDialogs
{
    class OpenAddNewBeleskaDialogCommand : BeleskaCommand
    {
        public override void Execute(object parameter)
        {
            AddNewBeleskaView v = new AddNewBeleskaView();
            v.ShowDialog();
        }
    }
}
