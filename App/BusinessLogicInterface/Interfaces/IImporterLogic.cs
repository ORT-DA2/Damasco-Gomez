using System.Collections.Generic;
using BusinessLogicInterface.Utils;

namespace BusinessLogicInterface.Interfaces
{
    public interface IImporterLogic
    {
        List<string> GetNames();
        void Import(ImportModel import);
    }
}