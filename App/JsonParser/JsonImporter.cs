
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

        public ListImporterModel ImportData(string path)
        {
            FileInfo jsonFile = new FileInfo(path);
            var jsontString = File.ReadAllText(jsonFile.FullName);
            var houseImportModel = JsonSerializer.Deserialize<ListImporterModel>(jsontString);
            return houseImportModel;
        }
    }
}