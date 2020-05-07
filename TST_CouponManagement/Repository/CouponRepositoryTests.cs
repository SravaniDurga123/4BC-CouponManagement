﻿using CouponManagementDBEntity.Models;
using CouponManagementDBEntity.Repository;
using CouponManagementTestCase.DATA;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CouponManagementTestCase.Repository
{
    class CouponRepositoryTests
    {
        private CouponRepository couponRepository;
        private CouponManagementContext mockCouponManagementContext;
        private CouponData mockCouponData;
        private UserDatas mockUserDatas;
        [SetUp]
        public void SetUp()
        {
            mockCouponManagementContext = new Sqlite().CreateSqliteConnection();
            couponRepository = new CouponRepository(mockCouponManagementContext);
            mockCouponData = new CouponData();
            mockUserDatas = new UserDatas();
        }
        /// <summary>
        /// To Test the GetAllCoupons using userId
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task GetAllCoupon_Valid_Returns()
        {
            mockCouponManagementContext.UserDetails.AddRange(mockUserDatas.userDetails);
            await mockCouponManagementContext.SaveChangesAsync();
            mockCouponManagementContext.CouponDetails.AddRange(mockCouponData.couponDetails);
            await mockCouponManagementContext.SaveChangesAsync();
            var getAllCoupon = await couponRepository.GetAllCoupon(10);
            Assert.That(getAllCoupon, Is.Not.Null);
            Assert.That(getAllCoupon.Count, Is.EqualTo(1));
        }
        /// <summary>
        /// to test exception of Adding coupon
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task AddCoupon_Valid_Returns()
        {
            mockCouponManagementContext.UserDetails.AddRange(mockUserDatas.userDetails);
            await mockCouponManagementContext.SaveChangesAsync();
            mockCouponManagementContext.CouponDetails.AddRange(mockCouponData.couponDetails);
            await mockCouponManagementContext.SaveChangesAsync();
            var getCouponId = await couponRepository.AddCoupon(new CouponDetails()
            {
                CouponId = 25,
                CouponNumber = "JHDF748N",
                CouponStatus = "valid",
                CouponStartDate = DateTime.Now,
                CouponExpiredDate = DateTime.Now.AddDays(29),
                CreateDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                UserId = 10
            });
        }
        /// <summary>
        /// 
        /// to test exceptions of Delete coupon
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task DeleteCoupon_Valid_Returns()
        {
            mockCouponManagementContext.UserDetails.AddRange(mockUserDatas.userDetails);
            await mockCouponManagementContext.SaveChangesAsync();
            mockCouponManagementContext.CouponDetails.AddRange(mockCouponData.couponDetails);
            await mockCouponManagementContext.SaveChangesAsync();
            var getAllCoupon = await couponRepository.DeleteCoupon(10);
            Assert.That(getAllCoupon, Is.Null);


        }

    }
}
