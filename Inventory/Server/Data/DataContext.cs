using Inventory.Shared;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Device> Devices { get; set; } 
    }
}
