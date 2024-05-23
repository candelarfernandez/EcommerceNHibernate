using EcommerceNHibernate.Domain.Entidades;
using EcommerceNHibernate.Domain.Interfaces;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceNHibernate.Persistance.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ISession _session;
        private Dictionary<string, Product> _productDictionary;

        public ProductRepository(ISession session)
        {
            _session = session;
            InitializeProductDictionary();
        }

        private void InitializeProductDictionary()
        {
            var allProducts = GetAll();
            _productDictionary = allProducts.ToDictionary(p => p.NameProduct);
        }

        public IEnumerable<Product> GetAll()
        {
            return _session.Query<Product>().ToList();
        }

        public void AddProduct(Product product)
        {
            _session.Save(product);
        }

        public void DeleteProduct(int id)
        {
            var product = _session.Get<Product>(id);
            if (product != null)
                _session.Delete(product);
        }
        public Product GetProductByName(string name)
        {
      
            return _productDictionary.ContainsKey(name) ? _productDictionary[name] : null;
        }

        public Product GetProductById(int id)
        {
            return _session.Get<Product>(id);
        }

        public void UpdateProduct(Product product)
        {
            _session.Update(product);
        }
        public IEnumerable<Product> GetProductsByPriceRange(decimal minPrice, decimal maxPrice)
        {
            /* asi se hace con HQL (
            var query = _session.CreateQuery("from Product where Price between :minPrice and :maxPrice");
            query.SetParameter("minPrice", minPrice);
            query.SetParameter("maxPrice", maxPrice);
            return query.List<Product>();*/
            var sqlQuery = @"SELECT * FROM Product WHERE Price BETWEEN :minPrice AND :maxPrice";
            var query = _session.CreateSQLQuery(sqlQuery)
                               .AddEntity(typeof(Product))
                               .SetParameter("minPrice", minPrice)
                               .SetParameter("maxPrice", maxPrice);

            return query.List<Product>();
        }
    }
}
