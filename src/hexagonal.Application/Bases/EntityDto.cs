using hexagonal.Application.Bases.Interfaces;

namespace hexagonal.Application.Bases;

public class EntityDto : Dto, IEntityDto
{
    public Guid Id { get; set; }
}