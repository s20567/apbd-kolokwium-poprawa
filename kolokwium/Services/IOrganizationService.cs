using kolokwium.Model.DTOs;

namespace kolokwium.Services;

public interface IOrganizationService
{
    public Task<TeamDTO> GetTeam(int id);
    public Task AddMember(int idMember, int idTeam);
}
