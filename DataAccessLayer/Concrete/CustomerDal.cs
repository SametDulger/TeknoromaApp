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
    public class CustomerDal : ICustomerDal
    {
        private readonly Context _context;
        private readonly SignInManager<AppUser> _signInManager;

        public CustomerDal(Context context, SignInManager<AppUser> signInManager)
        {
            _context = context;
            _signInManager = signInManager;
        }

        public void Create(Customer entity)
        {
            entity.CreatedBy = _signInManager.Context.User.Identity.Name;
            entity.CreatedComputerName = Environment.MachineName;
            entity.CreatedDate = DateTime.Now;
            entity.CreatedIP = Dns.GetHostEntry(Dns.GetHostName()).AddressList.GetValue(1).ToString();

            _context.Customers.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(Customer entity)
        {
            entity.Status = EntityLayer.Enum.Status.Deleted;
            Update(entity);

        }

        public Customer FindByTC(string TC)
        {
            var customer = _context.Customers.Where(x => x.TC == TC).FirstOrDefault();
            return customer;
        }

        public List<Customer> GetActive()
        {
            return _context.Customers.Where(x => x.Status == EntityLayer.Enum.Status.Active || x.Status == EntityLayer.Enum.Status.Updated).ToList();
        }

        public List<Customer> GetByDefault(Expression<Func<Customer, bool>> filter = null)
        {
            if (filter != null)
            {
                return _context.Customers.Where(filter).ToList();
            }
            else
            {
                return _context.Customers.ToList();
            }
        }

        public Customer GetById(Guid id)
        {
            var entity = _context.Customers.Where(x => x.Id == id).FirstOrDefault();
            return entity;
        }

        public void Update(Customer entity)
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

            _context.Customers.Update(entity);

            _context.SaveChanges();

        }
    }
}
