using CouponManagementDBEntity.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CouponManagementDBEntity.Repository
{
  public  class CouponRepository:ICouponRepository
    {
        private readonly CouponManagementContext _couponManagementContext;
        public CouponRepository(CouponManagementContext couponManagementContext)
        {
            _couponManagementContext = couponManagementContext;
        }
        /// <summary>
        /// To add a new coupon
        /// </summary>
        /// <param name="coupon"></param>
        /// <returns></returns>
        public async Task<bool> AddCoupon(CouponDetails coupon)
        {
            try
            {
                _couponManagementContext.CouponDetails.Add(coupon);
                int result = await _couponManagementContext.SaveChangesAsync();
                if (result > 0)
                    return true;
                else
                    return false;
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// For deleting coupon based on couponid
        /// </summary>
        /// <param name="couponId"></param>
        /// <returns></returns>
        public async Task<bool> DeleteCoupon(int couponId)
        {
            try
            {
                CouponDetails couponDetails = _couponManagementContext.CouponDetails.Find(couponId);
                _couponManagementContext.Remove(couponDetails);
                int result = await _couponManagementContext.SaveChangesAsync();
                if (result > 0)
                    return true;
                else
                    return false;
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// Viewing all coupons of a particular user
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<List<CouponDetails>> GetAllCoupon(int userId)
        {
            try
            {
                return await _couponManagementContext.CouponDetails.Where(e => e.UserId == userId).ToListAsync();
            }
            catch(Exception e)
            {
                throw;
            }
        }
        /// <summary>
        /// Updaating coupon status 
        /// </summary>
        /// <returns></returns>
        public async Task<bool> Status()
        {
            try
            {
                List<CouponDetails> couponDetails = _couponManagementContext.CouponDetails.ToList();
                foreach (var coupon in couponDetails)
                {
                    int result = DateTime.Compare(coupon.CouponExpiredDate, DateTime.Now);
                    if (result < 0)
                    {
                        coupon.CouponStatus = "Invalid";
                        _couponManagementContext.CouponDetails.Update(coupon);
                        await _couponManagementContext.SaveChangesAsync();


                    }
                    else
                    {
                        coupon.CouponStatus = "valid";
                        _couponManagementContext.CouponDetails.Update(coupon);
                        await _couponManagementContext.SaveChangesAsync();
                    }
                }
                return true;
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// Updating coupon Details 
        /// </summary>
        /// <param name="coupon"></param>
        /// <returns></returns>
        public async Task<bool> UpdateCoupon(CouponDetails coupon1)
        {
            try
            {
                _couponManagementContext.CouponDetails.Update(coupon1);
                int result = await _couponManagementContext.SaveChangesAsync();
                if (result > 0)
                    return true;
                else
                    return false;
            }
            catch
            {
                throw;
            }



        }
    }
}
