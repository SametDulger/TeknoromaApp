using DataAccessLayer.Abstract;
using DataAccessLayer.DTO;
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
    public class SupplierExpenseDal : ISupplierExpenseDal
    {
        private readonly Context _context;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IProductDal _productDal;

        public SupplierExpenseDal(Context context, SignInManager<AppUser> signInManager, IProductDal productDal)
        {
            _context = context;
            _signInManager = signInManager;
            _productDal = productDal;
        }

        public void Create(SupplierExpense entity)
        {
            try
            {
                entity.Id = Guid.NewGuid();
                entity.CreatedBy = _signInManager.Context.User.Identity.Name;
                entity.CreatedComputerName = Environment.MachineName;
                entity.CreatedDate = DateTime.Now;
                entity.CreatedIP = Dns.GetHostEntry(Dns.GetHostName()).AddressList.GetValue(1).ToString();

                _context.SupplierExpenses.Add(entity);
                _context.SaveChanges();

                var product = _productDal.GetById(entity.ProductId);
                product.UnıtsInStock += entity.Quantity;
                _productDal.Update(product);
            }
            catch (Exception ex)
            {
                var message = ex.Message;
                throw;
            }

        }

        public void Delete(SupplierExpense entity)
        {
            entity.Status = EntityLayer.Enum.Status.Deleted;
            Update(entity);
        }

        public List<SupplierExpense> GetActive()
        {
            return _context.SupplierExpenses.Where(x => x.Status == EntityLayer.Enum.Status.Active || x.Status == EntityLayer.Enum.Status.Updated).ToList();

        }

        public List<SupplierExpenseReportDTO> GetAllTimeReport()
        {
            List<SupplierExpenseReportDTO> supplierExpenseReports = new List<SupplierExpenseReportDTO>();

            var query = from se in _context.SupplierExpenses
                        join p in _context.Products on se.ProductId equals p.Id
                        join s in _context.Suppliers on p.SupplierId equals s.Id
                        select new SupplierExpenseReportDTO
                        {
                            ID = se.Id,
                            SupplierId = s.Id,
                            SupplierName = s.CompanyName,
                            ProductId = p.Id,
                            ProductName = p.ProductName,
                            CreatedDate = se.CreatedDate,
                            Total = se.Quantity
                        };

            foreach (SupplierExpenseReportDTO se in query)
            {
                bool exist = false;

                foreach (SupplierExpenseReportDTO v in supplierExpenseReports)
                {
                    if (se.ProductId == v.ProductId)
                    {
                        exist = true;
                        v.Total += se.Total;
                        break;
                    }
                }
                if (!exist)
                {
                    supplierExpenseReports.Add(new SupplierExpenseReportDTO
                    {
                        ID = se.ID,
                        CreatedDate = se.CreatedDate,
                        ProductName = se.ProductName,
                        SupplierName = se.SupplierName,
                        ProductId = se.ProductId,
                        SupplierId = se.SupplierId,
                        Total = se.Total

                    });
                }
            }

            return supplierExpenseReports;
        }

        public List<SupplierExpense> GetByDefault(Expression<Func<SupplierExpense, bool>> filter = null)
        {
            if (filter != null)
            {
                return _context.SupplierExpenses.Where(filter).ToList();
            }
            else
            {
                return _context.SupplierExpenses.ToList();
            }
        }

        public SupplierExpense GetById(Guid id)
        {
            return _context.SupplierExpenses.FirstOrDefault(x => x.Id == id);

        }

        public List<SupplierExpenseReportDTO> GetMonthlyReport()
        {
            List<SupplierExpenseReportDTO> supplierExpenseReports = new List<SupplierExpenseReportDTO>();

            var query = from se in _context.SupplierExpenses
                        join p in _context.Products on se.ProductId equals p.Id
                        join s in _context.Suppliers on p.SupplierId equals s.Id
                        select new SupplierExpenseReportDTO
                        {
                            ID = se.Id,
                            SupplierId = s.Id,
                            SupplierName = s.CompanyName,
                            ProductId = p.Id,
                            ProductName = p.ProductName,
                            CreatedDate = se.CreatedDate,
                            Total = se.Quantity
                        };

            foreach (SupplierExpenseReportDTO se in query)
            {
                bool exist = false;
                var seM = se.CreatedDate.Month;
                var seY = se.CreatedDate.Year;

                var dayY = DateTime.Now.Year;
                var dayM = DateTime.Now.Month;

                foreach (SupplierExpenseReportDTO v in supplierExpenseReports)
                {

                    if (se.ProductId == v.ProductId)
                    {
                        if (seM == dayM && seY == dayY)
                        {
                            exist = true;
                            v.Total += se.Total;
                            break;
                        }

                    }
                }
                if (!exist)
                {
                    if (seM == dayM && seY == dayY)
                    {
                        supplierExpenseReports.Add(new SupplierExpenseReportDTO
                        {
                            ID = se.ID,
                            CreatedDate = se.CreatedDate,
                            ProductName = se.ProductName,
                            SupplierName = se.SupplierName,
                            ProductId = se.ProductId,
                            SupplierId = se.SupplierId,
                            Total = se.Total

                        });
                    }

                }
            }

            return supplierExpenseReports;

        }

        public void Update(SupplierExpense entity)
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

            _context.SupplierExpenses.Update(entity);
            _context.SaveChanges();
        }
    }
}
