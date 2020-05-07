using CouponManagementDBEntity.Models;
using CouponManagementDBEntity.Repository;
using CouponManagementTestCase.DATA;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Helper;

namespace CouponManagementTestCase.Helper
{
    [TestFixture]
    class UserManagementHelperTests
    {
        private UserManagementHelper userManagementHelper;
        private Mock<IUserRepository> mockUserRepository;
        private UserDatas mockUserData;
        [SetUp]
        public void Setup()
        {
            mockUserRepository = new Mock<IUserRepository>();
            mockUserData = new UserDatas();
            userManagementHelper = new UserManagementHelper(mockUserRepository.Object);
        }
        /// <summary>
        /// To Test the GetAllUsers 
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task GetAllUsers_Valid_Returns()
        {
            mockUserRepository.Setup(d => d.GetAllUsers()).ReturnsAsync(mockUserData.userDetails);
            var result = await userManagementHelper.GetAllUsers();
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.Not.Empty);
            Assert.That(result.Count, Is.GreaterThan(0));
            Assert.That(result.Count, Is.EqualTo(2));
        }
        /// <summary>
        /// To Test Exception in GetAllUsers
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task GetAllUsers_InValid_ReturnsNull()
        {
            mockUserRepository.Setup(d => d.GetAllUsers()).ReturnsAsync((List<UserDetails>)(null));
            var result = await userManagementHelper.GetAllUsers();
            Assert.That(result, Is.Null);
        }
    }


}
