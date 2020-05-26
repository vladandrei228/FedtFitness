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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace FedtFitness.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class HamburgerMenu : Page
    {
        public HamburgerMenu()
        {
            this.InitializeComponent();
            Content.Navigate(typeof(HomePage));
        }

        private void Pane_Click(object sender, RoutedEventArgs e)
        {
            SideMenu.IsPaneOpen = !SideMenu.IsPaneOpen;
            if (SideMenu.IsPaneOpen == true)
            {
                SideMenu.DataContext = SideMenu.OpenPaneLength;
            }
            else
            {
                SideMenu.DataContext = SideMenu.CompactPaneLength;
            }

        }

        private void HomePage_Click(object sender, RoutedEventArgs e)
        {
            Content.Navigate(typeof(HomePage), e);
        }

        private void WorkoutEquipment_Click(object sender, RoutedEventArgs e)
        {
            Content.Navigate(typeof(WorkoutEquipment), e);
        }

        private void Training_Click(object sender, RoutedEventArgs e)
        {
            Content.Navigate(typeof(Training), e);
        }

        private void Content_Navigated(object sender, NavigationEventArgs e)
        {
        }
    }
}