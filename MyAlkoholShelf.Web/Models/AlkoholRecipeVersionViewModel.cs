using System;

namespace MyAlcoholShelf.Web.Models
{
    public class AlkoholRecipeVersionViewModel
    {
        public long Id { get; set; }
        public long AlkoholDefinitionId { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime ModifiedTime { get; set; }
        public int AlkoholCount { get; set; }
    }
}