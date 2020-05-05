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
