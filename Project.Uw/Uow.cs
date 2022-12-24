using Project.Dal;
using Project.Repos.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Uw
{
    public class Uow : IUow
    {
        ProjectContext _db;
        public IBasketDetailRep _basketDetailRep { get; private set; }

        public IBasketMasterRep _basketMasterRep { get; private set; }

        public IBrandRep _brandRep { get; private set; }

        public ICategoryRep _categoryRep { get; private set; }

        public ICityRep _cityRep { get; private set; }

        public IColourRep _colourRep { get; private set; }

        public ICountyRep _countyRep { get; private set; }

        public IModelRep _modelRep { get; private set; }

        public IProductsRep _productsRep { get; private set; }

        public IUnitRep _unitRep { get; private set; }

        public IUserRep _userRep { get; private set; }

        public IVatRep _vatRep { get; private set; }

        public void Commit()
        {

        }
        public Uow(ProjectContext db,IBasketDetailRep basketDetailRep, IBasketMasterRep basketMasterRep, IBrandRep brandRep, ICategoryRep categoryRep,
            ICityRep cityRep, IColourRep colourRep, ICountyRep countyRep, IModelRep modelRep, IProductsRep productsRep, IUnitRep unitRep, IUserRep userRep,
            IVatRep vatRep)
        {
            _db = db;
            _basketDetailRep = basketDetailRep;
            _basketMasterRep = basketMasterRep;
            _brandRep = brandRep;
            _categoryRep = categoryRep;
            _cityRep = cityRep;
            _colourRep = colourRep;
            _countyRep = countyRep;
            _modelRep = modelRep;
            _productsRep = productsRep;
            _unitRep = unitRep;
            _userRep = userRep;
            _vatRep = vatRep;


        }
    }
}
