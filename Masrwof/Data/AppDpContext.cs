using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Masrwof.Data
{
    public class AppDpContext: DbContext
    {
        public AppDpContext(DbContextOptions<AppDpContext> options) : base(options)
        {
        }
        public DbSet<Models.Expense> Expenses { get; set; }
    }
}
