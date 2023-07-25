using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using hexagonal.Domain.Bases;

namespace hexagonal.Domain.Entities;

[Table("book_book")]
public class Book : Entity
{
    [Column("book_tx_name", TypeName = "varchar")]
    [MaxLength(50)]
    [Required(ErrorMessage = "Name is required")]
    public string? Name { get; set; }

    [Column("book_tx_author", TypeName = "varchar")]
    [MaxLength(50)]
    [Required(ErrorMessage = "Author is required")]
    public string? Author { get; set; }

    // This represents the foreign key in the database.
    [ForeignKey("Category")] public Guid? CategoryId { get; set; }

    // This is the navigation property.
    public Category? Category { get; set; }

    [Column("book_qt_total_pages", TypeName = "int")]
    [Required(ErrorMessage = "Total Pages is required")]
    public int? TotalPages { get; set; }

    [Column("book_bt_is_active", TypeName = "bit")]
    [Required(ErrorMessage = "Is Active is required")]
    public bool IsActive { get; set; }
}