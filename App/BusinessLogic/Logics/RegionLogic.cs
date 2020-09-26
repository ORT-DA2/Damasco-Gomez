using BusinessLogic.Logics;
using BusinessLogicInterface;
using DataAccessInterface.Repositories;
using Domain;
using System;
using System.Collections.Generic;

namespace BusinessLogic
{
    public class RegionLogic : Logic<Region> , IRegionLogic
    {
        private readonly IRegionRepository regionRepository;
        public RegionLogic(IRegionRepository regionRepository)
        {
            this.regionRepository = regionRepository;
        }
        public override void Delete()
        {
            foreach(Region region in this.regionRepository.GetElements())
            {
                this.Delete(region.Id);
            }
        }
     }
}