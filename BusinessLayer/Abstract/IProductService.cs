using DataAccessLayer.DTO;
using EntityLayer.Concrete;
using System.Collections.Generic;

namespace BusinessLayer.Abstract
{
    public interface IProductService : IGenericService<Product>
    {
        List<ProductDTO> GetAllProductForApi();

        List<Top10ProductDTO> GetTop10();
    }
}
