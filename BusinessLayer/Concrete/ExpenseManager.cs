using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.DTO;
using DataAccessLayer.Repositories;
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
    public class ExpenseManager : IExpenseService
    {
       IExpenseDal _expenseDal;

        public ExpenseManager(IExpenseDal expenseDal)
        {
            _expenseDal = expenseDal;
        }

        public void Create(Expense entity)
        {
            _expenseDal.Create(entity);
        }

        public void Delete(Expense entity)
        {
            _expenseDal.Delete(entity);
        }

        public List<Expense> GetActive()
        {
            return _expenseDal.GetActive();
        }

        public List<Expense> GetByDefault(Expression<Func<Expense, bool>> filter = null)
        {
            return _expenseDal.GetByDefault(filter);
        }

        public Expense GetById(Guid id)
        {
            return _expenseDal.GetById(id);

        }

        public List<MonthlySalesDTO> MonthlySales(DateTime time)
        {
            return _expenseDal.MonthlySales(time);
        }

        public void Update(Expense entity)
        {
            _expenseDal.Update(entity);
        }
    }
}
