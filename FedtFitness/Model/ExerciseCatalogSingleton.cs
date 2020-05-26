using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FedtFitness.Persistency;

namespace FedtFitness.Model
{
    public class ExerciseCatalogSingleton
    {
        public ObservableCollection<Excercise> Exercises { get; set; }
        private static ExerciseCatalogSingleton _instance;
        public ObservableCollection<Excercise> TrainingExcercises { get; set; }
        private static string url = "api/Excercises";

        GenericFedtWebAPI<Excercise> exercicesweapi = new GenericFedtWebAPI<Excercise>(url);

        private ExerciseCatalogSingleton()
        {
            Exercises = new ObservableCollection<Excercise>();
            Exercises = new ObservableCollection<Excercise>(exercicesweapi.getAll());

        }

        public static ExerciseCatalogSingleton Instance
        {
            get
            {
                return _instance ?? (_instance = new ExerciseCatalogSingleton());
            }
        }




        public string _name;
        public string ExName
        {
            get { return _name; }
            set { _name = value; }
        }

    }
}