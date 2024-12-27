using Domain.Dtos;
using Domain.Entities;
using Infrastructure.Response;

namespace Infrastructure.Interface;

public interface IHackathonService
{
    public Task<Response<string>> CreateHackathon(CreateHackathonDto hackathon);
    public Task<Response<List<GetHackathonDto>>> GetHackathons();
    public Task<Response<GetHackathonDto>> GetById(int id);
    public Task<Response<string>> UpdateHackathon(Hackathon hackathon);
    public Task<Response<string>> DeleteHackathon(int id);

}