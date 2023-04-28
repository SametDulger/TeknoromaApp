using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
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
    public class IssueManager : IIssueService
    {
        IIssueDal _issueDal;

        public IssueManager(IIssueDal issueDal)
        {
            _issueDal = issueDal;
        }

        public void Create(Issue entity)
        {
            _issueDal.Create(entity);
        }

        public void Delete(Issue entity)
        {
            _issueDal.Delete(entity);
        }

        public List<Issue> GetActive()
        {
            return _issueDal.GetActive();
        }

        public List<Issue> GetByDefault(Expression<Func<Issue, bool>> filter = null)
        {
            return _issueDal.GetByDefault(filter);
        }

        public Issue GetById(Guid id)
        {
            return _issueDal.GetById(id);
        }

        public void Update(Issue entity)
        {
            _issueDal.Update(entity);
        }
    }
}
