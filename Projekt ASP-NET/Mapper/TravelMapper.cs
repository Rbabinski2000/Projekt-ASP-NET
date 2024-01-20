using Data.Entities;
using Projekt_ASP_NET.Models;

namespace Projekt_ASP_NET.Mapper
{
    public class TravelMapper
    {
        public static Travel FromEntity(TravelEntity entity)
        {
            return new Travel()
            {
                Id = entity.Id,
                Name = entity.Name,
                Email = entity.Email,
                Phone = entity.Phone,
                Birth = entity.Birth,
            };
        }

        public static TravelEntity ToEntity(Travel model)
        {
            return new TravelEntity()
            {
                Id = model.Id,
                Name = model.Name,
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                StartPlace = model.StartPlace,
                EndPlace = model.EndPlace,
                Participants = model.Participants,
                Guide = model.Guide.,
                Created = DateTime.Now
            };
        }
    }
}
