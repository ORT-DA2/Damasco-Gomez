using System;
namespace BusinessLogicInterface
{
    public interface ITouristPointController
    {
        void AddTouristPoint(string name, int image, string description, string token);

        void DeleteTouristPoint(int id, string token);

        void AddImage(int id, int image, string token);

        void RemoveImage(int id, int image, string token);

        void GetTouristPointByName(string name);

        void GetTouristPointById(int id);
    }
}
