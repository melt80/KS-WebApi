using KS.Database.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace KS.Database.Context
{
    public class KSContext : DbContext
    {
        public KSContext(DbContextOptions<KSContext> options) : base(options)
        {

        }
        public DbSet<UserEntity> UserTableAccess { get; set; }
    }
}
