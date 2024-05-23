using EcommerceNHibernate.Domain.Interfaces;
using EcommerceNHibernate.Persistance.Repository;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceNHibernate.Persistance.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IProductRepository Products { get; }
        int SaveChanges();
    }
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ISession _session;
        public UnitOfWork(ISession session)
        {
            _session = session;
        }
        public IProductRepository Products => new ProductRepository(_session);

        public void Dispose()
        {
            _session.Dispose();
        }

        public int SaveChanges()
        {
            using (var transaction = _session.BeginTransaction())
            {
                _session.Flush();
                transaction.Commit();
                return 1; 
            }
        }
    }


}
