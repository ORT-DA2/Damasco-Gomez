using DataAccessInterface.Repositories;
using Domain.Entities;

namespace DataAccess.Repositories
{
    public class ImageHouseRepository : AccessData<ImageHouse>, IImageHouseRepository
    {
        public ImageHouseRepository(RepositoryMaster repositoryMaster)
        {
            this.repository = repositoryMaster.ImagesHouses;
        }

        protected override void Update(ImageHouse elementToUpdate, ImageHouse element)
        {
            throw new System.NotImplementedException();
        }

        protected override void Validate(ImageHouse element)
        {
            throw new System.NotImplementedException();
        }
    }
}