namespace DataAccess
{
    using System.Data.Entity;

    public class PhoneBookDb<T> : DbContext where T : class
    {
        public PhoneBookDb() : base("PhoneBookDb")
        {
        }

        public DbSet<T> Items { get; set; }
    
    }
}
