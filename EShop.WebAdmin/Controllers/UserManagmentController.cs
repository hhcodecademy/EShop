using EShop.DAL.DBModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShop.WebAdmin.Controllers
{
    public class UserManagmentController : Controller
    {
        private UserManager<AppUser> _userManager;

        public UserManagmentController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult UserIndex()
        {
           
           
            return View();
        }


        

    }
}
