using BusinessLogicInterface;
using DataAccessInterface.Repositories;

namespace BusinessLogic
{
    public class TouristPointLogic : ITouristPointLogic
    {
        private readonly ITouristPointRepository touristPointRepository;
        public TouristPointLogic(ITouristPointRepository touristPointRepository)
        {
            this.touristPointRepository = touristPointRepository;
        }
    }
}