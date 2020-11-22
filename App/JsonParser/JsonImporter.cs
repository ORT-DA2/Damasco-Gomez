
using System.IO;
using System.Text.Json;
using ImporterInterface;
using ImporterInterface.Parser;

namespace JsonParser
{
    public class JsonImporter : IImporter
    {
        public string GetName()
        {
            return "JSON";
        }

        public ListHouseModel ImportData(string path)
        {
            FileInfo jsonFile = new FileInfo(path);
            var jsontString = File.ReadAllText(jsonFile.FullName);
            var houseImportModel = JsonSerializer.Deserialize<ListHouseModel>(jsontString);
            return houseImportModel;
        }
    }
}