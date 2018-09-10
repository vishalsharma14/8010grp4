using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4
{
    class VM: INotifyPropertyChanged
    {
     object selectedItem;
     public object SelectedItem
    {
        get { return selectedItem; }
        set { selectedItem = value; NotifyChanged(); }
    }
    public event PropertyChangedEventHandler PropertyChanged;
    private void NotifyChanged([CallerMemberName] string name = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
}