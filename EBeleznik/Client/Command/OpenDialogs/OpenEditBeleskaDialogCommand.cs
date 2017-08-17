using Client.View;
using Client.ViewModel;
using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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
            string grupe = caller.Selektovana.Split('-')[1].Split('(')[1];
            grupe = grupe.Substring(0, (grupe.Length - 2));
            string[] listaGrupa = grupe.Split(';');
            bool mozeDaMenja = false;
            foreach (string grupa in listaGrupa)
            {
                if (Globals.currentUser.Grupe.Contains(grupa))
                {
                    mozeDaMenja = true;
                    EditBeleskaView ev = new EditBeleskaView(caller);
                    ev.ShowDialog();
                    break;
                }
            }
            if (!mozeDaMenja)
            {
                MessageBox.Show("Ne mozete da menjate belesku, jer ne pripadate odgovarajucoj grupi", "Greska");
                return;
            }
            
        }

        public override void UnExecute()
        {
            
        }
    }
}
