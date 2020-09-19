using System;
using System.Collections.Generic;

namespace Domain
{
    public class House
    {
        public int Id {get ; set ; }

        public bool Avaible {get ; set; }
        public int PricePerNight {get; set;}

        public TouristPoint Spot {get ; set; }

        public string HouseName {get ; set; }

       public int Starts {get ; set; }

       public string Address {get ; set; }

       public List<Image> Images {get ; set; }

       public string Description {get ; set;}

       public int Phone {get; set; }

       public string Contanct {get; set;}

        public void udpatePricePerNight (int id) 
        {
            PricePerNight = id;
        }

        public void udpateContactInformation (int id , string phone , string contact)
        {
             Id = id;
             Phone = phone;
             Contact = contact;
        }

    }
}