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
    public class ConflictVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public PregaziTudjeIzmeneCommand pregaziIzmeneCommand { get; set; }
        public OdbaciSvojeIzmeneCommand odbaciSvojeCommand { get; set; }
        public EditBeleskaVM viewModel;
        public ConflictView view; 

        public ConflictVM(EditBeleskaVM vm, ConflictView view)
        {
            viewModel = vm;
            this.view = view;
            this.pregaziIzmeneCommand = new PregaziTudjeIzmeneCommand(this);
            this.odbaciSvojeCommand = new OdbaciSvojeIzmeneCommand(this);
        }
    }
}
