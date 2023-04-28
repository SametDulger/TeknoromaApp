using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class AppUserDal : IAppUserDal
    {
        private readonly Context _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<AppRole> _roleManager;

        public AppUserDal(Context context, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<AppRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        public void Create(AppUser entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(AppUser entity)
        {
            var user = _context.Users.Find(entity.Id);

            user.Status = EntityLayer.Enum.Status.Deleted;

            _context.SaveChanges();
        }

        public List<AppUser> GetActive()
        {
            return _context.Users.Where(x => x.Status == EntityLayer.Enum.Status.Active || x.Status == EntityLayer.Enum.Status.Updated).ToList();
        }

        public List<AppUser> GetByDefault(Expression<Func<AppUser, bool>> filter = null)
        {
            if (filter != null)
            {
                return _context.Users.Where(filter).ToList();
            }
            else
            {
                return _context.Users.ToList();
            }
        }

        public AppUser GetById(Guid id)
        {
            var entity = _context.Users.Where(x => x.Id == id).FirstOrDefault();
            return entity;
        }

        public void MonthlySalesBonus(List<OrderDetail> orderDetails, AppUser user)
        {
            var limit = 10000;
            var cut = 0.1;
            var totalSales = 0;
            foreach (OrderDetail od in orderDetails)
            {
                totalSales += od.Quantity * (int)od.UnitPrice;
            }


            if (user.MonthlySales >= limit)
            {
                var bonus = totalSales * cut;
                user.Bonus += (decimal)bonus;
                user.MonthlySales += totalSales;
            }
            else
            {
                if (totalSales >= limit)
                {
                    var bonus = (totalSales - limit) * cut;
                    user.Bonus += (decimal)bonus;
                    user.MonthlySales += totalSales;
                }
                else
                {
                    user.MonthlySales += totalSales;
                }
            }



            Update(user);
        }

        public AppUser AddUser(AppUser newUser, string roleName)
        {

            var existEmail = _userManager.FindByEmailAsync(newUser.Email).Result;
            var existUserName = _userManager.FindByNameAsync(newUser.UserName).Result;
            if (existEmail != null || existUserName != null)
            {
                return newUser;
            }
            else
            {
                var createdBy = string.Empty;
                if (_signInManager.Context.User.Identity.Name != null)
                {
                    createdBy = _signInManager.Context.User.Identity.Name;
                }
                else
                {
                    createdBy = newUser.UserName;
                }
                AppUser user = new AppUser
                {
                    UserName = newUser.UserName,
                    FirstName = newUser.FirstName,
                    LastName = newUser.LastName,
                    Email = newUser.Email,
                    PhoneNumber = newUser.PhoneNumber,
                    Address = newUser.Address,
                    Salary = newUser.Salary,
                    Status = EntityLayer.Enum.Status.Active,
                    CreatedBy = createdBy,
                    CreatedDate = DateTime.Now,
                    CreatedComputerName = Environment.MachineName,
                    CreatedIP = Dns.GetHostEntry(Dns.GetHostName()).AddressList.GetValue(1).ToString()

                };

                var result = _userManager.CreateAsync(user, newUser.Password).Result;
                if (result.Succeeded)
                {
                    var addRoleResult = _userManager.AddToRoleAsync(user, roleName).Result;
                }
                _context.SaveChanges();

                return user;

            }
        }

        public void UpdateUserAndRole(AppUser appUser, string roleName)
        {

            var user = _context.Users.Find(appUser.Id);

            user.UpdatedBy = _signInManager.Context.User.Identity.Name;
            user.UpdatedComputerName = Environment.MachineName;
            user.UpdatedDate = DateTime.Now;
            user.UpdatedIP = Dns.GetHostEntry(Dns.GetHostName()).AddressList.GetValue(1).ToString();


            if (user.Status == EntityLayer.Enum.Status.Deleted)
            {
                user.Status = EntityLayer.Enum.Status.Deleted;
            }
            else
            {
                user.Status = EntityLayer.Enum.Status.Updated;
            }

            user.FirstName = appUser.FirstName;
            user.LastName = appUser.LastName;
            user.UserName = appUser.UserName;
            user.Email = appUser.Email;
            user.PhoneNumber = appUser.PhoneNumber;
            user.Salary = appUser.Salary;
            user.Address = appUser.Address;

            if(appUser.Password != null)
            {
                user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, appUser.Password);

            }



            var query = from u in _context.Users
                        join userRole in _context.UserRoles on u.Id equals userRole.UserId
                        join role in _context.Roles on userRole.RoleId equals role.Id
                        where u.UserName == user.UserName
                        select new { u.UserName, role.Name };

            var existingRole = query.ToList()[0].Name;


            var removeRoleResult = _userManager.RemoveFromRoleAsync(user, existingRole).Result;

            var addRoleResult = _userManager.AddToRoleAsync(user, roleName).Result;

            _context.Users.Update(user);

            _context.SaveChanges();

        }


        public void Update(AppUser entity)
        {
            var user = _context.Users.Find(entity.Id);

            user.UpdatedBy = _signInManager.Context.User.Identity.Name;
            user.UpdatedComputerName = Environment.MachineName;
            user.UpdatedDate = DateTime.Now;
            user.UpdatedIP = Dns.GetHostEntry(Dns.GetHostName()).AddressList.GetValue(1).ToString();


            if (user.Status == EntityLayer.Enum.Status.Deleted)
            {
                user.Status = EntityLayer.Enum.Status.Deleted;
            }
            else
            {
                user.Status = EntityLayer.Enum.Status.Updated;
            }

            user.FirstName = entity.FirstName;
            user.LastName = entity.LastName;
            user.UserName = entity.UserName;
            user.Email = entity.Email;
            user.PhoneNumber = entity.PhoneNumber;
            user.Salary = entity.Salary;
            user.Address = entity.Address;

            user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, entity.Password);

            _context.Users.Update(user);

            _context.SaveChanges();
        }

        
             
    }
}
