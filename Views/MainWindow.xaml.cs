using Overgave.Models;
using Overgave.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Overgave
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<string> RegistratieLijst;
        private bool registratieCompleet = false;

        public MainWindow()
        {
            MainWindowViewModel viewModel = new MainWindowViewModel();
            
            InitializeComponent();

            DataContext = viewModel;

            //Maak een lijst met alle registraties.
            using(OvergaveContext _db = new OvergaveContext())
            {
                RegistratieLijst = (from r in _db.Aircraft
                                    select r.Registration).ToList();
            }
        }

        private void RegistratieTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            //Kijk of de text in de textbox voorkomt in de RegistratieLijst.
            //Als exact 1 registratie uit de query komt wordt het item uit de lijst naar de textbox gekopieerd.
            var n = from i in RegistratieLijst
                     where i.Contains(RegistratieTB.Text.ToUpper())
                     select i;
            if (n.Count() == 1)
            {
                string text = n.FirstOrDefault();
                RegistratieTB.Text = text;
                registratieCompleet = true;
            }
        }

        private void RegistratieTB_GotFocus(object sender, RoutedEventArgs e)
        {
            //Maak de textbox leeg als hij de focus krijgt.
            RegistratieTB.Clear();
        }

        private void RegistratieTB_KeyDown(object sender, KeyEventArgs e)
        {
            if (registratieCompleet)
            {
                //Maak de textbox leeg als je een nieuwe registratie wil invoeren
                RegistratieTB.Clear();
                //Maak de textbox leeg als hij de focus krijgt.
                registratieCompleet = false;
            }
        }
    }
}
