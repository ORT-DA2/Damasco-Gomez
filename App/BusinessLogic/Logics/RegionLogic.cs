using BusinessLogicInterface;
using DataAccessInterface.Repositories;
using Domain;
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
        public void Delete()
        {
            foreach(Region Region in this.regionRepository.GetElements())
            {
                this.Delete(Region.Id);
            }
        }
        public IEnumerable<Region> GetAll()
        {
            return this.regionRepository.GetElements();
        }
        public Region GetBy(int id)
        {
            return this.regionRepository.Find(id);
        }

        public Region Add(Region region)
        {
            return this.regionRepository.Add(region);
        }
        public Region Update(int id,Region region)
        {
            Region regionBd = this.regionRepository.Find(id);
            this.regionRepository.Update(regionBd.Id, region);
            return region;
        }
        public void Delete(int id)
        {
            this.regionRepository.Delete(id);
        }
        public bool Exist(Region Region)
        {
            return this.regionRepository.ExistElement(Region);
        }
    }
}