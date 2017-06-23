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

//        public IActionResult GetAlkoholRecipeAddditModal(long? recipeId)
//        {
//            AlkoholRecipeAddEditModel model = new AlkoholRecipeAddEditModel();
//            if (recipeId.HasValue)
//            {
//                var recipe = _repository.Get<AlkoholRecipe>(recipeId.Value);
//                model = new AlkoholRecipeAddEditModel()
//                {
//                    Id = recipe.Id,
//                    AlkoholRecipeDefinition = recipe.AlkoholRecipeDefinition.Id,
//                    Name = recipe.AlkoholRecipeDefinition.Name,
//                    AdditionalInformation = recipe.AdditionalInfo,
//                    Recipe = recipe.Recipe,
//                    PreparationTime = recipe.PreparationPeriod
//                };
//            }
//            return PartialView("AlkoholRecipeAddditModal", model);
//        }
        
        
        [HttpGet]
        public IActionResult GetAddEditView(long? recipeId)
        {
            var recipe = new AlkoholRecipeAddEditModel();
            if (recipeId.HasValue)
            {
                var entity = _repository.Get<AlkoholRecipe>(recipeId.Value);
                recipe.Id = entity.Id;
                recipe.Name = entity.AlkoholRecipeDefinition.Name;
                recipe.PreparationTime = entity.PreparationPeriod;
                recipe.Recipe = entity.Recipe;
                recipe.Ingredients = entity.Ingredients.Select(x => x.Ingredient.Name).ToList();
                recipe.AdditionalInformation = entity.AdditionalInfo;
                recipe.AlkoholRecipeDefinition = entity.AlkoholRecipeDefinition.Id;
                
                return View(recipe);
            }

            return View(recipe);
        }

        public IActionResult SaveOrUpdateRecipeVersion(AlkoholRecipeAddEditModel model)
        {
            throw new NotImplementedException();
        }

        public IActionResult DeleteRecipe(long recipeId)
        {
            throw new NotImplementedException();
        }
    }
}
