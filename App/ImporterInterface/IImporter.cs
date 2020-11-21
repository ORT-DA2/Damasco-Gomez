using System.Collections.Generic;

namespace ImporterInterface
{
    public interface IImporter
    {
        string GetName();
        HouseImportModel ImportData(string path);
    }
}