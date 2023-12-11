

using Mamba.Core.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Mamba.Data.DAL
{
    public class MambaContext : IdentityDbContext
    {
        public MambaContext(DbContextOptions<MambaContext> options) : base(options)
        {
         
        }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Profession> Professions { get; set;}
     
        public DbSet<AppUser> AppUsers { get; set; }

    }
}
