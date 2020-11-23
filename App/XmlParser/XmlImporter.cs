using System;
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

        public ListImporterModel ImportData(string path)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(path);
            XmlNodeList touristImportModels = xDoc.GetElementsByTagName("TouristImportModels");
            XmlNodeList houseImportModels = xDoc.GetElementsByTagName("HouseImportModels");
            ListImporterModel list = new ListImporterModel();

            foreach (XmlNode areaItem in touristImportModels)
            {
                TouristImportModel area = new TouristImportModel();
                area.Name = areaItem.ChildNodes[0].InnerText;
                area.Image = areaItem.ChildNodes[1].InnerText;
                area.Description = areaItem.ChildNodes[2].InnerText;
                area.RegionId = Int32.Parse(areaItem.ChildNodes[3].InnerText);
                XmlNodeList Categories = areaItem.ChildNodes[4].ChildNodes;
                foreach (XmlNode item in Categories)
                {
                    int category = Int32.Parse(item.InnerText);
                    area.Categories.Add(category);
                }

                list.TouristImportModels.Add(area);
            }
            foreach (XmlNode areaItem in houseImportModels)
            {
                HouseImportModel area = new HouseImportModel();
                area.PricePerNight = Int32.Parse(areaItem.ChildNodes[0].InnerText);
                area.TouristPointId = Int32.Parse(areaItem.ChildNodes[1].InnerText);
                area.Name = areaItem.ChildNodes[2].InnerText;
                area.Starts = Int32.Parse(areaItem.ChildNodes[3].InnerText);
                area.Address = areaItem.ChildNodes[4].InnerText;
                area.Description = areaItem.ChildNodes[5].InnerText;
                area.Phone = Int32.Parse(areaItem.ChildNodes[6].InnerText);
                area.Contact = areaItem.ChildNodes[7].InnerText;
                XmlNodeList images = areaItem.ChildNodes[8].ChildNodes;
                foreach (XmlNode item in images)
                {
                    string imageName = item.InnerText;
                    area.Images.Add(imageName);
                }
                list.HouseImportModels.Add(area);
            }
            return list ;
        }
    }
}