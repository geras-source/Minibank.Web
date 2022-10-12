using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Minibank.Data.Account;
using Minibank.Data.Users;

namespace Minibank.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> dbContextOptions) : base(dbContextOptions)
        {
            //Database.EnsureCreated();
        }

        public DbSet<UserEntity> Users { get; set; }

        public DbSet<BankAccountDbModel> BancAccountDbModels { get; set; }

        public DbSet<HistoryDbModel> HistoryDbModels { get; set; }
    }
}
