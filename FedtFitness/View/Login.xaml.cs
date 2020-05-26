using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using FedtFitness.ViewModel;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace FedtFitness.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Login : Page
    {
        public Login()
        {
            this.InitializeComponent();
        }

        RALVM access = new RALVM();

        private void Loginbutton(object sender, RoutedEventArgs e)
        {
           string username = Usernamebox.Text;
           string password = PasswordBox.Password;
            if (access.CanNavigate(username, password))
            {
               // Content.Navigate(typeof(MainPage), e);
               //Message.Text = "You logged in";
               Frame.Navigate(typeof(HamburgerMenu));
            }
            else
            {
                Message.Text = "Your username or your password is incorect!";
            }
        }

        private void Registerbutton(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Register));
        }
    }
}
