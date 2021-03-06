﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using FedtFitness.Model;
using FedtFitness.ViewModel;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace FedtFitness.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Training : Page
    {
        FiltersViewModel fvm = new FiltersViewModel();

        public Training()
        {
            this.InitializeComponent();
        }

        private void MarkAsDone_Click(object sender, RoutedEventArgs e)
        {
            fvm.ToggleMarkAsDoneButton_OnMarkAsDoneClicked();
        }

        private void CompleteWorkout_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(HamburgerMenu), e);
        }


    }
}