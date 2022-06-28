namespace kolokwium.Model.DTOs;

public class TeamDTO
{
    public string Name { get; set; }
    public string? Description { get; set; }
    public string OrganizationName { get; set; }
    public ICollection<MemberDTO> Members { get; set; }
}
