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
    public class CategoryDal : ICategoryDal
    {
        private readonly Context _context;
        private readonly SignInManager<AppUser> _signInManager;

        public CategoryDal(Context context, SignInManager<AppUser> signInManager)
        {
            _context = context;
            _signInManager = signInManager;
        }

        public void Create(Category entity)
        {
            entity.CreatedBy = _signInManager.Context.User.Identity.Name;
            entity.CreatedComputerName = Environment.MachineName;
            entity.CreatedDate = DateTime.Now;
            entity.CreatedIP = Dns.GetHostEntry(Dns.GetHostName()).AddressList.GetValue(1).ToString();


            _context.Categories.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(Category entity)
        {
            var category = GetById(entity.Id);
            category.Status = EntityLayer.Enum.Status.Deleted;
            Update(category);


        }

        public List<Category> GetActive()
        {
            return _context.Categories.Where(x => x.Status == EntityLayer.Enum.Status.Active || x.Status == EntityLayer.Enum.Status.Updated).ToList();
        }

        public List<Category> GetByDefault(Expression<Func<Category, bool>> filter = null)
        {
            if (filter != null)
            {
                return _context.Categories.Where(filter).ToList();
            }
            else
            {
                return _context.Categories.ToList();
            }
        }

        public Category GetById(Guid id)
        {
            var entity = _context.Categories.Where(x => x.Id == id).FirstOrDefault();
            return entity;
        }

        public void Update(Category entity)
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

            _context.Categories.Update(entity);

            _context.SaveChanges();

        }
    }
}
