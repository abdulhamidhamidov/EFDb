namespace Domain.Entities;

public class Team
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int HackathonId { get; set; }
    public DateTime CreatedDate { get; set; }
    public Hackathon Hackathon { get; set; }
    public List<Practicipant> Practicipants { get; set; }
}