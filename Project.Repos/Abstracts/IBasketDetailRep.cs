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
    public interface IBasketDetailRep : IBaseRepository<BasketDetail>
    {
        public BasketDetail FindWithBasketMaster(int Id);
        public List<BasketDetailCRUDModel> BasketDetailCRUDModel();
        public List<BasketDetailDTO> BasketDetailDTOs();

    }
}