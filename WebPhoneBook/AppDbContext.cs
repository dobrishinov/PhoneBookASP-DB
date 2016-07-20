namespace DataAccess
{
    using DataAccess.Entity;
    using System.Data.Entity;

    public class AppDbContext : DbContext 
    {
        public AppDbContext() 
            : base("PhoneBookDb")
        {
        }

        public DbSet<ContactEntity> Contacts { get; set; }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<PhoneEntity> Phones { get; set; }
    }
}