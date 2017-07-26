using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MyAlcoholShelf.Web.Core
{
    public abstract class UserBaseController : Controller
    {
        //TODO: WYPIERDOLIĆ TO !!!!!
        public long LoggedUserId => 1;
    }
}
