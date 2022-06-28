using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace kolokwium.Model;

public class File
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int FileID { get; set; }
    
    [Required]
    public int TeamID { get; set; }
    
    [Required]
    [MaxLength(100)]
    public string Name { get; set; }
    
    [Required]
    [MaxLength(4)]
    public string Extension { get; set; }

    [Required]
    public int Size { get; set; }
    
    [ForeignKey("TeamID")]
    public Team Team { get; set; }
}
