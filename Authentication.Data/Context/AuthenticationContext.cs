using Authentication.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Authentication.Data.Context
{
    public class AuthenticationContext: DbContext
    {
        #region ctor

        public AuthenticationContext(DbContextOptions<AuthenticationContext> options) : base(options)
        { }
        #endregion

        #region dbset
        public DbSet<User> Users { get; set; }
        #endregion

        #region OnModelCreating
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
        #endregion
    }
}
