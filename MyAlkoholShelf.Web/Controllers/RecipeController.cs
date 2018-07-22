using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyAlcoholShelf.Services;
using MyAlcoholShelf.Services.Recipies;
using MyAlcoholShelf.Services.Recipies.Dto;
using MyAlcoholShelf.Web.Models;
using MyAlkoholShelf.Entity;

namespace MyAlkoholShelf.Web.Controllers
{
    public class RecipeController : UserBaseController
    {
        private readonly IReadRepository _repository;
        private readonly IAlkoholRecipeService _alkoholRecipeService;

        public RecipeController(IReadRepository repository,
            IAlkoholRecipeService alkoholRecipeService)
        {
            _repository = repository;
            _alkoholRecipeService = alkoholRecipeService;
        }

        // GET: /<controller>/
        public IActionResult GetRecipies()
        {
            var recipies = _repository
                .Query<AlkoholRecipeDefinition>()
                .WhereNotDeleted()
                .WhereUserEntities(LoggedUserId)
                .Select(x => new
                {
                    Id = x.Id,
                    Name = x.Name,
                    Versions = x.AlkoholRecipies.Select(y => new
                    {
                        Id = y.Id,
                        CreatedTime = y.CreatedTime,
                        AlkoholCount = y.AlkoholInstances.Count,
                        AlkoholDefinitionId = x.Id,
                        ModifiedTime = y.ModifiedTime,
                        RecipeName = x.Name
                    }).ToList()
                })
                .ToList();
            return Json(recipies);
        }
        
        public IActionResult GetAddEditModel(long? recipeId)
        {
//            [FromQuery(Name = "recipeId")]
        var recipe = new AlkoholRecipeAddEditModel();
            if (recipeId.HasValue)
            {
                var entity = _repository.Query<AlkoholRecipe>()
                    .Where(x => x.Id == recipeId.Value)
                    .Include(x => x.AlkoholRecipeDefinition)
                    .Include(x => x.Ingredients)
                    .FirstOrDefault();
                recipe.Id = entity.Id;
                recipe.Name = entity.AlkoholRecipeDefinition.Name;
                recipe.PreparationTime = entity.PreparationPeriod;
                recipe.Recipe = entity.Recipe;
                recipe.Ingredients = entity.Ingredients.Select(x => x.Ingredient.Name).ToList();
                recipe.AdditionalInformation = entity.AdditionalInfo;
                recipe.AlkoholRecipeDefinition = entity.AlkoholRecipeDefinition.Id;

            }

            return Json(recipe);
        }

        private static AddEditAlkoholRecipeDto ModelToDto(AlkoholRecipeAddEditModel model)
        {
            var dto = new AddEditAlkoholRecipeDto()
            {
                Id = model.Id,
                AlkoholRecipeDefinition = model.AlkoholRecipeDefinition,
                Name = model.Name,
                Recipe = model.Recipe,
                AdditionalInformation = model.AdditionalInformation,
                PreparationTime = model.PreparationTime
            };
            return dto;
        }


        public IActionResult SaveRecipe(AlkoholRecipeAddEditModel model)
        {
            if (model.Id.HasValue)
            {
                _alkoholRecipeService.UpdateRecipe(ModelToDto(model));
            }
            else
            {
                _alkoholRecipeService.CreateRecipe(ModelToDto(model));
            }
            return Redirect("Index");
        }

        public IActionResult SaveAsNewVersion(AlkoholRecipeAddEditModel model)
        {
            _alkoholRecipeService.SaveAsNewVersionRecipe(ModelToDto(model));
            return Redirect("Index");
        }

        public IActionResult DeleteRecipeVersion(long recipeId)
        {
            _alkoholRecipeService.DeleteRecipeVersion(recipeId);
            return Ok();
        }

        [HttpPost]
        public IActionResult SaveMock([FromBody] TMPCLASS model)
        {
            if (string.IsNullOrEmpty(model.RecipeName))
            {
                return new StatusCodeResult(500);
            }
            return Ok();
        }

        [HttpPost]
        public IActionResult SaveMockId([FromBody]long? id)
        {
            if (id == null)
            {
                return new StatusCodeResult(500);
            }
            return Ok();
        }
    }

    public class TMPCLASS
    {
        public long Id { get; set; }
        public DateTime CreatedTime { get; set; }
        public int AlkoholCount { get; set; }
        public long AlkoholDefinitionId { get; set; }
        public DateTime ModifiedTime { get; set; }
        public string RecipeName { get; set; }
    }
}
