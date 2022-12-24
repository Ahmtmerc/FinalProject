using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Core;
using Project.Dal;
using Project.Dto;
using Project.Entity.Concretes;
using Project.Repos.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Project.Repos.Concretes
{
    public class ProductsRep<T> : BaseRepository<Products>, IProductsRep where T : class
    {
        ProjectContext _db;
        Products _newproducts;
        public ProductsRep(ProjectContext db, Products newproducts) : base(db)
        {
            _db = db;
            _newproducts = newproducts;
        }

        public ProductsDTO GetById(int id)
        {
            var product = ProductsDTOs().Where(x => x.Id == id).SingleOrDefault(); //x symbol represents ProductsDTO class in Project.DTO layer
            return product;

        }

        public void Post(ProductsCRUDModel Pm)
        {
            _newproducts.Id = Pm.Id;
            _newproducts.UnitPrice = Pm.UnitPrice;
            _newproducts.ModelId = Pm.ModelId;
            _newproducts.ColourId = Pm.ColourId;
            _newproducts.VatId = Pm.VatId;
            _newproducts.UnitId = Pm.UnitId;

            _db.Add(_newproducts);
            _db.SaveChanges();
        }
        public void Put(int id, ProductsCRUDModel pd)
        {
            _newproducts.Id = pd.Id != default ? pd.Id : _newproducts.Id;
            _newproducts.UnitPrice = pd.UnitPrice != default ? pd.UnitPrice : _newproducts.UnitPrice;
            _newproducts.ModelId = pd.ModelId != default ? pd.ModelId : _newproducts.ModelId;
            _newproducts.ColourId = pd.ColourId != default ? pd.ColourId : _newproducts.ColourId;
            _newproducts.VatId = pd.VatId != default ? pd.VatId : _newproducts.VatId;
            _newproducts.UnitId = pd.UnitId != default ? pd.UnitId : _newproducts.UnitId;

            _db.Update(_newproducts);
            _db.SaveChanges();
        }
        public List<ProductsCRUDModel> ProductsCRUDModels()
        {
            return Set().Select(x => new ProductsCRUDModel  //x symbol represents products class in database
            {
                Id = x.Id,
                UnitPrice = x.UnitPrice,
                ModelId = x.ModelId,
                ColourId = x.ColourId,
                VatId = x.VatId,
                UnitId = x.UnitId,
            }).ToList();
        }
        public List<ProductsDTO> ProductsDTOs()
        {
            return Set().Select(x => new ProductsDTO //x symbol represents products class in database
            {
                Id = x.Id,
                UnitPrice = x.UnitPrice,
                Model = x.Model.Description,
                Brand = x.Model.Brand.Description,
                Category = x.Model.Category.Description,
                Colour = x.Colour.Description,
                Vat = x.Vat.Description,
                Ratio = x.Vat.Ratio,
                Unit = x.Unit.Description
            }).ToList();
        }
    }
}


