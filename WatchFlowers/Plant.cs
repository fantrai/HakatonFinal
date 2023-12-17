using System.IO;
using System.Text.Json.Serialization;

namespace WatchFlowers
{
    internal class Plant
    {
        public Plant(string name, int prefWetAir,int prefLighting,int prefTemp, int rateWater, string desctription = "нет описания", string patchToImage = "")
        {
            Name = name;
            Description = desctription;
            PrefWetAir = prefWetAir;
            PrefLighting = prefLighting;
            PrefTemp = prefTemp;
            RateWater = rateWater;
            PatchToImage = patchToImage;
            
            Random random = new Random();

            WetSoil = Detectors.WetSoil;
            Lighting = Detectors.Light;
            Temp = Detectors.Temp;
            WetAir = Detectors.WetAir;

            NextWet = random.Next(0, rateWater);
            WaterIsGood = random.Next(0, 10) != 0;

            SunIsGood = Lighting <= prefLighting + Detectors.MaxLighting * 0.1f && Lighting >= prefLighting - Detectors.MaxLighting * 0.1f ? true : false;
            TempIsGood = Temp <= prefTemp + Detectors.MaxTemp * 0.1f && Temp >= prefTemp - Detectors.MaxTemp * 0.1f ? true : false;
            WetAirIsGood = WetAir <= prefWetAir + Detectors.MaxWetAir * 0.1f && WetAir >= prefWetAir - Detectors.MaxWetAir * 0.1f ? true : false;
        }

        public string Name;
        public string Description;
        public string PatchToImage;
        public int PrefWetAir;
        public int PrefLighting;
        public int PrefTemp;
        public int RateWater;

        public bool WaterIsGood;
        public bool SunIsGood;
        public bool TempIsGood;
        public bool WetAirIsGood;

        public int WetSoil;
        public int Lighting;
        public int Temp;
        public int WetAir;
        public int NextWet;
    }
}
