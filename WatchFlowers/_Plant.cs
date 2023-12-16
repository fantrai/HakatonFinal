using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchFlowers
{
    internal class _Plant
    {
        public _Plant(string name, float prefWetAir,float prefLighting,float prefTemp, int rateWater, string desctription = "нет описания")
        {
            Name = name;
            Description = desctription;
            PrefWetAir = prefWetAir;
            PrefLighting = prefLighting;
            PrefTemp = prefTemp;
            RateWater = rateWater;
        }

        public string Name;
        public string Description;
        public float PrefWetAir;
        public float PrefLighting;
        public float PrefTemp;
        public int RateWater;
    }
}
