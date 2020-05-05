using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CouponManagementDBEntity.Models;
using CouponManagementDBEntity.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Nancy.Json;
using SHR_Model.Models;
using UserManagement.Helper;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UserManagement
{
    [Route("api/v1")]
    [ApiController]
    public class UserController : Controller
    {

        private readonly IUserManagementHelper _iUserManagementHelper;
        public UserController(IUserManagementHelper iUserManagementHelper)
        {
            _iUserManagementHelper = iUserManagementHelper;
        }

        

        /// <summary>
        /// To Register the User Details
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("UserRegister")]
        [Produces( "application/json")]
        public async Task<IActionResult> UserRegister(UserDetails user)
        {

            try
            {
              
                    await _iUserManagementHelper.UserRegister(user);
                  
                    return Ok("success");
                
            }
            catch (Exception e)
            {
                return NotFound(e.StackTrace);
            }
        }
        /// <summary>
        /// To validate whether the user is authorized or not
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("UserLogin")]
        public async Task<IActionResult> UserLogin(UserLogin user)
        {
            try
            {
                //null checking
               return Ok( await  _iUserManagementHelper.UserLogin(user));
               
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
        /// <summary>
        /// To view the profile of the user
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetUser/{userId}")]
        public async Task<IActionResult> GetUser(int userId)
        {
            try
            {
             UserDetails user=   await _iUserManagementHelper.GetUser(userId);
                return Ok(user);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
        /// <summary>
        /// To update the user profile
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("UpdateUser")]
        public async Task<IActionResult> UpdateUser(UserDetails user)
        {
            try
            {
               await _iUserManagementHelper.UpdateUser(user);
                return Ok();
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
               return Ok( await _iUserManagementHelper.GetAllUsers());
            }
            catch(Exception e)
            {
                return NotFound(e.Message);
            }
        }
    }

   
}
