using EmsEmployeeManagementSytem.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace EmsEmployeeManagementSytem.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Employee> employees { get; set; }

    }
}
