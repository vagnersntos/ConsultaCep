using ConsultaCep.Data;
using ConsultaCep.Models;
using ConsultaCep.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ConsultaCep.Repositories
{
    public class UserRepositorie : IUserRepositories
    {
        private readonly UserDBContext _dbContext;
        public UserRepositorie(UserDBContext userDBContext)
        {
            _dbContext = userDBContext;
            
        }

        public async Task<UserModel> AddUser(UserModel user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            return user;
        }

        public async Task<bool> DeleteUser(long id)
        {
            UserModel userModel = await FindUserId(id);

            _dbContext.Users.Remove(userModel);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<UserModel>> GetAllUsers() => await _dbContext.Users.ToListAsync();

        public async Task<UserModel> GetUserById(long userId) => await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == userId);

        public async Task<UserModel> UpdateUser(UserModel user, long id)
        {
            UserModel userModel = await FindUserId(id);

            userModel.Name = user.Name;
            userModel.Email = user.Email;
            userModel.Cpf = user.Cpf;
            userModel.Address = user.Address;

            _dbContext.Update(userModel);
            await _dbContext.SaveChangesAsync();
            return userModel;
        }

        private async Task<UserModel> FindUserId(long id)
        {
            UserModel userModel = await GetUserById(id);

            if (userModel is null)
            {
                throw new InvalidOperationException($"Usuário para o ID: {id} não foi encontrado.");
            }

            return userModel;
        }
    }
}
