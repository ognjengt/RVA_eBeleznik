using Client.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Command.OpenDialogs
{
    class OpenAddNewUserDialogCommand : ClientCommand
    {   
        public override void Execute(object parameter)
        {
            AddNewUserView newView = new AddNewUserView();
            newView.ShowDialog();
        }
    }
}
