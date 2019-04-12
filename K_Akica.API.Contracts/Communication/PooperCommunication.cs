using K_Akica.API.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace K_Akica.API.Contracts.Communication
{
    public class PooperRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Race { get; set; }
        public string Description { get; set; }

    }

    //public class PooperResponce
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //    public string Race { get; set; }
    //    public string Description { get; set; }
    //}

    public static class PooperCommunicationExtensions
    {
        public static Pooper AsPooper(this PooperRequest request)
        {
            return new Pooper
            {
                Name = request.Name,
                Race = request.Race,
                Description = request.Description
            };
        }

        public static PooperRequest AsResponce(this Pooper pooper)
        {
            return new PooperRequest
            {
                Id = pooper.Id,
                Name = pooper.Name,
                Description = pooper.Description,
                Race = pooper.Race
            };
        }

        public static void UpdateFromRequest(this Pooper pooper, PooperRequest request)
        {
            pooper.Name = request.Name;
            pooper.Race = request.Race;
            pooper.Description = request.Description;
        }
    }
}
