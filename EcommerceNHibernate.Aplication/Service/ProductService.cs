using EcommerceNHibernate.Domain.Entidades;
using EcommerceNHibernate.Domain.Interfaces;
using EcommerceNHibernate.Persistance.Repository;
using EcommerceNHibernate.Persistance.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceNHibernate.Aplication.Service
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public Product GetProductByName(string name)
        {
           return  _unitOfWork.Products.GetProductByName(name);
        }


        public void AddProduct(Product product)
        {
            _unitOfWork.Products.AddProduct(product);
        }

        public void DeleteProduct(int id)
        {
            _unitOfWork.Products.DeleteProduct(id);
        }

        public Product GetProductById(int id)
        {
            return _unitOfWork.Products.GetProductById(id);
        }

        public IEnumerable<Product> GetProductsByPriceRange(decimal minPrice, decimal maxPrice)
        {
            return _unitOfWork.Products.GetProductsByPriceRange(minPrice, maxPrice);
        }

        public void UpdateProduct(Product product)
        {
            _unitOfWork.Products.UpdateProduct(product);
        }
    }
}
