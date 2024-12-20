﻿using Microsoft.EntityFrameworkCore;
using NineDotsAssesment.Domain.Entities;

namespace NineDotsAssesment.Infrastructure.Sql
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Customer> Customers { get; set; }
    }
}