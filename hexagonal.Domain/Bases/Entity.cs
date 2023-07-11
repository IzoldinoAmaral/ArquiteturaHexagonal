using System.ComponentModel.DataAnnotations;
using hexagonal.Domain.Bases.Interfaces;

namespace hexagonal.Domain.Bases;

public abstract class Entity : IEntity
{
    [Key] public Guid Id { get; set; }

    public virtual Guid Key => Id;

    public virtual string Value => ToString()!;
}