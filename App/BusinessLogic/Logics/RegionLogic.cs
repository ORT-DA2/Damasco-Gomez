using BusinessLogicInterface;
using DataAccessInterface.Repositories;
using Domain;
using System;
using System.Collections.Generic;

namespace BusinessLogic
{
    public class RegionLogic : IRegionLogic
    {
        private readonly IRegionRepository regionRepository;
        public RegionLogic(IRegionRepository regionRepository)
        {
            this.regionRepository = regionRepository;
        }

        public IEnumerable<Region> GetAll()
        {
            return this.regionRepository.GetElements();
        }
        public  Region GetBy(int id)
        {
           return this.regionRepository.Find(id);
        }
     }
}