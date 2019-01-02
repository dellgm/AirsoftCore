using AirsoftCore.Persistence.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace AirsoftCore.Persistence
{
    public class AirsoftDbContextFactory : DesignTimeDbContextFactoryBase<AirsoftDbContext>
    {
        protected override AirsoftDbContext CreateNewInstance(DbContextOptions<AirsoftDbContext> options)
        {
            return new AirsoftDbContext(options);
        }
    }
}
