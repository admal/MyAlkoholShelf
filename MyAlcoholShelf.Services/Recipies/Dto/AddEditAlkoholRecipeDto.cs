using System;
using System.Collections.Generic;

namespace MyAlcoholShelf.Services.Recipies.Dto
{
    public class AddEditAlkoholRecipeDto
    {
        public long? Id { get; set; }
        public long? AlkoholRecipeDefinition { get; set; }
        public string Name { get; set; }
        public IList<string> Ingredients { get; set; }
        public TimeSpan PreparationTime { get; set; }
        public string AdditionalInformation { get; set; }
        public string Recipe { get; set; }
    }
}