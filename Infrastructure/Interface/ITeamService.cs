using Domain.Entities;
using Infrastructure.Response;
namespace Infrastructure.Interface;

public interface ITeamService
{
    public Task<Response<string>> CreateTeam(Team team);
    public Task<Response<List<Team>>> GetTeams();
    public Task<Response<Team>> GetById(int id);
    public Task<Response<string>> UpdateTeam(Team team);
    public Task<Response<string>> DeleteTeam(int id);
}