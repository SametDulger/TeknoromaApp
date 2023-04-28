using DataAccessLayer.Abstract;
using DataAccessLayer.DTO;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class ExpenseDal : IExpenseDal
    {
        private readonly Context _context;
        private readonly SignInManager<AppUser> _signInManager;

        public ExpenseDal(Context context, SignInManager<AppUser> signInManager)
        {
            _context = context;
            _signInManager = signInManager;
        }

        public void Create(Expense entity)
        {

            entity.CreatedBy = _signInManager.Context.User.Identity.Name;
            entity.CreatedComputerName = Environment.MachineName;
            entity.CreatedDate = DateTime.Now;
            entity.CreatedIP = Dns.GetHostEntry(Dns.GetHostName()).AddressList.GetValue(1).ToString();

            entity.Status = EntityLayer.Enum.Status.Active;
            _context.Expenses.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(Expense entity)
        {

            entity.Status = EntityLayer.Enum.Status.Deleted;
            Update(entity);

        }

        public List<Expense> GetActive()
        {
            return _context.Expenses.Where(x => x.Status == EntityLayer.Enum.Status.Active || x.Status == EntityLayer.Enum.Status.Updated).ToList();
        }

        public List<Expense> GetByDefault(Expression<Func<Expense, bool>> filter = null)
        {
            if (filter != null)
            {
                return _context.Expenses.Where(filter).ToList();
            }
            else
            {
                return _context.Expenses.ToList();
            }
        }

        public Expense GetById(Guid id)
        {
            var entity = _context.Expenses.Where(x => x.Id == id).FirstOrDefault();
            return entity;
        }

        public List<MonthlySalesDTO> MonthlySales(DateTime startDate)
        {
            var query = from c in _context.Customers
                        join o in _context.Orders on c.Id equals o.CustomerId
                        join od in _context.OrderDetails on o.Id equals od.OrderId
                        join u in _context.Users on o.AppUserId equals u.Id
                        select new MonthlySalesDTO
                        {
                            CustomerName = c.CustomerName,
                            EmployeUserName = u.UserName,
                            OrderDate = o.OrderDate,
                            TCKN = c.TC,
                            SalesTotal = od.UnitPrice * od.Quantity,
                            OrderId = o.Id,
                        };

            List<MonthlySalesDTO> mountlySales = new List<MonthlySalesDTO>();

            foreach (var q in query)
            {
                var createdMount = q.OrderDate.Month;
                var createdYear = q.OrderDate.Year;

                if (createdMount == startDate.Month && createdYear == startDate.Year)
                {
                    bool exist = false;
                    foreach (var ms in mountlySales)
                    {
                        if (q.OrderId == ms.OrderId)
                        {
                            exist = true;
                            ms.SalesTotal += q.SalesTotal;
                            break;
                        }

                    }
                    if (!exist)
                    {
                        mountlySales.Add(new MonthlySalesDTO
                        {
                            CustomerName = q.CustomerName,
                            TCKN = q.TCKN,
                            OrderDate = q.OrderDate,
                            EmployeUserName = q.EmployeUserName,
                            SalesTotal = q.SalesTotal,
                            OrderId = q.OrderId,
                        });
                    }
                }

            }
            return mountlySales;
        }

        public void Update(Expense entity)
        {

            entity.UpdatedBy = _signInManager.Context.User.Identity.Name;
            entity.UpdatedComputerName = Environment.MachineName;
            entity.UpdatedDate = DateTime.Now;
            entity.UpdatedIP = Dns.GetHostEntry(Dns.GetHostName()).AddressList.GetValue(1).ToString();


            if (entity.Status == EntityLayer.Enum.Status.Deleted)
            {
                entity.Status = EntityLayer.Enum.Status.Deleted;
            }
            else
            {
                entity.Status = EntityLayer.Enum.Status.Updated;
            }

            _context.Expenses.Update(entity);

            _context.SaveChanges();

        }
    }
}
