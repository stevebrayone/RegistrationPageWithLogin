using Microsoft.EntityFrameworkCore;
using RegisterationForm.Models;
using System.Collections.Generic;

namespace RegisterationForm.Entities
{
    public class EntityDbContext: DbContext
    {
        
        public EntityDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<RegModel>RegistrationTable{ get; set; }

    }
}
