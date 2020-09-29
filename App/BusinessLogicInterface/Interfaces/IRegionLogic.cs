using System.Collections.Generic;
using BusinessLogicInterface.Interfaces;
using Domain;

namespace BusinessLogicInterface
{
    public interface IRegionLogic
    {
        IEnumerable<Region> GetAll();
        Region GetBy(int id);
        Region Add(Region element);
        void Update(Region element);
        void Delete(int id);
        void Delete();
        bool Exist(Region element);
    }
}