using hexagonal.Application.Bases;

namespace hexagonal.Application.Components.BookComponent.Contracts;

public class BookDto : EntityDto
{
    public string? Name { get; set; }

    public string? Author { get; set; }

    public Guid? CategoryId { get; set; }
    public string? CategoryName { get; set; }

    public int? TotalPages { get; set; }

    public bool? IsActive { get; set; }
}