using DataAccessLayer.DTO;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IExpenseService : IGenericService<Expense>
    {
        List<MonthlySalesDTO> MonthlySales(DateTime time);

    }
}
