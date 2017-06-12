using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MyAlcoholShelf.Web.Models
{
    public class AlkoholRecipeAddEditModel
    {
        [HiddenInput]
        public long? Id { get; set; }
        [HiddenInput]
        public long? AlkoholRecipeDefinition { get; set; }
        public string Name { get; set; }
        public IList<string> Ingredients { get; set; }
        public TimeSpan PreparationTime { get; set; }
        public string AdditionalInformation { get; set; }
        public string Recipe { get; set; }
    }
}
