using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CafisistHelperCMD.Domain.Interfaces.Infra;
using CafisistHelperCMD.Domain.Interfaces.Repository;
using CafisistHelperCMD.Domain.Queries.Duprec;
using Dapper;

namespace CafisistHelperCMD.Database.Repository
{
    public class DuprecRepository : BaseRepository, IDuprecRepository
    {

        public DuprecRepository(FirebirdContext context, IUnitOfWork uow) : base(context, uow)
        {
        }

        public void AjustaDuplicatasSmartSist(int dias)
        {
            _connection.Query(DuprecQueries.AjustaDuplicatasSmartSist(dias), new { }, _uow.CurrentTransaction());
        }
    }
}