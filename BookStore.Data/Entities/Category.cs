using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Data.Entities;

[Table("Categories")]
public class Category
{
    public int Id { get; set; }

    [Required]
    public string Name { get; set; } = null!;

    public List<Book> Books { get; set; } = new List<Book>();
}
