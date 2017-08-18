using Client.ViewModel;
using Common;
using Common.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Client.Command
{
    public class DeleteBeleskaCommand : BeleskaCommand
    {
        public HomeVM viewModel;
        private Beleska beleskaZaBrisanje;
        public DeleteBeleskaCommand(HomeVM homevm)
        {
            this.viewModel = homevm;
        }
        public DeleteBeleskaCommand() { }
        public override void Execute(object parameter)
        {
            int id = 0;
            // provera dalje za parameters[5]
            if (parameter == null)
            {
                if (viewModel.Selektovana == null || viewModel.Selektovana == "")
                {
                    MessageBox.Show("Selektujte belesku za brisanje");
                    return;
                }
                id = Int32.Parse(viewModel.Selektovana.Split('-')[0]);
            }
            else
            {
                Object[] parameters = parameter as Object[];
                id = Int32.Parse(parameters[5].ToString());
            }
            beleskaZaBrisanje = viewModel.proxyBeleske.GetBeleskaById(id);
            //Globals.listaObrisanih.Add(beleskaZaBrisanje);
            viewModel.proxyBeleske.ObrisiBelesku(id);
            viewModel.RefreshBeleske();
            viewModel.UndoHistory.Add(this);
            Globals.listaBeleskiUndo.Add(beleskaZaBrisanje);
        }

        public override void UnExecute()
        {
            // Add Command
            Beleska dodataBeleska = viewModel.proxyBeleske.DodajBelesku(Globals.listaBeleskiUndo[Globals.listaBeleskiUndo.Count - 1]);
            viewModel.RefreshBeleske();
            viewModel.RedoHistory.Add(this);
            Globals.listaBeleskiRedo.Add(dodataBeleska);
        }
    }
}
