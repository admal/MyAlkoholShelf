using System.Collections.Generic;
using MyAlkoholShelf.Web.FrontEndModels;

namespace MyAlcoholShelf.Web.Models
{
    public class AlkoholRecipeAddEditModel
    {
        public long? Id { get; set; }

        public long? AlkoholRecipeDefinition { get; set; }
        
        public string Name { get; set; }

        public IList<string> Ingredients { get; set; }

        public DurationFrontEndModel PreparationTime { get; set; }

        public string AdditionalInformation { get; set; }

        public string Recipe { get; set; }
    }
}
