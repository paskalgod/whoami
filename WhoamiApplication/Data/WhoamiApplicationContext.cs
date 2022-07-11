using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WhoamiApplication.Models;

namespace WhoamiApplication.Data
{
    public class WhoamiApplicationContext : DbContext
    {
        public WhoamiApplicationContext (DbContextOptions<WhoamiApplicationContext> options)
            : base(options)
        {
        }

        public DbSet<WhoamiApplication.Models.User> User { get; set; }
    }
}
