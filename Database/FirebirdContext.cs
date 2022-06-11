using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CafisistHelperCMD.Database
{
    public class FirebirdContext : DbContext
    {

        public FirebirdContext(DbContextOptions<FirebirdContext> options) : base(options)
        {

        }
    }
}