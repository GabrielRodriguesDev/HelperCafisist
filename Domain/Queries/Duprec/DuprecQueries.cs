using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CafisistHelperCMD.Domain.Queries.Duprec
{
    public class DuprecQueries
    {
        public static string AjustaDuplicatasSmartSist(int dias)
        {
            return @$"UPDATE DUPREC SET E9_QTD_ENVIOS_FORCADO_WEB = COALESCE(E9_QTD_ENVIOS_FORCADO_WEB,0) + 1
                    WHERE
                    DUPRPAG >= CURRENT_DATE - {dias}";
        }
    }
}