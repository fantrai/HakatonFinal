using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;
using System.Text.Json.Serialization;

namespace WatchFlowers
{
    internal class _AllPlants
    {
        public static string PathToData = Path.Combine(FileSystem.AppDataDirectory, "dataS");

        public static List<Plant> plants = new List<Plant>();

        public static void Save()
        {
            SavePlant[] saveArr = new SavePlant[plants.Count];

            for (int i = 0; i < saveArr.Length; i++)
            {
                saveArr[i] = new SavePlant();
                saveArr[i].Name = plants[i].Name;
                saveArr[i].PrefWetAir = plants[i].PrefWetAir;
                saveArr[i].PrefLighting = plants[i].PrefLighting;
                saveArr[i].PrefTemp = plants[i].PrefTemp;
                saveArr[i].RateWater = plants[i].RateWater;
                saveArr[i].Description = plants[i].Description;
                saveArr[i].NextWet = plants[i].NextWet;
                saveArr[i].PatchToImage = plants[i].PatchToImage;
            }

            var serialize = JsonSerializer.Serialize(saveArr);
            File.WriteAllText(PathToData, serialize);
        }

        public static void Load()
        {
            if (File.Exists(PathToData))
            {
                var data = File.ReadAllText(PathToData);
                SavePlant[] saves = JsonSerializer.Deserialize<SavePlant[]>(data);
                for (int i = 0; i < saves.Length; i++)
                {
                    var plant = saves[i];
                    plants.Add(new Plant(plant.Name, plant.PrefWetAir, plant.PrefLighting, plant.PrefTemp, plant.RateWater, plant.Description, plant.PatchToImage) { NextWet = plant.NextWet });
                }
            }
        }
    }

    class SavePlant()
    {
        [JsonInclude]
        public string Name = "";
        [JsonInclude]
        public string Description = "";
        [JsonInclude]
        public string PatchToImage = "";
        [JsonInclude]
        public int PrefWetAir;
        [JsonInclude]
        public int PrefLighting;
        [JsonInclude]
        public int PrefTemp;
        [JsonInclude]
        public int RateWater;
        [JsonInclude]
        public int NextWet;
    }
}
