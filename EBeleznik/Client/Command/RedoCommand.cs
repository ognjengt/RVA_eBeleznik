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
    public class RedoCommand : BeleskaCommand
    {
        private HomeVM viewModel;
        public RedoCommand(HomeVM homevm)
        {
            this.viewModel = homevm;
        }
        public override void Execute(object parameter)
        {
            if (viewModel.RedoHistory.Count == 0)
            {
                MessageBox.Show("Nema komandi za redo", "Nema komandi");
            }
            else
            {
                BeleskaCommand beleskaCommand = viewModel.RedoHistory[viewModel.RedoHistory.Count - 1];
                Object[] parametri = new Object[5];
                parametri[0] = Globals.listaBeleskiRedo[Globals.listaBeleskiRedo.Count - 1].Naslov;
                parametri[1] = Globals.listaBeleskiRedo[Globals.listaBeleskiRedo.Count - 1].Sadrzaj;
                // provera za grupe
                parametri[2] = true;
                parametri[3] = false;
                parametri[4] = true;
                beleskaCommand.Execute(parametri);
                viewModel.RedoHistory.Remove(beleskaCommand);
                Globals.listaBeleskiRedo.RemoveAt(Globals.listaBeleskiRedo.Count - 1);
            }
        }

        public override void UnExecute()
        {

        }
    }
}
