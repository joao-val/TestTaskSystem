using Microsoft.EntityFrameworkCore;
using SistemaDeTarefas_api_basica_.Data.Map;
using SistemaDeTarefas_api_basica_.Models;

namespace SistemaDeTarefas_api_basica_.Data
{
    public class SistemaDeTarefasDBContext : DbContext
    {
        public SistemaDeTarefasDBContext(DbContextOptions<SistemaDeTarefasDBContext> options)
            : base(options)
        {
        }

        public DbSet<UserModel> Users { get; set; }
        public DbSet<TaskModel> Tasks { get; set; }
        public DbSet<UserAuthModel> userAuths { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new TaskMap());
            modelBuilder.ApplyConfiguration(new UserAuthMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}