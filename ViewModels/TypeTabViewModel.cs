using Overgave.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Data;
using System.Data;
using System.Windows.Controls;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Diagnostics;
using Accessibility;

namespace Overgave.ViewModels
{
    public class TypeTabViewModel : INotifyPropertyChanged
    {
        public string Header { get; set; }
        private bool _isSelected;

        public bool IsSelected
        {
            get { return _isSelected; }
            set { _isSelected = value; }
        }

        public TypeTabViewModel()
        {

        }


        public event PropertyChangedEventHandler PropertyChanged;
    }
}
