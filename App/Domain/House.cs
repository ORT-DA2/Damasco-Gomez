using System;
using System.Collections.Generic;
using System.Drawing;

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

       public List<string> Ilustrations {get ; set; }

       public string Description {get ; set;}

       public int Phone {get; set; }

       public string Contact {get; set;}
        public void UpdateInformation (int id , int phone , string contact, int price)
        {
             Id = id;
             Phone = phone;
             Contact = contact;
             PricePerNight = price;
        }

    }
}