using Microsoft.EntityFrameworkCore;
using SleepTrackerAPI.Model;

namespace SleepTrackerAPI.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }

    public DbSet<SleepData> SleepDatas { get; set; }
}
