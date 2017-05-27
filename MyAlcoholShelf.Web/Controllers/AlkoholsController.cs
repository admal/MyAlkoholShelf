using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyAlcoholShelf.Services;
using MyAlcoholShelf.Web.Core;
using MyAlcoholShelf.Web.Models;
using MyAlkoholShelf.Entity;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyAlcoholShelf.Web.Controllers
{
    public class AlkoholsController : UserBaseController
    {
        private readonly IReadRepository _repository;

        public AlkoholsController(IReadRepository repository)
        {
            _repository = repository;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var loggedUser = this.LoggedUserId;//TMP!!!!
            var instances = _repository.Query<AlkoholInstance>()
                .WhereAlkoholInstancesForUser(loggedUser)
                .Select(x => new AlkoholInstanceViewModel()
                {
                    Id = x.Id,
                    Quantity = x.Quantity,
                    Name = x.AlkoholRecipe.AlkoholRecipeDefinition.Name,
                    FinishDate = x.FinishDate,
                    StartDate = x.CreatedTime,
                    VersionDate = x.AlkoholRecipe.CreatedTime
                }).ToList();
            return View(instances);
        }
    }
}
