using System.ComponentModel.DataAnnotations;

namespace Models;

public class Category{
    [Key]
    public int Id { get; set; }
    [Required]
    [StringLength(100)]
    public string Name { get; set; }

    public List<Question> Questions { get; set; } = new List<Question>(); 
}