using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FedtFitness.Persistency;

namespace FedtFitness.Model
{
    public class MuscleGroupCatalogSingleton
    {
        public ObservableCollection<MuscleGroup> MuscleGroups { get; set; }
        private static MuscleGroupCatalogSingleton _instance;
        private static string url = "api/MuscleGroups";

        GenericFedtWebAPI<MuscleGroup> musclegroupsapi = new GenericFedtWebAPI<MuscleGroup>(url);

        private MuscleGroupCatalogSingleton()
        {
            MuscleGroups = new ObservableCollection<MuscleGroup>();
            MuscleGroups = new ObservableCollection<MuscleGroup>(musclegroupsapi.getAll());
        }

        public static MuscleGroupCatalogSingleton Instance
        {
            get
            {
                return _instance ?? (_instance = new MuscleGroupCatalogSingleton());
            }
        }
    }
}