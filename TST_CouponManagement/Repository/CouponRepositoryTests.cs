using CouponManagementDBEntity.Models;
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
    }
}
