using System;
using IPEdge.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace IPEdge.Infrastructure
{
	public class IPEdgeDBContext : DbContext
    {
		public IPEdgeDBContext()
		{
		}

		public IPEdgeDBContext(DbContextOptions options)
			:base(options)
		{

		}

		public virtual DbSet<Employee> Employees { get; set; }
		public virtual DbSet<Role> Roles { get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.Entity<Employee>().HasKey(i => i.Id);
			builder.Entity<Employee>().Property(p => p.Id).UseIdentityColumn();

			builder.Entity<Role>().HasKey(i => i.Id);
            builder.Entity<Role>().Property(p => p.Id).UseIdentityColumn();

			base.OnModelCreating(builder);
        }
	}
}

