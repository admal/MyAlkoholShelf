using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyAlcoholShelf.Services;
using MyAlcoholShelf.Web.Models;

namespace MyAlcoholShelf.Web.ViewComponents.AlkoholRecipe
{
    [ViewComponent(Name = "AlkoholRecipeAddEdit")]
    public class AlkoholRecipeAddEditViewComponent : ViewComponent
    {
        private readonly IReadRepository _repository;

        public AlkoholRecipeAddEditViewComponent(IReadRepository repository)
        {
            _repository = repository;
        }

        public async Task<IViewComponentResult> InvokeAsync(long? recipeId)
        {

            var model =await Task.FromResult(GetAlkoholRecipeModel(recipeId));
            return View("AlkoholRecipeAddditModal", model);
        }

        private AlkoholRecipeAddEditModel GetAlkoholRecipeModel(long? recipeId)
        {
            AlkoholRecipeAddEditModel model = new AlkoholRecipeAddEditModel(){Name = "lelele"};
            if (recipeId.HasValue)
            {
                var recipe = _repository.Get<MyAlkoholShelf.Entity.AlkoholRecipe>(recipeId.Value);
                model = new AlkoholRecipeAddEditModel()
                {
                    Id = recipe.Id,
                    AlkoholRecipeDefinition = recipe.AlkoholRecipeDefinition.Id,
                    Name = recipe.AlkoholRecipeDefinition.Name,
                    AdditionalInformation = recipe.AdditionalInfo,
                    Recipe = recipe.Recipe,
                    PreparationTime = recipe.PreparationPeriod
                };
            }
            return model;
        }
    }
}
