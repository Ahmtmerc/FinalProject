using Project.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Entity.Concretes;
using Project.Uw;
using Newtonsoft.Json;

namespace PROJECT.Controllers
{
    [Route("[controller]/[Action]")]
    [ApiController]
    public class BasketMasterController : ControllerBase
    {
        IUow _uow;
        BasketMaster _basketMaster;
        public BasketMasterController(IUow uow, BasketMaster basketMaster)
        {
            _uow = uow;
            _basketMaster = basketMaster;
        }
        [HttpPost]
        public IActionResult Create()
        {
            var usr = JsonConvert.DeserializeObject<UserDTO>(HttpContext.Session.GetString("User"));
            var selectedBasket = _uow._basketMasterRep.Set().FirstOrDefault(x => x.Completed == false && x.UserId == usr.Id); //tamamlanmamış birşey var mı ve de hangi user da login olduysa.
            if (selectedBasket != null)
            {
                return BadRequest("Zaten Mevcut Sepeteniz Tamamlanmadı.");
            }
            else
            {
                _basketMaster.OrderDate = DateTime.Now;
                _basketMaster.UserId = usr.Id;
                _uow._basketMasterRep.Add(_basketMaster);
                _uow.Commit();
            }
            return Ok("Yeni Sepet Oluşturuldu");


        }
    }
}
