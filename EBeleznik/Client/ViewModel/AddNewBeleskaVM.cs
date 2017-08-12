using Client.Command;
using Client.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.ViewModel
{
    class AddNewBeleskaVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public AddNewBeleskaCommand addNewBeleskaCommand { get; set; }
        public AddNewBeleskaView view;

        public AddNewBeleskaVM(AddNewBeleskaView view)
        {
            this.addNewBeleskaCommand = new AddNewBeleskaCommand(this);
            this.view = view;

            // konekcija na beleske
        }
    }
}
