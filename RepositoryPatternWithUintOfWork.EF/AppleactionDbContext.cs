using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPatternWithUintOfWork.EF
{
    public class AppleactionDbContext : DbContext
    {
        public AppleactionDbContext(DbContextOptions<AppleactionDbContext> option) : base(option)
        {
        }
    }
}
