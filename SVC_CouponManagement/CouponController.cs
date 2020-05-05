using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CouponManagement.Helper;
using CouponManagementDBEntity.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CouponManagement
{
    [Route("api/v2")]
    [ApiController]
    public class CouponController : Controller
    {
        private readonly ICouponManagementHelper _iCouponManagementHelper;
        public CouponController(ICouponManagementHelper iCouponManagementHelper)
        {
            _iCouponManagementHelper = iCouponManagementHelper;
        }
        /// <summary>
        /// Adding coupon of particular user
        /// </summary>
        /// <param name="coupon"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AddCoupon")]
        public async Task<IActionResult> AddCoupon(CouponDetails coupon)
        {
            try
            {
              
                return Ok(await _iCouponManagementHelper.AddCoupon(coupon));
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
        /// <summary>
        ///  Deleting coupon based upon couponid
        /// </summary>
        /// <param name="couponId"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("DeleteCoupon/{couponId}")]
        public async Task<IActionResult> DeleteCoupon(int couponId)
        {
            try
            {
             
                return Ok(await _iCouponManagementHelper.DeleteCoupon(couponId));
            }
            catch (Exception e)
            { 
                return NotFound(e.Message);
            }
        }
        /// <summary>
        /// viewing all coupon of particular user
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetCoupons/{userId}")]
        public async Task<IActionResult> GetCoupons(int userId)
        {
            try
            {
                return Ok(await _iCouponManagementHelper.GetAllCoupon(userId));
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
        /// <summary>
        /// update coupon details
        /// </summary>
        /// <param name="coupon"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("UpdateCoupon")]
        public async Task<IActionResult> UpdateCoupon(CouponDetails coupon)
        {
            try
            {
             
                return Ok(await _iCouponManagementHelper.UpdateCoupon(coupon));
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
        /// <summary>
        ///  updating the coupon status
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [Route("StatusUpdate")]
        public async Task<IActionResult> Statusupdate()
        {
            try
            {
             
                return Ok(await _iCouponManagementHelper.Status());
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
    }
}
