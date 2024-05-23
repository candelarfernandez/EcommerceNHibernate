using EcommerceNHibernate.Domain.Entidades;
using EcommerceNHibernate.Persistance.Mappings;
using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Data;
using FluentNHibernate.MappingModel.Identity;
using Microsoft.Extensions.Configuration;
using NHibernate;

namespace EcommerceNHibernate.Persistance
{
    public class NHibernateConfiguration
    {
        public static ISessionFactory CreateSessionFactory(IConfiguration configuration)
        {
            return Fluently.Configure()
         .Database(MsSqlConfiguration.MsSql2012
            .ConnectionString(configuration.GetConnectionString("DefaultConnection")))
        .Mappings(m =>
        {
            m.FluentMappings.AddFromAssemblyOf<ProductMap>(); // Add your manual mappings here
        })
        .BuildSessionFactory();
        }
    }
}
