using DataAccessLayer.Abstract;
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
    public class EmployeePaymentDal : IEmployeePaymentDal
    {
        private readonly Context _context;
        private readonly SignInManager<AppUser> _signInManager;

        public EmployeePaymentDal(Context context, SignInManager<AppUser> signInManager)
        {
            _context = context;
            _signInManager = signInManager;
        }

        public void Create(EmployeePayment entity)
        {
            entity.CreatedBy = _signInManager.Context.User.Identity.Name;
            entity.CreatedComputerName = Environment.MachineName;
            entity.CreatedDate = DateTime.Now;
            entity.CreatedIP = Dns.GetHostEntry(Dns.GetHostName()).AddressList.GetValue(1).ToString();

            entity.Status = EntityLayer.Enum.Status.Active;
            _context.EmployeePayments.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(EmployeePayment entity)
        {
            entity.Status = EntityLayer.Enum.Status.Deleted;
            Update(entity);
        }

        public List<EmployeePayment> GetActive()
        {
            return _context.EmployeePayments.Where(x => x.Status == EntityLayer.Enum.Status.Active || x.Status == EntityLayer.Enum.Status.Updated).ToList();
        }

        public List<EmployeePayment> GetByDefault(Expression<Func<EmployeePayment, bool>> filter = null)
        {
            if (filter != null)
            {
                return _context.EmployeePayments.Where(filter).ToList();
            }
            else
            {
                return _context.EmployeePayments.ToList();
            }
        }

        public EmployeePayment GetById(Guid id)
        {
            var entity = _context.EmployeePayments.Where(x => x.Id == id).FirstOrDefault();
            return entity;
        }

        public void Update(EmployeePayment entity)
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

            _context.EmployeePayments.Update(entity);

            _context.SaveChanges();

        }
    }
}
