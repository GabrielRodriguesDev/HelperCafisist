using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using CafisistHelperCMD.Domain.Interfaces.Infra;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace CafisistHelperCMD.Database
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
#nullable disable
        private FirebirdContext _context;

        private IDbContextTransaction _dbContextTransaction;

        public UnitOfWork(FirebirdContext context)
        {
            _context = context;
        }

        public void Dispose()
        {
            if (_dbContextTransaction != null)
            {
                _dbContextTransaction.DisposeAsync();
            }

        }

        public void BeginTransaction()
        {
            _dbContextTransaction = _context.Database.BeginTransaction();
        }

        public void Commit()
        {
            if (_dbContextTransaction == null)
            {
                throw new Exception("Transação não iniciada");
            }

            _context.SaveChangesAsync().Wait();
            _dbContextTransaction.CommitAsync().Wait();
            this.DetachedChanges();
            _dbContextTransaction = null;
        }

        public void DetachedChanges()
        {
            foreach (var entry in _context.ChangeTracker.Entries())
            {

                // Libera o estado de uma entidade adicionada para liberado(detached);
                if (entry.State == EntityState.Unchanged)
                {
                    entry.State = EntityState.Detached;
                }
            }
        }
        public void Rollback()
        {
            if (_dbContextTransaction != null)
            {
                _dbContextTransaction.RollbackAsync().Wait();
            }
        }

        public IDbTransaction CurrentTransaction()
        {
            IDbTransaction result = null;
            if (_dbContextTransaction != null)
            {
                result = _dbContextTransaction.GetDbTransaction();
            }
            return result;
        }
    }
}