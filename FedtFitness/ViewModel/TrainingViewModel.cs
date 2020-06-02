using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using FedtFitness.Annotations;
using FedtFitness.Model;
using FedtFitness.Persistency;
using Windows.UI.Xaml.Controls;

namespace FedtFitness.ViewModel
{
    public class TrainingViewModel : INotifyPropertyChanged
    {

        public ObservableCollection<Excercise> AllExcercises { get; set; }
        public ExerciseCatalogSingleton ExerciseCatalogSingleton { get; set; }

        public int Exercise_ID { get; set; }
        public string ExName { get; set; }
        public int Length { get; set; }
        public int Equipment_ID { get; set; }
        public int Muscles_ID { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }

        public TrainingViewModel()
        {
            ExerciseCatalogSingleton = ExerciseCatalogSingleton.Instance;
            _selectedExercise = new Excercise(Exercise_ID, ExName, Length, Equipment_ID, Muscles_ID, Description, Image);
            AllExcercises = ExerciseCatalogSingleton.Exercises;
        }

        private Excercise _selectedExercise;
        public Excercise SelectedExercise
        {
            get
            {
                return _selectedExercise;
            }
            set
            {
                _selectedExercise = value;
                OnPropertyChanged(nameof(SelectedExercise));
            }
        }



        public event PropertyChangedEventHandler PropertyChanged;
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }
}