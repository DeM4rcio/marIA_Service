using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models;


public class Question{
    [Key]
    public int Id {get;set;}
    [Required]
    [StringLength(350)]
    public string Text {get;set;}

    [ForeignKey("Category")]
    public int categoryId {get;set;}

   
}