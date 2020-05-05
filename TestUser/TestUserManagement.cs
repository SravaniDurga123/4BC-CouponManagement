using CouponManagementDBEntity.Models;
using NUnit.Framework;
using SHR_Model.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Helper;

namespace TestUser
{
    [TestFixture]
    class TestUserManagement
    {
        UserRepository _userRepository;
        [SetUp]
        public void Setup()
        {
            _userRepository = new UserRepository(new CouponManagementContext());
        }
        [Test]
        [Description("TestUserLogin")]
        public async Task TestUserLogin()
        {
            var result =await _userRepository.UserLogin(new UserLogin()
            {
                UserName = "sravani",
                UserPassword="sravani"
            });
            Assert.IsNotNull(result);
        }
        [Test]
        [Description("TestUserRegister")]
        public async Task TestUserRegister()
        {
           await  _userRepository.UserRegister(new UserDetails()
            {
                FirstName="jai",
                LastName="kishan",
                UserName="kishan",
                UserPassword="kishan",
                EmailAddr="kishan@gmail.com",
                PhoneNumber="7660947176",
                CreateDate=DateTime.Now,
                UserAddress ="kishan"

            });
        }
        [Test]
        [Description("user profile")]
        public async Task TestGetUser()
        {
          var result=await  _userRepository.GetUser(1);
            Assert.NotNull(result);
        }
        [Test]
        [Description("update user")]
        public async Task UpdateUser()
        {
          UserDetails user =await _userRepository.GetUser(2);
             user.EmailAddr = "bannu@gmail.com";
            user.UpdatedDate = DateTime.Now;
           await _userRepository.UpdateUser(user);
            UserDetails user1 =await _userRepository.GetUser(2);
            Assert.AreSame(user, user1);
           
        }
    }
}
