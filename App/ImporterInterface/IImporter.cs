using ImporterInterface.Parser;

namespace ImporterInterface
{
    public interface IImporter
    {
        string GetName();
        ListImporterModel ImportData(string path);
    }
}