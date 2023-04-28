using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IAppUserService: IGenericService<AppUser>
    {


        void MonthlySalesBonus(List<OrderDetail> orderDetails, AppUser user);

        AppUser AddUser(AppUser newUser, string roleName);

        void UpdateUserAndRole(AppUser appUser, string roleName);

    }
}
