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
            var touristPointAdded = this.touristPointRepository.Add(touristPoint);
            touristPointAdded.CategoriesTouristPoints.ForEach(m=>m.Category = this.categoryRepository.Find(m.CategoryId)); // revisar acáaaa
            return touristPoint;
        }
        public void Update(int id, TouristPoint TouristPoint)
        {
            this.touristPointRepository.Update(id, TouristPoint);
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