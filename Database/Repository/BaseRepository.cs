using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using CafisistHelperCMD.Domain.Interfaces.Infra;
using Microsoft.EntityFrameworkCore;

namespace CafisistHelperCMD.Database.Repository
{
    public class BaseRepository
    {
        protected FirebirdContext _context;
        protected DbConnection _connection;

        protected IUnitOfWork _uow;

        public BaseRepository(FirebirdContext context, IUnitOfWork uow)
        {
            _context = context;
            _connection = _context.Database.GetDbConnection();
            _uow = uow;

        }
    }
}