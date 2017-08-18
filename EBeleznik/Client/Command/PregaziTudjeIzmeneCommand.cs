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
    public class PregaziTudjeIzmeneCommand : BeleskaCommand
    {
        private ConflictVM viewModel;
        public PregaziTudjeIzmeneCommand(ConflictVM vm)
        {
            viewModel = vm;
        }
        public override void Execute(object parameter)
        {
            bool uspesno;

            if (Globals.currentUser.Admin)
            {
                uspesno = viewModel.viewModel.homeVM.proxyBeleske.IzmeniBelesku(new Beleska()
                {
                    Id = viewModel.viewModel.BeleskaZaIzmenu.Id,
                    Naslov = viewModel.viewModel.BeleskaZaIzmenu.Naslov,
                    Sadrzaj = viewModel.viewModel.BeleskaZaIzmenu.Sadrzaj
                },"admin");
            }
            else
            {
                uspesno = viewModel.viewModel.homeVM.proxyBeleske.IzmeniBelesku(new Beleska()
                {
                    Id = viewModel.viewModel.BeleskaZaIzmenu.Id,
                    Naslov = viewModel.viewModel.BeleskaZaIzmenu.Naslov,
                    Sadrzaj = viewModel.viewModel.BeleskaZaIzmenu.Sadrzaj
                }, "regular");
            }
            if (uspesno)
            {
                MessageBox.Show("Uspesno pregazene izmene", "Uspeh");
                viewModel.view.Close();
                viewModel.viewModel.view.Close();
                viewModel.viewModel.homeVM.RefreshBeleske();
            }
            else {
                MessageBox.Show("Neuspesno pregazene izmene", "Neuspeh");
                viewModel.view.Close();
                viewModel.viewModel.view.Close();
                viewModel.viewModel.homeVM.RefreshBeleske();
            }
        }
    }
}
