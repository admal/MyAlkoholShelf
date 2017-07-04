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
            throw new System.NotImplementedException();
        }

        public void UpdateRecipe(AddEditAlkoholRecipeDto dto)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteRecipeVersion(long recipeId)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteRecipeDefinition(long recipeDefinitionId)
        {
            throw new System.NotImplementedException();
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