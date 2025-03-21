using System.ComponentModel.DataAnnotations;

namespace BookStore.Business.Dtos;

public class BookResponse
{
    [Key]
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }

}
