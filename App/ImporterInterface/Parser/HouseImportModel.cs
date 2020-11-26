using System.Collections.Generic;
using ImporterInterface.Parser;

namespace ImporterInterface
{
    public class HouseImportModel
    {
        public int PricePerNight {get; set;}
        public int TouristPointId {get ; set; }
        public string Name {get ; set; }
        public int Starts {get ; set; }
        public string Address {get ; set; }
        public string Description {get ; set;}
        public int Phone {get; set; }
        public string Contact {get; set;}
        public List<string> Images {get; set;}
        public HouseImportModel(){
            Images = new List<string>();
        }
    }
}