
using Microsoft.EntityFrameworkCore;
using PatientsApi.Models;
namespace PatientsApi.Data
{
    public class ApiContext : DbContext
    {
        public DbSet<Patients> Patients { get; set; }
        public ApiContext(DbContextOptions<ApiContext> options)
            :base(options) { }


    }
}
