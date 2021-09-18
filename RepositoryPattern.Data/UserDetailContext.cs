using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RepositoryPattern.Infrastructure.Models;

namespace RepositoryPattern.Data
{
    public class UserDetailContext : DbContext
    {
        public UserDetailContext(DbContextOptions<UserDetailContext> options) : base(options)
        {

        }
        public DbSet<UserDetail> UserDetails { get; set; }
    }
}
