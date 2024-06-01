using ConsultaCep.Models;

namespace ConsultaCep.Repositories.Interfaces
{
    public interface IUserRepositories
    {
        Task<List<UserModel>> GetAllUsers();
        Task<UserModel> GetUserById(long userId);
        Task<UserModel> AddUser(UserModel user);
        Task<UserModel> UpdateUser(UserModel user, long id);
        Task<bool> DeleteUser(long id);
    }
}
