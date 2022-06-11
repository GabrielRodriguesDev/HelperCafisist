using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CafisistHelperCMD.Domain.Interfaces.Repository
{
    public interface IDuprecRepository
    {
        void AjustaDuplicatasSmartSist(int dias);
    }
}