using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.DTO;
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
    public class SupplierExpenseManager : ISupplierExpenseService
    {
        ISupplierExpenseDal _supplierExpenseDal;

        public SupplierExpenseManager(ISupplierExpenseDal supplierExpenseDal)
        {
            _supplierExpenseDal = supplierExpenseDal;
        }

        public void Create(SupplierExpense entity)
        {
            _supplierExpenseDal.Create(entity);
        }

        public void Delete(SupplierExpense entity)
        {
            _supplierExpenseDal.Delete(entity);
        }

        public List<SupplierExpense> GetActive()
        {
            return _supplierExpenseDal.GetActive();
        }

        public List<SupplierExpenseReportDTO> GetAllTimeReport()
        {
            return _supplierExpenseDal.GetAllTimeReport();
        }

        public List<SupplierExpense> GetByDefault(Expression<Func<SupplierExpense, bool>> filter = null)
        {
            return _supplierExpenseDal.GetByDefault(filter);
        }

        public SupplierExpense GetById(Guid id)
        {
            return _supplierExpenseDal.GetById(id);
        }

        public List<SupplierExpenseReportDTO> GetMonthlyReport()
        {
            return _supplierExpenseDal.GetMonthlyReport();
        }

        public void Update(SupplierExpense entity)
        {
            _supplierExpenseDal.Update(entity);
        }
    }
}
