using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.DTO;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Text;

namespace BusinessLayer.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public void Create(Product entity)
        {
            _productDal.Create(entity);
        }

        public void Delete(Product entity)
        {
            _productDal.Delete(entity);
        }

        public List<Product> GetActive()
        {
            return _productDal.GetActive();
        }

        public List<ProductDTO> GetAllProductForApi()
        {
            return _productDal.GetAllProductForApi();
        }

        public List<Product> GetByDefault(Expression<Func<Product, bool>> filter = null)
        {
            return _productDal.GetByDefault(filter);
        }

        public Product GetById(Guid id)
        {
            return _productDal.GetById(id);
        }

        public List<Top10ProductDTO> GetTop10()
        {
            return _productDal.GetTop10();        
        }

        public void Update(Product entity)
        {
            _productDal.Update(entity);
        }
    }

}
