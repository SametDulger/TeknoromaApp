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
    public class IssueDal : IIssueDal
    {
        private readonly Context _context;
        private readonly SignInManager<AppUser> _signInManager;

        public IssueDal(Context context, SignInManager<AppUser> signInManager)
        {
            _context = context;
            _signInManager = signInManager;
        }

        public void Create(Issue entity)
        {

            entity.CreatedBy = _signInManager.Context.User.Identity.Name;
            entity.CreatedComputerName = Environment.MachineName;
            entity.CreatedDate = DateTime.Now;
            entity.CreatedIP = Dns.GetHostEntry(Dns.GetHostName()).AddressList.GetValue(1).ToString();


            entity.IssueStatus = EntityLayer.Enum.IssueStatus.Open;
            _context.Issues.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(Issue entity)
        {
            entity.Status = EntityLayer.Enum.Status.Deleted;

            entity.IssueStatus = EntityLayer.Enum.IssueStatus.Closed;
            Update(entity);
        }

        public List<Issue> GetActive()
        {
            return _context.Issues.Where(x => x.Status == EntityLayer.Enum.Status.Active || x.Status == EntityLayer.Enum.Status.Updated).ToList();
        }

        public List<Issue> GetByDefault(Expression<Func<Issue, bool>> filter = null)
        {
            if (filter != null)
            {
                return _context.Issues.Where(filter).ToList();
            }
            else
            {
                return _context.Issues.ToList();
            }
        }

        public Issue GetById(Guid id)
        {
            var entity = _context.Issues.Where(x => x.Id == id).FirstOrDefault();
            return entity;
        }

        public void Update(Issue entity)
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

            _context.Issues.Update(entity);

            _context.SaveChanges();

        }
    }
}
