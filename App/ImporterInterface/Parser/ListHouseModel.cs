using System.Collections.Generic;

namespace ImporterInterface.Parser
{
    public class ListHouseModel
    {
        public List<TouristImportModel> TouristImportModels {get; set;}
        public List<HouseImportModel> HouseImportModels {get ; set; }
        public ListHouseModel(){}
    }
}