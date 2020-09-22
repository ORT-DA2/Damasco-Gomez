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

        public IEnumerable <Region> GetAll()
        {
            return this.regionRepository.GetAll();
        }
        // public void AddRegion(string name, string token)
        // {
            
        // }
        // public void DeleteRegion(int id, string token)
        // {
            
        // }
        // public void AddTouristPoint(int id, string touristPoint, string token)
        // {
            
        // }
        // public void GetTouristPoints()
        // {
            
        // }
        // public void GetTouristPointById(int id)
        // {
            
        // }
        // public void GetCategoryByName(string name)
        // {
            
        // }
    }
}