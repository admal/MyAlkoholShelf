using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyAlcoholShelf.Services;
using MyAlcoholShelf.Services.Recipies;
using MyAlcoholShelf.Services.Recipies.Dto;
using MyAlcoholShelf.Web.Core;
using MyAlcoholShelf.Web.Models;
using MyAlkoholShelf.Entity;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyAlcoholShelf.Web.Controllers
{
    public class RecipiesController : UserBaseController
    {
        private readonly IReadRepository _repository;
        private IAlkoholRecipeService _alkoholRecipeService;

        public RecipiesController(IReadRepository repository, 
            IAlkoholRecipeService alkoholRecipeService)
        {
            _repository = repository;
            _alkoholRecipeService = alkoholRecipeService;
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
//                var entity = _repository.Get<AlkoholRecipe>(recipeId.Value);
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
                
                return View(recipe);
            }

            return View(recipe);
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
        
        public IActionResult UpdateRecipe(AlkoholRecipeAddEditModel model)
        {
            _alkoholRecipeService.UpdateRecipe(ModelToDto(model));
            return Ok();
        }
        
        public IActionResult SaveAsNewVersion(AlkoholRecipeAddEditModel model)
        {
            _alkoholRecipeService.SaveAsNewVersionRecipe(ModelToDto(model));
            return Ok();
        }
        
        public IActionResult CreateRecipe(AlkoholRecipeAddEditModel model)
        {
            _alkoholRecipeService.CreateRecipe(ModelToDto(model));
            return Ok();
        }

        public IActionResult DeleteRecipeVersion(long recipeId)
        {
            _alkoholRecipeService.DeleteRecipeVersion(recipeId);
            return Ok();
        }
    }
}
