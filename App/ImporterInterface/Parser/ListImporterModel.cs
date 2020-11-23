using System.Collections.Generic;

namespace ImporterInterface.Parser
{
    public class ListImporterModel
    {
        public List<TouristImportModel> TouristImportModels {get; set;}
        public List<HouseImportModel> HouseImportModels {get ; set; }
        public ListImporterModel(){
            TouristImportModels = new List<TouristImportModel>();
            HouseImportModels = new List<HouseImportModel>();
        }
    }
}