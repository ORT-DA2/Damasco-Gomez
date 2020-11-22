using System.Collections.Generic;
using ImporterInterface.Parser;

namespace ImporterInterface
{
    public interface IImporter
    {
        string GetName();
        ListHouseModel ImportData(string path);
    }
}