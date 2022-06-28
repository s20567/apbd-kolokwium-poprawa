using kolokwium.Context;
using kolokwium.Model.DTOs;
using Microsoft.EntityFrameworkCore;

namespace kolokwium.Services;

public class OrganizationService : IOrganizationService
{
    private readonly OrganizationDbContext _context;

    public OrganizationService(OrganizationDbContext dbx) { _context = dbx; }
    
    public async Task<TeamDTO> GetTeam(int id)
    {
        var team = await _context.Team.Where(t => t.TeamID == id).Select(
            o => new TeamDTO
            {
                Name = o.Name,
                Description = o.Description,
                OrganizationName = o.Organization.Name,
                Members = o.Memberships.Where(ms => ms.TeamID == o.TeamID).Select(
                    o => new MemberDTO
                    {
                        Name = o.Member.Name,
                        Surname = o.Member.Surname,
                        Nickname = o.Member.Nickname,
                        MembershipDate = o.Date
                    }
                ).OrderBy(md => md.MembershipDate).ToList()
            }
        ).SingleOrDefaultAsync();
        
        if (team == null)
            throw new BadHttpRequestException("Team with a given ID has not been found", 404);

        return team;
    }

    public async Task AddMember(int idMember, int idTeam)
    {
        var member = await _context.Member.Where(m => m.MemberID == idMember).SingleOrDefaultAsync();
        
        if (member == null)
            throw new BadHttpRequestException("Member with a given ID has not been found", 404);

        var organization = await _context.Organization.SelectMany(o => o.Members).Where(m => m.MemberID == idMember).SingleOrDefaultAsync();

        if (organization == null)
            throw new BadHttpRequestException("Member doesn't belong to the team's organization", 404);
    }
}
