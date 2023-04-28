using DataAccessLayer.DTO;
using EntityLayer.Concrete;
using System.Collections.Generic;

namespace DataAccessLayer.Abstract
{
    public interface IProductDal : IGenericDal<Product>
    {
        List<ProductDTO> GetAllProductForApi();

        List<Top10ProductDTO> GetTop10();

    }
}
