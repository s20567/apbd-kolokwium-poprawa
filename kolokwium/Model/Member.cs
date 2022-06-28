using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace kolokwium.Model;

public class Member
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int MemberID { get; set; }
    
    [Required]
    [MaxLength(20)]
    public string Name { get; set; }
    
    [Required]
    [MaxLength(50)]
    public string Surname { get; set; }
    
    [MaxLength(20)]
    public string? Nickname { get; set; }
    
    [Required]
    public int OrganizationID { get; set; }

    [ForeignKey("OrganizationID")]
    public Organization Organization { get; set; }

    public ICollection<Membership> Memberships { get; set; }
}
