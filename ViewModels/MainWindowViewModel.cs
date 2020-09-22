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

namespace Overgave.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private List<Aircraft> _aircraftList;
        private List<MVAta> _ataList;
        private List<SubAta> _subAtaList;
        private List<CBItem> _cbItems = new List<CBItem>();
        private ObservableCollection<TabViewModel> _tabs;


        public MainWindowViewModel()
        {
            LoadInitialData();
        }

        #region Models
        public class MVAta
        {
            public int ATA { get; set; }
            public string AtaDescription { get; set; }
        }

        public List<Aircraft> AircraftList
        {
            get { return _aircraftList; }
        }

        public List<MVAta> ATAList
        {
            get { return _ataList; }
        }

        public List<SubAta> SubATAList
        {
            get { return _subAtaList; }
        }

        public class CBItem
        {
            public string Content { get; set; }
            public bool IsChecked { get; set; }
        }

        public List<CBItem> CBItems
        {
            get { return _cbItems; }
        }

        public ObservableCollection<TabViewModel> tabs 
        {
            get { return _tabs; }
        }
        #endregion

        #region Commands
        private ICommand _typeChecksChanged;
        #endregion

        private void LoadInitialData()
        {
            using (OvergaveContext _db = new OvergaveContext())
            {
                _aircraftList = (from a in _db.Aircraft
                                 select a).ToList();

                var alist = from at in _db.Ata
                            select at;
                _ataList = new List<MVAta>();
                foreach (var item in alist)
                {
                    MVAta mva = new MVAta();
                    mva.ATA = item.Ata;
                    mva.AtaDescription = mva.ATA.ToString() + " -" + item.AtaText;
                    _ataList.Add(mva);
                }

                _subAtaList = (from sa in _db.SubAta
                               select sa).ToList();

                List<string> tabs = (from b in _db.DefaultUserTypes
                           where b.Klmid == App.Current.Properties["CurrentUserName"]
                           select b.Actype.Trim()).ToList();

                List<string> types = (from t in _db.Actypes
                            select t.Actypes.Trim()).ToList();

                foreach (var t in types)
                {
                    CBItem cb = new CBItem();
                    
                    cb.Content = t;
                    if (tabs.Contains(t))
                    {
                        cb.IsChecked = true;
                    }
                    else
                    {
                        cb.IsChecked = false;
                    }
                    _cbItems.Add(cb);
                }
            }
            LoadTabs();
        }

        private void LoadTabs()
        {
            if(tabs == null)
            {
                _tabs = new ObservableCollection<TabViewModel>();
            }
            foreach(CBItem i in CBItems)
            {
                if(i.IsChecked == true)
                {
                    TabViewModel tvm = new TabViewModel();
                    tvm.Header = i.Content;
                    _tabs.Add(tvm);
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        private void OnPropertyChanged(string propertyName)
        {
            VerifyPropertyName(propertyName);
            var handler = PropertyChanged;
            handler?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        [Conditional("DEBUG")]
        private void VerifyPropertyName(string propertyName)
        {
            if (TypeDescriptor.GetProperties(this)[propertyName] == null)
                throw new ArgumentNullException(GetType().Name + " does not contain property: " + propertyName);
        }
    }
}
