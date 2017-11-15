using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MyAlkoholShelf.Web
{
    public abstract class UserBaseController : Controller
    {
        public long LoggedUserId => 1;
    }
}
