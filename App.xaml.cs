using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Overgave.Models;

namespace Overgave
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            // Check of de persoon die ingelogd is op de computer in de TS tabel voorkomt.
            //Als hij niet in de TS tabel voorkomt wordt de applicatie gesloten.
            //Als hij wel in de tabel voorkomt wordt het MainWindow geopend.
            string currentUserName = Environment.UserName; //currentUserName wordt de inlog naam van de computer gebruiker.
            App.Current.Properties["CurrentUserName"] = currentUserName; //store the user in a global variable for future use.
            using(OvergaveContext _db = new OvergaveContext())
            {
                TS overgaveUser = (from u in _db.Ts
                                   where u.Klmid == currentUserName
                                   select u).FirstOrDefault();
                if (overgaveUser == null)
                {
                    MessageBox.Show("Sorry " + currentUserName + " je komt niet voor in de gebruikers lijst. \r\n  U kunt geen gebruik maken van de TS Overgave!");
                    Application.Current.Shutdown();
                }
                else
                {
                    MessageBox.Show("Welkom " + overgaveUser.Name);
                    new MainWindow().Show();
                }
            }
            
        }
    }
}
