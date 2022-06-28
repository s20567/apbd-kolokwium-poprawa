using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace kolokwium.Model;

public class Team
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int TeamID { get; set; }
    
    [Required]
    public int OrganizationID { get; set; }
    
    [Required]
    [MaxLength(50)]
    public string Name { get; set; }
    
    [MaxLength(500)]
    public string? Description { get; set; }
    
    [ForeignKey("OrganizationID")]
    public Organization Organization { get; set; }

    public ICollection<File> Files { get; set; }
    
    public ICollection<Membership> Memberships { get; set; }
}
