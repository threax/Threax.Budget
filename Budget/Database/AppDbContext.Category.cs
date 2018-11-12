using Microsoft.EntityFrameworkCore;

namespace Budget.Database
{
    public partial class AppDbContext
    {
        public DbSet<CategoryEntity> Categories { get; set; }
    }
}
