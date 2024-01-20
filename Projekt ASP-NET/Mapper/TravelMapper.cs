using Data.Entities;
using Projekt_ASP_NET.Models;
using Projekt_ASP_NET.Enums;

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
                StartDate = entity.StartDate,
                EndDate = entity.EndDate,
                StartPlace = entity.StartPlace,
                EndPlace = entity.EndPlace,
                Participants = entity.Participants,
                Guide = (Guides)(entity.GuideId),
                Created = entity.Created
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
                GuideId = (int)model.Guide,
                Created = model.Created
            };
        }
    }
}
