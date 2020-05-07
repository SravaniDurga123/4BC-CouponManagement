using CouponManagementDBEntity.Models;
using CouponManagementDBEntity.Repository;
using CouponManagementTestCase.DATA;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Helper;

namespace CouponManagementTestCase.Repository
{
    [TestFixture]
    public class UserRepositoryTests
    {
        private IUserRepository userRepository;
        private CouponManagementContext mockCouponManagementContext;
        private UserDatas mockUserDatas;
        [SetUp]
        public void Setup()
        {
            mockCouponManagementContext = new Sqlite().CreateSqliteConnection();
            userRepository = new UserRepository(mockCouponManagementContext);
            mockUserDatas = new UserDatas();
        }
        [Test]
        public async Task GetAllUsers_Valid_Returns()
        {
            mockCouponManagementContext.UserDetails.AddRange(mockUserDatas.userDetails);
            await mockCouponManagementContext.SaveChangesAsync();
            var getAllUser = await userRepository.GetAllUsers();
            Assert.That(getAllUser, Is.Not.Null);
            Assert.That(getAllUser.Count, Is.EqualTo(2));

        }
        [Test]
        public async Task UserRegister_valid_Returns()
        {
            mockCouponManagementContext.UserDetails.AddRange(mockUserDatas.userDetails);
            await mockCouponManagementContext.SaveChangesAsync();

            var getUserById = await userRepository.UserRegister(new UserDetails()
            {
                UserId = 12,
                FirstName = "sai",
                LastName = "manasa",
                UserName = "sree",
                UserPassword = "manasa",
                EmailAddr = "manasa@gmail.com",
                PhoneNumber = "7660912345",
                CreateDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                UserAddress = "chennai"

            });
            Assert.That(getUserById, Is.Not.Null);
            Assert.That(getUserById, Is.EqualTo("true"));

        }
        [Test]
        public async Task GetUser_Valid_Returns()
        {
            mockCouponManagementContext.UserDetails.AddRange(mockUserDatas.userDetails);
            await mockCouponManagementContext.SaveChangesAsync();
            var getUserById = await userRepository.GetUser(10);
            Assert.That(getUserById, Is.Not.Null);
            Assert.That(getUserById.UserId, Is.EqualTo(10));
        }

    }

}



