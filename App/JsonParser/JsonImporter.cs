
using System.IO;
using System.Text.Json;
using ImporterInterface;

namespace JsonParser
{
    public class JsonImporter : IImporter
    {
        public string GetName()
        {
            return "JSON";
        }

        public HouseImportModel ImportData(string path)
        {
            FileInfo jsonFile = new FileInfo(path);
            var jsontString = File.ReadAllText(jsonFile.FullName);
            var houseImportModel = JsonSerializer.Deserialize<HouseImportModel>(jsontString);
            return houseImportModel;
        }
    }
}