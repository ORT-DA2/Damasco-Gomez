using System;
using System.Collections.Generic;
using BusinessLogicInterface;
using DataAccessInterface.Repositories;
using Domain;

namespace BusinessLogic
{
    public class TouristPointLogic : ITouristPointLogic
    {
        private readonly ITouristPointRepository touristPointRepository;
        private readonly ICategoryRepository categoryRepository;
        private readonly IImageTouristPointRepository imageRepository;
        private readonly IRegionRepository regionRepository;
        public TouristPointLogic(ITouristPointRepository touristPointRepository, ICategoryRepository categoryRepository,
            IImageTouristPointRepository imageRepository, IRegionRepository regionRepository)
        {
            this.touristPointRepository = touristPointRepository;
            this.categoryRepository = categoryRepository;
            this.imageRepository = imageRepository;
            this.regionRepository = regionRepository;
        }
        public void Delete()
        {
            foreach (TouristPoint TouristPoint in this.touristPointRepository.GetElements())
            {
                this.Delete(TouristPoint.Id);
            }
        }
        public IEnumerable<TouristPoint> GetAll()
        {
            return this.touristPointRepository.GetElements();
        }
        public TouristPoint GetBy(int id)
        {
            return this.touristPointRepository.Find(id);
        }

        public TouristPoint Add(TouristPoint touristPoint)
        {
            touristPoint.Region = ValidateRegion(touristPoint.RegionId);
            if (touristPoint.CategoriesTouristPoints != null)
            {
                touristPoint.CategoriesTouristPoints.ForEach
                (
                    m => m.Category = this.categoryRepository.Find(m.CategoryId)
                );
            }
            TouristPoint touristPointAdded = this.touristPointRepository.Add(touristPoint);
            return touristPointAdded;
        }
        public TouristPoint Update(int id, TouristPoint touristPoint)
        {
            TouristPoint touristPointBD = this.touristPointRepository.Find(id);
            if (touristPoint.RegionId > 0)
            {
                touristPoint.Region = ValidateRegion(touristPoint.RegionId);
            }
            if (touristPoint.CategoriesTouristPoints != null)
            {
                touristPoint.CategoriesTouristPoints.ForEach
                (
                    m => m.Category = this.categoryRepository.Find(m.CategoryId)
                );
                touristPointBD.CategoriesTouristPoints.RemoveAll(x => x.TouristPointId == touristPointBD.Id);
                touristPointBD.CategoriesTouristPoints = touristPoint.CategoriesTouristPoints;
            }
            if (touristPoint.ImageTouristPointId > 0)
            {
                var oldImage = this.imageRepository.Find(touristPointBD.ImageTouristPointId);
                oldImage.Update(touristPoint.ImageTouristPoint);
            }
            touristPointBD.Update(touristPoint);
            this.touristPointRepository.Update(id, touristPointBD);
            return touristPointBD;
        }
        public void Delete(int id)
        {
            this.touristPointRepository.Delete(id);
        }
        public bool Exist(TouristPoint TouristPoint)
        {
            return this.touristPointRepository.ExistElement(TouristPoint);
        }

        public Region ValidateRegion(int regionId)
        {
            if (this.regionRepository.ExistElement(regionId))
            {
                return this.regionRepository.Find(regionId);
            }
            throw new ArgumentException("There is no Region with id: " + regionId);
        }
    }
}