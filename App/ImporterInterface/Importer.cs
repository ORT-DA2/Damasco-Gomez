using System.Collections.Generic;

namespace ImporterInterface
{
    public interface Importer<T> where T : class
    {
        string GetName();
        List<T> ImportData(string path);

    }
}