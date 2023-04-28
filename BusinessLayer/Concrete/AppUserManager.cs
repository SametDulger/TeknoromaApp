using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;
using System.Net;

namespace BusinessLayer.Concrete
{
    public class AppUserManager : IAppUserService
    {
        IAppUserDal _appUserDal;

        public AppUserManager(IAppUserDal appUserDal)
        {
            _appUserDal = appUserDal;
        }



        public void Create(AppUser entity)
        {
            _appUserDal.Create(entity);
        }

        public void Delete(AppUser entity)
        {
            _appUserDal.Delete(entity);
        }

        public List<AppUser> GetActive()
        {
            return _appUserDal.GetActive();

        }

        public List<AppUser> GetByDefault(Expression<Func<AppUser, bool>> filter = null)
        {
            return _appUserDal.GetByDefault(filter);
        }

        public AppUser GetById(Guid id)
        {
            return _appUserDal.GetById(id);
        }

        public void MonthlySalesBonus(List<OrderDetail> orderDetails, AppUser user)
        {
            _appUserDal.MonthlySalesBonus(orderDetails, user);
        }

        public AppUser AddUser(AppUser newUser, string roleName)
        {
            _appUserDal.AddUser(newUser, roleName);
            return newUser;
        }

        public void Update(AppUser entity)
        {
            _appUserDal.Update(entity);
        }


        public void UpdateUserAndRole(AppUser appUser, string roleName)
        {
            _appUserDal.UpdateUserAndRole(appUser, roleName);
        }


    }
}
