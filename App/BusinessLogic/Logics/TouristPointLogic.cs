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
        public TouristPointLogic(ITouristPointRepository touristPointRepository,ICategoryRepository categoryRepository )
        {
            this.touristPointRepository = touristPointRepository;
            this.categoryRepository = categoryRepository;
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
            Validate(touristPoint);
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
            Validate(touristPoint);
            TouristPoint touristPointBD = this.touristPointRepository.Find(id);
            if (touristPoint.CategoriesTouristPoints != null)
            {
                touristPoint.CategoriesTouristPoints.ForEach
                (
                    m => m.Category = this.categoryRepository.Find(m.CategoryId)
                );
            }
            this.touristPointRepository.Update(id, touristPointBD);
            touristPointBD.Update(touristPoint);
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
        public void Validate(TouristPoint touristPoint)
        {
            if (touristPoint == null) throw new ArgumentException("Tourist Point is empty");
        }
    }
}