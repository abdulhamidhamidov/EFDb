using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DataContext;

public class Context(DbContextOptions<Context> options): DbContext(options)
{
    public DbSet<Team> Teams { get; set; }
    public DbSet<Practicipant> Practicipants { get; set; }
    public DbSet<Hackathon> Hackathons { get; set; }
    
}