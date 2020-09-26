using System.Collections.Generic;
using Domain;

namespace BusinessLogicInterface
{
    public interface IRegionLogic
    {
        IEnumerable<Region> GetAll();

        Region GetBy(int id);
        void Add(Region region);
        void Update(Region region);
       void Delete(int id);
    
    }
}