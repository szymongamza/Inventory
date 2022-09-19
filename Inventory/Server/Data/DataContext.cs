using Inventory.Shared;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var now = DateTime.UtcNow;

            foreach (var changedEntity in ChangeTracker.Entries())
            {
                if (changedEntity.Entity is IEntity entity)
                {
                    switch (changedEntity.State)
                    {
                        case EntityState.Added:
                            entity.CreatedDate = now;
                            entity.UpdatedDate = now;
                            entity.CreatedBy = "Unknown"; //TODO
                            entity.UpdatedBy = "Unknown"; // TODO
                            break;
                        case EntityState.Modified:
                            Entry(entity).Property(x => x.CreatedBy).IsModified = false;
                            Entry(entity).Property(x => x.CreatedDate).IsModified = false;
                            entity.UpdatedDate = now;
                            entity.UpdatedBy = "Unknown"; //TODO
                            break;
                    }
                }
            }
            return base.SaveChangesAsync();
        }
        public DbSet<Device> Devices { get; set; } 
        public DbSet<Department> Departments { get; set; }
        public DbSet<Room> Rooms { get; set; }
    }
}
