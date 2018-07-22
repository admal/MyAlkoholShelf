using Microsoft.AspNetCore.Mvc;

namespace MyAlcoholShelf.Web.Controllers.Base
{
    public abstract class UserBaseController : Controller
    {
        public long LoggedUserId => 1;
    }
}