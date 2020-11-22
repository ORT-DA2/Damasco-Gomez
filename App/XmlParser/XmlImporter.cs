using System.Collections.Generic;
using System.Xml;
using ImporterInterface;
using ImporterInterface.Parser;

namespace XmlParser
{
    public class XmlImporter : IImporter
    {
        public string GetName()
        {
            return "XML";
        }

        public ListHouseModel ImportData(string path)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(path);
            XmlNodeList touristImportModels = xDoc.GetElementsByTagName("TouristImportModels");
            XmlNodeList houseImportModels = xDoc.GetElementsByTagName("HouseImportModels");
            XmlElement myElement= new XmlDocument().CreateElement("TouristImportModels", "ns");
            ListHouseModel list = new ListHouseModel();
            return new ListHouseModel(){HouseImportModels = new List<HouseImportModel>(), TouristImportModels = new List<TouristImportModel>()};
        }
    }
}