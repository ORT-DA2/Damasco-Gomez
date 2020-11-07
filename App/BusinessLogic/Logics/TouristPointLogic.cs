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
        public TouristPointLogic(ITouristPointRepository touristPointRepository,ICategoryRepository categoryRepository,
            IImageTouristPointRepository imageRepository )
        {
            this.touristPointRepository = touristPointRepository;
            this.categoryRepository = categoryRepository;
            this.imageRepository = imageRepository;
        }
        public void Delete()
        {
            foreach(TouristPoint TouristPoint in this.touristPointRepository.GetElements())
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
            if (touristPoint.CategoriesTouristPoints != null)
            {
                touristPoint.CategoriesTouristPoints.ForEach
                (
                    m => m.Category = this.categoryRepository.Find(m.CategoryId)
                );
                touristPointBD.CategoriesTouristPoints.RemoveAll(x => x.TouristPointId == touristPointBD.Id);
                touristPointBD.CategoriesTouristPoints = touristPoint.CategoriesTouristPoints;
                System.Console.WriteLine(touristPointBD.CategoriesTouristPoints);
            }
            if(touristPoint.ImageTouristPointId > 0) 
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
    }
}