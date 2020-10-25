using DataAccessInterface.Repositories;
using Domain.Entities;

namespace DataAccess.Repositories
{
    public class ImageTouristPointRepository : AccessData<ImageTouristPoint>, IImageTouristPointRepository
    {
        public ImageTouristPointRepository(RepositoryMaster repositoryMaster)
        {
            this.repository = repositoryMaster.ImagesTouristPoints;
        }
        protected override void Update(ImageTouristPoint elementToUpdate, ImageTouristPoint element)
        {
            elementToUpdate.Update(element);
        }

        protected override void Validate(ImageTouristPoint element)
        {
            throw new System.NotImplementedException();
        }
    }
}