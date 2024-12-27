using Domain.Enums;

namespace Domain.Dtos;

public class CreatePracticipantDto
{
    public string Name { get; set; }
    public string Email { get; set; }
    public int TeamId { get; set; }
    public Role Role { get; set; }
    public DateTime JoinedDate { get; set; }
}