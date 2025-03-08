using HoQuocCuong_2280605191.Models;
using System.Collections.Generic;

namespace HoQuocCuong_2280605191.Repositories
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAll();
        Product GetById(int id);
        void Add(Product product);
        void Update(Product product);
        void Delete(int id);
    }
}
