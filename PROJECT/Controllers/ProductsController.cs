using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Dal;
using Project.Dto;
using Project.Entity.Concretes;
using Project.Uw;


namespace PROJECT.Controllers
{
    [Route("[controller]/[Action]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        ProjectContext _db;
        IUow _uow;
        public ProductsController(ProjectContext db, IUow uow)
        {
            _db = db;
            _uow = uow;
        }
        [HttpGet]
        public List<ProductsDTO> productsDTOs()
        {
            var ProductsList = _uow._productsRep.ProductsDTOs().ToList();
            return ProductsList;
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var pd = _uow._productsRep.GetById(id);

            if (pd is null)
            {
                return BadRequest("The Product was not Found");
            }

            return Ok(pd);
        }

        [HttpPost]
        public IActionResult Add(ProductsCRUDModel Pm)
        {
            var product = _uow._productsRep.ProductsDTOs().SingleOrDefault(x => x.Id == Pm.Id); //x symbol represent the ProductsDTO class in Project.DTO layer
            if (product is not null)
                return BadRequest("Product is already available");

            _uow._productsRep.Post(Pm);

            return Ok("Product Added");
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, ProductsCRUDModel pd)
        {
            var product = _uow._productsRep.ProductsDTOs().SingleOrDefault(x => x.Id == id); //x symbol represent the ProductsDTO class in Project.DTO layer
            if (product is null)
                return BadRequest("The Product that you want to update is not available in DataBase");

            _uow._productsRep.Put(id, pd);
            return Ok("Product Updated");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var product = _db.Products.SingleOrDefault(x => x.Id == id);  //x symbol represent the products class in database
            if (product is null)
                return BadRequest("The Product that you want to delete is not available in DataBase");

            _db.Products.Remove(product);
            _db.SaveChanges();
            return Ok("Product Deleted");
        }
    }
}

