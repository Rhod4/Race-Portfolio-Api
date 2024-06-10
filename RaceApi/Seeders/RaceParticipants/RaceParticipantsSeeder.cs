using Microsoft.EntityFrameworkCore;
using RaceApi.Persistence;

namespace RaceApi.Seeders.RaceParticipants;

public static class RaceParticipantsSeeder
{
    public static async Task Seed(RaceProjectContext db)
    {
        var participants = await db.Profile.ToListAsync();
        IEnumerable<Persistence.Models.RaceParticipants> raceParticipants =
        [
            new Persistence.Models.RaceParticipants
            {
                Id = Guid.Parse("9f36ec77-83c5-4bd7-999d-b56e49d6acaf"),
                UserRaceNumber = 2,
                Profile = participants.OrderByDescending(p => p.Firstname).Last(),
                Race = await db.Race.SingleAsync(r => r.Id == Guid.Parse("7b70673b-d00c-49ad-8508-4bb968dd7e06")),
                Car = await db.Cars.SingleAsync(c => c.Id == Guid.Parse("29208687-5bb3-4a1e-86c9-d639287a897e"))
            }
        ];

        await db.RaceParticipants.AddRangeAsync(raceParticipants);
        await db.SaveChangesAsync();
    }
}