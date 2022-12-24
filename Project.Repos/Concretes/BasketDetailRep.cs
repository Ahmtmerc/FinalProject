using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Project.Core;
using Project.Dal;
using Project.Dto;
using Project.Entity.Concretes;
using Project.Repos.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Repos.Concretes
{
    public class BasketDetailRep<T> : BaseRepository<BasketDetail>, IBasketDetailRep where T : class
    {

        ProjectContext _db;
        BasketDetail _bd;
        public BasketDetailRep(ProjectContext db, BasketDetail bd) : base(db)
        {
            _db = db;
            _bd = bd;
        }
        public BasketDetail FindWithBasketMaster(int Id)
        {
            return Set().Where(x => x.Id == Id).Include(x => x.BasketMaster).FirstOrDefault(); //x symbol represent the BasketDetail class in database
        }
        public List<BasketDetailCRUDModel> BasketDetailCRUDModel()
        {
            return Set().Select(x => new BasketDetailCRUDModel

            {
                Id = x.Id,
                ProductId = x.ProductId,
                BmId = x.BmId,
                UnitPrice = x.Products.UnitPrice,
                Amount = x.Amount,
                VatId = x.VatId,
                UnitId = x.UnitId

            }).ToList();
        }
        public List<BasketDetailDTO> BasketDetailDTOs()
        {
            return Set().Select(x => new BasketDetailDTO
            {
                Id = x.Id,
                //ProductId = x.Products.Id, //These lines were converted into comment line so that End-User can not see
                //BmId = x.BasketMaster.Id,  //These lines were converted into comment line so that End-User can not see
                Amount = x.Amount,
                UnitId = x.Products.Unit.Description,
                UnitPrice = x.Products.UnitPrice,
                ProductName = x.Products.Model.Brand.Description + " " + x.Products.Model.Description,
                Ratio = x.Products.Vat.Ratio,
                ColourName = x.Products.Colour.Description,
                Total = (x.Products.UnitPrice * x.Amount) * (1 + x.Products.Vat.Ratio / 100),

            }).ToList();
        }
    }
}

