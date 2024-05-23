using EcommerceNHibernate.Domain.Entidades;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceNHibernate.Persistance.Mappings
{
    public class ProductMap : ClassMap<Product>
    {
        public ProductMap()
        {
            Table("Product");

            Id(x => x.IdProduct).GeneratedBy.Identity();

            Map(x => x.NameProduct);
            Map(x => x.Price);
            Map(x => x.Stock);
            Map(x => x.IdBrand);
            Map(x => x.IdSubCategory);
            Map(x => x.IdCategory);
        }
    }
}
