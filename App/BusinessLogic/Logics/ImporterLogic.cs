using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using BusinessLogicInterface;
using BusinessLogicInterface.Interfaces;
using BusinessLogicInterface.Utils;
using Domain;
using ImporterInterface;

namespace BusinessLogic.Logics
{
    public class ImporterLogic : IImporterLogic
    {
        private readonly IHouseLogic houseLogic;
        private readonly string configurationPath;

        public ImporterLogic(IHouseLogic houseLogic) //, string path)
        {
            this.houseLogic = houseLogic;
            this.configurationPath = @"../../WebApi/Parser/";
        }
        public List<string> GetNames()
        {
            //REFLECTION
            /*
            1- Traer todas las clases que implementen la interfaz
            2- Retornarla
            */

            /*
            Sacar de archivo de configuracion
            */
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

        public void Import(ImportModel import)
        {
            //REFLECTION
            /*
            1- Traigo la implementacion especifica
            2- La uso
            3- Guardo la nueva pelicula
            4- Termino
            */

            List<string> names = new List<string>();
            
            var directory = new DirectoryInfo(configurationPath);
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
                    if (implementation.GetName() == import.Name)
                    {
                        try 
                        {
                            var parseo = implementation.ImportData(import.Path);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                        }
                        // parseo.ForEach(m =>
                        //     this.houseLogic.Add(new House()
                        //     {
                        //         Avaible = m.Avaible,
                        //         PricePerNight = m.PricePerNight,
                        //         TouristPointId = m.TouristPointId,
                        //         Name = m.Name,
                        //         Starts = m.Starts,
                        //         Address = m.Address,
                        //         Description = m.Description,
                        //         Phone = m.Phone,
                        //         Contact = m.Contact
                        //     })
                        // );


                    }
                }
            }
        }
    }
}
