using DataAccessLayer.Abstract;
using DataAccessLayer.DTO;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;

namespace DataAccessLayer.Repositories
{
    public class ProductDal : IProductDal
    {
        private readonly Context _context;
        private readonly SignInManager<AppUser> _signInManager;

        public ProductDal(Context context, SignInManager<AppUser> signInManager)
        {
            _context = context;
            _signInManager = signInManager;
        }

        public void Create(Product entity)
        {
            entity.CreatedBy = _signInManager.Context.User.Identity.Name;
            entity.CreatedComputerName = Environment.MachineName;
            entity.CreatedDate = DateTime.Now;
            entity.CreatedIP = Dns.GetHostEntry(Dns.GetHostName()).AddressList.GetValue(1).ToString();

            _context.Products.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(Product entity)
        {

            entity.Status = EntityLayer.Enum.Status.Deleted;
            Update(entity);

        }

        public List<Product> GetActive()
        {
            return _context.Products.Where(x => x.Status == EntityLayer.Enum.Status.Active || x.Status == EntityLayer.Enum.Status.Updated).ToList();
        }

        public List<ProductDTO> GetAllProductForApi()
        {
            var query = from p in _context.Products
                        select new ProductDTO
                        {
                            ProductName = p.ProductName,
                            UnitPrice = p.UnitPrice,
                            UnıtsInStock = p.UnıtsInStock
                        };

            return query.ToList();

        }

        public List<Top10ProductDTO> GetTop10()
        {
            var query = from p in _context.Products
                        join od in _context.OrderDetails on p.Id equals od.ProductId
                        join o in _context.Orders on od.OrderId equals o.Id
                        select new Top10ProductDTO
                        {
                            ProductName = p.ProductName,
                            TotalSell = od.Quantity,
                            ProductId = p.Id,
                            Customer = o.Customer

                        };

            List<Top10ProductDTO> top10Products = new List<Top10ProductDTO>();

            foreach (var q in query)
            {
                bool exist = false;
                var count = 0;

                foreach (var v in top10Products)
                {
                    if (v.ProductId == q.ProductId)
                    {
                        exist = true;
                        v.TotalSell += q.TotalSell;

                        v.Customers.Add(q.Customer);
                        break;
                    }
                }
                if (!exist && count <= 10)
                {
                    count++;

                    List<Customer> customers = new List<Customer>();
                    customers.Add(q.Customer);

                    Top10ProductDTO x = new Top10ProductDTO();
                    x.Customers = customers;
                    x.ProductId = q.ProductId;
                    x.ProductName = q.ProductName;
                    x.TotalSell = q.TotalSell;

                    top10Products.Add(x);
                }
            }



            return top10Products.OrderByDescending(x => x.TotalSell).ToList();
        }

        public List<Product> GetByDefault(Expression<Func<Product, bool>> filter = null)
        {
            if (filter != null)
            {
                return _context.Products.Where(filter).ToList();
            }
            else
            {
                return _context.Products.ToList();
            }
        }

        public Product GetById(Guid id)
        {
            return _context.Products.FirstOrDefault(x => x.Id == id);

        }




        public void Update(Product entity)
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

            if (entity.UnıtsInStock > 0)
            {
                _context.Products.Update(entity);
                _context.SaveChanges();

            }


        }

        List<ProductDTO> IProductDal.GetAllProductForApi()
        {
            var query = from p in _context.Products
                        select new ProductDTO
                        {
                            ProductName = p.ProductName,
                            UnitPrice = p.UnitPrice,
                            UnıtsInStock = p.UnıtsInStock
                        };

            return query.ToList();
        }
    }
}
