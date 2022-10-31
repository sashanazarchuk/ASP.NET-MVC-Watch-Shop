using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Data.Mock
{
    public static class MockData
    {
        static Random random = new Random();
        public static List<Watch> GetWatches()
        {
            return new List<Watch>() {
                new Watch()
                {
                    Id = 1,
                    Model="Air-King",
                    img="/Images/Rolex Air-King.png",
                    Brand="Rolex",
                    Material="Steel 904L",
                    Guarantee ="3 years",
                    ClockFaceId= 3,
                    Price=7400
                },

                new Watch()
                {
                    Id = 2,
                    Model="Datejust",
                    img = "/Images/Rolex Datejust.png",
                    Brand="Rolex",
                    Material="Stainless Steel",
                    Guarantee ="3 years",
                    ClockFaceId= 3,
                    Price=7800
                },

                new Watch()
                {
                    Id = 3,
                    Model="Yacht-Master",
                    img="/Images/Rolex Yacht-Master.png",
                    Brand="Rolex",
                    Material="18-carat Everose gold",
                    Guarantee ="4 years",
                    ClockFaceId= 3,
                    Price=47150
                },
                new Watch()
                {
                    Id = 4,
                    Model="Sea-Dweller",
                    img="/Images/Rolex Sea-Dweller.png",
                    Brand="Rolex",
                    Material="Stainless Steel, Yellow Gold 18k",
                    Guarantee ="5 years",
                    ClockFaceId= 2,
                    Price=23500
                }
            };
        }
        public static Watch GetWatch()
        {
            var list = GetWatches();
            return list[random.Next(list.Count)];
        }
        public static Watch GetWatchById(int id)
        {
            return GetWatches().FirstOrDefault(w => w.Id == id);
        }
        public static List<ClockFace> GetClockFace()
        {
            return new List<ClockFace>() {
                new ClockFace()
                {
                  Id=1,
                  Name = "Blue"
                },

                new ClockFace()
                {
                    Id = 2,
                    Name = "White"
                },

                new ClockFace()
                {
                   Id = 3,
                   Name = "Black"
                },
                new ClockFace()
                {
                    Id = 4,
                    Name = "Green"
                }
            };
        }
    }
}