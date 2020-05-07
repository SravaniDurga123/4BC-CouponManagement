using CouponManagement;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using CouponManagement.Helper;
using CouponManagementTestCase.DATA;
using NUnit.Framework;
using System.Threading.Tasks;
using CouponManagementDBEntity.Models;

namespace CouponManagementTestCase.Controller
{
    class CouponControllerTests
    {
        private CouponController couponController;
        private Mock<ICouponManagementHelper> mockCouponManagementHelper;
        private CouponData mockCouponData;
        [SetUp]
        public void Setup()
        {
            mockCouponManagementHelper = new Mock<ICouponManagementHelper>();
            mockCouponData= new CouponData();
            couponController = new CouponController(mockCouponManagementHelper.Object);
        }
        /// <summary>
        /// To The GetAllCoupons
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task GetAllCoupons_Valid_Return()
        {
            mockCouponManagementHelper.Setup(d => d.GetAllCoupon(It.IsAny<int>())).ReturnsAsync(mockCouponData.couponDetails);
            var result = await couponController.GetCoupons(10);
            Assert.That(result, Is.Not.Null);
        }
        /// <summary>
        /// To Test the Exception for GetAllCoupon
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task GetAllCoupon_InValid_RetunsNull()
        {
            mockCouponManagementHelper.Setup(d => d.GetAllCoupon(It.IsAny<int>())).ReturnsAsync((List<CouponDetails>)(null));
            var result = await couponController.GetCoupons(10);
            Assert.That(result, Is.Null);
        }
    }
}
