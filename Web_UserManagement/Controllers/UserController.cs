using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVC_UI.Models;
using Newtonsoft.Json;

namespace MVC_UI.Controllers
{
    public class UserController : Controller
    {
        public async Task<IActionResult> GetUsers()
        {
            List<UserDetails> userDetails = new List<UserDetails>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:50443/api/v1/GetAllUsers"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    userDetails = JsonConvert.DeserializeObject<List<UserDetails>>(apiResponse);
                }
            }
            return View(userDetails);
        }
        [HttpGet]
        public async Task<IActionResult> GetUserById(int id)
        {
            UserDetails user = new UserDetails();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:61644/api/v1/GetUser/" + id))
                {
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    user = JsonConvert.DeserializeObject<UserDetails>(apiResponse);
                }
            }
            return View(user);
        }

        public async Task<IActionResult> UserRegister()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UserRegister(UserDetails user)
        {
            UserDetails user1 = new UserDetails();
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync("http://localhost:50443/api/v1/UserRegister/", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    //user1 = JsonConvert.DeserializeObject<UserDetails>(apiResponse);
                }
            }
            return RedirectToAction("GetUsers");
        }
        public async Task<IActionResult> UserLogin()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UserLogin(UserDetails userDetails)
        {
            UserDetails userDetails1 = new UserDetails();
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(userDetails), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync("http://localhost:52746/api/v1/UserLogin/", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    if (apiResponse != null)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        Console.WriteLine("Invalid Credentials");
                        return RedirectToAction("UserLogin");
                    }
                    //userDetails1 = JsonConvert.DeserializeObject<UserDetails>(apiResponse);
                }
            }
        }
        [HttpGet]
        public async Task<IActionResult> UpdateUser(string userid)
        {
            UserDetails user = new UserDetails();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:52746/api/v1/UpdateUser/" + userid))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    user = JsonConvert.DeserializeObject<UserDetails>(apiResponse);
                }
            }
            return View(user);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateUser(UserDetails userdetails)
        {
            UserDetails user = new UserDetails();
            int userid = user.UserId;
            using (var httpClient = new HttpClient())
            {
                var content = new MultipartFormDataContent();
                content.Add(new StringContent(user.UserId.ToString()), "Empid");
                content.Add(new StringContent(user.FirstName), "FirstName");
                content.Add(new StringContent(user.LastName), "LastName");
                content.Add(new StringContent(user.UserName), "UserName");
                content.Add(new StringContent(user.UserPassword), "Password");
                content.Add(new StringContent(user.UpdatedDate.ToString()), "UpdatedDate");
                content.Add(new StringContent(user.PhoneNumber), "contactNumber");
                content.Add(new StringContent(user.EmailAddr), "EmailAddress");
                content.Add(new StringContent(user.UserAddress), "UserAddress");

                using (var response = await httpClient.PutAsync("http://localhost:52746/api/v1/UpdateUser/", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    ViewBag.Result = "Success";
                    user = JsonConvert.DeserializeObject<UserDetails>(apiResponse);
                }
            }
            return RedirectToAction("GetAllUsers");
        }



    }
}