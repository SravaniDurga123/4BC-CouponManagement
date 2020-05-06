using CouponManagementDBEntity.Models;
using SHR_Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CouponManagementTestCase.DATA
{
    public interface ISqlite
    {
        string UserRegister(UserDetails user);
        UserDetails UserLogin(UserLogin user);
        bool UpdateUser(UserDetails user);
        UserDetails GetUser(int userId);

        List<UserDetails> GetAllUsers();
    }
    class Sqlite : ISqlite
    {
        public readonly CouponManagementContext _couponManagementContext;
        public  Sqlite(CouponManagementContext couponManagementContext)
        {
            _couponManagementContext = couponManagementContext;
        }
        public List<UserDetails> GetAllUsers()
        {
            return _couponManagementContext.UserDetails.ToList();
        }

        public UserDetails GetUser(int userId)
        {
            return _couponManagementContext.UserDetails.Find(userId);
        }

        public bool UpdateUser(UserDetails user)
        {
            user.UpdatedDate = DateTime.Now;
            _couponManagementContext.UserDetails.Update(user);
            var id =  _couponManagementContext.SaveChanges();
            if (id > 0)
                return true;
            else return false;
        }

        public UserDetails UserLogin(UserLogin user)
        {
            UserDetails userDetails =  _couponManagementContext.UserDetails.SingleOrDefault(e => e.UserName == user.UserName && e.UserPassword == user.UserPassword);
            if (userDetails == null)
                return null;
            else
                return userDetails;
        }

        public string UserRegister(UserDetails user)
        {
            _couponManagementContext.UserDetails.Add(user);
            var id = _couponManagementContext.SaveChanges();
            if (id > 0)
                return "true";
            else
                return "false";
        }
    }
}
