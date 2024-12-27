using Domain.Entities;

namespace Domain.Dtos;

public class GetHackathonDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime Date { get; set; }
    public string Theme { get; set; }
    public List<Team> Teams { get; set; }
}