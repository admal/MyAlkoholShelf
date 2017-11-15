using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Display(Name="Nazwa przepisu")]
        public string Name { get; set; }
        public IList<string> Ingredients { get; set; }
        [Display(Name = "Czas przygotowania")]
        public TimeSpan PreparationTime { get; set; }
        [Display(Name = "Dodatkowe informacje")]
        public string AdditionalInformation { get; set; }
        [Display(Name = "Przepis")]
        public string Recipe { get; set; }
    }
}
