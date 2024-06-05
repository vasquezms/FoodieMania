using FoodieMania.DAL.Entities;

namespace FoodieMania.Domain.Interfaces
{
    public interface IFoodieService
    {
        Task<IEnumerable<Foodie>>GetFoodiesAsync();

        Task<Foodie> CreateFoodieAsync(Foodie foodie);
        Task<Foodie> GetFoodieByIdAsync(Guid id);

        Task<Foodie> EditFoodieAsync(Foodie foodie);
        Task<Foodie> DeleteFoodieAsync(Guid id);


    }
}
