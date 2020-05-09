﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CouponManagementDBEntity.Models;
using CouponManagementDBEntity.Repository;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SHR_Model.Models;

namespace UserManagement.Helper
{
    public class UserRepository:IUserRepository
    {
        private readonly CouponManagementContext _couponManagementContext;
        public UserRepository(CouponManagementContext couponManagementContext)
        {
            _couponManagementContext = couponManagementContext;
        }

        public async Task<List<UserDetails>> GetAllUsers()
        {
            try
            {
                return await _couponManagementContext.UserDetails.ToListAsync();
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// To view the profile of the user
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<UserDetails> GetUser(int userId)
        {
            try
            {
               // return _couponManagementContext.UserDetails.FromSqlRaw("EXEC dbo.spGetUsersById @UserId={0}", userId).ToListAsync().Result.FirstOrDefault();
                 return await _couponManagementContext.UserDetails.FindAsync(userId);

            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// To update the user profile
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>

        public async Task<bool> UpdateUser(UserDetails user1)
        {
            try
            {
               
                _couponManagementContext.UserDetails.Update(user1);
                var id = await _couponManagementContext.SaveChangesAsync();
                if (id > 0)
                    return true;
                else return false;
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// To validate whether the user is authorized or not
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<UserDetails> UserLogin(UserLogin user)
        {
            try
            {
                UserDetails userDetails = await _couponManagementContext.UserDetails.SingleOrDefaultAsync(e => e.UserName ==user.UserName && e.UserPassword ==user.UserPassword);
                    if(userDetails == null)
                    return null;
                else
                    return userDetails;
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// To Register the User Details
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<string> UserRegister(UserDetails user)
        {
            try
            {
                ////int uid = user.UserId;
                ////string uname = user.UserName;
                ////var param = new SqlParameter("@UserId", uid);
                ////var param1 = new SqlParameter("@UserName", uname);
               // _couponManagementContext.Database.ExecuteSqlCommand("spUserRegister", param,param1);
                 _couponManagementContext.UserDetails.Add(user);
                var id = await _couponManagementContext.SaveChangesAsync();
                if (id > 0)
                    return "true";
                else
                    return "false";
            }
            catch
            {
                throw;
            }
        }
    }
}
