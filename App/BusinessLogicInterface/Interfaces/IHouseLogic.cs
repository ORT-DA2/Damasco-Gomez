using System;

namespace BusinessLogicInterface
{
    public interface IHouseLogic
    {
        void GetHouses(DateTime checkIn, DateTime checkOut, int adult, int kids, int babies, string touristPoint);

        void PostHospedaje(int pricePerNight,string touristPoint,string houseName,int starts,string address,int image,string description,string phone,string contact,string token);
    
        void GetHouseByName(string name);

        void GetHouseById(int id);

        void DeleteHouse(int id, string token);

        void UpdatePricePerNight(int id,string token);

        void UpdateContactInformation(int id, string phone, string contact, string token);

        void CalculatePrice(DateTime checkIn, DateTime checkOut);
    }
}