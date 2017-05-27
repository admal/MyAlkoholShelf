using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAlcoholShelf.Web.Models
{
    public class AlkoholInstanceViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        public DateTime VersionDate { get; set; }
    }
}
