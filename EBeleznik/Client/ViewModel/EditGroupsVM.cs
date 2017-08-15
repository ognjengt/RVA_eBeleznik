using Client.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.ViewModel
{
    public class EditGroupsVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public EditGroupsView view;

        public EditGroupsVM(EditGroupsView view)
        {
            this.view = view;
        }

        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, e);
            }
        }
    }
}
