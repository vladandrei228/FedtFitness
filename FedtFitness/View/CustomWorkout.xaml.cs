using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.ServiceModel;
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


namespace FedtFitness.View
{
    // A workout page where the user can freely select exercises and monitor their time
   
    public sealed partial class CustomWorkout : Page
    {
        //instance fields 
        private DispatcherTimer dispatcherTimer, timeDispatcher, demoDispatcher;
        private int timesTicked = 1;
        private double ProgressAmount = 0;
        private int sec = 0;
        private int min = 0;
        private int hour = 0;

        //datetime instance
        private DateTime startedTime;
        //timespan instances 
        private TimeSpan timePassed, timeSinceLastStop;


        //constructor containing the InitializeComponent method defines
        //what you see on the form (properties and controls) 
        public CustomWorkout()
        {
            this.InitializeComponent();
        }

        // This is called when you start the timer
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

        //When you call this it sets up the circle timer by using the dispatcherTimer_Tick
        // and the DemoDispatcher_Tick 
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



        // The txtSet.Text provides the view with time passed in between each workout 
        int setCount = 0;
        private void Set_Click(object sender, RoutedEventArgs e)
        {
            isStop = true; 
            startedTime = DateTime.Now;
            ProgressControl.SetBarLength(0.0);
            ProgressAmount = 0.0;
            setCount++;
            txtSet.Text += "Set: " +  setCount + "   Seconds: " + timePassed.Seconds +  "   Minutes: " + timePassed.Minutes + "\n";
        }


        //This formats how the digit string should be displayed 
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
        
        //This contains the way that the Hour.Text that is displayed in the circle timer 
        //it formats what should be displayed as well as in what order and with how many digits
        private void DemoDispatcher_Tick(object sender, object e)
        {
            timePassed = DateTime.Now - startedTime;
            Hour.Text = MakeDigitString((timeSinceLastStop + timePassed).Hours, 1) + ":"
                + MakeDigitString((timeSinceLastStop + timePassed).Minutes, 2) + ":"
                + MakeDigitString((timeSinceLastStop + timePassed).Seconds, 2);
        }

        //This makes the circle timer reset when it reaches a full circle as well as as the timesTicked
        //which is essentially how much time has passed in an instance
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
