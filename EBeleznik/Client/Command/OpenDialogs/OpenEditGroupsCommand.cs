using Client.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Command.OpenDialogs
{
    public class OpenEditGroupsCommand : ClientCommand
    {
        public override void Execute(object parameter)
        {
            EditGroupsView egv = new EditGroupsView();
            egv.ShowDialog();
        }
    }
}
