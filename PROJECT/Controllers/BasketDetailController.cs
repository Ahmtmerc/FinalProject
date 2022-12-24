using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Dal;
using Project.Dto;
using Project.Entity.Concretes;
using Project.Uw;

namespace PROJECT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketDetailController : ControllerBase
    {
        ProjectContext _db;
        BasketDetail _bd;
        IUow _uow;

        public BasketDetailController(ProjectContext db, BasketDetail bd, IUow uow)
        {
            _db = db;
            _bd = bd;
            _uow = uow;
        }

        [HttpGet]
        public List<BasketDetailDTO> BasketDetailDTOs()
        {
            var BasketDetailList = _uow._basketDetailRep.BasketDetailDTOs().ToList();
            return BasketDetailList;
        }

        [HttpPost]
        public IActionResult Add(BasketDetailCRUDModel bd, int id)
        {
            Products products = _uow._productsRep.Find(bd.ProductId);

            _uow._basketDetailRep.FindWithBasketMaster(id);

            _bd.Id = id;
            _bd.ProductId = bd.ProductId;
            _bd.BmId = id;
            _bd.UnitPrice = products.UnitPrice;
            _bd.Amount = bd.Amount;
            _bd.UnitId = bd.UnitId;
            _bd.VatId = bd.VatId;

            _db.Add(_bd);
            _db.SaveChanges();

            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Update(int Amount, int id, int ProductId)
        {
            var x = _uow._basketDetailRep.Find(id, ProductId);
            if (x is null)
                return BadRequest("Not Found");

            x.Amount = Amount;
            _uow._basketDetailRep.Update(x);
            _db.SaveChanges();

            return Ok("Updated Completed");
        }


        [HttpDelete]
        public IActionResult Delete(int Productid, int BasketdetailId)
        {
            var BasketDetail = _db.BasketDetails.SingleOrDefault(x => x.Id == BasketdetailId && x.ProductId == Productid); //x symbol represent the BasketDetail class in database
            if (BasketDetail is null)

                return BadRequest("Wrong Choice (Please!!! Be sure wanted to be deleted the correct Product in the BasketDetail)");

            _db.BasketDetails.Remove(BasketDetail);
            _db.SaveChanges();
            return Ok("Product Deleted");
        }

    }
}