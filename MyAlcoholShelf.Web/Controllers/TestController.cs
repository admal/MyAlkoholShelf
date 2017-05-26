using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyAlcoholShelf.Services;
using MyAlcoholShelf.Web.Models;
using MyAlkoholShelf.Entity;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyAlcoholShelf.Web.Controllers
{
    public class TestController : Controller
    {
        private readonly IReadRepository _repository;

        public TestController(IReadRepository repository)
        {
            _repository = repository;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var users = _repository.Query<User>();
            return View(users.Select(x => new UserModel() { UserName = x.UserName, Email = x.Email }).ToList());
        }
    }
}
