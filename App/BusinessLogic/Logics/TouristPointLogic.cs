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
            foreach(TouristPoint tourisPoint in this.touristPointRepository.GetElements())
            {
                this.Delete(tourisPoint.Id);
            }
        }
    }
}