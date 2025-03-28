using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Data.Entities;

[Table("Categories")]
public class Category
{
    public int Id { get; set; }

    [Required]
    public string Name { get; set; } = null!;

    public List<Book> Books { get; set; } = new List<Book>();
}
