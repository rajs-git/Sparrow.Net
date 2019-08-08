﻿using System.Data;
using Microsoft.EntityFrameworkCore;

namespace Sparrow.EntityFrameworkCore.Configurations
{
    public class EfDbContextConfiguration<TDbContext> where TDbContext : DbContext
    {
        public string ConnectionString { get; set; }

        public IDbConnection DbConnection { get; set; }

        public DbContextOptionsBuilder<TDbContext> Builder { get; }

        public EfDbContextConfiguration(string connectionString, IDbConnection dbConnection)
        {
            ConnectionString = connectionString;
            DbConnection = dbConnection;

            Builder = new DbContextOptionsBuilder<TDbContext>();
        }
    }
}