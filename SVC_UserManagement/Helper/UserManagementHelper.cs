using CouponManagementDBEntity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CouponManagementDBEntity.Repository;
using SHR_Model.Models;

namespace UserManagement.Helper
{
    public interface IUserManagementHelper
    {
        Task<string> UserRegister(UserDetails user);
        Task<string> UserLogin(UserLogin user);
        Task<bool> UpdateUser(UserDetails user);
        Task<UserDetails> GetUser(int userId);
        Task<List<UserDetails>> GetAllUsers();
    }
    public class UserManagementHelper : IUserManagementHelper
    {
        private readonly IUserRepository _iUserRepository;
        public UserManagementHelper(IUserRepository iUserRepository)
        {
            _iUserRepository = iUserRepository;
        }

        public async Task<List<UserDetails>> GetAllUsers()
        {
            try
            {
                return await _iUserRepository.GetAllUsers();
            }
            catch(Exception e)
            {
                throw;
            }
        }

        public async Task<UserDetails> GetUser(int userId)
        {
            try
            {
                return await _iUserRepository.GetUser(userId);
               
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> UpdateUser(UserDetails user)
        {
            try
            {
                bool id = await _iUserRepository.UpdateUser(user);
                if (id == true)
                    return true;
                else
                    return false;
            }
            catch
            {
                throw;
            }
        }

        public async Task<string> UserLogin(UserLogin user)
        {
            try
            {
                UserDetails userDetails = await _iUserRepository.UserLogin(user);
                if (userDetails == null)
                    return "Invalid Crendentails";
                else return "successfully logged in";
            }
            catch
            {
                throw;
            }
        }

       

        public async Task<string> UserRegister(UserDetails user)
        {
            try
            {
               return await _iUserRepository.UserRegister(user);
               
            }
            catch
            {
                throw;
            }
        }
    }
}
