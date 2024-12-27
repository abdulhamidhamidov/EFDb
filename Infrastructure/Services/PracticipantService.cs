using Domain.Entities;
using Infrastructure.DataContext;
using Infrastructure.Interface;
using Infrastructure.Response;

namespace Infrastructure.Services;

public class PracticipantService(Context context): IPracticipantService
{
   public async Task<Response<string>> CreatePracticipant(CreatePracticipantDto hackathon)
    {
        Practicipant hackathon1 = new Practicipant();
        
        await context.Practicipants.AddAsync(hackathon1);
        var res = await context.SaveChangesAsync();

        if (res == 0)
            return new Response<string>(HttpStatusCode.InternalServerError,"Internal Server Error");
        return new Response<string>("Created");

    }

    public async Task<Response<List<Practicipant>>> GetPracticipants()
    {
        var res = await context.Practicipants.ToListAsync();
        if (res.Count == 0)
            return new Response<List<Practicipant>>(HttpStatusCode.NotFound, "Practicipants not Found");
        return new Response<List<Practicipant>>(res);

    }

    public async Task<Response<Practicipant>> GetById(int id)
    {
        var res = await context.Practicipants.FirstOrDefaultAsync(x=>x.Id==id);
        if (res == null) return new Response<Practicipant>(HttpStatusCode.NotFound,"Not Found");
        return new Response<Practicipant>(res);
    }
    public async Task<Response<string>> UpdatePracticipant(Practicipant hackathon)
    {
        var res = await context.Practicipants.FirstOrDefaultAsync(x=>x.Id==hackathon.Id);
        if (res == null) return new Response<string>(HttpStatusCode.InternalServerError,"Internal Server Error");
     
        var data = await context.SaveChangesAsync();
        if (data == 0) return new Response<string>(HttpStatusCode.NotFound,"Not Found");
        return new Response<string>("Updated");

    }

    public async Task<Response<string>> DeletePracticipant(int id)
    {
        var res = await context.Practicipants.FirstOrDefaultAsync(x=>x.Id==id);
        if (res == null) return new Response<string>(HttpStatusCode.InternalServerError,"Internal Server Error");
        context.Practicipants.Remove(res);
        var data = await context.SaveChangesAsync();
        if (data == 0) return new Response<string>(HttpStatusCode.NotFound,"Not Found");
        return new Response<string>("Deleted");
    }
}