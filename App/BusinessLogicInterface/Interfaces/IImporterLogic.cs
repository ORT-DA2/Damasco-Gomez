using System.Collections.Generic;
using BusinessLogicInterface.Utils;
using ImporterInterface.Parser;

namespace BusinessLogicInterface.Interfaces
{
    public interface IImporterLogic
    {
        List<string> GetNames();
        ListImporterModel Import(ImportModel import);
    }
}