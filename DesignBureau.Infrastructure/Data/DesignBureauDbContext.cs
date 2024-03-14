using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DesignBureau.Data
{
    public class DesignBureauDbContext : IdentityDbContext
    {
        public DesignBureauDbContext(DbContextOptions<DesignBureauDbContext> options)
            : base(options)
        {
        }
    }
}
