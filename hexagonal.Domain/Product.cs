using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using hexagonal.Domain.Bases;

namespace hexagonal.Domain;

public class Product : Entity
{
    [Column("prod_tx_name", TypeName = "varchar")]
    [MaxLength(255)]
    [Required(ErrorMessage = "Name is required")]
    public string? Name { get; set; }

    [Column("prod_dc_price", TypeName = "decimal")]
    [Required(ErrorMessage = "Price is required")]
    public decimal? Price { get; set; }
}