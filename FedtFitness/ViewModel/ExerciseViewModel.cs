using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.Security.Authentication.Web.Core;
using FedtFitness.Annotations;
using FedtFitness.Model;


namespace FedtFitness.ViewModel
{
    public class ExerciseViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Excercise> AllExcercises { get; set; }
        public ObservableCollection<Excercise> F1 { get; set; }
        public ExerciseCatalogSingleton ExerciseCatalogSingleton { get; set; }

        public int Exercise_ID { get; set; }
        public string ExName { get; set; }
        public int Length { get; set; }
        public int Equipment_ID { get; set; }
        public int Muscles_ID { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }

        public ExerciseViewModel()
        {
            ExerciseCatalogSingleton = ExerciseCatalogSingleton.Instance;
            AllExcercises = ExerciseCatalogSingleton.Exercises;
        }




        public event PropertyChangedEventHandler PropertyChanged;
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }
}