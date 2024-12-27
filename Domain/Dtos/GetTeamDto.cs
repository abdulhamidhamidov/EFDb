using Domain.Entities;

namespace Domain.Dtos;

public class GetTeamDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime CreatedDate { get; set; }
    public List<Practicipant> Practicipants { get; set; }
}