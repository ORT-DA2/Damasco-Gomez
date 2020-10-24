using DataAccessInterface.Repositories;
using Domain.Entities;

namespace DataAccess.Repositories
{
    public class ImageRepository : AccessData<Image>, IImageRepository
    {
        public ImageRepository(RepositoryMaster repositoryMaster)
        {
            this.repository = repositoryMaster.Images;
        }
        protected override void Update(Image elementToUpdate, Image element)
        {
            throw new System.NotImplementedException();
        }

        protected override void Validate(Image element)
        {
            throw new System.NotImplementedException();
        }
    }
}