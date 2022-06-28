using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace kolokwium.Model;

public class Membership
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int MemberID { get; set; }
    
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int TeamID { get; set; }
    
    [Required]
    public DateTime Date { get; set; }
    
    [ForeignKey("MemberID")]
    public Member Member { get; set; }
    
    [ForeignKey("TeamID")]
    public Team Team { get; set; }
}
