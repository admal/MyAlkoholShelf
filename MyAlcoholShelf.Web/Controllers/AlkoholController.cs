using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MyAlcoholShelf.Services;
using MyAlcoholShelf.Web.Controllers.Base;
using MyAlkoholShelf.Entity;

namespace MyAlcoholShelf.Web.Controllers
{
    public class AlkoholController : UserBaseController
    {
        private readonly IReadRepository _repository;

        public AlkoholController(IReadRepository repository)
        {
            _repository = repository;
        }

        public IActionResult GetAlkohols()
        {
            var loggedUser = this.LoggedUserId;
            var instances = _repository.Query<AlkoholInstance>()
                .WhereAlkoholInstancesForUser(loggedUser)
                .Select(x => new
                {
                    Id = x.Id,
                    Quantity = x.Quantity,
                    Name = x.AlkoholRecipe.AlkoholRecipeDefinition.Name,
                    FinishDate = x.FinishDate,
                    StartDate = x.CreatedTime,
                    VersionDate = x.AlkoholRecipe.CreatedTime
                }).ToList();

            return Json(instances);
        }
    }
}