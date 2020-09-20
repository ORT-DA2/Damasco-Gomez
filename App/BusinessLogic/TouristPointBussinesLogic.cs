using DataAccess.Repositories;

namespace BusinessLogic
{
    public class TouristPointBussinesLogic
    {
        private TouristPointRepository touristPointRepository;

        public TouristPointBussinesLogic()
        {
            TouristPointContext context = ContextFactory.GetNewContext();
            touristPointRepository = new TouristPointRepository(context);
        }
        public void AddTouristPoint(in string name, in int image, in string description, in string token)
        {

        }
        public void DeleteTouristPoint(in int id, in string token)
        {
            
        }
        public void AddImage(in int id, in int image, in string token)
        {
            
        }
        public void RemoveImage(in int id, in int image, in string token)
        {
            
        }
        public void GetTouristPointByName(in string name)
        {
            
        }
        public void GetTouristPointById(in int id)
        {
            
        }
    }
}