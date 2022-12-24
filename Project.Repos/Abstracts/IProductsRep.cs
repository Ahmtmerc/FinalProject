using Microsoft.AspNetCore.Mvc;
using Project.Core;
using Project.Dto;
using Project.Entity.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Repos.Abstracts
{
    public interface IProductsRep : IBaseRepository<Products>
    {
        public ProductsDTO GetById(int id);
        public void Post(ProductsCRUDModel Pm);
        public void Put(int id, ProductsCRUDModel pd);
        public List<ProductsCRUDModel> ProductsCRUDModels();
        public List<ProductsDTO> ProductsDTOs();

    }
}
