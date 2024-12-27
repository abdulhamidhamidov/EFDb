using System.Data.Common;
using System.Net;
using Domain.Dtos;
using Domain.Entities;
using Infrastructure.DataContext;
using Infrastructure.Interface;
using Infrastructure.Response;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class HackathonService(Context context): IHackathonService
{
    public async Task<Response<string>> CreateHackathon(CreateHackathonDto hackathon)
    {
        Hackathon hackathon1 = new Hackathon();
        hackathon1.Date = hackathon.Date;
        hackathon1.Name = hackathon.Name;
        hackathon1.Theme = hackathon.Theme;
        await context.Hackathons.AddAsync(hackathon1);
        var res = await context.SaveChangesAsync();

        if (res == 0)
            return new Response<string>(HttpStatusCode.InternalServerError,"Internal Server Error");
        return new Response<string>("Created");

    }

    public async Task<Response<List<GetHackathonDto>>> GetHackathons()
    {
        var hackathons = await context.Hackathons.Include(c=>c.Teams).ToListAsync();
        var dtos = hackathons.Select(x => new GetHackathonDto()
        {
            Id = x.Id,
            Date = x.Date,
            Theme = x.Theme,
            Name = x.Name,
            Teams = x.Teams.Select(c=>new GetTeamDto()
                {
                    
                });
        }
        );
        if (res.Count == 0)
            return new Response<List<Hackathon>>(HttpStatusCode.NotFound, "Hackathons not Found");
        return new Response<List<Hackathon>>(res);

    }

    public async Task<Response<Hackathon>> GetById(int id)
    {
        var res = await context.Hackathons.FirstOrDefaultAsync(x=>x.Id==id);
        if (res == null) return new Response<Hackathon>(HttpStatusCode.NotFound,"Not Found");
        return new Response<Hackathon>(res);
    }
    public async Task<Response<string>> UpdateHackathon(Hackathon hackathon)
    {
        var res = await context.Hackathons.FirstOrDefaultAsync(x=>x.Id==hackathon.Id);
        if (res == null) return new Response<string>(HttpStatusCode.InternalServerError,"Internal Server Error");
        res.Date = hackathon.Date;
        res.Name = hackathon.Name;
        res.Theme = hackathon.Theme;
        var data = await context.SaveChangesAsync();
        if (data == 0) return new Response<string>(HttpStatusCode.NotFound,"Not Found");
        return new Response<string>("Updated");

    }

    public async Task<Response<string>> DeleteHackathon(int id)
    {
        var res = await context.Hackathons.FirstOrDefaultAsync(x=>x.Id==id);
        if (res == null) return new Response<string>(HttpStatusCode.InternalServerError,"Internal Server Error");
        context.Hackathons.Remove(res);
        var data = await context.SaveChangesAsync();
        if (data == 0) return new Response<string>(HttpStatusCode.NotFound,"Not Found");
        return new Response<string>("Deleted");
    }
}