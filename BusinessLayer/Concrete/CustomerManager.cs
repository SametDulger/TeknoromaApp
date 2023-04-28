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
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public void Create(Customer entity)
        {
            _customerDal.Create(entity);
        }

        public void Delete(Customer entity)
        {
            _customerDal.Delete(entity);
        }

        public Customer FindByTC(string TC)
        {
            return _customerDal.FindByTC(TC);
        }

        public List<Customer> GetActive()
        {
            return _customerDal.GetActive();
        }

        public List<Customer> GetByDefault(Expression<Func<Customer, bool>> filter = null)
        {
            return _customerDal.GetByDefault(filter);
        }

        public Customer GetById(Guid id)
        {
            return _customerDal.GetById(id);
        }

        public void Update(Customer entity)
        {
            _customerDal.Update(entity);    
        }
    }
}
