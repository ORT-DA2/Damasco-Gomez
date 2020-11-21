using System.Collections.Generic;

namespace ImporterInterface
{
    public interface IImporter
    {
        string GetName();
        List<HouseImportModel> ImportData(string path);
    }
}