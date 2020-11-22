using System.Collections.Generic;

namespace ImporterInterface.Parser
{
    public class TouristImportModel
    {
        public string Name {get; set;}
        public string Description {get; set;}
        public int RegionId {get; set;}
        public string Image{get; set;}
        public virtual  IEnumerable<int> Categories {get; set;}
    }
}