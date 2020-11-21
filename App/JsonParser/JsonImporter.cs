using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Domain;
using ImporterInterface;

namespace JsonParser
{
    public class JsonImporter : IImporter
    {
        public string GetName()
        {
            return "JSON";
        }

        public List<HouseImportModel> ImportData(string path)
        {
            string currentDirectory = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            string archiveFolder = Path.Combine(currentDirectory, "archive");
            string[] files = Directory.GetFiles(archiveFolder, "*.zip");
            throw new System.NotImplementedException();
        }
    }
}