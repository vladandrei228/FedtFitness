using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FedtFitness.Model
{
    public class Excercise
    {
        public int _exerciseId;
        public string _name;
        public int? _length;
        public int _equipmentId;
        public int _musclesId;
        public string _description;

        public Excercise(int exerciseId, string name, int? length, int equipmentId, int musclesId,
            string description)
        {
            _exerciseId = exerciseId;
            _name = name;
            _length = length;
            _equipmentId = equipmentId;
            _musclesId = musclesId;
            _description = description;
        }



        public int Excercise_ID
        {
            get { return _exerciseId; }
            set { _exerciseId = value; }
        }

        public string ExName
        {
            get { return _name; }
            set { _name = value; }
        }

        public int? Length
        {
            get { return _length; }
            set { _length = value; }
        }

        public int Equipment_ID
        {
            get { return _equipmentId; }
            set { _equipmentId = value; }
        }

        public int Muscles_ID
        {
            get { return _musclesId; }
            set { _musclesId = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public bool IsSelected { get; internal set; }
    }
}