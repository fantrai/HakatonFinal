using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchFlowers
{
    public class Detectors
    {
        public static int MaxWetDirt = 100;
        public static int WetSoil { get { Random random = new Random(); return random.Next(0, MaxWetDirt); }}

        public static int MaxLighting = 10;
        public static int Light { get { Random random = new Random(); return random.Next(0, MaxLighting); }}

        public static int MaxTemp = 40;
        public static int Temp { get { Random random = new Random(); return random.Next(0, MaxTemp); }}

        public static int MaxWetAir = 100;
        public static int WetAir { get { Random random = new Random(); return random.Next(0, MaxWetAir); }}
    }
}
