using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;

namespace BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {

         ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public void Create(Category entity)
        {
            _categoryDal.Create(entity);
        }

        public void Delete(Category entity)
        {
            _categoryDal.Delete(entity);
        }

        public List<Category> GetActive()
        {
           return _categoryDal.GetActive();
        }

        public List<Category> GetByDefault(Expression<Func<Category, bool>> filter = null)
        {
            return _categoryDal.GetByDefault(filter);
        }

        public Category GetById(Guid id)
        {
           return _categoryDal.GetById(id);
        }

        public void Update(Category entity)
        {
            _categoryDal.Update(entity);
        }
    }
}
