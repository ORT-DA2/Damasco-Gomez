using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using BusinessLogicInterface;
using BusinessLogicInterface.Interfaces;
using BusinessLogicInterface.Utils;
using Domain;
using Domain.Entities;
using ImporterInterface;
using ImporterInterface.Parser;

namespace BusinessLogic.Logics
{
    public class ImporterLogic : IImporterLogic
    {
        private readonly IHouseLogic houseLogic;
        private readonly ITouristPointLogic touristPointLogic;
        private readonly IRegionLogic regionLogic;
        private readonly string configurationPath;

        public ImporterLogic(IHouseLogic houseLogic, ITouristPointLogic touristPointLogic,
            IRegionLogic regionLogic) //, string path)
        {
            this.houseLogic = houseLogic;
            this.touristPointLogic = touristPointLogic;
            this.regionLogic = regionLogic;
            this.configurationPath = @"../WebApi/Parser/";
        }
        public List<string> GetNames()
        {
            List<string> names = new List<string>();

            var directory = new DirectoryInfo(this.configurationPath);
            FileInfo[] files = directory.GetFiles("*.dll");

            foreach (var file in files)
            {
                Assembly assemblyLoaded = Assembly.LoadFile(file.FullName);
                var loadedImplementation = assemblyLoaded.GetTypes().Where(t => typeof(IImporter).IsAssignableFrom(t) && t.IsClass).FirstOrDefault();

                if (loadedImplementation == null)
                {
                    Console.WriteLine("Nadie implementa la interfaz: {0} en el assembly: {1} ", nameof(IImporter), file.FullName);
                }
                else
                {
                    var implementation = Activator.CreateInstance(loadedImplementation) as IImporter;
                    names.Add(implementation.GetName());
                }
            }

            return names;
        }

        public ListHouseModel Import(ImportModel import)
        {
            List<string> names = new List<string>();

            var directory = new DirectoryInfo(configurationPath);
            FileInfo[] files = directory.GetFiles("*.dll");

            foreach (var file in files)
            {
                Assembly assemblyLoaded = Assembly.LoadFile(file.FullName);
                var loadedImplementation = assemblyLoaded.GetTypes().Where(t => typeof(IImporter).IsAssignableFrom(t) && t.IsClass).FirstOrDefault();

                if (loadedImplementation == null)
                {
                    throw new ArgumentException("Nadie implementa la interfaz: {0} en el assembly: {1} " + nameof(IImporter) + file.FullName);
                }
                else
                {
                    var implementation = Activator.CreateInstance(loadedImplementation) as IImporter;
                    if (implementation.GetName() == import.Name)
                    {
                        var parseo = implementation.ImportData(import.Path);
                        this.ParseDateTouristPoint(parseo);
                        return parseo;
                    }
                }
            }
            throw new ArgumentException("Cant find dll");
        }

        private void ParseDateTouristPoint(ListHouseModel parseo)
        {
            try
            {
                parseo.TouristImportModels.ForEach(m =>
                    {
                        TouristPoint tourist = new TouristPoint()
                        {
                            Name = m.Name,
                            Description = m.Description,
                            RegionId = m.RegionId,
                            ImageTouristPoint = new ImageTouristPoint(m.Image) { },
                        };
                        this.touristPointLogic.Add(tourist);
                    }
                                        );
                parseo.HouseImportModels.ForEach(m =>
                {
                    House house = new House()
                    {
                        Avaible = m.Avaible,
                        PricePerNight = m.PricePerNight,
                        TouristPointId = m.TouristPointId,
                        Name = m.Name,
                        Starts = m.Starts,
                        Address = m.Address,
                        Description = m.Description,
                        Phone = m.Phone,
                        Contact = m.Contact
                    };
                    if (m.Images != null && m.Images.Count > 0)
                    {
                        List<ImageHouse> listImage = new List<ImageHouse>();
                        m.Images.ForEach(image =>
                            listImage.Add(new ImageHouse(image, house.Id)));

                        house.ImagesHouse = listImage;
                    }
                    this.houseLogic.Add(house);
                });
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}

