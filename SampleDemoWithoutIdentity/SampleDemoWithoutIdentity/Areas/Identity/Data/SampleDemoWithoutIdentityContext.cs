﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SampleDemoWithoutIdentity.Models;
using DataAccess.Models;

namespace SampleDemoWithoutIdentity.Data;

public class SampleDemoWithoutIdentityContext : IdentityDbContext<ApplicationUser>
{
    public SampleDemoWithoutIdentityContext(DbContextOptions<SampleDemoWithoutIdentityContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }

public DbSet<DataAccess.Models.Employee> Employee { get; set; } = default!;

}
