using Data.Entities;

namespace Projekt_ASP_NET.Interfaces
{
    public interface IGuideService
    {
        public Task AddGuide(GuideEntity guide);
        public Task Delete(int id);
        public Task Update(GuideEntity travel);
        public Task<List<GuideEntity>> FindAll();
        Task<GuideEntity?> FindById(int id);
        public Task<List<AddressEntity>> FindAllAddressForVieModel();
    }
}
