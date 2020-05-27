using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls.Primitives;
using FedtFitness.Annotations;
using FedtFitness.Model;
using FedtFitness.View;


namespace FedtFitness.ViewModel
{
    public class FiltersViewModel : INotifyPropertyChanged
    {

        public FiltersViewModel()
        {
            EquipmentCatalogSingleton = EquipmentCatalogSingleton.Instance;
            _selectedEquipment = new Equipment(Equipment_ID, Name);
            AllEquipments = EquipmentCatalogSingleton.Equipments;

            MuscleGroupCatalogSingleton = MuscleGroupCatalogSingleton.Instance;
            _selectedMuscleGroup = new MuscleGroup(Muscles_ID, MGName);
            AllMuscleGroups = MuscleGroupCatalogSingleton.MuscleGroups;

            ExerciseCatalogSingleton = ExerciseCatalogSingleton.Instance;
            AllExcercises = ExerciseCatalogSingleton.Exercises;

            StartWorkoutVisibility = "false";
            //MarkAsDoneVisibility = "true";
        }


        public string StartWorkoutVisibility { get; set; }
        // Method that checks if Start Workout Button must be either enabled or disabled
        public void ToggleStartWorkoutButtonIfNeeded()
        {
            if (F1.Count == 0)
            {
                if (StartWorkoutVisibility != "false")
                {
                    StartWorkoutVisibility = "false";
                    OnPropertyChanged(nameof(StartWorkoutVisibility));
                }
            }
            else
            {
                if (StartWorkoutVisibility != "true")
                {
                    StartWorkoutVisibility = "true";
                    OnPropertyChanged(nameof(StartWorkoutVisibility));
                }
            }
        }


        


        public string MarkAsDoneVisibility { get; set; }
        // Method that checks if Mark as Done Button must be either enabled or disabled
        
        public void ToggleMarkAsDoneButton_OnMarkAsDoneClicked()
        {
            for (int i = 0; i < ExerciseCatalogSingleton.TrainingExcercises.Count; i++)
            {
                if (ExerciseCatalogSingleton.TrainingExcercises[i].Excercise_ID == SelectedExercise.Excercise_ID)
                {
                    ExerciseCatalogSingleton.FinishedTrainingExercises[i] = true;
                    break;
                }
            }

            MarkAsDoneVisibility = "false";
            OnPropertyChanged(nameof(MarkAsDoneVisibility));
            OnPropertyChanged(nameof(ProgressPercentage));
        }




        //public void ToggleMarkAsDoneButton_OnSelectedExercise()
        //{
        //    for (int i = 0; i < ExerciseCatalogSingleton.TrainingExcercises.Count; i++)
        //    {
        //        if (ExerciseCatalogSingleton.TrainingExcercises[i].Excercise_ID == SelectedExercise.Excercise_ID)
        //        {
        //            if (ExerciseCatalogSingleton.FinishedTrainingExercises[i])
        //                MarkAsDoneVisibility = "false";
        //            else
        //                MarkAsDoneVisibility = "true";
        //            break;
        //        }
        //    }

        //    OnPropertyChanged(nameof(MarkAsDoneVisibility));
        //}

        //EQUIPMENT

        public EquipmentCatalogSingleton EquipmentCatalogSingleton { get; set; }
        public int Equipment_ID { get; set; }
        public string Name { get; set; }
        public ObservableCollection<Equipment> AllEquipments { get; set; }

        private Equipment _selectedEquipment;

        public Equipment SelectedEquipment
        {
            get
            {
                return _selectedEquipment;
            }
            set
            {
                _selectedEquipment = value;
                OnPropertyChanged(nameof(F1));
                ToggleStartWorkoutButtonIfNeeded();
            }
        }

        //MUSCLE GROUP

        public MuscleGroupCatalogSingleton MuscleGroupCatalogSingleton { get; set; }
        public int Muscles_ID { get; set; }
        public string MGName { get; set; }
        public ObservableCollection<MuscleGroup> AllMuscleGroups { get; set; }

        private MuscleGroup _selectedMuscleGroup;

        public MuscleGroup SelectedMuscleGroup
        {
            get { return _selectedMuscleGroup; }
            set
            {
                _selectedMuscleGroup = value;
                OnPropertyChanged(nameof(F1));
                ToggleStartWorkoutButtonIfNeeded();
            }
        }

        //REFERENCES

        public ExerciseCatalogSingleton ExerciseCatalogSingleton { get; set; }
        public ObservableCollection<Excercise> AllExcercises { get; set; }

        
        //CHECK IF ANY EXERCISES APPLY BOTH FILTERS AND CREATE FILTERED COLLECTION

        public ObservableCollection<Excercise> _f1;


        public ObservableCollection<Excercise> F1
        {
            get
            {
                IEnumerable<Excercise> filtered = AllExcercises.Where(ex => ex.Equipment_ID == SelectedEquipment.Equipment_ID
                                                                          && ex.Muscles_ID == SelectedMuscleGroup.Muscles_ID);
                ExerciseCatalogSingleton.TrainingExcercises = new ObservableCollection<Excercise>(filtered.ToList());
                return new ObservableCollection<Excercise>(filtered);
            }
        }

        

        public decimal ProgressPercentage
        {
            get
            {
                if (ExerciseCatalogSingleton.TrainingExcercises == null)
                {
                    return 0;

                }
                else
                {
                    decimal numfinishedexercises = 0m;
                    foreach (var finishedexercise in ExerciseCatalogSingleton.FinishedTrainingExercises)
                    {
                        if (finishedexercise)
                        {
                            numfinishedexercises += 1.0m;
                        }
                    }

                    return numfinishedexercises / ExerciseCatalogSingleton.TrainingExcercises.Count * 100m;
                }
            }
        }


        public Excercise SelectedExercise
        {
            get
            {
                return ExerciseCatalogSingleton.SelectedExercise;
            }
            set
            {
                ExerciseCatalogSingleton.SelectedExercise = value;
                OnPropertyChanged(nameof(SelectedExercise));
                //ToggleMarkAsDoneButton_OnSelectedExercise();
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
