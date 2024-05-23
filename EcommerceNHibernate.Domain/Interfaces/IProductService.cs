using EcommerceNHibernate.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceNHibernate.Domain.Interfaces
{
    public  interface IProductService
    {
        public Product GetProductById(int id);
        public void AddProduct(Product product);
        public void UpdateProduct(Product product);
        public void DeleteProduct(int id);
        public IEnumerable<Product> GetProductsByPriceRange(decimal minPrice, decimal maxPrice);
        public Product GetProductByName(string name);
    }
}
