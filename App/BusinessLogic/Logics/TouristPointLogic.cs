using System.Collections.Generic;
using BusinessLogic.Logics;
using BusinessLogicInterface;
using DataAccessInterface.Repositories;
using Domain;

namespace BusinessLogic
{
    public class TouristPointLogic : Logic<TouristPoint> , ITouristPointLogic
    {
        private readonly ITouristPointRepository touristPointRepository;
        public TouristPointLogic(ITouristPointRepository touristPointRepository)
        {
            this.touristPointRepository = touristPointRepository;
        }
        public override void Delete()
        {
            foreach(TouristPoint TouristPoint in this.touristPointRepository.GetElements())
            {
                this.Delete(TouristPoint.Id);
            }
        }
        // public IEnumerable<TouristPoint> GetAll()
        // {
        //     return this.touristPointRepository.GetElements();
        // }
        // public TouristPoint GetBy(int id)
        // {
        //     return this.touristPointRepository.Find(id);
        // }

        // public void Add(TouristPoint TouristPoint)
        // {
        //     this.touristPointRepository.Add(TouristPoint);
        // }
        // public void Update(TouristPoint TouristPoint)
        // {
        //     this.touristPointRepository.Update(TouristPoint);
        // }
        // public void Delete(int id)
        // {
        //     this.touristPointRepository.Delete(id);
        // }
        // public bool Exist(TouristPoint TouristPoint)
        // {
        //     return this.touristPointRepository.ExistElement(TouristPoint);
        // }
    }
}