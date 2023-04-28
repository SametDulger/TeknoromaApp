using DataAccessLayer.DTO;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface ISupplierExpenseDal : IGenericDal<SupplierExpense>
    {
        List<SupplierExpenseReportDTO> GetMonthlyReport();
        List<SupplierExpenseReportDTO> GetAllTimeReport();
    }
}
