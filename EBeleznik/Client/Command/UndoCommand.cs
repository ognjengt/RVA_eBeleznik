using Client.ViewModel;
using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Client.Command
{
    public class UndoCommand : BeleskaCommand
    {
        private HomeVM viewModel;
        public UndoCommand(HomeVM homevm)
        {
            this.viewModel = homevm;
        }
        public override void Execute(object parameter)
        {
            if (viewModel.UndoHistory.Count == 0)
            {
                MessageBox.Show("Ne postoji komanda za undo", "Ne postoji");
            }
            else
            {
                BeleskaCommand beleskaCommand = viewModel.UndoHistory[viewModel.UndoHistory.Count - 1];
                beleskaCommand.UnExecute();
                viewModel.UndoHistory.Remove(beleskaCommand);
                Globals.listaBeleskiUndo.RemoveAt(Globals.listaBeleskiUndo.Count - 1);
            }
        }

        public override void UnExecute()
        {
            
        }
    }
}
