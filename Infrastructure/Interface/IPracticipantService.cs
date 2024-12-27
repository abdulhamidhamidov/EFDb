using Domain.Entities;
using Infrastructure.Response;

namespace Infrastructure.Interface;

public interface IPracticipantService
{
    public Task<Response<string>> CreatePracticipant(Practicipant practicipant);
    public Task<Response<List<Practicipant>>> GetPracticipants();
    public Task<Response<Practicipant>> GetById(int id);
    public Task<Response<string>> UpdatePracticipant(Practicipant practicipant);
    public Task<Response<string>> DeletePracticipant(int id);
}