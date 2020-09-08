using Overgave.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Data;
using System.Data;

namespace Overgave.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private List<Aircraft> _aircraftList;
        private List<MVAta> _ataList;
        private List<SubATA> _subAtaList;
        private bool _B737selected;
        private bool _B747selected;
        private bool _B787selected;
        private bool _B777selected;
        private bool _A330selected;

        public MainWindowViewModel()
        {
            LoadInitialData();
        }
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

        public List<SubATA> SubATAList
        {
            get { return _subAtaList; }
        }

        public bool B737selected
        {
            get { return _B737selected; }
            set
            {
                if (_B737selected == value) 
                {
                    return;
                }
                else
                {
                    _B737selected = value;
                    RaisePropertyChanged("B737selected");
                }
                
            }
        }

        public bool B747selected
        {
            get { return _B747selected; }
            set
            {
                if (_B747selected == value)
                {
                    return;
                }
                else
                {
                    _B747selected = value;
                    RaisePropertyChanged("B747selected");
                }

            }
        }

        public bool B777selected
        {
            get { return _B777selected; }
            set
            {
                if (_B777selected == value)
                {
                    return;
                }
                else
                {
                    _B777selected = value;
                    RaisePropertyChanged("B777selected");
                }

            }
        }

        public bool B787selected
        {
            get { return _B787selected; }
            set
            {
                if (_B787selected == value)
                {
                    return;
                }
                else
                {
                    _B787selected = value;
                    RaisePropertyChanged("B787selected");
                }

            }
        }

        public bool A330selected
        {
            get { return _A330selected; }
            set
            {
                if (_A330selected == value)
                {
                    return;
                }
                else
                {
                    _A330selected = value;
                    RaisePropertyChanged("A330selected");
                }

            }
        }

        private void LoadInitialData()
        {
            using(OvergaveContext _db = new OvergaveContext())
            {
                _aircraftList = (from a in _db.Aircraft
                                 select a).ToList();

                var alist = from at in _db.Ata
                            select at;
                _ataList = new List<MVAta>();
                foreach(var item in alist)
                {
                    MVAta mva = new MVAta();
                    mva.ATA = item.Ata;
                    mva.AtaDescription = mva.ATA.ToString() + " -" + item.AtaText;
                    _ataList.Add(mva);
                }

                _subAtaList = (from sa in _db.SubAta
                               select sa).ToList();
                TS user = (from u in _db.Ts
                           where u.Klmid == (string)App.Current.Properties["CurrentUserName"]
                           select u).FirstOrDefault();
                if(user !=null)
                {
                    B737selected = user.Def737;
                    B747selected = user.Def747;
                    B777selected = user.Def777;
                    B787selected = user.Def787;
                    A330selected = user.DefA330;
                }
            }
        }



        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
