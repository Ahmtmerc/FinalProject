using Project.Repos.Abstracts;
using Project.Repos.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Uw
{
    public interface IUow
    {
        public IBasketDetailRep _basketDetailRep { get; }
        public IBasketMasterRep _basketMasterRep { get; }
        public IBrandRep _brandRep { get; }
        public ICategoryRep _categoryRep { get; }
        public ICityRep _cityRep { get; }
        public IColourRep _colourRep { get; }
        public ICountyRep _countyRep { get; }
        public IModelRep _modelRep { get; }
        public IProductsRep _productsRep { get; }
        public IUnitRep _unitRep { get; }
        public IUserRep _userRep { get; }
        public IVatRep _vatRep { get; }
        void Commit();
    }
}
