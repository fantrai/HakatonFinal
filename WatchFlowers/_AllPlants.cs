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
                saveArr[i].Description = plants[i].Description;
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
                    plants.Add(new Plant(saves[i].Name, 0, 0, 0, 0, saves[i].Description));
                }
            }
        }
    }

    class SavePlant()
    {
        [JsonInclude]
        public string Name = "a";
        [JsonInclude]
        public string Description = "ahahahaha";
    }
}
