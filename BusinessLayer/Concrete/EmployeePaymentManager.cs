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
    public class EmployeePaymentManager : IEmployeePaymentService
    {
         IEmployeePaymentDal _employeePaymentDal;

        public EmployeePaymentManager(IEmployeePaymentDal employeePaymentDal)
        {
            _employeePaymentDal = employeePaymentDal;
        }

        public void Create(EmployeePayment entity)
        {
            _employeePaymentDal.Create(entity);
        }

        public void Delete(EmployeePayment entity)
        {
            _employeePaymentDal.Delete(entity);
        }

        public List<EmployeePayment> GetActive()
        {
            return _employeePaymentDal.GetActive();
        }

        public List<EmployeePayment> GetByDefault(Expression<Func<EmployeePayment, bool>> filter = null)
        {
            return _employeePaymentDal.GetByDefault(filter);
        }

        public EmployeePayment GetById(Guid id)
        {
           return _employeePaymentDal.GetById(id);
        }

        public void Update(EmployeePayment entity)
        {
            _employeePaymentDal.Update(entity);
        }
    }
}
