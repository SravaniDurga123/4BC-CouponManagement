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
        private CouponManagementContext  mockCouponManagementContext;
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
           await  mockCouponManagementContext.SaveChangesAsync();
            var getAllUser = await userRepository.GetAllUsers();
            Assert.That(getAllUser, Is.Not.Null);
            Assert.That(getAllUser.Count,Is.EqualTo(2));
           
        }
        [Test]
        public async Task GetUser_Valid_Returns(int userId)
        {
            // mockCouponManagementContext.UserDetails.AddRange(mockUserDatas.userDetails);
            // await mockCouponManagementContext.SaveChangesAsync();
            var getUserById = await userRepository.GetUser(10);
            Assert.That(getUserById, Is.Not.Null);
            Assert.That(getUserById.UserId, Is.EqualTo(10));
        }
    }
}
