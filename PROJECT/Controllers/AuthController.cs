using Project.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Project.Entity.Concretes;
using Project.Uw;

namespace PROJECT.Controllers
{
    [Route("[controller]/[Action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public const string SessionUser = ""; //bu kısım session için https://learn.microsoft.com/tr-tr/aspnet/core/fundamentals/app-state?view=aspnetcore-6.0 adresinden alındı.

        UserCRUDModel _model;
        IUow _uow;
        public AuthController(UserCRUDModel model, IUow uow)
        {
            _model = model;
            _uow = uow;
        }
        //public IActionResult Register()
        //{
        //    _model.Users = new Users();
        //    _model.Counties = _uow._countyRep.List();
        //    return Ok();
        //}

        [HttpPost]
        public IActionResult Add(UserCRUDModel model)
        {
            var user = _uow._userRep.UserDTO().SingleOrDefault(x => x.Id == model.Id); //x symbol represent the ProductsDTO class in Project.DTO layer
            if (user is not null)
                return BadRequest("User is already available");

            _uow._userRep.Post(model);

            return Ok("Product Added");
        }

        [HttpPost]
        public IActionResult Login(string Mail, string Password) //Model kullanılmadığı için parametre verildi.
        {
            UserDTO user = _uow._userRep.Login(Mail, Password); //repository e parametre olarak gelir.
            if (user.Error == false) //hata yoksa
            {
                HttpContext.Session.SetString("User", JsonConvert.SerializeObject(user)); //session kayıt atıldıı
                return Ok();
            }
            return BadRequest("Kullanıcı Zaten Var)");

        }
        //public IActionResult Logout()
        //{
        //    HttpContext.Session.Clear();
        //    return Ok("Çıkış Yapıldı");

        //}

    }
}


