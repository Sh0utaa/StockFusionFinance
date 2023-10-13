using AuthSystem.Areas.Identity.Data;
using AuthSystem.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AuthSystem.Data;

public class AuthSystemDBContext : IdentityDbContext<ApplicationUser>
{
    public AuthSystemDBContext(DbContextOptions<AuthSystemDBContext> options)
        : base(options)
    {
    }
    public DbSet<TransactionsModel> Transactions { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
        builder.Entity<TransactionsModel>().ToTable("Transactions");
        builder.Entity<PortfolioModel>().ToTable("Portfolio");
    }
}
