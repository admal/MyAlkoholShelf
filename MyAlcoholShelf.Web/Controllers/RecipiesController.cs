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
    public class RecipiesController : UserBaseController
    {
        private IReadRepository _repository;

        public RecipiesController(IReadRepository repository)
        {
            _repository = repository;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var recipies = _repository
                .Query<AlkoholRecipeDefinition>()
                .WhereNotDeleted()
                .WhereUserEntities(LoggedUserId)
                .Select(x => new AlkoholRecipeViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Versions = x.AlkoholRecipies.Select(y => new AlkoholRecipeVersionViewModel()
                    {
                        Id = y.Id,
                        CreatedTime = y.CreatedTime,
                        AlkoholCount = y.AlkoholInstances.Count,
                        AlkoholDefinitionId = x.Id,
                        ModifiedTime = y.ModifiedTime
                    }).ToList()
                })
                .ToList();
            return View(recipies);
        }
    }
}
