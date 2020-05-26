using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FedtFitness.Persistency;

namespace FedtFitness.Model
{
    public class EquipmentCatalogSingleton
    {
        public ObservableCollection<Equipment> Equipments { get; set; }
        private static EquipmentCatalogSingleton _instance;
        private static string url = "api/Equipments";

        GenericFedtWebAPI<Equipment> equipmentwebapi = new GenericFedtWebAPI<Equipment>(url);

        private EquipmentCatalogSingleton()
        {
            Equipments = new ObservableCollection<Equipment>();
            Equipments = new ObservableCollection<Equipment>(equipmentwebapi.getAll());
        }

        public static EquipmentCatalogSingleton Instance
        {
            get
            {
                return _instance ?? (_instance = new EquipmentCatalogSingleton());
            }
        }
    }
}