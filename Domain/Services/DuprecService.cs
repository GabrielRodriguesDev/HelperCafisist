using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CafisistHelperCMD.Domain.Interfaces.Infra;
using CafisistHelperCMD.Domain.Interfaces.Repository;
using CafisistHelperCMD.Domain.Interfaces.Services;

namespace CafisistHelperCMD.Domain.Services
{
    public class DuprecService : IDuprecService
    {
        private IDuprecRepository _duprecRepository;

        private IUnitOfWork _uow;

        public DuprecService(IDuprecRepository duprecRepository, IUnitOfWork uow)
        {
            _duprecRepository = duprecRepository;
            _uow = uow;
        }

        public void AjustaDuplicatasSmartSist()
        {
            _uow.BeginTransaction();
            try
            {
                _duprecRepository.AjustaDuplicatasSmartSist(4);
                _uow.Commit();
            }
            catch (System.Exception)
            {
                _uow.Rollback();
                throw;
            }
        }
    }
}