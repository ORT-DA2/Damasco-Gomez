using System;
using System.Collections.Generic;
using BusinessLogicInterface;
using DataAccessInterface.Repositories;
using Domain;
using Domain.Entities;

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
                touristPointBD.CategoriesTouristPoints = touristPointBD.CategoriesTouristPoints;
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
    }
}