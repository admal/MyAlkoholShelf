using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAlcoholShelf.Web.Models
{
    public class AlkoholRecipeViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public IList<AlkoholRecipeVersionViewModel> Versions { get; set; }

    }
}
