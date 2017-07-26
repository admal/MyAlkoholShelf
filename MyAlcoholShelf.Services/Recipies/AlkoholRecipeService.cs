using System;
using System.Linq;
using MyAlcoholShelf.Services.Recipies.Dto;
using MyAlkoholShelf.Entity;

namespace MyAlcoholShelf.Services.Recipies
{
    public class AlkoholRecipeService : IAlkoholRecipeService
    {
        private readonly IRepository _repository;

        public AlkoholRecipeService(IRepository repository)
        {
            _repository = repository;
        }

        public void CreateRecipe(AddEditAlkoholRecipeDto dto)
        {
            //TODO: TMP!!!!
            var user = _repository.Query<User>().First();
            var recipeDefinition = new AlkoholRecipeDefinition()
            {
                Name = dto.Name,
                CreatedBy = user
            };
            _repository.SaveOrUpdate(recipeDefinition);

            var recipe = new AlkoholRecipe()
            {
                AlkoholRecipeDefinition = recipeDefinition,
                Recipe = dto.Recipe,
                AdditionalInfo = dto.AdditionalInformation,
                PreparationPeriod = dto.PreparationTime,
            };
            _repository.SaveOrUpdate(recipe);

            recipeDefinition.AlkoholRecipies.Add(recipe);
            _repository.SaveOrUpdate(recipeDefinition);
        }

        public void SaveAsNewVersionRecipe(AddEditAlkoholRecipeDto dto)
        {
            var recipeVersion = new AlkoholRecipe
            {
                Recipe = dto.Recipe,
                AdditionalInfo = dto.AdditionalInformation,
                PreparationPeriod = dto.PreparationTime,
                AlkoholRecipeDefinitionId =  dto.AlkoholRecipeDefinition.Value,
                CreatedTime = DateTime.Now,
                ModifiedTime = DateTime.Now
            };
            
            _repository.SaveOrUpdate(recipeVersion);
        }

        public void UpdateRecipe(AddEditAlkoholRecipeDto dto)
        {
            var recipe = _repository.Get<AlkoholRecipe>(dto.Id.Value);
            recipe.Recipe = dto.Recipe;
            recipe.AdditionalInfo = dto.AdditionalInformation;
            recipe.PreparationPeriod = dto.PreparationTime;
            recipe.ModifiedTime = DateTime.Now;
            _repository.SaveOrUpdate(recipe);
        }

        public void DeleteRecipeVersion(long recipeId)
        {
            var recipeVersion = _repository.Get<AlkoholRecipe>(recipeId);
            _repository.SoftDelete(recipeVersion);
        }

        public void DeleteRecipeDefinition(long recipeDefinitionId)
        {
            var recipeDefinition = _repository.Get<AlkoholRecipeDefinition>(recipeDefinitionId);
            _repository.SoftDelete(recipeDefinition);
        }
    }

    public interface IAlkoholRecipeService
    {
        void CreateRecipe(AddEditAlkoholRecipeDto dto);
        void SaveAsNewVersionRecipe(AddEditAlkoholRecipeDto dto);
        void UpdateRecipe(AddEditAlkoholRecipeDto dto);
        void DeleteRecipeVersion(long recipeId);
        void DeleteRecipeDefinition(long recipeDefinitionId);
    }
}