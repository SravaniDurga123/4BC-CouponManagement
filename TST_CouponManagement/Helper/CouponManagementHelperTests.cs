using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using CouponManagement.Helper;
using CouponManagementDBEntity.Models;
using CouponManagementDBEntity.Repository;
using CouponManagementTestCase.DATA;
using NUnit.Framework;
using System.Threading.Tasks;

namespace CouponManagementTestCase.Helper
{
    class CouponManagementHelperTests
    {
        private CouponManagementHelper couponManagementHelper;
        private Mock<ICouponRepository> mockCouponRepository;
        private CouponData mockCouponData;
        [SetUp]
        public void Setup()
        {
            mockCouponRepository = new Mock<ICouponRepository>();
            mockCouponData = new CouponData();
            couponManagementHelper = new CouponManagementHelper(mockCouponRepository.Object);
        }
        /// <summary>
        /// To Test the GetAllCoupons
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task GetAllCoupon_Valid_Returns()
        {
            mockCouponRepository.Setup(d => d.GetAllCoupon(It.IsAny<int>())).ReturnsAsync(mockCouponData.couponDetails);
            var result = await couponManagementHelper.GetAllCoupon(10);
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.Not.Empty);
            Assert.That(result.Count, Is.GreaterThan(0));
            Assert.That(result.Count, Is.EqualTo(1));
        }
        /// <summary>
        /// To Test the Exception of GetAllCoupon
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task GetAllCoupon_InValid_RetunsNull()
        {
            mockCouponRepository.Setup(d => d.GetAllCoupon(It.IsAny<int>())).ReturnsAsync((List<CouponDetails>)(null));
            var result = await couponManagementHelper.GetAllCoupon(10);
            Assert.That(result, Is.Null);
        }

    }
}
