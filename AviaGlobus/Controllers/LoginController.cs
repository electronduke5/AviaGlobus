using AviaGlobus.Models;
using AviaGlobus.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AviaGlobus.Controllers
{
    public class LoginController : Controller
    {
        private ApplicationContext db;

        public LoginController(ApplicationContext context)
        {
            db = context;
        }

        public IActionResult Loging()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Loging (User user)
        {
            if (ModelState.IsValid)
            {
                User u = db.Users.Where(o => o.Login == user.Login).FirstOrDefault();

                if (u != null)
                {
                    if (u.Password == user.Password)
                    {
                        Console.WriteLine("USER CHECK" + u.ID_User + " - " + u.Lastname + " : " + u.Role);
                        string roleName = db.Roles.Find(u.Role_ID).Title;

                        CookieOptions cookie = new CookieOptions();
                        cookie.Expires = DateTime.Now.AddMinutes(30);
                        Response.Cookies.Append("login", user.Login, cookie);
                        Response.Cookies.Append("password", user.Password, cookie);

                        if (u.Role_ID == 1) return RedirectToAction("Users", "Home");
                        else return RedirectToAction("Cashier", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("Password", "Неверный пароль!");
                        return View();
                    }
                }
                else
                {
                    ModelState.AddModelError("Login", "Неверный логин!");
                    return View();
                }
            }
            else
            {
                return View();
            }
        }
    }
}