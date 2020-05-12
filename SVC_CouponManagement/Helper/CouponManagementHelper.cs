using CouponManagementDBEntity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CouponManagementDBEntity.Repository;


namespace CouponManagement.Helper
{
    public interface ICouponManagementHelper
    {
        Task<List<CouponDetails>> GetCoupons();
        Task<CouponDetails> GetCouponById(int couponId);
        Task<List<CouponDetails>> GetAllCoupon(int userId);
        Task<bool> AddCoupon(CouponDetails coupon);
        Task<bool> UpdateCoupon(CouponDetails coupon);
        Task<bool> DeleteCoupon(int couponId);
        Task<bool> Status();
    }
    public class CouponManagementHelper : ICouponManagementHelper
    {
        private readonly ICouponRepository _iCoupounRepositoty;
        public CouponManagementHelper(ICouponRepository iCouponRepository)
        {
            _iCoupounRepositoty = iCouponRepository;
        }
        /// <summary>
        /// adding coupon
        /// </summary>
        /// <param name="coupon"></param>
        /// <returns></returns>
        public async Task<bool> AddCoupon(CouponDetails coupon)
        {
            try
            {
                bool result = await _iCoupounRepositoty.AddCoupon(coupon);
                if (result == true)
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
        /// deleting  coupon based on couponid
        /// </summary>
        /// <param name="couponId"></param>
        /// <returns></returns>
        public async Task<bool> DeleteCoupon(int couponId)
        {
            try
            {
                bool result = await _iCoupounRepositoty.DeleteCoupon(couponId);
                if (result == true)
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
        /// Getting all coupons of a particular user
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<List<CouponDetails>> GetAllCoupon(int userId)
        {
            try
            {
                return await _iCoupounRepositoty.GetAllCoupon(userId);
            }
            catch
            {
                throw;
            }
        }

        public async Task<CouponDetails> GetCouponById(int couponId)
        {
            try
            {
                return await _iCoupounRepositoty.GetCouponById(couponId);
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<CouponDetails>> GetCoupons()
        {
           try
            {
                return await _iCoupounRepositoty.GetCoupons();
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// updating coupon status
        /// </summary>
        /// <returns></returns>

        public async Task<bool> Status()
        {
            try
            {
                return await _iCoupounRepositoty.Status();
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// Updating coupon details
        /// </summary>
        /// <param name="coupon"></param>
        /// <returns></returns>

        public async Task<bool> UpdateCoupon(CouponDetails coupon)
        {
            try
            {
                bool result = await _iCoupounRepositoty.UpdateCoupon(coupon);
                if (result == true)
                    return true;
                else return false;
            }
            catch
            {
                throw;
            }
        }
    }
}
