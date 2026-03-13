
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalculatorBackend
{
    public partial class CalculatorHistory
    {
        public void SaveData(string path, CalculatorData newData) 
        {
            List<CalculatorData> history;

            // Om filen redan finns
            if (File.Exists(path))
            {
                string json = File.ReadAllText(path);
                history = JsonConvert.DeserializeObject<List<CalculatorData>>(json)
                          ?? new List<CalculatorData>();
            }
            else
            {
                history = new List<CalculatorData>();
            }

            // Lägg till ny beräkning
            history.Add(newData);

            // Skriv tillbaka hela listan
            string updatedJson = JsonConvert.SerializeObject(history, Formatting.Indented);
            File.WriteAllText(path, updatedJson);
        }
    }
}
