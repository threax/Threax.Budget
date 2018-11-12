using Microsoft.EntityFrameworkCore;

namespace Budget.Database
{
    public partial class AppDbContext
    {
        public DbSet<ValueEntity> Values { get; set; }
    }
}
