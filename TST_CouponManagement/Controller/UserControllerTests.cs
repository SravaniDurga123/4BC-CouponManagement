using CouponManagementDBEntity.Models;
using CouponManagementTestCase.DATA;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UserManagement;
using UserManagement.Helper;

namespace CouponManagementTestCase.Controller
{
    class UserControllerTests
    {
        private UserController userController;
        private Mock<IUserManagementHelper> mockUserManagementHelper;
        private UserDatas mockUserDatas;
        [SetUp]
        public void Setup()
        {
            mockUserManagementHelper = new Mock<IUserManagementHelper>();
            mockUserDatas = new UserDatas();
            userController = new UserController(mockUserManagementHelper.Object);
        }
        /// <summary>
        /// To Test the GetAllUsers
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task GetAllUsers_Valid_Return()
        {
            mockUserManagementHelper.Setup(d => d.GetAllUsers()).ReturnsAsync(mockUserDatas.userDetails);
           var result= await userController.GetAllUsers();
            Assert.That(result, Is.Not.Null);
        }
        /// <summary>
        /// To Test the Exception for GetAllUsers
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task GetAllUsers_Invalid_ReturnsNull()
        {
            mockUserManagementHelper.Setup(d => d.GetAllUsers()).ReturnsAsync((List<UserDetails>)(null));
            var result = await userController.GetAllUsers();
            Assert.That(result, Is.Null);
        }
        [Test]
        public async Task GetUser_Valid_Returns()
        {
            mockUserManagementHelper.Setup(d => d.GetUser(It.IsAny<int>())).ReturnsAsync(new UserDetails());
            var result = await userController.GetUser(10);
            Assert.That(result, Is.Not.Null);
        }
        [Test]
        public async Task GetUser_Invalid_ReturnsNull()
         {
            mockUserManagementHelper.Setup(d => d.GetUser(It.IsAny<int>())).ReturnsAsync(new UserDetails());
            var result = await userController.GetUser(10);
            Assert.That(result, Is.Null);
        }
        //[Test]
        //public async Task UserLogin_Valid_Returns()
        //{
        //    mockUserManagementHelper.Setup(d => d.UserLogin(It.IsAny<UserDetails>())).ReturnsAsync(default(string));
        //    var result = await userController.UserLogin(new UserDetails()
        //    {
        //        UserName = "hello",
        //        UserPassword = "hello"
        //    });
        //    Assert.That(result, Is.Not.Null);
        //    Assert.That(result, Is.EqualTo(true));

        //}
        [Test]
        public async Task UserRegister_valid_Returns()
        {
            mockUserManagementHelper.Setup(d => d.UserRegister(It.IsAny<UserDetails>())).ReturnsAsync(default(string));
            var result = await userController.UserRegister(new UserDetails()
            {
                UserId = 67,
                UserName = "Abc",
                EmailAddr = "Abc@gmail.com",
                UserPassword = "4545",
                UserAddress = "Ap",
                CreateDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                PhoneNumber = "9874563210",
                FirstName = "Abc",
                LastName = "Xyz"
            });
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.EqualTo(true));
        }
        [Test]
        public async Task UpdateUser_valid_Returns()
        {
            mockUserManagementHelper.Setup(d => d.UpdateUser(It.IsAny<UserDetails>())).ReturnsAsync(new Boolean());
            var result = await userController.UpdateUser(new UserDetails()
            {
                UserId = 10,
                UserName = "Abc1",
                EmailAddr = "Abc1@gmail.com",
                UserPassword = "4545",
                UserAddress = "Ap",
                CreateDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                PhoneNumber = "9874563210",
                FirstName = "Abc1",
                LastName = "Xyz"
            });
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.EqualTo(true));
        }
    }
}
