using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Text;

namespace BusinessLayer.Concrete
{
    public class SubCategoryManager : ISubCategoryService
    {
        ISubCategoryDal _subCategoryDal;

        public SubCategoryManager(ISubCategoryDal subCategoryDal)
        {
            _subCategoryDal = subCategoryDal;
        }

        public void Create(SubCategory entity)
        {
            _subCategoryDal.Create(entity);
        }

        public void Delete(SubCategory entity)
        {
            _subCategoryDal.Delete(entity);
        }

        public List<SubCategory> GetActive()
        {
            return _subCategoryDal.GetActive();
        }

        public List<SubCategory> GetByDefault(Expression<Func<SubCategory, bool>> filter = null)
        {
            return _subCategoryDal.GetByDefault(filter);
        }

        public SubCategory GetById(Guid id)
        {
            return _subCategoryDal.GetById(id);
        }

        public void Update(SubCategory entity)
        {
            _subCategoryDal.Update(entity);
        }
    }
}
