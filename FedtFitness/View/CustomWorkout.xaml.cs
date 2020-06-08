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
using FedtFitness.View;

//// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238



namespace FedtFitness.View
{
    /// <summary>
    /// A workout page where the user can freely select exercises and monitor their time
    /// </summary>
    public sealed partial class CustomWorkout : Page
    {
        private DispatcherTimer dispatcherTimer, timeDispatcher, demoDispatcher;
        private int timesTicked = 1;
        private double ProgressAmount = 0;
        private int sec = 0;
        private int min = 0;
        private int hour = 0;

        private DateTime startedTime;
        private TimeSpan timePassed, timeSinceLastStop;


        public CustomWorkout()
        {
            this.InitializeComponent();
        }

        bool isStop = false;
        private void Start_Click(object sender, RoutedEventArgs e)
        {
            if (isStop == false)
            {
                isStop = true;
                startedTime = DateTime.Now;
                DispatcherTimerSetup();

                Start.Content = "End Workout";
            }
            else
            {
                isStop = false;
                dispatcherTimer.Stop();
                demoDispatcher.Stop();
                Hour.Text = "0:00:00";
                Start.Content = "Start Workout";
                ProgressControl.SetBarLength(0.0);
                ProgressAmount = 0.0;
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            ProgressControl.SetBarLength(1.0);
        }
        private void DispatcherTimerSetup()
        {
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += dispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 1000 / 10);
            dispatcherTimer.Start();



            timeSinceLastStop = TimeSpan.Zero;
            Hour.Text = "0:00:00";
            demoDispatcher = new DispatcherTimer();
            demoDispatcher.Tick += DemoDispatcher_Tick;
            demoDispatcher.Interval = new TimeSpan(0, 0, 0, 0, 1);
            demoDispatcher.Start();
        }
        

        int setCount = 0;
        private void Set_Click(object sender, RoutedEventArgs e)
        {
            setCount++;
            txtSet.Text += "Set " + setCount + ": " + Hour.Text + "\n";
        }

        private string MakeDigitString(int number, int count)
        {
            string result = "0";
            if (count == 2)
            {
                if (number < 10)
                    result = "0" + number;
                else
                    result = number.ToString();
            }
            else if (count == 3)
            {
                if (number < 10)
                    result = "00" + number;
                else if (number > 9 && number < 100)
                {
                    result = "0" + number;
                }
                else
                    result = number.ToString();
            }
            return result;
        }
        
        private void DemoDispatcher_Tick(object sender, object e)
        {
            timePassed = DateTime.Now - startedTime;
            Hour.Text = MakeDigitString((timeSinceLastStop + timePassed).Hours, 1) + ":"
                + MakeDigitString((timeSinceLastStop + timePassed).Minutes, 2) + ":"
                + MakeDigitString((timeSinceLastStop + timePassed).Seconds, 2);
        }



        private void dispatcherTimer_Tick(object sender, object e)
        {
            timesTicked++;
            ProgressControl.SetBarLength(ProgressAmount);
            ProgressAmount += (1.0 / 60.0) * (7.95 / 60.0);
            if (ProgressAmount > 1.0)
                ProgressAmount = 0.0;
        }
    }
}
