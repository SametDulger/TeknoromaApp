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
    public class SupplierManager : ISupplierService
    {
        ISupplierDal _supplierDal;

        public SupplierManager(ISupplierDal supplierDal)
        {
            _supplierDal = supplierDal;
        }

        public void Create(Supplier entity)
        {
            _supplierDal.Create(entity);        }

        public void Delete(Supplier entity)
        {
            _supplierDal.Delete(entity);
        }

        public List<Supplier> GetActive()
        {
            return _supplierDal.GetActive();    
        }

        public List<Supplier> GetByDefault(Expression<Func<Supplier, bool>> filter = null)
        {
            return _supplierDal.GetByDefault(filter);
        }

        public Supplier GetById(Guid id)
        {
            return _supplierDal.GetById(id);
        }

        public void Update(Supplier entity)
        {
            _supplierDal.Update(entity);
        }
    }
}
