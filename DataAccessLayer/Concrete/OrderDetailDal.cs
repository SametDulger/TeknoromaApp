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
    public class OrderDetailDal : IOrderDetailDal
    {
        private readonly Context _context;
        private readonly SignInManager<AppUser> _signInManager;

        public OrderDetailDal(Context context, SignInManager<AppUser> signInManager)
        {
            _context = context;
            _signInManager = signInManager;
        }
        public void Create(OrderDetail entity)
        {

            entity.CreatedBy = _signInManager.Context.User.Identity.Name;
            entity.CreatedComputerName = Environment.MachineName;
            entity.CreatedDate = DateTime.Now;
            entity.CreatedIP = Dns.GetHostEntry(Dns.GetHostName()).AddressList.GetValue(1).ToString();

            entity.Id = Guid.NewGuid();
            _context.OrderDetails.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(OrderDetail entity)
        {

            entity.Status = EntityLayer.Enum.Status.Deleted;
            Update(entity);


        }

        public List<OrderDetail> GetActive()
        {
            return _context.OrderDetails.Where(x => x.Status == EntityLayer.Enum.Status.Active || x.Status == EntityLayer.Enum.Status.Updated).ToList();
        }

        public List<OrderDetail> GetByDefault(Expression<Func<OrderDetail, bool>> filter = null)
        {
            if (filter != null)
            {
                return _context.OrderDetails.Where(filter).ToList();
            }
            else
            {
                return _context.OrderDetails.ToList();
            }
        }

        public OrderDetail GetById(Guid id)
        {
            var entity = _context.OrderDetails.Where(x => x.Id == id).FirstOrDefault();
            return entity;
        }

        public void Update(OrderDetail entity)
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

            _context.OrderDetails.Update(entity);

            _context.SaveChanges();
        }
    }
}
