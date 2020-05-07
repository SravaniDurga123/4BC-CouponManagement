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
        /// <summary>
        /// To Test the Get all users
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task GetAllUsers_Valid_Returns()
        {
            mockCouponManagementContext.UserDetails.AddRange(mockUserDatas.userDetails);
            await mockCouponManagementContext.SaveChangesAsync();
            var getAllUser = await userRepository.GetAllUsers();
            Assert.That(getAllUser, Is.Not.Null);
            Assert.That(getAllUser.Count, Is.EqualTo(2));

        }
        /// <summary>
        /// To the User Register
        /// </summary>
        /// <returns></returns>
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
        /// <summary>
        ///     To test Get User 
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task GetUser_Valid_Returns()
        {
            mockCouponManagementContext.UserDetails.AddRange(mockUserDatas.userDetails);
            await mockCouponManagementContext.SaveChangesAsync();
            var getUserById = await userRepository.GetUser(10);
            Assert.That(getUserById, Is.Not.Null);
            Assert.That(getUserById.UserId, Is.EqualTo(10));
        }
        /// <summary>
        /// To Test the UpdateUser
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [Test]
        public async Task UpdateUser_Valid_Returns(UserDetails user)
        {
            mockCouponManagementContext.UserDetails.AddRange(mockUserDatas.userDetails);
            await mockCouponManagementContext.SaveChangesAsync();
            var getUserById = await userRepository.GetUser(10);
            user.EmailAddr = "hello@cognizant.com";
            var updateUser = await userRepository.UpdateUser(user);
            UserDetails user1 = await userRepository.GetUser(10);
            Assert.AreSame(user, user1);
        }

    }

}



